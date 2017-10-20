using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace QualityScenariosManager
{
	/// <summary>
	/// Interaction logic for TestSuiteCreation.xaml
	/// </summary>
	public partial class TestSuiteCreation : UserControl
	{
		TestSuite nTestSuite;
		List<TestCase> nTestCaseList = new List<TestCase>();
		private int counter=0;
		bool bUpdate = false;
		public TestSuiteCreation()
		{
			InitializeComponent();
            LoadEssentials();
        }

		public TestSuiteCreation(TestSuite oTestSuite)
		{
			InitializeComponent();
            LoadEssentials();
            nTestSuite = oTestSuite;
			LoadTestCases();
		}

        public void LoadEssentials()
        {
            DButils tsdb = DButils.Instance;
            List<Keyword> Keywords = new List<Keyword>(tsdb.GetAllKeywords());
            KeywordLB.ItemsSource = Keywords;

            List<Versions> Versions = new List<Versions>(tsdb.GetAllVersions());
            VersionCB.ItemsSource = Versions;

            List<Network> Networks = new List<Network>(tsdb.GetAllNetworks());
            BrandCB.ItemsSource = Networks;
        }

		private void AddTC_Click(object sender, RoutedEventArgs e)
		{
			TestCasesDG.ItemsSource = null;
			List<string> selectedKeywords = new List<string>();
			if(TCID_TB.Text!="")
			{
				foreach(Keyword oKeyword in KeywordLB.Items)
				{
					if(oKeyword.IsChecked)
						selectedKeywords.Add(oKeyword.KeywordName);
				}
				TestCase nTestCase = new TestCase()
				{
					TestCaseID = ++counter,
					TestCaseName = TCID_TB.Text,
					Objective = TCObj.Text,
					Preconditions = TCPrecon.Text,
					Actions = TCAction.Text,
					ExpectedResult = TCExpecRes.Text,
					Execution = Int32.Parse(((ComboBoxItem)TCExecCB.SelectedItem).Tag.ToString()),
					Importance = Int32.Parse(((ComboBoxItem)TCPriorityCB.SelectedItem).Tag.ToString()),
					Keywords = new List<string>(selectedKeywords)
				};
				nTestCaseList.Add(nTestCase);
			}
			TestCasesDG.ItemsSource = nTestCaseList;
			ClearControllers();
		}

		private void SaveTSInfo_Click(object sender, RoutedEventArgs e)
		{
			
			if(SaveTSInfo.Content.ToString()== "Save TS Info")
			{
				if (TSNameTB.Text != "" && TSJiraTB.Text != "")
				{
					DButils tsdb = DButils.Instance;
					int ID = tsdb.getLastID("TestSuite");
					try
					{
						//test comment
						nTestSuite = new TestSuite()
						{
							TestSuiteID = ++ID,
							TestSuiteName = TSNameTB.Text,
							JiraLink = TSJiraTB.Text,
							Brand = ((Network)BrandCB.SelectedItem).NetworkTag.ToString(),
							Version = ((Versions)VersionCB.SelectedItem).VersionTag.ToString()
						};
						TSNameTB.IsEnabled = false;
						TSJiraTB.IsEnabled = false;
						BrandCB.IsEnabled = false;
						VersionCB.IsEnabled = false;
						SaveTSInfo.Content = "Change TS info";

						TestCasesDG.IsEnabled = true;
						TCID_TB.IsEnabled = true;
						KeywordLB.IsEnabled = true;
						TCObj.IsEnabled = true;
						TCPrecon.IsEnabled = true;
						TCAction.IsEnabled = true;
						TCExpecRes.IsEnabled = true;
						TCExecCB.IsEnabled = true;
						TCPriorityCB.IsEnabled = true;
						AddTC.IsEnabled = true;
						EditTC.IsEnabled = true;
						RemoveTC.IsEnabled = true;
						CancelTC.IsEnabled = true;
						SaveTS.IsEnabled = true;
					}
					catch(NullReferenceException nre)
					{
						MessageBox.Show(nre.Message);
					}
				}
				else
				{
					MessageBox.Show("Please set a name and a jira link for the test suite");
				}
			}
			else
			{
				SaveTSInfo.Content = "Save TS Info";
				TSNameTB.IsEnabled = true;
				TSJiraTB.IsEnabled = true;
				BrandCB.IsEnabled = true;
				VersionCB.IsEnabled = true;

				TestCasesDG.IsEnabled = false;
				TCID_TB.IsEnabled = false;
				KeywordLB.IsEnabled = false;
				TCObj.IsEnabled = false;
				TCPrecon.IsEnabled = false;
				TCAction.IsEnabled = false;
				TCExpecRes.IsEnabled = false;
				TCExecCB.IsEnabled = false;
				TCPriorityCB.IsEnabled = false;
				AddTC.IsEnabled = false;
				EditTC.IsEnabled = false;
				RemoveTC.IsEnabled = false;
				CancelTC.IsEnabled = false;
				SaveTS.IsEnabled = false;
			}
		}

		public void ClearControllers()
		{
			TCID_TB.Clear();
			TCObj.Clear();
			TCPrecon.Clear();
			TCAction.Clear();
			TCExpecRes.Clear();
			foreach (Keyword oKeyword in KeywordLB.Items)
			{
				if (oKeyword.IsChecked)
					oKeyword.IsChecked = false;
			}
			KeywordLB.Items.Refresh();
		}

		private void EditTC_Click(object sender, RoutedEventArgs e)
		{
			TestCase currentTC = (TestCase)TestCasesDG.SelectedItem;
			if (EditTC.Content.ToString()=="Edit")
			{
				PopulateBoxes(currentTC);
				EditTC.Content = "Update";
			}
			else
			{
				UpdateTestCase(currentTC);
				EditTC.Content = "Edit";
			}
		}

		private void PopulateBoxes(TestCase oTC)
		{
			TCID_TB.Text = oTC.TestCaseName;
			TCExecCB.SelectedItem = oTC.Execution;
			TCPriorityCB.SelectedItem = oTC.Importance;
			TCObj.Text = oTC.Objective;
			TCPrecon.Text = oTC.Preconditions;
			TCAction.Text = oTC.Actions;
			TCExpecRes.Text = oTC.ExpectedResult;
			TCExecCB.SelectedIndex = oTC.Execution-1;
			TCPriorityCB.SelectedIndex = oTC.Importance - 1;

			foreach(Keyword oKeyword in KeywordLB.Items)
			{
				foreach(String _keyword in oTC.Keywords)
				{
					if (oKeyword.KeywordName == _keyword)
						oKeyword.IsChecked = true;
				}
			}
			KeywordLB.Items.Refresh();
		}

		private void RemoveTC_Click(object sender, RoutedEventArgs e)
		{
			int newCounter = 0;
			TestCase currentTC = (TestCase)TestCasesDG.SelectedItem;
			nTestCaseList.Remove(currentTC);
			foreach(TestCase tc in nTestCaseList)
			{
				tc.TestCaseID = ++newCounter; 
			}
			ClearControllers();
			TestCasesDG.Items.Refresh();

		}

		private void UpdateTestCase(TestCase oTC)
		{
			//TestCasesDG.ItemsSource = null;

			List<string> selectedKeywords = new List<string>();
			foreach (Keyword oKeyword in KeywordLB.Items)
			{
				if (oKeyword.IsChecked)
					selectedKeywords.Add(oKeyword.KeywordName);
			}
			TestCase nTestCase = new TestCase()
			{
				TestCaseID = oTC.TestCaseID,
				TestCaseName = TCID_TB.Text,
				Objective = TCObj.Text,
				Preconditions = TCPrecon.Text,
				Actions = TCAction.Text,
				ExpectedResult = TCExpecRes.Text,
				Execution = Int32.Parse(((ComboBoxItem)TCExecCB.SelectedItem).Tag.ToString()),
				Importance = Int32.Parse(((ComboBoxItem)TCPriorityCB.SelectedItem).Tag.ToString()),
				Keywords = new List<string>(selectedKeywords)
			};
			nTestCaseList[oTC.TestCaseID - 1] = nTestCase;
			ClearControllers();
			TestCasesDG.Items.Refresh();
		}

		private void CancelTC_Click(object sender, RoutedEventArgs e)
		{
			ClearControllers();
			EditTC.Content = "Edit";
		}

		private void SaveTS_Click(object sender, RoutedEventArgs e)
		{
			if(TestCasesDG.ItemsSource is null)
			{
				MessageBox.Show("You must add at least one test case before you save the test suite");
			}
			else
			{
				bool bSuccess = true;
				List<XmlDocument> xmls = new List<XmlDocument>();
				DButils tsdb = DButils.Instance;
				nTestSuite.TestCases = nTestCaseList;
				XMLCreator TestSuite = new XMLCreator();
				xmls = TestSuite.CreateXML(nTestSuite);
				nTestSuite.TestSuiteDefinition = xmls[0].InnerXml;
				nTestSuite.RegressionDefinition = xmls[1].InnerXml;
				nTestSuite.SmokeDefinition = xmls[2].InnerXml;
				bSuccess = tsdb.SaveTestSuite(nTestSuite, bUpdate);
				bUpdate = false;
				if (bSuccess)
				{
					TestCasesDG.ItemsSource = null;
					TestCasesDG.Items.Refresh();
					TSNameTB.Clear();
					TSJiraTB.Clear();
					VersionCB.SelectedIndex = 0;
					BrandCB.SelectedIndex = 0;
				}
			}
		}

		private void LoadTestCases()
		{
			DButils tsdb = DButils.Instance;
			nTestCaseList = new List<TestCase>(tsdb.GetAllTestCases(nTestSuite.TestSuiteID));
			counter = nTestCaseList.Count();
			bUpdate = true;
			ClearControllers();
			TestCasesDG.ItemsSource = nTestCaseList;
			TSNameTB.Text = nTestSuite.TestSuiteName;
			TSJiraTB.Text = nTestSuite.JiraLink;
			BrandCB.SelectedItem = nTestSuite.Brand;
			VersionCB.SelectedItem = nTestSuite.Version;

			TSNameTB.IsEnabled = false;
			TSJiraTB.IsEnabled = false;
			BrandCB.IsEnabled = false;
			VersionCB.IsEnabled = false;
			SaveTSInfo.Content = "Change TS info";

			TestCasesDG.IsEnabled = true;
			TCID_TB.IsEnabled = true;
			KeywordLB.IsEnabled = true;
			TCObj.IsEnabled = true;
			TCPrecon.IsEnabled = true;
			TCAction.IsEnabled = true;
			TCExpecRes.IsEnabled = true;
			TCExecCB.IsEnabled = true;
			TCPriorityCB.IsEnabled = true;
			AddTC.IsEnabled = true;
			EditTC.IsEnabled = true;
			RemoveTC.IsEnabled = true;
			CancelTC.IsEnabled = true;
			SaveTS.IsEnabled = true;
		}
	}
}
