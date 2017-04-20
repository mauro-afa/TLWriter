namespace TLWriter
{
    partial class TestSuiteCreation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.TestSuiteTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.JiraLinkTB = new System.Windows.Forms.TextBox();
            this.NetworkCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.VersionCB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ExecutionCB = new System.Windows.Forms.ComboBox();
            this.ImportanceCB = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ChangeTSButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddTCButton = new System.Windows.Forms.Button();
            this.UpdateTCButton = new System.Windows.Forms.Button();
            this.RemoveTCButton = new System.Windows.Forms.Button();
            this.CancelSelect = new System.Windows.Forms.Button();
            this.testsDataSet = new TLWriter.TestsDataSet();
            this.testCasesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testCasesTableAdapter = new TLWriter.TestsDataSetTableAdapters.TestCasesTableAdapter();
            this.tCIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testCaseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testObjectiveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preconditionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expecresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keywordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exectypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testCasesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1286, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Test Suite Name";
            // 
            // TestSuiteTB
            // 
            this.TestSuiteTB.Location = new System.Drawing.Point(16, 44);
            this.TestSuiteTB.Name = "TestSuiteTB";
            this.TestSuiteTB.Size = new System.Drawing.Size(447, 20);
            this.TestSuiteTB.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jira Link";
            // 
            // JiraLinkTB
            // 
            this.JiraLinkTB.Location = new System.Drawing.Point(487, 44);
            this.JiraLinkTB.Name = "JiraLinkTB";
            this.JiraLinkTB.Size = new System.Drawing.Size(456, 20);
            this.JiraLinkTB.TabIndex = 1;
            // 
            // NetworkCB
            // 
            this.NetworkCB.FormattingEnabled = true;
            this.NetworkCB.Location = new System.Drawing.Point(964, 44);
            this.NetworkCB.Name = "NetworkCB";
            this.NetworkCB.Size = new System.Drawing.Size(105, 21);
            this.NetworkCB.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(961, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Network";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1104, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Version";
            // 
            // VersionCB
            // 
            this.VersionCB.FormattingEnabled = true;
            this.VersionCB.Location = new System.Drawing.Point(1107, 44);
            this.VersionCB.Name = "VersionCB";
            this.VersionCB.Size = new System.Drawing.Size(71, 21);
            this.VersionCB.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Test Case ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(736, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Execution";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(881, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Importance";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 113);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(685, 20);
            this.textBox1.TabIndex = 3;
            // 
            // ExecutionCB
            // 
            this.ExecutionCB.FormattingEnabled = true;
            this.ExecutionCB.Items.AddRange(new object[] {
            "Manual",
            "Automated"});
            this.ExecutionCB.Location = new System.Drawing.Point(739, 112);
            this.ExecutionCB.Name = "ExecutionCB";
            this.ExecutionCB.Size = new System.Drawing.Size(121, 21);
            this.ExecutionCB.TabIndex = 4;
            // 
            // ImportanceCB
            // 
            this.ImportanceCB.FormattingEnabled = true;
            this.ImportanceCB.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.ImportanceCB.Location = new System.Drawing.Point(884, 112);
            this.ImportanceCB.Name = "ImportanceCB";
            this.ImportanceCB.Size = new System.Drawing.Size(121, 21);
            this.ImportanceCB.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 183);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(214, 143);
            this.textBox2.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Objective";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(197, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Objective";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(249, 183);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(214, 143);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(487, 183);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(214, 143);
            this.textBox4.TabIndex = 9;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(729, 183);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(214, 143);
            this.textBox5.TabIndex = 10;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "1GENAC",
            "2 Wire Over IP",
            "7-ELEVEN",
            "7-ELEVEN-Conoco",
            "7ELEVEN-EXXON",
            "ADD2REGRESSION",
            "APPLAUSE",
            "BP",
            "CHEVRON",
            "CHEVRON CA",
            "CITGO",
            "CONCORD",
            "CONTROL CENTER",
            "CORE",
            "DASHBOARD",
            "DEFECT",
            "Dual Tank Monitor",
            "EMV",
            "EXCEPTION",
            "EXXON",
            "FDC",
            "FUNCTIONAL",
            "HPSC",
            "HPSD",
            "HPSD-Generic_brand",
            "Incomm",
            "IOL",
            "Kris Sprint 13 Test Cases",
            "MARATHON",
            "NBS",
            "P66",
            "PADSS",
            "PADSS-Lite",
            "REGRESSION",
            "SANITY CHECK",
            "SHELL",
            "SITE SERVER",
            "SMOKE TEST",
            "WORLDPAY"});
            this.checkedListBox1.Location = new System.Drawing.Point(964, 183);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(214, 139);
            this.checkedListBox1.TabIndex = 11;
            // 
            // ChangeTSButton
            // 
            this.ChangeTSButton.Location = new System.Drawing.Point(1054, 111);
            this.ChangeTSButton.Name = "ChangeTSButton";
            this.ChangeTSButton.Size = new System.Drawing.Size(124, 23);
            this.ChangeTSButton.TabIndex = 6;
            this.ChangeTSButton.Text = "Change test suite info";
            this.ChangeTSButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tCIDDataGridViewTextBoxColumn,
            this.testCaseIDDataGridViewTextBoxColumn,
            this.testObjectiveDataGridViewTextBoxColumn,
            this.preconditionsDataGridViewTextBoxColumn,
            this.actionsDataGridViewTextBoxColumn,
            this.expecresDataGridViewTextBoxColumn,
            this.keywordDataGridViewTextBoxColumn,
            this.exectypeDataGridViewTextBoxColumn,
            this.importanceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.testCasesBindingSource;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.Location = new System.Drawing.Point(16, 391);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1162, 150);
            this.dataGridView1.TabIndex = 23;
            // 
            // AddTCButton
            // 
            this.AddTCButton.Location = new System.Drawing.Point(99, 349);
            this.AddTCButton.Name = "AddTCButton";
            this.AddTCButton.Size = new System.Drawing.Size(127, 23);
            this.AddTCButton.TabIndex = 12;
            this.AddTCButton.Text = "Add Test Case";
            this.AddTCButton.UseVisualStyleBackColor = true;
            this.AddTCButton.Click += new System.EventHandler(this.AddTCButton_Click);
            // 
            // UpdateTCButton
            // 
            this.UpdateTCButton.Location = new System.Drawing.Point(336, 349);
            this.UpdateTCButton.Name = "UpdateTCButton";
            this.UpdateTCButton.Size = new System.Drawing.Size(127, 23);
            this.UpdateTCButton.TabIndex = 13;
            this.UpdateTCButton.Text = "Update Test Case";
            this.UpdateTCButton.UseVisualStyleBackColor = true;
            // 
            // RemoveTCButton
            // 
            this.RemoveTCButton.Location = new System.Drawing.Point(574, 349);
            this.RemoveTCButton.Name = "RemoveTCButton";
            this.RemoveTCButton.Size = new System.Drawing.Size(127, 23);
            this.RemoveTCButton.TabIndex = 14;
            this.RemoveTCButton.Text = "Remove Test Case";
            this.RemoveTCButton.UseVisualStyleBackColor = true;
            // 
            // CancelSelect
            // 
            this.CancelSelect.Location = new System.Drawing.Point(816, 349);
            this.CancelSelect.Name = "CancelSelect";
            this.CancelSelect.Size = new System.Drawing.Size(127, 23);
            this.CancelSelect.TabIndex = 15;
            this.CancelSelect.Text = "Cancel selection";
            this.CancelSelect.UseVisualStyleBackColor = true;
            // 
            // testsDataSet
            // 
            this.testsDataSet.DataSetName = "TestsDataSet";
            this.testsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testCasesBindingSource
            // 
            this.testCasesBindingSource.DataMember = "TestCases";
            this.testCasesBindingSource.DataSource = this.testsDataSet;
            // 
            // testCasesTableAdapter
            // 
            this.testCasesTableAdapter.ClearBeforeFill = true;
            // 
            // tCIDDataGridViewTextBoxColumn
            // 
            this.tCIDDataGridViewTextBoxColumn.DataPropertyName = "TCID";
            this.tCIDDataGridViewTextBoxColumn.HeaderText = "TCID";
            this.tCIDDataGridViewTextBoxColumn.Name = "tCIDDataGridViewTextBoxColumn";
            // 
            // testCaseIDDataGridViewTextBoxColumn
            // 
            this.testCaseIDDataGridViewTextBoxColumn.DataPropertyName = "TestCaseID";
            this.testCaseIDDataGridViewTextBoxColumn.HeaderText = "TestCaseID";
            this.testCaseIDDataGridViewTextBoxColumn.Name = "testCaseIDDataGridViewTextBoxColumn";
            // 
            // testObjectiveDataGridViewTextBoxColumn
            // 
            this.testObjectiveDataGridViewTextBoxColumn.DataPropertyName = "TestObjective";
            this.testObjectiveDataGridViewTextBoxColumn.HeaderText = "TestObjective";
            this.testObjectiveDataGridViewTextBoxColumn.Name = "testObjectiveDataGridViewTextBoxColumn";
            // 
            // preconditionsDataGridViewTextBoxColumn
            // 
            this.preconditionsDataGridViewTextBoxColumn.DataPropertyName = "Preconditions";
            this.preconditionsDataGridViewTextBoxColumn.HeaderText = "Preconditions";
            this.preconditionsDataGridViewTextBoxColumn.Name = "preconditionsDataGridViewTextBoxColumn";
            // 
            // actionsDataGridViewTextBoxColumn
            // 
            this.actionsDataGridViewTextBoxColumn.DataPropertyName = "Actions";
            this.actionsDataGridViewTextBoxColumn.HeaderText = "Actions";
            this.actionsDataGridViewTextBoxColumn.Name = "actionsDataGridViewTextBoxColumn";
            // 
            // expecresDataGridViewTextBoxColumn
            // 
            this.expecresDataGridViewTextBoxColumn.DataPropertyName = "Expec_res";
            this.expecresDataGridViewTextBoxColumn.HeaderText = "Expec_res";
            this.expecresDataGridViewTextBoxColumn.Name = "expecresDataGridViewTextBoxColumn";
            // 
            // keywordDataGridViewTextBoxColumn
            // 
            this.keywordDataGridViewTextBoxColumn.DataPropertyName = "Keyword";
            this.keywordDataGridViewTextBoxColumn.HeaderText = "Keyword";
            this.keywordDataGridViewTextBoxColumn.Name = "keywordDataGridViewTextBoxColumn";
            // 
            // exectypeDataGridViewTextBoxColumn
            // 
            this.exectypeDataGridViewTextBoxColumn.DataPropertyName = "Exec_type";
            this.exectypeDataGridViewTextBoxColumn.HeaderText = "Exec_type";
            this.exectypeDataGridViewTextBoxColumn.Name = "exectypeDataGridViewTextBoxColumn";
            // 
            // importanceDataGridViewTextBoxColumn
            // 
            this.importanceDataGridViewTextBoxColumn.DataPropertyName = "Importance";
            this.importanceDataGridViewTextBoxColumn.HeaderText = "Importance";
            this.importanceDataGridViewTextBoxColumn.Name = "importanceDataGridViewTextBoxColumn";
            // 
            // TestSuiteCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 571);
            this.Controls.Add(this.CancelSelect);
            this.Controls.Add(this.RemoveTCButton);
            this.Controls.Add(this.UpdateTCButton);
            this.Controls.Add(this.AddTCButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ChangeTSButton);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.ImportanceCB);
            this.Controls.Add(this.ExecutionCB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VersionCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NetworkCB);
            this.Controls.Add(this.JiraLinkTB);
            this.Controls.Add(this.TestSuiteTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TestSuiteCreation";
            this.Text = "TestSuiteCreation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestSuiteCreation_FormClosed);
            this.Load += new System.EventHandler(this.TestSuiteCreation_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testCasesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TestSuiteTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox JiraLinkTB;
        private System.Windows.Forms.ComboBox NetworkCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox VersionCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox ExecutionCB;
        private System.Windows.Forms.ComboBox ImportanceCB;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button ChangeTSButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddTCButton;
        private System.Windows.Forms.Button UpdateTCButton;
        private System.Windows.Forms.Button RemoveTCButton;
        private System.Windows.Forms.Button CancelSelect;
        private TestsDataSet testsDataSet;
        private System.Windows.Forms.BindingSource testCasesBindingSource;
        private TestsDataSetTableAdapters.TestCasesTableAdapter testCasesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testCaseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testObjectiveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn preconditionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expecresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keywordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exectypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importanceDataGridViewTextBoxColumn;
    }
}