using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

namespace TLWriter
{
    public partial class Form1 : Form
    {
        string[] selectionString = new string[9];
        CommonFunctions cf = new CommonFunctions();
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand scmd = new SqlCommand();
        DataTable data = new DataTable();
        SqlDataReader sdr;
        public Form1()
        {
            InitializeComponent();
            if(Debugger.IsAttached==false)
            {
                AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qSMTCDataSet1.TestSuites' table. You can move, or remove it, as needed.
            //            this.testSuitesTableAdapter.Fill(this.qSMTCDataSet1.TestSuites);

            ReloadData();

        }

        private void TestSuiteGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetTSInfo();
        }

        public void ReloadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QSM.Properties.Settings.QSMTCConnectionString"].ConnectionString;
            SqlConnection scn = new SqlConnection(connectionString);
            data.Clear();
            adapter.SelectCommand = new SqlCommand("SELECT Name, Brand, JiraLink, Version, CreationDate, UploadDate, UpdateDate, Id FROM TestSuites", scn);
            adapter.Fill(data);
            TestSuiteGrid.DataSource = data;
            adapter.SelectCommand.Parameters.Clear();
            TestSuiteGrid.Columns[7].Visible = false;
        }

        private void CreateTSButton_Click(object sender, EventArgs e)
        {
            TestSuiteCreation f = new TestSuiteCreation();
            f.Show(this);
            //Hide();
        }

        private void UploadTSButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Interacion with a web service missing");
        }

        private void OpenTSButton_Click(object sender, EventArgs e)
        {
            TestSuiteCreation f = new TestSuiteCreation(selectionString, true);
            f.Show(this);
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void DeleteTSButton_Click(object sender, EventArgs e)
        {
            DeleteTS();
        }

        private void GetTSInfo()
        {
            DataGridViewRow dgvr = new DataGridViewRow();

            dgvr = TestSuiteGrid.CurrentRow;
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    selectionString[i] = dgvr.Cells[i].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Test suite must be selected first");
                    break;
                }

            }
        }

        private void XMLButton_Click(object sender, EventArgs e)
        {
            XMLParse();
        }

        private void DeleteTS()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QSM.Properties.Settings.QSMTCConnectionString"].ConnectionString;
            SqlConnection scn = new SqlConnection(connectionString);
            DataGridViewRow dgvr = new DataGridViewRow();

            dgvr = TestSuiteGrid.CurrentRow;

            scn.Open();
            scmd.Connection = scn;
            scmd.CommandText = "DELETE FROM TestSuites WHERE Id = @Id";
            scmd.Parameters.AddWithValue("@Id", dgvr.Cells[7].Value.ToString());
            scmd.ExecuteNonQuery();
            scmd.CommandText = "DELETE FROM TestCases WHERE TSID = @Id";
            scmd.ExecuteNonQuery();
            scmd.Parameters.Clear();
            scn.Close();
            ReloadData();
        }
        private void XMLParse()
        {
            try
            {
                XmlDocument TSDoc = new XmlDocument();
                XmlDeclaration xmlDec = TSDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes");

                // Inserts declaration before root.
                XmlElement root = TSDoc.DocumentElement;
                TSDoc.InsertBefore(xmlDec, root);

                //Creates test suite element
                XmlElement TSElement = TSDoc.CreateElement("testsuite");
                TSElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                TSElement.SetAttribute("name", selectionString[0].Trim());
                TSDoc.AppendChild(TSElement);

                //Creates details for test suite element

                XmlElement TSdetailsElement = TSDoc.CreateElement("details");
                TSdetailsElement.InnerText = selectionString[2].Trim();
                TSElement.AppendChild(TSdetailsElement);

                //Creates test case element

                string connectionString = ConfigurationManager.ConnectionStrings["QSM.Properties.Settings.QSMTCConnectionString"].ConnectionString;
                SqlConnection scn = new SqlConnection(connectionString);
                scn.Open();
                scmd.Connection = scn;
                scmd.CommandText = "SELECT * FROM TestCases where TSID = @TSID";
                scmd.Parameters.AddWithValue("@TSID", selectionString[7].Trim());
                sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    //Adds test case name
                    XmlElement TestCaseID = TSDoc.CreateElement("testcase");
                    TestCaseID.SetAttribute("name", sdr[2].ToString());
                    TSElement.AppendChild(TestCaseID);

                    //Adds test case information
                    XmlElement TestCaseSummary = TSDoc.CreateElement("summary");
                    TestCaseSummary.InnerText = sdr[3].ToString();
                    TestCaseID.AppendChild(TestCaseSummary);

                    XmlElement TestCasePreCon = TSDoc.CreateElement("preconditions");
                    TestCasePreCon.InnerText = sdr[4].ToString();
                    TestCaseID.AppendChild(TestCasePreCon);

                    XmlElement TestCaseExecType = TSDoc.CreateElement("execution_type");
                    TestCaseExecType.InnerText = sdr[8].ToString();
                    TestCaseID.AppendChild(TestCaseExecType);

                    XmlElement TestCaseImportance = TSDoc.CreateElement("importance");
                    TestCaseImportance.InnerText = sdr[9].ToString();
                    TestCaseID.AppendChild(TestCaseImportance);

                    XmlElement TestCaseStatus = TSDoc.CreateElement("status");
                    TestCaseStatus.InnerText = sdr[10].ToString();
                    TestCaseID.AppendChild(TestCaseStatus);

                    XmlElement TestCaseKeywordList = TSDoc.CreateElement("keywords");
                    TestCaseID.AppendChild(TestCaseKeywordList);

                    string keywords = sdr[7].ToString();
                    foreach(string Key in keywords.Split(';'))
                    {
                        XmlElement TestCaseKeyword = TSDoc.CreateElement("keyword");
                        TestCaseKeyword.SetAttribute("name", Key);
                        TestCaseKeywordList.AppendChild(TestCaseKeyword);
                    }
                }
                scn.Close();
                scmd.Parameters.Clear();

                //Saves the document
                TSDoc.Save("C:\\temp\\test.xml");

            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Test suite must be selected first");
            }
        }

    }
}
