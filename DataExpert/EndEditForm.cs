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
    public partial class EndEditForm : Form
    {
        private Hashtable item;
        private ArrayList items;
        public EndEditForm(Hashtable item, ArrayList items)
        {
            InitializeComponent();
            this.item = item;
            this.items = items;
            if (item["description"] != null) this.textBoxDescription.Text = (string)item["description"];
            if (item["problemType"] != null) this.textBoxProblemType.Text = (string)item["problemType"];
            if (item["cause"] != null) this.textBoxCause.Text = (string)item["cause"];
            if (item["suggestion"] != null) this.textBoxSuggestion.Text = (string)item["suggestion"];
            getPreviousDataTable(item);
            this.comboBoxPreviousDataTable.Items.Add("Ð¡ÇøÃû³Æ");
            if (item["reportKey"] != null)
            {
                this.comboBoxPreviousDataTable.SelectedItem = (string)item["reportKey"];
            }
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

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (item["description"] == null) item.Add("description", this.textBoxDescription.Text);
            else item["description"] = this.textBoxDescription.Text;
            if (item["problemType"] == null) item.Add("problemType", this.textBoxProblemType.Text);
            else item["problemType"] = this.textBoxProblemType.Text;
            if (item["cause"] == null) item.Add("cause", this.textBoxCause.Text);
            else item["cause"] = this.textBoxCause.Text;
            if (item["suggestion"] == null) item.Add("suggestion", this.textBoxSuggestion.Text);
            else item["suggestion"] = this.textBoxSuggestion.Text;
            if (item["suggestion"] == null) item.Add("suggestion", this.textBoxSuggestion.Text);
            else item["suggestion"] = this.textBoxSuggestion.Text;
            if (item["reportKey"] == null) item.Add("reportKey", "" + this.comboBoxPreviousDataTable.SelectedItem);
            else item["reportKey"] = "" + this.comboBoxPreviousDataTable.SelectedItem;
        }
    }
}