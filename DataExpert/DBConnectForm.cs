using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;

namespace DataExpert
{
    public partial class DBConnectForm : Form
    {
        private Hashtable attributes;
        public IDbConnection conn;
        private DataTable data;
        public DBConnectForm(Hashtable attributes)
        {
            InitializeComponent();
            this.attributes = attributes;
            if (attributes["databaseType"] != null) this.setDatabaseType((string)attributes["databaseType"]);
            if (attributes["server"] != null) this.server.Text = (string)attributes["server"];
            if (attributes["userid"] != null) this.userid.Text = (string)attributes["userid"];
            if (attributes["password"] != null) this.password.Text = (string)attributes["password"];
            if (attributes["port"] != null) this.port.Text = (string)attributes["port"];
            if (attributes["database"] != null) this.database.Text = (string)attributes["database"];
            try
            {
                conn = DBConnector.getDBConnection();
                if (conn != null)
                {
                    tables.Items.Clear();
                    tables.Items.AddRange(DBConnector.getTables());
                    connectStatus.Text = "connected to: " + String.Format("server={0};user id={1}; password={2}; port={3}; database={4}; pooling=false",
                        server.Text, userid.Text, password.Text, port.Text, database.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connectStatus.Text = "database connection error";
            }
        }
        private void connectBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                connectStatus.Text = "connecting";
                conn = DBConnector.getConnection(this.getDatabaseType(), server.Text, port.Text, userid.Text, password.Text, database.Text);
                connectStatus.Text = "connected to: " + String.Format("server={0};user id={1}; password={2}; port={3}; database={4}; pooling=false",
                    server.Text, userid.Text, password.Text, port.Text, database.Text);
                DBConnector.refreshDBTreeView();
                tables.Items.Clear();
                tables.Items.AddRange(DBConnector.getTables());
                if (attributes["databaseType"] == null) attributes.Add("databaseType", this.getDatabaseType());
                else attributes["databaseType"] = this.getDatabaseType();
                if (attributes["server"] == null) attributes.Add("server", this.server.Text);
                else attributes["server"] = this.server.Text;
                if (attributes["userid"] == null) attributes.Add("userid", this.userid.Text);
                else attributes["userid"] = this.userid.Text;
                if (attributes["port"] == null) attributes.Add("port", this.port.Text);
                else attributes["port"] = this.port.Text;
                if (attributes["password"] == null) attributes.Add("password", this.password.Text);
                else attributes["password"] = this.password.Text;
                if (attributes["database"] == null) attributes.Add("database", this.database.Text);
                else attributes["database"] = this.database.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void tables_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            data = DBConnector.getDataTable("SELECT * FROM " + tables.SelectedItem.ToString());
            dataGrid.DataSource = data;
        }

        private void updateBtn_Click(object sender, System.EventArgs e)
        {
            DBConnector.updateDataTable();
        }

        private string getDatabaseType()
        {
            if (this.mySQL.Checked == true) return this.mySQL.Text;
            else if (this.oracle.Checked == true) return this.oracle.Text;
            else return null;
        }

        private void setDatabaseType(string databaseType)
        {
            if (this.mySQL.Text.Equals(databaseType)) this.mySQL.Checked = true;
            else if (this.oracle.Text.Equals(databaseType)) this.oracle.Checked = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (attributes["databaseType"] == null) attributes.Add("databaseType", this.getDatabaseType());
            else attributes["databaseType"] = this.getDatabaseType();
            if (attributes["server"] == null) attributes.Add("server", this.server.Text);
            else attributes["server"] = this.server.Text;
            if (attributes["userid"] == null) attributes.Add("userid", this.userid.Text);
            else attributes["userid"] = this.userid.Text;
            if (attributes["port"] == null) attributes.Add("port", this.port.Text);
            else attributes["port"] = this.port.Text;
            if (attributes["password"] == null) attributes.Add("password", this.password.Text);
            else attributes["password"] = this.password.Text;
            if (attributes["database"] == null) attributes.Add("database", this.database.Text);
            else attributes["database"] = this.database.Text;
        }
    }
}
