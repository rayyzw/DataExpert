namespace DataExpert
{
    partial class EndEditForm
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
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProblemType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCause = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSuggestion = new System.Windows.Forms.TextBox();
            this.comboBoxPreviousDataTable = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSubmit.Location = new System.Drawing.Point(330, 330);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 2;
            this.buttonSubmit.Text = "确定";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(12, 22);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(393, 42);
            this.textBoxDescription.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 55;
            this.label1.Text = "说明";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 57;
            this.label2.Text = "问题类型";
            // 
            // textBoxProblemType
            // 
            this.textBoxProblemType.Location = new System.Drawing.Point(12, 91);
            this.textBoxProblemType.Multiline = true;
            this.textBoxProblemType.Name = "textBoxProblemType";
            this.textBoxProblemType.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxProblemType.Size = new System.Drawing.Size(393, 42);
            this.textBoxProblemType.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 59;
            this.label3.Text = "原因";
            // 
            // textBoxCause
            // 
            this.textBoxCause.Location = new System.Drawing.Point(12, 160);
            this.textBoxCause.Multiline = true;
            this.textBoxCause.Name = "textBoxCause";
            this.textBoxCause.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCause.Size = new System.Drawing.Size(393, 42);
            this.textBoxCause.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 61;
            this.label4.Text = "处理建议";
            // 
            // textBoxSuggestion
            // 
            this.textBoxSuggestion.Location = new System.Drawing.Point(12, 230);
            this.textBoxSuggestion.Multiline = true;
            this.textBoxSuggestion.Name = "textBoxSuggestion";
            this.textBoxSuggestion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSuggestion.Size = new System.Drawing.Size(393, 42);
            this.textBoxSuggestion.TabIndex = 62;
            // 
            // comboBoxPreviousDataTable
            // 
            this.comboBoxPreviousDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPreviousDataTable.Location = new System.Drawing.Point(12, 299);
            this.comboBoxPreviousDataTable.Name = "comboBoxPreviousDataTable";
            this.comboBoxPreviousDataTable.Size = new System.Drawing.Size(393, 20);
            this.comboBoxPreviousDataTable.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 64;
            this.label5.Text = "小区名称对应字段";
            // 
            // EndEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 365);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxPreviousDataTable);
            this.Controls.Add(this.textBoxSuggestion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCause);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxProblemType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EndEditForm";
            this.Text = "EndEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxProblemType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCause;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSuggestion;
        private System.Windows.Forms.ComboBox comboBoxPreviousDataTable;
        private System.Windows.Forms.Label label5;




    }
}