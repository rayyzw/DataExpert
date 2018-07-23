using System;
using System.Collections;
using System.Data;
using System.IO;

namespace DataExpert
{
    public class DBProcessor
    {
        static int count = 0;
        private static void toEnd(Hashtable attributes, ArrayList items, Hashtable item, DataTable data, string reportFilePath)
        {
            foreach (Hashtable item1 in items)
            {
                if ("route".Equals(item1["type"]) && ((string)item1["pointX"]).Equals((string)item["guid"]))
                {
                    count++;
                    DataTable subData;
                    if (item1["condition"] != null && !item1["condition"].Equals(""))
                    {
                        subData = data.Clone();
                        string item1Condition = ((string)item1["condition"]).Replace("{minValue}", (string)attributes["startTime"]).Replace("{maxValue}", (string)attributes["endTime"]);
                        if (attributes["startTime1"] != null && attributes["endTime1"] != null)
                        {
                            item1Condition = item1Condition.Replace("{minValue1}", (string)attributes["startTime1"]).Replace("{maxValue1}", (string)attributes["endTime1"]);
                        }
                        DataRow[] rows = data.Select(item1Condition);
                        foreach (DataRow row in rows)
                        {
                            subData.ImportRow(row);
                        }
                    }
                    else
                    {
                        subData = data;
                    }
                    string pointY = (string)item1["pointY"];
                    Hashtable item2 = DBProcessor.getItemByGuid(items, pointY);
                    if ("node".Equals(item2["type"]))
                    {
                        count++;
                        if (item2["sql"] != null && !item2["sql"].Equals(""))
                        {
                            string item2Sql = ((string)item2["sql"]).Replace("{minValue}", (string)attributes["startTime"]).Replace("{maxValue}", (string)attributes["endTime"]);
                            if (attributes["startTime1"] != null && attributes["endTime1"] != null)
                            {
                                item2Sql = item2Sql.Replace("{minValue1}", (string)attributes["startTime1"]).Replace("{maxValue1}", (string)attributes["endTime1"]);
                            }
                            string newSql = item2Sql;
                            if ((item2Sql).IndexOf("'{previousDataTable.") > -1)
                            {
                                newSql = "";
                                foreach (DataRow subRow in subData.Rows)
                                {
                                    string tempSql = item2Sql;
                                    int i = 0;
                                    foreach (DataColumn subColumn in subData.Columns)
                                    {
                                        tempSql = tempSql.Replace("{previousDataTable." + subColumn + "}", subRow.ItemArray[i].ToString());
                                        i++;
                                    }
                                    if (newSql.Length == 0) newSql += tempSql;
                                    else newSql += " union " + tempSql;
                                }
                            }
                            DataTable subSubData = DBConnector.getDataTable(newSql);
                            if (item2["condition"] != null && !item2["condition"].Equals(""))
                            {
                                string item2Condition = ((string)item2["condition"]).Replace("{minValue}", (string)attributes["startTime"]).Replace("{maxValue}", (string)attributes["endTime"]);
                                if (attributes["startTime1"] != null && attributes["endTime1"] != null)
                                {
                                    item2Condition = item2Condition.Replace("{minValue1}", (string)attributes["startTime1"]).Replace("{maxValue1}", (string)attributes["endTime1"]);
                                }
                                DataTable subSubSubData;
                                if ((item2Condition).IndexOf("'{previousDataTable.") > -1)
                                {
                                    string[] conditions = System.Text.RegularExpressions.Regex.Split(item2Condition," and ");
                                    string[] previousColumns = new string[conditions.Length];
                                    string[] thisColumns = new string[conditions.Length];
                                    int i = 0;
                                    foreach (string condition in conditions)
                                    {
                                        string[] columns = condition.Split('=');
                                        if (columns.Length == 2)
                                        {
                                            previousColumns[i] = columns[1].Replace("'{previousDataTable.", "").Replace("}'", "").Trim();
                                            thisColumns[i] = columns[0].Trim();
                                        }
                                        else
                                        {
                                            throw new Exception("É¸Ñ¡Óï¾ä³ö´í");
                                        }
                                        i++;
                                    }
                                    subSubSubData = Functions.Join(subData, subSubData, previousColumns, thisColumns);
                                }
                                else
                                {
                                    subSubSubData = subSubData.Clone();
                                    DataRow[] subSubRows = subSubData.Select(item2Condition);
                                    foreach (DataRow subSubRow in subSubRows)
                                    {
                                        subSubSubData.ImportRow(subSubRow);
                                    }
                                }
                                toEnd(attributes, items, item2, subSubSubData, reportFilePath);
                            }
                            else
                            {
                                toEnd(attributes, items, item2, subSubData, reportFilePath);
                            }
                        }
                    }
                    else if ("end".Equals(item2["type"]))
                    {
                        count++;
                        string timeString = Functions.FormatString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        Functions.DataTableToFile(subData, reportFilePath + timeString + ".csv");
                        ResultForm resultForm = new ResultForm(reportFilePath, subData);
                        resultForm.Show();
                    }
                }
            }
        }

        public static void runWorkflow(Hashtable attributes, ArrayList items, string reportFilePath)
        {
            count = 0;
            try
            {
                foreach (Hashtable item in items)
                {
                    if ("start".Equals(item["type"]))
                    {
                        count++;
                        string sql = ((string)item["sql"]).Replace("{minValue}", (string)attributes["startTime"]).Replace("{maxValue}", (string)attributes["endTime"]);
                        if (attributes["startTime1"] != null && attributes["endTime1"] != null)
                        {
                            sql = sql.Replace("{minValue1}", (string)attributes["startTime1"]).Replace("{maxValue1}", (string)attributes["endTime1"]);
                        }
                        DataTable data = DBConnector.getDataTable(sql);
                        DBProcessor.toEnd(attributes, items, item, data, reportFilePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static Hashtable getItemByGuid(ArrayList items, string guid)
        {
            foreach (Hashtable item in items)
            {
                if (guid.Equals((string)item["guid"]))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
