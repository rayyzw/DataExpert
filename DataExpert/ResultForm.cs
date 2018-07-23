using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataExpert
{
    public partial class ResultForm : Form
    {
        public ResultForm(string text, DataTable dataTable)
        {
            InitializeComponent();
            DataGrid dataGrid = new DataGrid();
            TabPage tabPage = new TabPage();
            ((System.ComponentModel.ISupportInitialize)(dataGrid)).BeginInit();
            tabPage.SuspendLayout();
            // 
            // dataGrid
            // 
            dataGrid.CaptionVisible = false;
            dataGrid.DataMember = "";
            dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            dataGrid.Location = new System.Drawing.Point(3, 3);
            dataGrid.Name = "dataGrid";
            dataGrid.Size = new System.Drawing.Size(779, 500);
            dataGrid.DataSource = dataTable;
            // 
            // tabPage
            // 
            tabPage.Controls.Add(dataGrid);
            tabPage.Location = new System.Drawing.Point(4, 21);
            tabPage.Name = "tabPage1";
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(785, 506);
            tabPage.TabIndex = 0;
            tabPage.Text = text;
            tabPage.UseVisualStyleBackColor = true;
            tabControl1.Controls.Add(tabPage);
        }
        public ResultForm(string[] texts, DataTable[] dataTables)
        {
            InitializeComponent();
            if (texts.Length > 0 && texts.Length == dataTables.Length)
            {
                for (int i = 0; i < texts.Length; i++)
                {
                    DataGrid dataGrid = new DataGrid();
                    TabPage tabPage = new TabPage();
                    ((System.ComponentModel.ISupportInitialize)(dataGrid)).BeginInit();
                    tabPage.SuspendLayout();
                    // 
                    // dataGrid
                    // 
                    dataGrid.CaptionVisible = false;
                    dataGrid.DataMember = "";
                    dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
                    dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
                    dataGrid.Location = new System.Drawing.Point(3, 3);
                    dataGrid.Name = "dataGrid";
                    dataGrid.Size = new System.Drawing.Size(779, 500);
                    dataGrid.DataSource = dataTables[i];
                    // 
                    // tabPage
                    // 
                    tabPage.Controls.Add(dataGrid);
                    tabPage.Location = new System.Drawing.Point(4, 21);
                    tabPage.Name = "tabPage1";
                    tabPage.Padding = new System.Windows.Forms.Padding(3);
                    tabPage.Size = new System.Drawing.Size(785, 506);
                    tabPage.TabIndex = 0;
                    tabPage.Text = texts[i];
                    tabPage.UseVisualStyleBackColor = true;
                    tabControl1.Controls.Add(tabPage);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Functions.DataTableToFile((DataTable)this.dataGrid1.DataSource, saveFileDialog1.FileName);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}