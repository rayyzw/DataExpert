using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Data.Common;

namespace DataExpert
{
    public static class DBConnector
    {
        public static TreeView mySqlTreeView;
        public static MySqlConnection mysqlConn;
        public static MySqlCommandBuilder cb;
        public static DataTable data;
        public static MySqlDataAdapter da;
        public static string databaseType = "MySQL";

        public static IDbConnection getDBConnection()
        {
            if ("MySQL".Equals(databaseType)) return mysqlConn;
            else throw new Exception("oracle not available");
        }
        public static IDbConnection getConnection(string databaseType, string server, string port, string userid, string password, string database)
        {
            DBConnector.databaseType = databaseType;

            if (mysqlConn != null)
                mysqlConn.Close();

            if ("MySQL".Equals(databaseType))
            {
                string connStr = String.Format("Server={0};UId={1};Password={2};Port={3};Database={4}",
                    server, userid, password, port, database);
                try
                {
                    mysqlConn = new MySqlConnection(connStr);
                    mysqlConn.Open();
                    return mysqlConn;
                }
                catch (MySqlException ex)
                {
                    if (mysqlConn != null)
                        mysqlConn.Close();
                    mysqlConn = null;
                    throw ex;
                }
            }
            else
            {
                throw new Exception("oracle not available");
            }
        }
        public static DataTable getDataTable(string sql)
        {
            if ("MySQL".Equals(databaseType))
            {
                try
                {
                    data = new DataTable();
                    da = new MySqlDataAdapter(sql, mysqlConn);
                    cb = new MySqlCommandBuilder(da);
                    da.Fill(data);
                    return data;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else throw new Exception("oracle not available");
        }
        public static void updateDataTable()
        {
            if ("MySQL".Equals(databaseType))
            {
                try
                {
                    DataTable changes = data.GetChanges();
                    if (changes != null && da != null)
                    {
                        da.Update(changes);
                        data.AcceptChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else throw new Exception("oracle not available");
        }
        public static DbDataAdapter getDataAdapter(string sql)
        {
            if ("MySQL".Equals(databaseType))
            {
                try
                {
                    DbDataAdapter da = new MySqlDataAdapter(sql, mysqlConn);
                    return da;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else return null;
        }
        public static string[] getTables()
        {
            if ("MySQL".Equals(databaseType))
            {
                MySqlDataReader reader = null;
                ArrayList al = new ArrayList();
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SHOW TABLES", mysqlConn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        al.Add(reader.GetString(0));
                    }
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    if (reader != null) reader.Close();
                }
                return (string[])al.ToArray(typeof(string));
            }
            else throw new Exception("oracle not available");
        }

        public static TreeView getDBTreeView()
        {
            if ("MySQL".Equals(databaseType)) return mySqlTreeView;
            else return null;
        }

        public static void refreshDBTreeView()
        {
            if ("MySQL".Equals(databaseType))
            {
                MySqlDataReader reader = null;
                try
                {
                    if (mySqlTreeView == null)
                    {
                        mySqlTreeView = new TreeView();
                    }
                    MySqlCommand cmd = new MySqlCommand("SHOW TABLES", mysqlConn);
                    reader = cmd.ExecuteReader();
                    mySqlTreeView.Nodes.Clear();
                    while (reader.Read())
                    {
                        TreeNode table = new TreeNode(reader.GetString(0));
                        mySqlTreeView.Nodes.Add(table);
                    }
                    reader.Close();
                    foreach (TreeNode table in mySqlTreeView.Nodes)
                    {
                        cmd.CommandText = "DESCRIBE " + table.Text;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            TreeNode column = new TreeNode(reader.GetString(0));
                            table.Nodes.Add(column);
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (reader != null) reader.Close();
                }
            }
            else throw new Exception("oracle not available");
        }
    }
}
