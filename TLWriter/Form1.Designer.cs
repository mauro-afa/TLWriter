namespace TLWriter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.XMLButton = new System.Windows.Forms.Button();
            this.DeleteTSButton = new System.Windows.Forms.Button();
            this.OpenTSButton = new System.Windows.Forms.Button();
            this.UploadTSButton = new System.Windows.Forms.Button();
            this.CreateTSButton = new System.Windows.Forms.Button();
            this.TestSuiteGrid = new System.Windows.Forms.DataGridView();
            this.testSuitesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qSMTCDataSet1 = new QSM.QSMTCDataSet();
            this.qSMTCDataSet = new QSM.QSMTCDataSet();
            this.testCasesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testCasesTableAdapter = new QSM.QSMTCDataSetTableAdapters.TestCasesTableAdapter();
            this.testSuitesTableAdapter = new QSM.QSMTCDataSetTableAdapters.TestSuitesTableAdapter();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestSuiteGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testSuitesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qSMTCDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qSMTCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testCasesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(954, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.RefreshButton);
            this.splitContainer1.Panel1.Controls.Add(this.XMLButton);
            this.splitContainer1.Panel1.Controls.Add(this.DeleteTSButton);
            this.splitContainer1.Panel1.Controls.Add(this.OpenTSButton);
            this.splitContainer1.Panel1.Controls.Add(this.UploadTSButton);
            this.splitContainer1.Panel1.Controls.Add(this.CreateTSButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TestSuiteGrid);
            this.splitContainer1.Size = new System.Drawing.Size(954, 489);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.TabIndex = 1;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(241, 3);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 5;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // XMLButton
            // 
            this.XMLButton.Location = new System.Drawing.Point(66, 291);
            this.XMLButton.Name = "XMLButton";
            this.XMLButton.Size = new System.Drawing.Size(155, 42);
            this.XMLButton.TabIndex = 4;
            this.XMLButton.Text = "Export to XML";
            this.XMLButton.UseVisualStyleBackColor = true;
            this.XMLButton.Click += new System.EventHandler(this.XMLButton_Click);
            // 
            // DeleteTSButton
            // 
            this.DeleteTSButton.Location = new System.Drawing.Point(66, 243);
            this.DeleteTSButton.Name = "DeleteTSButton";
            this.DeleteTSButton.Size = new System.Drawing.Size(155, 42);
            this.DeleteTSButton.TabIndex = 3;
            this.DeleteTSButton.Text = "Delete test suite";
            this.DeleteTSButton.UseVisualStyleBackColor = true;
            this.DeleteTSButton.Click += new System.EventHandler(this.DeleteTSButton_Click);
            // 
            // OpenTSButton
            // 
            this.OpenTSButton.Location = new System.Drawing.Point(66, 195);
            this.OpenTSButton.Name = "OpenTSButton";
            this.OpenTSButton.Size = new System.Drawing.Size(155, 42);
            this.OpenTSButton.TabIndex = 2;
            this.OpenTSButton.Text = "Open test suite";
            this.OpenTSButton.UseVisualStyleBackColor = true;
            this.OpenTSButton.Click += new System.EventHandler(this.OpenTSButton_Click);
            // 
            // UploadTSButton
            // 
            this.UploadTSButton.Location = new System.Drawing.Point(66, 147);
            this.UploadTSButton.Name = "UploadTSButton";
            this.UploadTSButton.Size = new System.Drawing.Size(155, 42);
            this.UploadTSButton.TabIndex = 1;
            this.UploadTSButton.Text = "Upload test suite";
            this.UploadTSButton.UseVisualStyleBackColor = true;
            this.UploadTSButton.Click += new System.EventHandler(this.UploadTSButton_Click);
            // 
            // CreateTSButton
            // 
            this.CreateTSButton.Location = new System.Drawing.Point(66, 99);
            this.CreateTSButton.Name = "CreateTSButton";
            this.CreateTSButton.Size = new System.Drawing.Size(155, 42);
            this.CreateTSButton.TabIndex = 0;
            this.CreateTSButton.Text = "Create test suite";
            this.CreateTSButton.UseVisualStyleBackColor = true;
            this.CreateTSButton.Click += new System.EventHandler(this.CreateTSButton_Click);
            // 
            // TestSuiteGrid
            // 
            this.TestSuiteGrid.AllowUserToAddRows = false;
            this.TestSuiteGrid.AllowUserToDeleteRows = false;
            this.TestSuiteGrid.AllowUserToResizeColumns = false;
            this.TestSuiteGrid.AllowUserToResizeRows = false;
            this.TestSuiteGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TestSuiteGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TestSuiteGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestSuiteGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestSuiteGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TestSuiteGrid.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TestSuiteGrid.Location = new System.Drawing.Point(0, 0);
            this.TestSuiteGrid.Name = "TestSuiteGrid";
            this.TestSuiteGrid.ReadOnly = true;
            this.TestSuiteGrid.RowHeadersVisible = false;
            this.TestSuiteGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TestSuiteGrid.ShowCellErrors = false;
            this.TestSuiteGrid.ShowRowErrors = false;
            this.TestSuiteGrid.Size = new System.Drawing.Size(632, 489);
            this.TestSuiteGrid.TabIndex = 0;
            this.TestSuiteGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TestSuiteGrid_CellClick);
            // 
            // testSuitesBindingSource
            // 
            this.testSuitesBindingSource.DataMember = "TestSuites";
            this.testSuitesBindingSource.DataSource = this.qSMTCDataSet1;
            // 
            // qSMTCDataSet1
            // 
            this.qSMTCDataSet1.DataSetName = "QSMTCDataSet";
            this.qSMTCDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qSMTCDataSet
            // 
            this.qSMTCDataSet.DataSetName = "QSMTCDataSet";
            this.qSMTCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testCasesBindingSource
            // 
            this.testCasesBindingSource.DataMember = "TestCases";
            this.testCasesBindingSource.DataSource = this.qSMTCDataSet;
            // 
            // testCasesTableAdapter
            // 
            this.testCasesTableAdapter.ClearBeforeFill = true;
            // 
            // testSuitesTableAdapter
            // 
            this.testSuitesTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 513);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "QSM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TestSuiteGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testSuitesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qSMTCDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qSMTCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testCasesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button DeleteTSButton;
        private System.Windows.Forms.Button OpenTSButton;
        private System.Windows.Forms.Button UploadTSButton;
        private System.Windows.Forms.Button CreateTSButton;
        private System.Windows.Forms.DataGridView TestSuiteGrid;
        private QSM.QSMTCDataSet qSMTCDataSet;
        private System.Windows.Forms.BindingSource testCasesBindingSource;
        private QSM.QSMTCDataSetTableAdapters.TestCasesTableAdapter testCasesTableAdapter;
        private QSM.QSMTCDataSet qSMTCDataSet1;
        private System.Windows.Forms.BindingSource testSuitesBindingSource;
        private QSM.QSMTCDataSetTableAdapters.TestSuitesTableAdapter testSuitesTableAdapter;
        private System.Windows.Forms.Button XMLButton;
        private System.Windows.Forms.Button RefreshButton;
    }
}

