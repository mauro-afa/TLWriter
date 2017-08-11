using Microsoft.Win32;
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

		private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Close();
		}

		private void Label_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
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
			bool bContinue = false;
			foreach (UserControl uc in ContentPanel.Children)
			{
				if(uc is Home)
				{
					_home = (Home)uc;
					bContinue = true;
					break;
				}
			}

			if (bContinue)
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
			bool bContinue = false;
			foreach (UserControl uc in ContentPanel.Children)
			{
				if (uc is Home)
				{
					_home = (Home)uc;
					bContinue = true;
					break;
				}
			}

			if (bContinue)
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
				}
			}
			else
				MessageBox.Show("You need to be in home screen to edit a test suite");
		}

		private void ExportTSButton_Click(object sender, RoutedEventArgs e)
		{
			Home _home = null;
			bool bContinue = false;
			foreach (UserControl uc in ContentPanel.Children)
			{
				if (uc is Home)
				{
					_home = (Home)uc;
					bContinue = true;
					break;
				}
			}

			if (bContinue)
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

					}
				}
			}
			else
				MessageBox.Show("You need to be in home screen to edit a test suite");
		}
	}
}
