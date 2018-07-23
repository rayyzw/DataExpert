using DataExpert;
namespace DataExpert
{
    partial class NodeEditForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            this.treeViewTables = null;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewTables = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRunCondition = new System.Windows.Forms.Button();
            this.textBoxCondition = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPreviousDataTable = new System.Windows.Forms.ComboBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonGroupBy = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDistinct = new System.Windows.Forms.Button();
            this.comboBoxKeyword = new System.Windows.Forms.ComboBox();
            this.buttonAnd = new System.Windows.Forms.Button();
            this.buttonOr = new System.Windows.Forms.Button();
            this.buttonOn = new System.Windows.Forms.Button();
            this.buttonRightJoin = new System.Windows.Forms.Button();
            this.buttonLeftJoin = new System.Windows.Forms.Button();
            this.buttonJoin = new System.Windows.Forms.Button();
            this.buttonWhere = new System.Windows.Forms.Button();
            this.buttonFrom = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRunSQL = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSql = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGrid();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewTables);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonRunCondition);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxCondition);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxPreviousDataTable);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxDescription);
            this.splitContainer1.Panel2.Controls.Add(this.buttonGroupBy);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.buttonDistinct);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxKeyword);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAnd);
            this.splitContainer1.Panel2.Controls.Add(this.buttonOr);
            this.splitContainer1.Panel2.Controls.Add(this.buttonOn);
            this.splitContainer1.Panel2.Controls.Add(this.buttonRightJoin);
            this.splitContainer1.Panel2.Controls.Add(this.buttonLeftJoin);
            this.splitContainer1.Panel2.Controls.Add(this.buttonJoin);
            this.splitContainer1.Panel2.Controls.Add(this.buttonWhere);
            this.splitContainer1.Panel2.Controls.Add(this.buttonFrom);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAll);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSelect);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.buttonRunSQL);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxSql);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSubmit);
            this.splitContainer1.Panel2.Controls.Add(this.dataGrid);
            this.splitContainer1.Size = new System.Drawing.Size(994, 735);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeViewTables
            // 
            this.treeViewTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewTables.Location = new System.Drawing.Point(3, 30);
            this.treeViewTables.Name = "treeViewTables";
            this.treeViewTables.Size = new System.Drawing.Size(205, 702);
            this.treeViewTables.TabIndex = 22;
            this.treeViewTables.Visible = false;
            this.treeViewTables.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewTables_NodeMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "数据库结构";
            // 
            // buttonRunCondition
            // 
            this.buttonRunCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRunCondition.Location = new System.Drawing.Point(692, 397);
            this.buttonRunCondition.Name = "buttonRunCondition";
            this.buttonRunCondition.Size = new System.Drawing.Size(75, 23);
            this.buttonRunCondition.TabIndex = 55;
            this.buttonRunCondition.Text = "筛选";
            this.buttonRunCondition.UseVisualStyleBackColor = true;
            this.buttonRunCondition.Click += new System.EventHandler(this.buttonRunCondition_Click);
            // 
            // textBoxCondition
            // 
            this.textBoxCondition.Location = new System.Drawing.Point(1, 328);
            this.textBoxCondition.Multiline = true;
            this.textBoxCondition.Name = "textBoxCondition";
            this.textBoxCondition.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCondition.Size = new System.Drawing.Size(775, 63);
            this.textBoxCondition.TabIndex = 53;
            this.textBoxCondition.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(3, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 54;
            this.label3.Text = "筛选条件";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(1, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "上一节点数据结构";
            // 
            // comboBoxPreviousDataTable
            // 
            this.comboBoxPreviousDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPreviousDataTable.Location = new System.Drawing.Point(108, 276);
            this.comboBoxPreviousDataTable.Name = "comboBoxPreviousDataTable";
            this.comboBoxPreviousDataTable.Size = new System.Drawing.Size(286, 20);
            this.comboBoxPreviousDataTable.TabIndex = 48;
            this.comboBoxPreviousDataTable.SelectedIndexChanged += new System.EventHandler(this.comboBoxPreviousDataTable_SelectedIndexChanged);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.Location = new System.Drawing.Point(1, 30);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(777, 55);
            this.textBoxDescription.TabIndex = 47;
            this.textBoxDescription.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // buttonGroupBy
            // 
            this.buttonGroupBy.AutoSize = true;
            this.buttonGroupBy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGroupBy.Location = new System.Drawing.Point(514, 114);
            this.buttonGroupBy.Name = "buttonGroupBy";
            this.buttonGroupBy.Size = new System.Drawing.Size(63, 22);
            this.buttonGroupBy.TabIndex = 46;
            this.buttonGroupBy.Text = "group by";
            this.buttonGroupBy.UseVisualStyleBackColor = true;
            this.buttonGroupBy.Click += new System.EventHandler(this.button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 45;
            this.label5.Text = "说明";
            // 
            // buttonDistinct
            // 
            this.buttonDistinct.AutoSize = true;
            this.buttonDistinct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDistinct.Location = new System.Drawing.Point(56, 114);
            this.buttonDistinct.Name = "buttonDistinct";
            this.buttonDistinct.Size = new System.Drawing.Size(63, 22);
            this.buttonDistinct.TabIndex = 44;
            this.buttonDistinct.Text = "distinct";
            this.buttonDistinct.UseVisualStyleBackColor = true;
            this.buttonDistinct.Click += new System.EventHandler(this.button_Click);
            // 
            // comboBoxKeyword
            // 
            this.comboBoxKeyword.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKeyword.Items.AddRange(new object[] {
            "order by",
            "union",
            "in",
            "not in",
            "like",
            "=",
            "<>",
            "<",
            ">",
            "<=",
            ">=",
            "sum",
            "pow",
            "abs",
            "mod",
            "sqrt",
            "round",
            "count",
            "concat",
            "avg",
            "min",
            "max",
            "date",
            "today",
            "day",
            "month",
            "year",
            "weekday",
            "between \'{minValue}\' and \'{maxValue}\'",
            "between \'{minValue1}\' and \'{maxValue1}\'"});
            this.comboBoxKeyword.Location = new System.Drawing.Point(579, 114);
            this.comboBoxKeyword.Name = "comboBoxKeyword";
            this.comboBoxKeyword.Size = new System.Drawing.Size(188, 20);
            this.comboBoxKeyword.TabIndex = 43;
            this.comboBoxKeyword.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyword_SelectedIndexChanged);
            // 
            // buttonAnd
            // 
            this.buttonAnd.AutoSize = true;
            this.buttonAnd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAnd.Location = new System.Drawing.Point(450, 114);
            this.buttonAnd.Name = "buttonAnd";
            this.buttonAnd.Size = new System.Drawing.Size(33, 22);
            this.buttonAnd.TabIndex = 41;
            this.buttonAnd.Text = "and";
            this.buttonAnd.UseVisualStyleBackColor = true;
            this.buttonAnd.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonOr
            // 
            this.buttonOr.AutoSize = true;
            this.buttonOr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOr.Location = new System.Drawing.Point(485, 114);
            this.buttonOr.Name = "buttonOr";
            this.buttonOr.Size = new System.Drawing.Size(27, 22);
            this.buttonOr.TabIndex = 40;
            this.buttonOr.Text = "or";
            this.buttonOr.UseVisualStyleBackColor = true;
            this.buttonOr.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonOn
            // 
            this.buttonOn.AutoSize = true;
            this.buttonOn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOn.Location = new System.Drawing.Point(421, 114);
            this.buttonOn.Name = "buttonOn";
            this.buttonOn.Size = new System.Drawing.Size(27, 22);
            this.buttonOn.TabIndex = 39;
            this.buttonOn.Text = "on";
            this.buttonOn.UseVisualStyleBackColor = true;
            this.buttonOn.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonRightJoin
            // 
            this.buttonRightJoin.AutoSize = true;
            this.buttonRightJoin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRightJoin.Location = new System.Drawing.Point(344, 114);
            this.buttonRightJoin.Name = "buttonRightJoin";
            this.buttonRightJoin.Size = new System.Drawing.Size(75, 22);
            this.buttonRightJoin.TabIndex = 38;
            this.buttonRightJoin.Text = "right join";
            this.buttonRightJoin.UseVisualStyleBackColor = true;
            this.buttonRightJoin.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonLeftJoin
            // 
            this.buttonLeftJoin.AutoSize = true;
            this.buttonLeftJoin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonLeftJoin.Location = new System.Drawing.Point(273, 114);
            this.buttonLeftJoin.Name = "buttonLeftJoin";
            this.buttonLeftJoin.Size = new System.Drawing.Size(69, 22);
            this.buttonLeftJoin.TabIndex = 37;
            this.buttonLeftJoin.Text = "left join";
            this.buttonLeftJoin.UseVisualStyleBackColor = true;
            this.buttonLeftJoin.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonJoin
            // 
            this.buttonJoin.AutoSize = true;
            this.buttonJoin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonJoin.Location = new System.Drawing.Point(232, 114);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(39, 22);
            this.buttonJoin.TabIndex = 36;
            this.buttonJoin.Text = "join";
            this.buttonJoin.UseVisualStyleBackColor = true;
            this.buttonJoin.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonWhere
            // 
            this.buttonWhere.AutoSize = true;
            this.buttonWhere.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonWhere.Location = new System.Drawing.Point(184, 114);
            this.buttonWhere.Name = "buttonWhere";
            this.buttonWhere.Size = new System.Drawing.Size(45, 22);
            this.buttonWhere.TabIndex = 35;
            this.buttonWhere.Text = "where";
            this.buttonWhere.UseVisualStyleBackColor = true;
            this.buttonWhere.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonFrom
            // 
            this.buttonFrom.AutoSize = true;
            this.buttonFrom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonFrom.Location = new System.Drawing.Point(143, 114);
            this.buttonFrom.Name = "buttonFrom";
            this.buttonFrom.Size = new System.Drawing.Size(39, 22);
            this.buttonFrom.TabIndex = 34;
            this.buttonFrom.Text = "from";
            this.buttonFrom.UseVisualStyleBackColor = true;
            this.buttonFrom.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.AutoSize = true;
            this.buttonAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAll.Location = new System.Drawing.Point(120, 114);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(21, 22);
            this.buttonAll.TabIndex = 33;
            this.buttonAll.Text = "*";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.AutoSize = true;
            this.buttonSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSelect.Location = new System.Drawing.Point(3, 114);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(51, 22);
            this.buttonSelect.TabIndex = 32;
            this.buttonSelect.Text = "select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.Location = new System.Drawing.Point(-1, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "运行结果";
            // 
            // buttonRunSQL
            // 
            this.buttonRunSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRunSQL.Location = new System.Drawing.Point(692, 268);
            this.buttonRunSQL.Name = "buttonRunSQL";
            this.buttonRunSQL.Size = new System.Drawing.Size(75, 23);
            this.buttonRunSQL.TabIndex = 29;
            this.buttonRunSQL.Text = "运行";
            this.buttonRunSQL.UseVisualStyleBackColor = true;
            this.buttonRunSQL.Click += new System.EventHandler(this.buttonRunSQL_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(-1, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "运行语句（SQL）";
            // 
            // textBoxSql
            // 
            this.textBoxSql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSql.Location = new System.Drawing.Point(-1, 142);
            this.textBoxSql.Multiline = true;
            this.textBoxSql.Name = "textBoxSql";
            this.textBoxSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSql.Size = new System.Drawing.Size(777, 120);
            this.textBoxSql.TabIndex = 25;
            this.textBoxSql.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSubmit.Location = new System.Drawing.Point(692, 700);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 1;
            this.buttonSubmit.Text = "确定";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.DataMember = "";
            this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid.Location = new System.Drawing.Point(1, 452);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(777, 242);
            this.dataGrid.TabIndex = 23;
            // 
            // NodeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 735);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NodeEditForm";
            this.Text = "NodeEditForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonRunSQL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSql;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.DataGrid dataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeViewTables;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonRightJoin;
        private System.Windows.Forms.Button buttonLeftJoin;
        private System.Windows.Forms.Button buttonJoin;
        private System.Windows.Forms.Button buttonWhere;
        private System.Windows.Forms.Button buttonFrom;
        private System.Windows.Forms.Button buttonAnd;
        private System.Windows.Forms.Button buttonOr;
        private System.Windows.Forms.Button buttonOn;
        private System.Windows.Forms.ComboBox comboBoxKeyword;
        private System.Windows.Forms.Button buttonDistinct;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonGroupBy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPreviousDataTable;
        private System.Windows.Forms.Button buttonRunCondition;
        private System.Windows.Forms.TextBox textBoxCondition;
        private System.Windows.Forms.Label label3;



    }
}