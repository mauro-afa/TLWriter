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
        static string connectionString = ConfigurationManager.ConnectionStrings["QSM.Properties.Settings.QSMTCConnectionString"].ConnectionString;
        int newTestSuite = 0;
        string[] translateResult = new string[20];
        string[] selectionString = new string[9];
        string testsuiteID;
        int tcounter = 1;
        CommonFunctions cf = new CommonFunctions();
        SqlConnection scn = new SqlConnection(connectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand scmd = new SqlCommand();
        SqlDataReader sdr;
        DataTable data = new DataTable();
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
            if(newTestSuite==1)
            {
                addTestCase();
            }
            else
            {
                addTestSuite();
                addTestCase();
            }

        }

        private void TestSuiteCreation_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getClickedTC();
            UpdateTCButton.Visible = true;
            RemoveTCButton.Visible = true;
            CancelSelect.Visible = true;
        }

        private void CancelSelect_Click(object sender, EventArgs e)
        {
            updateClearFields();
            UpdateTCButton.Visible = false;
            CancelSelect.Visible = false;
            RemoveTCButton.Visible = false;
        }

        private void UpdateTCButton_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);

            if (answer == DialogResult.Yes)
            {
                UpdateTestCase();
            }
            else
            {

            }
        }

        private void RemoveTCButton_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);

            if (answer == DialogResult.Yes)
            {
                RemoveTestCase();
            }
            else
            {

            }
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            Hide();
            this.parent.Show();
        }

        private void UpdateTestCase()
        {
            string keywords = "";
            translateResult = cf.translateStep(ExecutionCB.SelectedItem.ToString(), ImportanceCB.SelectedItem.ToString());
            data.Clear();
            foreach (string checkeditems in KeywordLB.CheckedItems)
            {
                scmd.Connection = scn;
                keywords = keywords + checkeditems + ";";
            }
            scn.Open();
            scmd.CommandText = "UPDATE TestCases SET TestCaseID = @TestCaseID, TestObjective = @obj, Preconditions = @Precon, Actions = @Action, Expec_res = @ExpRes, Keyword = @Keywords, Exec_type = @Result1, Importance = @Result2 WHERE TCID = @TCID AND TSID = @TSID";
            scmd.Parameters.AddWithValue("@TestCaseID", TestCaseTB.Text);
            scmd.Parameters.AddWithValue("@obj", ObjTB.Text);
            scmd.Parameters.AddWithValue("@Precon", PreconTB.Text);
            scmd.Parameters.AddWithValue("@Action", ActionTB.Text);
            scmd.Parameters.AddWithValue("@ExpRes", ExpecReTB.Text);
            scmd.Parameters.AddWithValue("@Keywords", keywords);
            scmd.Parameters.AddWithValue("@result1", translateResult[0]);
            scmd.Parameters.AddWithValue("@result2", translateResult[1]);
            scmd.Parameters.AddWithValue("@TCID", selectionString[0]);
            scmd.Parameters.AddWithValue("@TSID", testsuiteID);

            scmd.ExecuteNonQuery();
            scmd.Parameters.Clear();
            scn.Close();
            adapter.SelectCommand = new SqlCommand("SELECT TCID, TestCaseID, TestObjective, Preconditions, Actions, Expec_res, Keyword, Exec_type, Importance FROM TestCases WHERE TSID = @TSID", scn);
            adapter.SelectCommand.Parameters.AddWithValue("@TSID", testsuiteID);
            adapter.Fill(data);
            TestCaseGrid.DataSource = data;
            adapter.SelectCommand.Parameters.Clear();
            updateClearFields();
            UpdateTCButton.Visible = false;
            CancelSelect.Visible = false;
            RemoveTCButton.Visible = false;
        }
        private void RemoveTestCase()
        {
            data.Clear();
            scn.Open();
            scmd.Connection = scn;
            scmd.CommandText = "DELETE FROM TestCases WHERE TCID = @TCID AND TSID = @TSID";
            scmd.Parameters.AddWithValue("@TCID", selectionString[0]);
            scmd.Parameters.AddWithValue("@TSID", testsuiteID);
            scmd.ExecuteNonQuery();
            scmd.CommandText = "exec FixTCIDNumber 1, @TSID";
            scmd.ExecuteNonQuery();
            scmd.Parameters.Clear();
            scn.Close();

            adapter.SelectCommand = new SqlCommand("SELECT TCID, TestCaseID, TestObjective, Preconditions, Actions, Expec_res, Keyword, Exec_type, Importance FROM TestCases WHERE TSID = @TSID", scn);
            adapter.SelectCommand.Parameters.AddWithValue("@TSID", testsuiteID);
            adapter.Fill(data);
            TestCaseGrid.DataSource = data;
            adapter.SelectCommand.Parameters.Clear();

            tcounter = tcounter - 1;
            updateClearFields();
            UpdateTCButton.Visible = false;
            CancelSelect.Visible = false;
            RemoveTCButton.Visible = false;
        }
        private void getClickedTC()
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            var KeyIndex = new List<int>();

            foreach (int CheckedItems in KeywordLB.CheckedIndices)
            {
                KeywordLB.SetItemCheckState(CheckedItems, CheckState.Unchecked);

            }
            UpdateTCButton.Visible = true;
            CancelSelect.Visible = true;
            RemoveTCButton.Visible = true;

            dgvr = TestCaseGrid.CurrentRow;
            selectionString[0] = dgvr.Cells[0].Value.ToString();
            selectionString[1] = dgvr.Cells[1].Value.ToString();
            selectionString[2] = dgvr.Cells[2].Value.ToString();
            selectionString[3] = dgvr.Cells[3].Value.ToString();
            selectionString[4] = dgvr.Cells[4].Value.ToString();
            selectionString[5] = dgvr.Cells[5].Value.ToString();
            selectionString[6] = dgvr.Cells[6].Value.ToString();
            selectionString[7] = dgvr.Cells[7].Value.ToString();
            selectionString[8] = dgvr.Cells[8].Value.ToString();

            translateResult = cf.translateStep(selectionString[7], selectionString[8]);

            TestCaseTB.Text = selectionString[1];
            ObjTB.Text = selectionString[2];
            PreconTB.Text = selectionString[3];
            ActionTB.Text = selectionString[4];
            ExpecReTB.Text = selectionString[5];
            ExecutionCB.Text = translateResult[0];
            ImportanceCB.Text = translateResult[1];

            foreach(string word in selectionString[6].Split(';'))
            {
                foreach (object key in KeywordLB.Items)
                {
                    if(word == key.ToString())
                    {
                        KeyIndex.Add(KeywordLB.Items.IndexOf(key));
                        continue;
                    }
                }
            }
            foreach(int keyI in KeyIndex)
            {
                KeywordLB.SetItemCheckState(keyI, CheckState.Checked);
            }
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
            tcounter = 1;
            newTestSuite = 1;
            TestSuiteTB.Enabled = false;
            JiraLinkTB.Enabled = false;
            BrandCB.Enabled = false;
            VersionCB.Enabled = false;
            ChangeTSButton.Visible = true;
        }
        private void addTestCase()
        {
            data.Clear();
            translateResult = cf.translateStep(ExecutionCB.SelectedItem.ToString(), ImportanceCB.SelectedItem.ToString());
            string keywords = "";
            foreach (string checkeditems in KeywordLB.CheckedItems)
            {
                scmd.Connection = scn;
                keywords = keywords + checkeditems + ";";
            }
            scn.Open();
            scmd.CommandText = "SELECT * FROM TestSuites WHERE Name = @TSN";
            scmd.Parameters.AddWithValue("TSN", TestSuiteTB.Text);
            testsuiteID = scmd.ExecuteScalar().ToString();
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
            TestCaseGrid.DataSource = data;
            adapter.SelectCommand.Parameters.Clear();
            updateClearFields();
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

            foreach (int CheckedItems in KeywordLB.CheckedIndices)
            {
                KeywordLB.SetItemCheckState(CheckedItems, CheckState.Unchecked);
            }

        }
    }
}
        