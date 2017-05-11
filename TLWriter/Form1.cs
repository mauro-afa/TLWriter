using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLWriter
{
    public partial class Form1 : Form
    {
        string[] selectionString = new string[9];

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qSMTCDataSet1.TestSuites' table. You can move, or remove it, as needed.
            this.testSuitesTableAdapter.Fill(this.qSMTCDataSet1.TestSuites);
            // TODO: This line of code loads data into the 'qSMTCDataSet.TestCases' table. You can move, or remove it, as needed.
            this.testCasesTableAdapter.Fill(this.qSMTCDataSet.TestCases);

        }

        private void CreateTSButton_Click(object sender, EventArgs e)
        {
            TestSuiteCreation f = new TestSuiteCreation();
            f.Show(this);
            //Hide();
        }

        private void UploadTSButton_Click(object sender, EventArgs e)
        {
        }

        private void OpenTSButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = new DataGridViewRow();

            dgvr = TestSuiteGrid.CurrentRow;
            for(int i=0; i<8; i++)
            {
                selectionString[i] = dgvr.Cells[i].Value.ToString();
            }
            TestSuiteCreation f = new TestSuiteCreation(selectionString, true);
            f.Show(this);
        }
    }
}
