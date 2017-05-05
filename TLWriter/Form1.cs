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
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testsDataSet.TestSuites' table. You can move, or remove it, as needed.
            this.testSuitesTableAdapter.Fill(this.testsDataSet.TestSuites);
            // TODO: This line of code loads data into the 'testsDataSet.TestSuites' table. You can move, or remove it, as needed.
            this.testSuitesTableAdapter.Fill(this.testsDataSet.TestSuites);
            // TODO: This line of code loads data into the 'testsDataSet.TestSuites' table. You can move, or remove it, as needed.
            this.testSuitesTableAdapter.Fill(this.testsDataSet.TestSuites);

        }

        private void CreateTSButton_Click(object sender, EventArgs e)
        {
            TestSuiteCreation f = new TestSuiteCreation(this);
            f.Show(this);
            Hide();
        }

        private void TestSuiteGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
