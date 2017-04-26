using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TLWriter
{
    public partial class TestSuiteCreation : Form
    {
        int newTestSuite = 0;
        string[] translateResult;
        int tcounter = 0;
        CommonFunctions cf;
        SqlConnection scn;
        SqlDataAdapter adapter;
        SqlCommand scmd;
        SqlDataReader sdr;
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
            addTestCase();
        }

        private void TestSuiteCreation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testsDataSet.TestCases' table. You can move, or remove it, as needed.
            //this.testCasesTableAdapter.Fill(this.testsDataSet.TestCases);

        }

        private void addTestSuite()
        {
            scmd.Connection = scn;
            translateResult = cf.translateStep(ExecutionCB.SelectedItem.ToString(), ImportanceCB.SelectedItem.ToString());
            scn.Open();
            scmd.CommandText = "INSERT INTO TestSuites (Name, Network, Version, UploadDate) VALUES(@TestSuiteName, @Network, @Version, getdate())";
            scmd.Parameters.AddWithValue("TestSuiteName", TestSuiteTB.Text);
            scmd.Parameters.AddWithValue("Network", NetworkCB.Text);
            scmd.Parameters.AddWithValue("Version", VersionCB.Text);

            scmd.ExecuteNonQuery();
            scn.Close();
            tcounter = 0;
        }
        private void addTestCase()
        {
            var keywords = new List<string>();
            foreach (string checkeditems in KeywordLB.CheckedItems)
            {
                scmd.Connection = scn;
                keywords.Add(checkeditems);
            }
            scn.Open();
            scmd.CommandText = "SELECT * FROM TestSuites WHERE Name = @TSN";
            scmd.Parameters.AddWithValue("TSN", TestSuiteTB.Text);
            var testsuiteID = scmd.ExecuteScalar();
            scmd.CommandText = "INSERT INTO TestCases (TCID, TSID; TestCaseID, TestObjective, Preconditions, Actions, Expec_res, Keyword, Exec_type, Importance, Stat) VALUES (@TCCounter, @TSID, @TCID, @obj, @Precon, @Action, @ExpRes, Keywords, @result1, @result2, '1')";
            scmd.Parameters.AddWithValue("TCCOunter", tcounter);
            scmd.Parameters.AddWithValue("TSID", TestSuiteTB.Text);
            scmd.Parameters.AddWithValue("TCID", TestCaseTB.Text);
            scmd.Parameters.AddWithValue("obj", ObjTB.Text);
            scmd.Parameters.AddWithValue("Precon", PreconTB.Text);
            scmd.Parameters.AddWithValue("Action", ActionTB.Text);
            scmd.Parameters.AddWithValue("ExpRes", ExpecReTB.Text);
            //scmd.Parameters.AddWithValue("Keywords", Keywords.Text);
            //scmd.Parameters.AddWithValue("result1", PreconTB.Text);
            //scmd.Parameters.AddWithValue("result2", PreconTB.Text);
            scmd.ExecuteNonQuery();
            scn.Close();
        }
    }
}
        