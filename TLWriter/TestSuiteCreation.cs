using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace TLWriter
{
    public partial class TestSuiteCreation : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["TLWriter.Properties.Settings.TestsConnectionString"].ConnectionString;
        int newTestSuite = 0;
        string[] translateResult = new string[20];
        int tcounter = 0;
        CommonFunctions cf = new CommonFunctions();
        SqlConnection scn = new SqlConnection(connectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand scmd = new SqlCommand();
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

        private void addTestSuite()
        {
            scn.Open();
            scmd.Connection = scn;
            scmd.CommandText = "INSERT INTO TestSuites (Name, Brand, Version, UploadDate) VALUES(@TestSuiteName, @Brand, @Version, getdate())";
            scmd.Parameters.AddWithValue("@TestSuiteName", TestSuiteTB.Text);
            scmd.Parameters.AddWithValue("@Brand", BrandCB.Text);
            scmd.Parameters.AddWithValue("@Version", VersionCB.Text);

            scmd.ExecuteNonQuery();
            scmd.Parameters.Clear();
            scn.Close();
            tcounter = 0;
            TestSuiteTB.Enabled = false;
            JiraLinkTB.Enabled = false;
            BrandCB.Enabled = false;
            VersionCB.Enabled = false;
            ChangeTSButton.Visible = true;
        }
        private void addTestCase()
        {
            DataTable data = new DataTable();
            translateResult=cf.translateStep(ExecutionCB.SelectedItem.ToString(), ImportanceCB.SelectedItem.ToString());
            string keywords="";
            foreach (string checkeditems in KeywordLB.CheckedItems)
            {
                scmd.Connection = scn;
                keywords = keywords + checkeditems +"; ";
            }
            scn.Open();
            scmd.CommandText = "SELECT * FROM TestSuites WHERE Name = @TSN";
            scmd.Parameters.AddWithValue("TSN", TestSuiteTB.Text);
            var testsuiteID = scmd.ExecuteScalar();
            scmd.CommandText = "INSERT INTO TestCases (TCID, TSID, TestCaseID, TestObjective, Preconditions, Actions, Expec_res, Keyword, Exec_type, Importance, Stat) VALUES (@TCCounter, @TSID, @TCID, @obj, @Precon, @Action, @ExpRes, @Keywords, @result1, @result2, '1')";
            scmd.Parameters.AddWithValue("@TCCOunter", tcounter);
            scmd.Parameters.AddWithValue("@TSID", testsuiteID);
            scmd.Parameters.AddWithValue("@TCID", TestCaseTB.Text);
            scmd.Parameters.AddWithValue("@obj", ObjTB.Text);
            scmd.Parameters.AddWithValue("@Precon", PreconTB.Text);
            scmd.Parameters.AddWithValue("@Action", ActionTB.Text);
            scmd.Parameters.AddWithValue("@ExpRes", ExpecReTB.Text);
            scmd.Parameters.AddWithValue("@Keywords", keywords);
            scmd.Parameters.AddWithValue("@result1", translateResult[0]);
            scmd.Parameters.AddWithValue("@result2", translateResult[1]);
            scmd.ExecuteNonQuery();
            scmd.Parameters.Clear();
            scn.Close();
            tcounter = tcounter + 1;
            adapter.SelectCommand = new SqlCommand("SELECT TCID, TestCaseID, TestObjective, Preconditions, Actions, Expec_res, Keyword, Exec_type, Importance FROM TestCases WHERE TSID = @TSID", scn);
            adapter.SelectCommand.Parameters.AddWithValue("@TSID", testsuiteID);
            adapter.Fill(data);
            dataGridView1.DataSource = data;
            adapter.SelectCommand.Parameters.Clear();
        }
        private void updateClearFields()
        {
            ObjTB.Clear();
            PreconTB.Clear();
            ActionTB.Clear();
            ExpecReTB.Clear();
            TestCaseTB.Clear();
            ExecutionCB.Text = "";
            ImportanceCB.Text = "";

            foreach(int CheckedItems in KeywordLB.CheckedIndices)
            {
                KeywordLB.SetItemCheckState(CheckedItems, CheckState.Unchecked);
            }

        }

        private void TestSuiteCreation_Load(object sender, EventArgs e)
        {

        }
    }
}
        