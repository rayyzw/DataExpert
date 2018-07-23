using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Collections;
using System.Data;
using System.IO;
using System.Security.Cryptography;

using System.Windows.Forms;


namespace DataExpert
{
    public class Functions
    {
        public static void DrawRoundRectangle(Graphics g, Pen pen, Rectangle rect, int cornerRadius)
        {
            rect.X -= rect.Width / 2;
            rect.Y -= rect.Height / 2;
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.DrawPath(pen, path);
            }
        }
        public static void FillRoundRectangle(Graphics g, Brush brush, Rectangle rect, int cornerRadius)
        {
            rect.X -= rect.Width / 2;
            rect.Y -= rect.Height / 2;
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.FillPath(brush, path);
            }
        }
        public static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }
        public static DataTable Join(DataTable first, DataTable second, DataColumn[] FJC, DataColumn[] SJC)
        {
            //创建一个新的DataTable
            DataTable table = new DataTable("Join");
            // Use a DataSet to leverage DataRelation
            using (DataSet ds = new DataSet())
            {
                //把DataTable Copy到DataSet中
                ds.Tables.AddRange(new DataTable[] { first.Copy(), second.Copy() });
                DataColumn[] parentcolumns = new DataColumn[FJC.Length];
                for (int i = 0; i < parentcolumns.Length; i++)
                {
                    parentcolumns[i] = ds.Tables[0].Columns[FJC[i].ColumnName];
                }
                DataColumn[] childcolumns = new DataColumn[SJC.Length];
                for (int i = 0; i < childcolumns.Length; i++)
                {
                    childcolumns[i] = ds.Tables[1].Columns[SJC[i].ColumnName];
                }
                //创建关联
                DataRelation r = new DataRelation(string.Empty, parentcolumns, childcolumns, false);
                ds.Relations.Add(r);
                //为关联表创建列
                for (int i = 0; i < first.Columns.Count; i++)
                {
                    table.Columns.Add(first.Columns[i].ColumnName, first.Columns[i].DataType);
                }
                for (int i = 0; i < second.Columns.Count; i++)
                {
                    //看看有没有重复的列，如果有在第二个DataTable的Column的列明后加_1
                    if (!table.Columns.Contains(second.Columns[i].ColumnName))
                        table.Columns.Add(second.Columns[i].ColumnName, second.Columns[i].DataType);
                    else
                        table.Columns.Add(second.Columns[i].ColumnName + "_1", second.Columns[i].DataType);
                }
                table.BeginLoadData();
                foreach (DataRow firstrow in ds.Tables[0].Rows)
                {
                    //得到行的数据
                    DataRow[] childrows = firstrow.GetChildRows(r);
                    if (childrows != null && childrows.Length > 0)
                    {
                        object[] parentarray = firstrow.ItemArray;
                        foreach (DataRow secondrow in childrows)
                        {
                            object[] secondarray = secondrow.ItemArray;
                            object[] joinarray = new object[parentarray.Length + secondarray.Length];
                            Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length);
                            Array.Copy(secondarray, 0, joinarray, parentarray.Length, secondarray.Length);
                            table.LoadDataRow(joinarray, true);
                        }
                    }
                }
                table.EndLoadData();
            }
            return table;
        }


        public static DataTable Join(DataTable first, DataTable second, DataColumn FJC, DataColumn SJC)
        {
            return Join(first, second, new DataColumn[] { FJC }, new DataColumn[] { SJC });
        }

        public static DataTable Join(DataTable first, DataTable second, string FJC, string SJC)
        {
            return Join(first, second, new DataColumn[] { first.Columns[FJC] }, new DataColumn[] { second.Columns[SJC] });
        }

        public static DataTable Join(DataTable first, DataTable second, string[] FJC, string[] SJC)
        {
            if (FJC.Length == SJC.Length && FJC.Length > 0)
            {
                DataColumn[] FDC = new DataColumn[FJC.Length];
                DataColumn[] SDC = new DataColumn[SJC.Length];
                for (int i = 0; i < FJC.Length; i++)
                {
                    FDC[i] = first.Columns[FJC[i]];
                    SDC[i] = second.Columns[SJC[i]];
                }
                return Join(first, second, FDC, SDC);
            }
            else
            {
                throw new Exception("DataTable关联列数不一致");
            }
        }

        public static void DataTableToFile(DataTable dataTable, string fileName)
        {
            if (!Directory.Exists(fileName.Substring(0, fileName.LastIndexOf("\\"))))
            {
                Directory.CreateDirectory(fileName.Substring(0, fileName.LastIndexOf("\\")));
            }
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            StreamWriter textWriter = null;
            string line = "";
            try
            {
                textWriter = new StreamWriter(File.Create(fileName));
                foreach (DataColumn column in dataTable.Columns)
                {
                    line += column + ",";
                }
                if (line.Length > 0) line = line.Substring(0, line.Length - 1);
                textWriter.WriteLine(line);
                foreach (DataRow row in dataTable.Rows)
                {
                    line = "";
                    foreach (Object obj in row.ItemArray)
                    {
                        line += obj.ToString().Replace(",","_") + ",";
                    }
                    if (line.Length > 0) line = line.Substring(0, line.Length - 1);
                    textWriter.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if(textWriter!=null)textWriter.Close();
            }
        }

        public static DataTable FileToDataTable(string fileName)
        {
            DataTable table = new DataTable();
            StreamReader textReader = null;
            string line = "";
            try
            {
                textReader = new StreamReader(fileName);
                int i = 0;
                while (line != null)
                {
                    line = textReader.ReadLine();
                    if (i == 0)
                    {
                        string[] columnsStr = line.Split(',');
                        foreach (string columnStr in columnsStr)
                        {
                            table.Columns.Add(columnStr);
                        }
                    }
                    else
                    {
                        string[] rowsStr = line.Split(',');
                        table.Rows.Add(rowsStr);
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if(textReader!=null)textReader.Close();
            }
            return table;
        }

        public static void ListViewToFile(ListView listView, string fileName)
        {
            if (!Directory.Exists(fileName.Substring(0, fileName.LastIndexOf("\\"))))
            {
                Directory.CreateDirectory(fileName.Substring(0, fileName.LastIndexOf("\\")));
            }
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            StreamWriter textWriter = null;
            string line = "";
            try
            {
                textWriter = new StreamWriter(File.Create(fileName));
                foreach (ColumnHeader column in listView.Columns)
                {
                    line += column.Text + ",";
                }
                if (line.Length > 0) line = line.Substring(0, line.Length - 1);
                textWriter.WriteLine(line);
                foreach (ListViewItem item in listView.Items)
                {
                    line = "";
                    foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                    {
                        line += subitem.Text + ",";
                    }
                    if (line.Length > 0) line = line.Substring(0, line.Length - 1);
                    textWriter.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if(textWriter!=null)textWriter.Close();
            }
        }

        public static ListView FileToListView(string fileName)
        {
            ListView listView = new ListView();
            StreamReader textReader = null;
            string line = "";
            try
            {
                textReader = new StreamReader(fileName);
                int i = 0;
                while (line != null)
                {
                    line = textReader.ReadLine();
                    if (i == 0)
                    {
                        string[] columnsStr = line.Split(',');
                        foreach (string columnStr in columnsStr)
                        {
                            listView.Columns.Add(columnStr);
                        }
                    }
                    else
                    {
                        string[] rowsStr = line.Split(',');
                        System.Windows.Forms.ListViewItem listViewItem = new System.Windows.Forms.ListViewItem(rowsStr, -1);
                        listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
                            listViewItem});
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if(textReader!=null)textReader.Close();
            }
            return listView;
        }

        public static string FormatString(string str)
        {
            if (str != null) return str.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "");
            else return "";
        }

        public static void DataToXML(Hashtable attributes, ArrayList items, ArrayList items1, string xmlFileName, string encryptKey)
        {
            if (!Directory.Exists(xmlFileName.Substring(0, xmlFileName.LastIndexOf("\\"))))
            {
                Directory.CreateDirectory(xmlFileName.Substring(0, xmlFileName.LastIndexOf("\\")));
            }
            if (File.Exists(xmlFileName))
            {
                File.Delete(xmlFileName);
            }
            XmlTextWriter xmlWriter = null;
            try
            {
                if (encryptKey != null && encryptKey.Length == 8)
                {
                    if (File.Exists(xmlFileName + "_temp"))
                    {
                        File.Delete(xmlFileName + "_temp");
                    }
                    xmlWriter = new XmlTextWriter(xmlFileName + "_temp", null);
                }
                else
                {
                    xmlWriter = new XmlTextWriter(xmlFileName, null);
                }
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("workFlow");
                foreach (DictionaryEntry attribute in attributes)
                {
                    xmlWriter.WriteAttributeString((string)attribute.Key, (string)attribute.Value);
                }
                foreach (Hashtable item in items)
                {
                    xmlWriter.WriteStartElement("item");
                    foreach (DictionaryEntry de in item)
                    {
                        xmlWriter.WriteElementString((string)de.Key, (string)de.Value);
                    }
                    xmlWriter.WriteEndElement();
                }
                foreach (Hashtable item in items1)
                {
                    xmlWriter.WriteStartElement("item1");
                    foreach (DictionaryEntry de in item)
                    {
                        xmlWriter.WriteElementString((string)de.Key, (string)de.Value);
                    }
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
                if (encryptKey != null && encryptKey.Length == 8)
                {
                    EncryptFile(xmlFileName + "_temp", xmlFileName, encryptKey);
                    File.Delete(xmlFileName + "_temp");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (xmlWriter != null) xmlWriter.Close();
                if (File.Exists(xmlFileName + "_temp"))
                {
                    File.Delete(xmlFileName + "_temp");
                }
            }
        }

        public static void DataToXML(Hashtable attributes, string xmlFileName, string encryptKey)
        {
            if (!Directory.Exists(xmlFileName.Substring(0, xmlFileName.LastIndexOf("\\"))))
            {
                Directory.CreateDirectory(xmlFileName.Substring(0, xmlFileName.LastIndexOf("\\")));
            }
            if (File.Exists(xmlFileName))
            {
                File.Delete(xmlFileName);
            }
            XmlTextWriter xmlWriter = null;
            try
            {
                if (encryptKey != null && encryptKey.Length == 8)
                {
                    if (File.Exists(xmlFileName + "_temp"))
                    {
                        File.Delete(xmlFileName + "_temp");
                    }
                    xmlWriter = new XmlTextWriter(xmlFileName + "_temp", null);
                }
                else
                {
                    xmlWriter = new XmlTextWriter(xmlFileName, null);
                }
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("workFlow");
                foreach (DictionaryEntry attribute in attributes)
                {
                    xmlWriter.WriteAttributeString((string)attribute.Key, (string)attribute.Value);
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
                if (encryptKey != null && encryptKey.Length == 8)
                {
                    EncryptFile(xmlFileName + "_temp", xmlFileName, encryptKey);
                    File.Delete(xmlFileName + "_temp");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (xmlWriter != null) xmlWriter.Close();
                if (File.Exists(xmlFileName + "_temp"))
                {
                    File.Delete(xmlFileName + "_temp");
                }
            }
        }

        public static void XmlToData(out Hashtable attributes, out ArrayList items, out ArrayList items1, string xmlFileName, string decryptKey)
        {
            attributes = new Hashtable();
            items = new ArrayList();
            items1 = new ArrayList();
            XmlTextReader xmlReader = null;
            try
            {
                if (decryptKey != null && decryptKey.Length == 8)
                {
                    if (File.Exists(xmlFileName + "_temp"))
                    {
                        File.Delete(xmlFileName + "_temp");
                    }
                    DecryptFile(xmlFileName, xmlFileName + "_temp", decryptKey);
                    xmlReader = new XmlTextReader(xmlFileName + "_temp");
                }
                else
                {
                    xmlReader = new XmlTextReader(xmlFileName);
                }
                xmlReader.WhitespaceHandling = WhitespaceHandling.None;
                xmlReader.MoveToContent();
                if (xmlReader.Name == "workFlow" && xmlReader.HasAttributes)
                {
                    while (xmlReader.MoveToNextAttribute())
                    {
                        attributes.Add(xmlReader.Name, xmlReader.Value);
                    }
                }
                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement("item") && !xmlReader.IsEmptyElement)
                    {
                        Hashtable item = new Hashtable();
                        while (xmlReader.Read() && xmlReader.Name != "item")
                        {
                            if (xmlReader.IsStartElement() && !xmlReader.IsEmptyElement)
                            {
                                item.Add(xmlReader.Name, xmlReader.ReadString());
                            }
                        }
                        items.Add(item);
                    }
                    if (xmlReader.IsStartElement("item1") && !xmlReader.IsEmptyElement)
                    {
                        Hashtable item = new Hashtable();
                        while (xmlReader.Read() && xmlReader.Name != "item1")
                        {
                            if (xmlReader.IsStartElement() && !xmlReader.IsEmptyElement)
                            {
                                item.Add(xmlReader.Name, xmlReader.ReadString());
                            }
                        }
                        items1.Add(item);
                    }
                }
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                throw ex;
            }
            finally
            {
                if (xmlReader != null) xmlReader.Close();
                if (File.Exists(xmlFileName + "_temp"))
                {
                    File.Delete(xmlFileName + "_temp");
                }
            }
        }

        public static void XmlToData(out Hashtable attributes, string xmlFileName, string decryptKey)
        {
            attributes = new Hashtable();
            XmlTextReader xmlReader = null;
            try
            {
                if (decryptKey != null && decryptKey.Length == 8)
                {
                    if (File.Exists(xmlFileName + "_temp"))
                    {
                        File.Delete(xmlFileName + "_temp");
                    }
                    DecryptFile(xmlFileName, xmlFileName + "_temp", decryptKey);
                    xmlReader = new XmlTextReader(xmlFileName + "_temp");
                }
                else
                {
                    xmlReader = new XmlTextReader(xmlFileName);
                }
                xmlReader.WhitespaceHandling = WhitespaceHandling.None;
                xmlReader.MoveToContent();
                if (xmlReader.Name == "workFlow" && xmlReader.HasAttributes)
                {
                    while (xmlReader.MoveToNextAttribute())
                    {
                        attributes.Add(xmlReader.Name, xmlReader.Value);
                    }
                }
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                throw ex;
            }
            finally
            {
                if (xmlReader != null) xmlReader.Close();
                if (File.Exists(xmlFileName + "_temp"))
                {
                    File.Delete(xmlFileName + "_temp");
                }
            }
        }

        public static void EncryptFile(string sInputFilename, string sOutputFilename, string sKey)
        {
            FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);

            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[fsInput.Length];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
            fsInput.Close();
            fsEncrypted.Close();
        }

        public static void DecryptFile(string sInputFilename,
           string sOutputFilename,
           string sKey)
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            //A 64 bit key and IV is required for this provider.
            //Set secret key For DES algorithm.
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //Set initialization vector.
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            //Create a file stream to read the encrypted file back.
            FileStream fsread = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            //Create a DES decryptor from the DES instance.
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //DES decryption transform on incoming bytes.
            CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);
            //Print the contents of the decrypted file.
            StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
            try
            {
                fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
                fsDecrypted.Flush();
                cryptostreamDecr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fsDecrypted.Close();
                fsread.Close();
            }
        }

        //private static readonly ILog log = GetLog("Antares");

        //private static ILog GetLog(string name)
        //{
        //    XmlConfigurator.Configure(new FileInfo(Application.StartupPath + "\\log4net.config")); 
        //    return LogManager.GetLogger(name);
        //}
        //public static void LogError(string message,Exception ex)
        //{
        //    log.Error(message, ex);
        //}
        //public static void LogInfo(string message, Exception ex)
        //{
        //    log.Info(message, ex);
        //}
        //public static void LogWarn(string message, Exception ex)
        //{
        //    log.Warn(message, ex);
        //}
    }
}
