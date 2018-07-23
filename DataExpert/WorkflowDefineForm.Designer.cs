namespace DataExpert
{
    partial class WorkflowDefineForm
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewWorkflows = new System.Windows.Forms.TreeView();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonDBConnect = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblRoute = new System.Windows.Forms.Label();
            this.lblNode = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.labelXY = new System.Windows.Forms.Label();
            this.labelScaleDown = new System.Windows.Forms.Label();
            this.labelScaleUp = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewWorkflows);
            this.splitContainer1.Panel1.Controls.Add(this.buttonRun);
            this.splitContainer1.Panel1.Controls.Add(this.buttonImport);
            this.splitContainer1.Panel1.Controls.Add(this.buttonDBConnect);
            this.splitContainer1.Panel1.Controls.Add(this.buttonNew);
            this.splitContainer1.Panel1.Controls.Add(this.buttonOpen);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSave);
            this.splitContainer1.Panel1.Controls.Add(this.lblEnd);
            this.splitContainer1.Panel1.Controls.Add(this.lblRoute);
            this.splitContainer1.Panel1.Controls.Add(this.lblNode);
            this.splitContainer1.Panel1.Controls.Add(this.lblStart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.labelXY);
            this.splitContainer1.Panel2.Controls.Add(this.labelScaleDown);
            this.splitContainer1.Panel2.Controls.Add(this.labelScaleUp);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Panel2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel2_MouseDoubleClick);
            this.splitContainer1.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel2_MouseDown);
            this.splitContainer1.Panel2.MouseEnter += new System.EventHandler(this.splitContainer1_Panel2_MouseEnter);
            this.splitContainer1.Panel2.MouseLeave += new System.EventHandler(this.splitContainer1_Panel2_MouseLeave);
            this.splitContainer1.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel2_MouseMove);
            this.splitContainer1.Panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel2_MouseUp);
            this.splitContainer1.Size = new System.Drawing.Size(792, 621);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewWorkflows
            // 
            this.treeViewWorkflows.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewWorkflows.Location = new System.Drawing.Point(0, 0);
            this.treeViewWorkflows.Name = "treeViewWorkflows";
            this.treeViewWorkflows.Size = new System.Drawing.Size(145, 621);
            this.treeViewWorkflows.TabIndex = 13;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(154, 470);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 25);
            this.buttonRun.TabIndex = 9;
            this.buttonRun.Text = "run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(153, 377);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 25);
            this.buttonImport.TabIndex = 8;
            this.buttonImport.Text = "import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonDBConnect
            // 
            this.buttonDBConnect.Location = new System.Drawing.Point(154, 439);
            this.buttonDBConnect.Name = "buttonDBConnect";
            this.buttonDBConnect.Size = new System.Drawing.Size(75, 25);
            this.buttonDBConnect.TabIndex = 7;
            this.buttonDBConnect.Text = "database";
            this.buttonDBConnect.UseVisualStyleBackColor = true;
            this.buttonDBConnect.Click += new System.EventHandler(this.buttonDBConnect_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(153, 314);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 25);
            this.buttonNew.TabIndex = 6;
            this.buttonNew.Text = "new";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(153, 346);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 25);
            this.buttonOpen.TabIndex = 5;
            this.buttonOpen.Text = "open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(153, 408);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 25);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // lblEnd
            // 
            this.lblEnd.BackColor = System.Drawing.Color.White;
            this.lblEnd.Location = new System.Drawing.Point(151, 236);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(80, 65);
            this.lblEnd.TabIndex = 3;
            this.lblEnd.Text = "end";
            this.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEnd.Click += new System.EventHandler(this.lblEnd_Click);
            // 
            // lblRoute
            // 
            this.lblRoute.BackColor = System.Drawing.Color.White;
            this.lblRoute.Location = new System.Drawing.Point(151, 160);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(80, 65);
            this.lblRoute.TabIndex = 2;
            this.lblRoute.Text = "route";
            this.lblRoute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRoute.Click += new System.EventHandler(this.lblRoute_Click);
            // 
            // lblNode
            // 
            this.lblNode.BackColor = System.Drawing.Color.White;
            this.lblNode.Location = new System.Drawing.Point(151, 86);
            this.lblNode.Name = "lblNode";
            this.lblNode.Size = new System.Drawing.Size(80, 65);
            this.lblNode.TabIndex = 1;
            this.lblNode.Text = "node";
            this.lblNode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNode.Click += new System.EventHandler(this.lblNode_Click);
            // 
            // lblStart
            // 
            this.lblStart.BackColor = System.Drawing.Color.White;
            this.lblStart.Location = new System.Drawing.Point(151, 10);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(80, 65);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "start";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStart.Click += new System.EventHandler(this.lblStart_Click);
            // 
            // labelXY
            // 
            this.labelXY.AutoSize = true;
            this.labelXY.BackColor = System.Drawing.Color.Transparent;
            this.labelXY.Location = new System.Drawing.Point(17, 23);
            this.labelXY.Name = "labelXY";
            this.labelXY.Size = new System.Drawing.Size(44, 26);
            this.labelXY.TabIndex = 2;
            this.labelXY.Text = "x=0;y=0\nscale=5";
            this.labelXY.Click += new System.EventHandler(this.labelXY_Click);
            // 
            // labelScaleDown
            // 
            this.labelScaleDown.AutoSize = true;
            this.labelScaleDown.BackColor = System.Drawing.Color.Transparent;
            this.labelScaleDown.Location = new System.Drawing.Point(34, 10);
            this.labelScaleDown.Name = "labelScaleDown";
            this.labelScaleDown.Size = new System.Drawing.Size(10, 13);
            this.labelScaleDown.TabIndex = 1;
            this.labelScaleDown.Text = "-";
            this.labelScaleDown.Click += new System.EventHandler(this.labelScaleDown_Click);
            // 
            // labelScaleUp
            // 
            this.labelScaleUp.AutoSize = true;
            this.labelScaleUp.BackColor = System.Drawing.Color.Transparent;
            this.labelScaleUp.Location = new System.Drawing.Point(17, 10);
            this.labelScaleUp.Name = "labelScaleUp";
            this.labelScaleUp.Size = new System.Drawing.Size(13, 13);
            this.labelScaleUp.TabIndex = 0;
            this.labelScaleUp.Text = "+";
            this.labelScaleUp.Click += new System.EventHandler(this.labelScaleUp_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WorkflowDefineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 621);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WorkflowDefineForm";
            this.Text = "WorkflowDesignForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblNode;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonDBConnect;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Label labelScaleUp;
        private System.Windows.Forms.Label labelScaleDown;
        private System.Windows.Forms.Label labelXY;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TreeView treeViewWorkflows;
    }
}

