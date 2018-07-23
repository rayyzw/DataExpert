using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DataExpert;

namespace DataExpert
{
    public partial class RouteEditForm : Form
    {
        private Hashtable item;
        private ArrayList items;
        private TextBox currentTextBox;
        public RouteEditForm(Hashtable item, ArrayList items)
        {
            InitializeComponent();
            this.item = item;
            this.items = items;
            if (item["condition"] != null) this.textBoxCondition.Text = (string)item["condition"];
            if (item["description"] != null) this.textBoxDescription.Text = (string)item["description"];
            getPreviousDataTable(item);
            this.comboBoxPreviousDataTable.Items.Add("Ð¡ÇøÃû³Æ");
            currentTextBox = this.textBoxCondition;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (item["condition"] == null) item.Add("condition", this.textBoxCondition.Text);
            else item["condition"] = this.textBoxCondition.Text;
            if (item["description"] == null) item.Add("description", this.textBoxDescription.Text);
            else item["description"] = this.textBoxDescription.Text;
        }

        private void button_Click(object sender, EventArgs e)
        {
            currentTextBox.SelectedText = " " + ((Button)sender).Text;
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
            currentTextBox.SelectedText = " " + comboBoxPreviousDataTable.SelectedItem.ToString();
            currentTextBox.Focus();
        }

        private void comboBoxKeyword_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTextBox.SelectedText = " " + comboBoxKeyword.SelectedItem.ToString();
            currentTextBox.Focus();
        }
    }
}