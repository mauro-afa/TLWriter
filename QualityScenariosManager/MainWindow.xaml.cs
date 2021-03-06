﻿using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;

namespace QualityScenariosManager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			ContentPanel.Children.Add(new Home());
			TitleLabel.Content = "Home";
		}

		private void Header_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				this.DragMove();
		}

		private void CreateTSButton_Click(object sender, RoutedEventArgs e)
		{
			if (ContentPanel.Children.Count > 0)
			{
				ContentPanel.Children.Clear();
			}
			ContentPanel.Children.Add(new TestSuiteCreation());
			TitleLabel.Content = "Test suite creation";
		}

		private void HomeButton_Click(object sender, RoutedEventArgs e)
		{
			if (ContentPanel.Children.Count > 0)
			{
				ContentPanel.Children.Clear();
			}
			ContentPanel.Children.Add(new Home());
			TitleLabel.Content = "Home";
		}

		private void EditTSButton_Click(object sender, RoutedEventArgs e)
		{
			Home _home = null;
			bool bSuccess = false;
			_home = GetHome(out bSuccess);

			if (bSuccess)
			{
				TestSuite sTestSuite = (TestSuite)_home.TestSuiteDG.SelectedItem;
				if (sTestSuite is null)
				{
					MessageBox.Show("Please select a test suite");
				}
				else
				{
					if (ContentPanel.Children.Count > 0)
					{
						ContentPanel.Children.Clear();
					}
					ContentPanel.Children.Add(new TestSuiteCreation(sTestSuite));
					TitleLabel.Content = "Test suite creation";
				}
			}
			else
				MessageBox.Show("You need to be in home screen to edit a test suite");
		}

		private void DeleteTSButton_Click(object sender, RoutedEventArgs e)
		{
			Home _home = null;
			bool bSuccess = false;
			_home = GetHome(out bSuccess);

			if (bSuccess)
			{
				TestSuite sTestSuite = (TestSuite)_home.TestSuiteDG.SelectedItem;
				if (sTestSuite is null)
				{
					MessageBox.Show("Please select a test suite");
				}
				else
				{
					DButils tsdb = DButils.Instance;
					tsdb.DeleteTestSuite(sTestSuite);
					_home.LoadTestSuites();
				}
			}
			else
				MessageBox.Show("You need to be in home screen to edit a test suite");
		}

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (ContentPanel.Children.Count > 0)
                {
                    ContentPanel.Children.Clear();
                }
                ContentPanel.Children.Add(new Settings());
                TitleLabel.Content = "Settings";
            }
        }

        private void ExportTSButton_Click(object sender, RoutedEventArgs e)
		{
			Home _home = null;
			bool bSuccess = false;
			_home = GetHome(out bSuccess);

			if (bSuccess)
			{
				TestSuite sTestSuite = (TestSuite)_home.TestSuiteDG.SelectedItem;
				if (sTestSuite is null)
				{
					MessageBox.Show("Please select a test suite");
				}
				else
				{
					SaveFileDialog sfd = new SaveFileDialog();
					sfd.FileName = sTestSuite.TestSuiteName;
					sfd.DefaultExt = ".xml";
					if (sfd.ShowDialog() == true)
					{
						XmlDocument doc = new XmlDocument();
						doc.LoadXml(sTestSuite.TestSuiteDefinition);
						doc.Save(sfd.FileName);
                        doc.LoadXml(sTestSuite.RegressionDefinition);
                        doc.Save(sfd.FileName.Replace(".xml"," - Regression.xml"));
                        doc.LoadXml(sTestSuite.SmokeDefinition);
                        doc.Save(sfd.FileName.Replace(".xml", " - Smoke.xml"));
                    }
				}
			}
			else
				MessageBox.Show("You need to be in home screen to edit a test suite");
		}

		private void ImportTSButton_Click(object sender, RoutedEventArgs e)
		{
			Home _home = null;
			bool bSuccess = false;
			_home = GetHome(out bSuccess);

			if (bSuccess)
			{
				OpenFileDialog ofd = new OpenFileDialog();
				if (ofd.ShowDialog() == true)
				{
					XmlDocument doc = new XmlDocument();
					using (var myStream = ofd.OpenFile())
					{
						try
						{
							doc.Load(myStream);
							XMLCreator xmlImporter = new XMLCreator();
							TestSuite nTestSuite = xmlImporter.GetTestSuiteInformation(doc);

							DButils tsdb = DButils.Instance;

							nTestSuite.TestSuiteID = tsdb.getLastID("TestSuite") + 1;
							tsdb.SaveTestSuite(nTestSuite, false);

							_home.LoadTestSuites();
						}
						catch
						{
						}
					}
				}
			}
			else
				MessageBox.Show("You need to be in home screen to import a test suite");
		}
		public Home GetHome(out bool bSuccess)
		{
			bSuccess = false;
			Home _home = null;
			foreach (UserControl uc in ContentPanel.Children)
			{
				if (uc is Home)
				{
					_home = (Home)uc;
					bSuccess = true;
					break;
				}
			}
			return _home;
		}

		private void btClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void btMinimize_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}
	}
}
