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
    public partial class WorkflowAttributesForm : Form
    {
        private Hashtable attributes;
        public WorkflowAttributesForm(Hashtable attributes)
        {
            InitializeComponent();
            this.attributes = attributes;
            if (attributes["workflowName"] != null) this.textBoxWorkflowName.Text = (string)attributes["workflowName"];
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (attributes["workflowName"] == null) attributes.Add("workflowName", this.textBoxWorkflowName.Text);
            else attributes["workflowName"] = this.textBoxWorkflowName.Text;
        }
    }
}