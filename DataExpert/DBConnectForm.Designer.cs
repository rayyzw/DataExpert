using System.Windows.Forms;

namespace DataExpert
{
    partial class DBConnectForm
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.server = new System.Windows.Forms.TextBox();
            this.userid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tables = new System.Windows.Forms.ComboBox();
            this.dataGrid = new System.Windows.Forms.DataGrid();
            this.updateBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.database = new System.Windows.Forms.TextBox();
            this.connectStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mySQL = new System.Windows.Forms.RadioButton();
            this.oracle = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // server
            // 
            this.server.Location = new System.Drawing.Point(93, 37);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(187, 20);
            this.server.TabIndex = 1;
            this.server.Text = "localhost";
            // 
            // userid
            // 
            this.userid.Location = new System.Drawing.Point(93, 64);
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(187, 20);
            this.userid.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Id:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(401, 65);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(181, 20);
            this.password.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(319, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // connectBtn
            // 
            this.connectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connectBtn.Location = new System.Drawing.Point(492, 91);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(90, 26);
            this.connectBtn.TabIndex = 6;
            this.connectBtn.Text = "Connect";
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tables";
            // 
            // tables
            // 
            this.tables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tables.Location = new System.Drawing.Point(93, 198);
            this.tables.Name = "tables";
            this.tables.Size = new System.Drawing.Size(381, 21);
            this.tables.TabIndex = 7;
            this.tables.SelectedIndexChanged += new System.EventHandler(this.tables_SelectedIndexChanged);
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.DataMember = "";
            this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid.Location = new System.Drawing.Point(2, 226);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(590, 244);
            this.dataGrid.TabIndex = 8;
            // 
            // updateBtn
            // 
            this.updateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateBtn.Location = new System.Drawing.Point(492, 193);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(90, 27);
            this.updateBtn.TabIndex = 9;
            this.updateBtn.Text = "Update";
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Databases:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(319, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Port:";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(401, 34);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(181, 20);
            this.port.TabIndex = 14;
            this.port.Text = "3306";
            // 
            // database
            // 
            this.database.Location = new System.Drawing.Point(93, 93);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(187, 20);
            this.database.TabIndex = 21;
            // 
            // connectStatus
            // 
            this.connectStatus.Location = new System.Drawing.Point(9, 127);
            this.connectStatus.Name = "connectStatus";
            this.connectStatus.Size = new System.Drawing.Size(561, 63);
            this.connectStatus.TabIndex = 22;
            this.connectStatus.Text = "no connection to database";
            this.connectStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Database";
            // 
            // mySQL
            // 
            this.mySQL.AutoSize = true;
            this.mySQL.Checked = true;
            this.mySQL.Location = new System.Drawing.Point(93, 12);
            this.mySQL.Name = "mySQL";
            this.mySQL.Size = new System.Drawing.Size(60, 17);
            this.mySQL.TabIndex = 24;
            this.mySQL.TabStop = true;
            this.mySQL.Text = "MySQL";
            this.mySQL.UseVisualStyleBackColor = true;
            // 
            // oracle
            // 
            this.oracle.AutoSize = true;
            this.oracle.Location = new System.Drawing.Point(152, 12);
            this.oracle.Name = "oracle";
            this.oracle.Size = new System.Drawing.Size(56, 17);
            this.oracle.TabIndex = 25;
            this.oracle.TabStop = true;
            this.oracle.Text = "Oracle";
            this.oracle.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(492, 477);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(90, 26);
            this.buttonOK.TabIndex = 26;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // DBConnectForm
            // 
            this.ClientSize = new System.Drawing.Size(594, 515);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.oracle);
            this.Controls.Add(this.mySQL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.connectStatus);
            this.Controls.Add(this.database);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.tables);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.server);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBConnectForm";
            this.Text = "DBConnectForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tables;
        private System.Windows.Forms.TextBox server;
        private System.Windows.Forms.TextBox userid;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button updateBtn;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Label label5;

        private DataGrid dataGrid;
        private Label label6;
        private TextBox port;
        private TextBox database;
        private Label connectStatus;
        private Label label7;
        private RadioButton mySQL;
        private RadioButton oracle;
        private Button buttonOK;
    }
}