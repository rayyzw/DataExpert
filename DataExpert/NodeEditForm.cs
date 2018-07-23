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
    public partial class NodeEditForm : Form
    {
        private Hashtable item;
        private ArrayList items;
        private DataTable data;
        private TextBox currentTextBox;
        public NodeEditForm(Hashtable item, ArrayList items)
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
            if (item["condition"] != null) this.textBoxCondition.Text = (string)item["condition"];
            getPreviousDataTable(item);
            this.comboBoxPreviousDataTable.Items.Add("Ð¡ÇøÃû³Æ");
            currentTextBox = this.textBoxSql;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (item["sql"] == null) item.Add("sql", this.textBoxSql.Text);
            else item["sql"] = this.textBoxSql.Text;
            if (item["description"] == null) item.Add("description", this.textBoxDescription.Text);
            else item["description"] = this.textBoxDescription.Text;
            if (item["condition"] == null) item.Add("condition", this.textBoxCondition.Text);
            else item["condition"] = this.textBoxCondition.Text;
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

        private void getPreviousDataTable(Hashtable curItem)
        {
            DataTable data = null;
            foreach (Hashtable item1 in items)
            {
                if ("route".Equals(item1["type"]) && (((string)item1["pointY"]).Equals((string)curItem["guid"]) || ((string)item1["guid"]).Equals((string)curItem["guid"])))
                {
                    string pointX = (string)item1["pointX"];
                    Hashtable item2 = getItemByGuid(pointX);
                    try
                    {
                        if ((string)item2["sql"] != null && !((string)item2["sql"]).Equals(""))
                        {
                            data = DBConnector.getDataTable((string)item2["sql"] + " limit 0,0");
                            if (data != null)
                            {
                                foreach (DataColumn dc in data.Columns)
                                {
                                    this.comboBoxPreviousDataTable.Items.Add(dc.ToString());
                                }
                            }
                            if (item2["condition"] != null && ((string)item2["condition"]).IndexOf("'{previousDataTable.") > -1)
                            {
                                getPreviousDataTable(item2);
                            }
                        }
                        else
                        {
                            getPreviousDataTable(item2);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
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

        private void comboBoxPreviousDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTextBox.SelectedText = " '{previousDataTable." + comboBoxPreviousDataTable.SelectedItem.ToString() + "}'";
            currentTextBox.Focus();
        }

        private void buttonRunCondition_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable subData = data.Clone();
                DataRow[] rows = data.Select(this.textBoxCondition.Text);
                foreach (DataRow row in rows)
                {
                    subData.ImportRow(row);
                }
                dataGrid.DataSource = subData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}