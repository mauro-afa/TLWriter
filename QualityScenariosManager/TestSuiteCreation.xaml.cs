using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QualityScenariosManager
{
	/// <summary>
	/// Interaction logic for TestSuiteCreation.xaml
	/// </summary>
	public partial class TestSuiteCreation : UserControl
	{
		private string[] KeywordList =
		{
			"1GENAC",
			"2 Wire Over IP",
			"7-ELEVEN",
			"7-ELEVEN-Conoco",
			"7ELEVEN-EXXON",
			"ADD2REGRESSION",
			"APPLAUSE",
			"BP",
			"CHEVRON",
			"CHEVRON CA",
			"CITGO",
			"CONCORD",
			"CONTROL CENTER",
			"CORE",
			"DASHBOARD",
			"DEFECT",
			"Dual Tank Monitor",
			"EMV",
			"EXCEPTION",
			"EXXON",
			"FDC",
			"FUNCTIONAL",
			"HPSC",
			"HPSD",
			"HPSD-Generic_brand",
			"Incomm",
			"IOL",
			"Kris Sprint 13 Test Cases",
			"MARATHON",
			"NBS",
			"P66",
			"PADSS",
			"PADSS-Lite",
			"REGRESSION",
			"SANITY CHECK",
			"SHELL",
			"SITE SERVER",
			"SMOKE TEST",
			"WORLDPAY"
		};
		TestSuite nTestSuite;
		List<TestCase> nTestCaseList = new List<TestCase>();
		private int counter=0;
		public TestSuiteCreation()
		{
			InitializeComponent();
			foreach(string key in KeywordList)
			{
				KeywordLB.Items.Add(new Keyword() { KeywordName = key });
			}
		}

		public class Keyword
		{
			public bool IsChecked { get; set; }
			public string KeywordName { get; set; }
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
					Execution = ((ComboBoxItem)TCExecCB.SelectedItem).Content.ToString(),
					Importance = ((ComboBoxItem)TCPriorityCB.SelectedItem).Content.ToString(),
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
					nTestSuite = new TestSuite()
					{
						TestSuiteID = 1,
						TestSuiteName = TSNameTB.Text,
						JiraLink = TSJiraTB.Text,
						Brand = BrandCB.SelectedItem.ToString(),
						Version = VersionCB.SelectedItem.ToString()
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
				else
				{
					MessageBox.Show("Please set a name and a jira link for the test suite");
				}
			}
			else
			{
				SaveTSInfo.Content = "Save TS Info";

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

		private void TestCasesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			EditTC.Visibility = System.Windows.Visibility.Visible;
			RemoveTC.Visibility = System.Windows.Visibility.Visible;
		}

		private void EditTC_Click(object sender, RoutedEventArgs e)
		{
			CancelTC.Visibility = System.Windows.Visibility.Visible;
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
				HideTCButtons();
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
				Execution = ((ComboBoxItem)TCExecCB.SelectedItem).Content.ToString(),
				Importance = ((ComboBoxItem)TCPriorityCB.SelectedItem).Content.ToString(),
				Keywords = new List<string>(selectedKeywords)
			};
			nTestCaseList[oTC.TestCaseID - 1] = nTestCase;
			ClearControllers();
			TestCasesDG.Items.Refresh();
			//TestCasesDG.ItemsSource = nTestCaseList;
		}

		private void HideTCButtons()
		{
			EditTC.Visibility = System.Windows.Visibility.Hidden;
			RemoveTC.Visibility = System.Windows.Visibility.Hidden;
			CancelTC.Visibility = System.Windows.Visibility.Hidden;
		}

		private void CancelTC_Click(object sender, RoutedEventArgs e)
		{
			ClearControllers();
			HideTCButtons();
			EditTC.Content = "Edit";
		}
	}
}
