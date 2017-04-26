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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DeleteTSButton = new System.Windows.Forms.Button();
            this.OpenTSButton = new System.Windows.Forms.Button();
            this.UploadTSButton = new System.Windows.Forms.Button();
            this.CreateTSButton = new System.Windows.Forms.Button();
            this.TestSuiteGrid = new System.Windows.Forms.DataGridView();
            this.testSuitesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testsDataSet = new QSM.TestsDataSet();
            this.testsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testSuitesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.testSuitesTableAdapter = new QSM.TestsDataSetTableAdapters.TestSuitesTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.networkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uploadDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestSuiteGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testSuitesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testsDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testSuitesBindingSource1)).BeginInit();
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
            // DeleteTSButton
            // 
            this.DeleteTSButton.Location = new System.Drawing.Point(66, 243);
            this.DeleteTSButton.Name = "DeleteTSButton";
            this.DeleteTSButton.Size = new System.Drawing.Size(155, 42);
            this.DeleteTSButton.TabIndex = 3;
            this.DeleteTSButton.Text = "Delete test suite";
            this.DeleteTSButton.UseVisualStyleBackColor = true;
            // 
            // OpenTSButton
            // 
            this.OpenTSButton.Location = new System.Drawing.Point(66, 195);
            this.OpenTSButton.Name = "OpenTSButton";
            this.OpenTSButton.Size = new System.Drawing.Size(155, 42);
            this.OpenTSButton.TabIndex = 2;
            this.OpenTSButton.Text = "Open test suite";
            this.OpenTSButton.UseVisualStyleBackColor = true;
            // 
            // UploadTSButton
            // 
            this.UploadTSButton.Location = new System.Drawing.Point(66, 147);
            this.UploadTSButton.Name = "UploadTSButton";
            this.UploadTSButton.Size = new System.Drawing.Size(155, 42);
            this.UploadTSButton.TabIndex = 1;
            this.UploadTSButton.Text = "Upload test suite";
            this.UploadTSButton.UseVisualStyleBackColor = true;
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
            this.TestSuiteGrid.AutoGenerateColumns = false;
            this.TestSuiteGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TestSuiteGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestSuiteGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.networkDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.creationDateDataGridViewTextBoxColumn,
            this.uploadDateDataGridViewTextBoxColumn,
            this.updateDateDataGridViewTextBoxColumn});
            this.TestSuiteGrid.DataSource = this.testSuitesBindingSource1;
            this.TestSuiteGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestSuiteGrid.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TestSuiteGrid.Location = new System.Drawing.Point(0, 0);
            this.TestSuiteGrid.Name = "TestSuiteGrid";
            this.TestSuiteGrid.ReadOnly = true;
            this.TestSuiteGrid.Size = new System.Drawing.Size(632, 489);
            this.TestSuiteGrid.TabIndex = 0;
            this.TestSuiteGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TestSuiteGrid_CellContentClick);
            // 
            // testsDataSet
            // 
            this.testsDataSet.DataSetName = "TestsDataSet";
            this.testsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testsDataSetBindingSource
            // 
            this.testsDataSetBindingSource.DataSource = this.testsDataSet;
            this.testsDataSetBindingSource.Position = 0;
            // 
            // testSuitesBindingSource1
            // 
            this.testSuitesBindingSource1.DataMember = "TestSuites";
            this.testSuitesBindingSource1.DataSource = this.testsDataSet;
            // 
            // testSuitesTableAdapter
            // 
            this.testSuitesTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // networkDataGridViewTextBoxColumn
            // 
            this.networkDataGridViewTextBoxColumn.DataPropertyName = "Network";
            this.networkDataGridViewTextBoxColumn.HeaderText = "Network";
            this.networkDataGridViewTextBoxColumn.Name = "networkDataGridViewTextBoxColumn";
            this.networkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // creationDateDataGridViewTextBoxColumn
            // 
            this.creationDateDataGridViewTextBoxColumn.DataPropertyName = "CreationDate";
            this.creationDateDataGridViewTextBoxColumn.HeaderText = "CreationDate";
            this.creationDateDataGridViewTextBoxColumn.Name = "creationDateDataGridViewTextBoxColumn";
            this.creationDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uploadDateDataGridViewTextBoxColumn
            // 
            this.uploadDateDataGridViewTextBoxColumn.DataPropertyName = "UploadDate";
            this.uploadDateDataGridViewTextBoxColumn.HeaderText = "UploadDate";
            this.uploadDateDataGridViewTextBoxColumn.Name = "uploadDateDataGridViewTextBoxColumn";
            this.uploadDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // updateDateDataGridViewTextBoxColumn
            // 
            this.updateDateDataGridViewTextBoxColumn.DataPropertyName = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.HeaderText = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.Name = "updateDateDataGridViewTextBoxColumn";
            this.updateDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 513);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TestSuiteGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testSuitesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testsDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testSuitesBindingSource1)).EndInit();
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
        private System.Windows.Forms.BindingSource testSuitesBindingSource;
        private System.Windows.Forms.BindingSource testsDataSetBindingSource;
        private QSM.TestsDataSet testsDataSet;
        private System.Windows.Forms.BindingSource testSuitesBindingSource1;
        private QSM.TestsDataSetTableAdapters.TestSuitesTableAdapter testSuitesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn networkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uploadDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDateDataGridViewTextBoxColumn;
    }
}

