﻿using System;
using System.Windows.Forms;

namespace TLWriter
{
    public partial class TestSuiteCreation : Form
    {
        int newTestSuite = 0;
        string[] translateResult;
        CommonFunctions cf;

        public Form parent
        {

            get;
            private set;

        }

        public TestSuiteCreation(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void TestSuiteCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.parent.Show();            
        }

        private void AddTCButton_Click(object sender, EventArgs e)
        {
            addTestSuite();
        }

        private void TestSuiteCreation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testsDataSet.TestCases' table. You can move, or remove it, as needed.
            this.testCasesTableAdapter.Fill(this.testsDataSet.TestCases);

        }

        private void addTestSuite()
        {
            MessageBox.Show(ExecutionCB.SelectedItem.ToString());
            //translateResult = cf.translateStep(ExecutionCB.SelectedItem.ToString, ImportanceCB.SelectedItem);
        }
    }
}
