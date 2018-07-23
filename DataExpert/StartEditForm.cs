using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DataExpert
{
    public partial class StartEditForm : Form
    {
        private Hashtable item;
        private ArrayList items;
        private DataTable data;
        private TextBox currentTextBox;
        public StartEditForm(Hashtable item, ArrayList items)
        {
            InitializeComponent();
            this.item = item;
            this.items = items;
            TreeView treeViewTables1 = DBConnector.getDBTreeView();
            // 
            // treeViewTables
            //
            if (treeViewTables1 != null)
            {
                treeViewTables1.Anchor = this.treeViewTables.Anchor;
                treeViewTables1.Location = this.treeViewTables.Location;
                treeViewTables1.Name = this.treeViewTables.Name;
                treeViewTables1.Size = this.treeViewTables.Size;
                treeViewTables1.TabIndex = this.treeViewTables.TabIndex;
                treeViewTables1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewTables_NodeMouseDoubleClick);
                this.splitContainer1.Panel1.Controls.Add(treeViewTables1);
            }
            if (item["sql"] != null) this.textBoxSql.Text = (string)item["sql"];
            if (item["description"] != null) this.textBoxDescription.Text = (string)item["description"];
            currentTextBox = this.textBoxSql;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (item["sql"] == null) item.Add("sql", this.textBoxSql.Text);
            else item["sql"] = this.textBoxSql.Text;
            if (item["description"] == null) item.Add("description", this.textBoxDescription.Text);
            else item["description"] = this.textBoxDescription.Text;
        }

        private void buttonRunSQL_Click(object sender, EventArgs e)
        {
            try
            {
                data = DBConnector.getDataTable(this.textBoxSql.Text);
                dataGrid.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeViewTables_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null) currentTextBox.SelectedText = " " + e.Node.Parent.Text + "." + e.Node.Text;
            else currentTextBox.SelectedText = " " + e.Node.Text;
            currentTextBox.Focus();
        }

        private void button_Click(object sender, EventArgs e)
        {
            currentTextBox.SelectedText = " " + ((Button)sender).Text;
            currentTextBox.Focus();
        }

        private void comboBoxKeyword_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTextBox.SelectedText = " " + comboBoxKeyword.SelectedItem.ToString();
            currentTextBox.Focus();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            currentTextBox = (TextBox)sender;
        }
        private Hashtable getItemByGuid(string guid)
        {
            foreach (Hashtable item1 in items)
            {
                if (guid.Equals((string)item1["guid"]))
                {
                    return item1;
                }
            }
            return null;
        }
    }
}