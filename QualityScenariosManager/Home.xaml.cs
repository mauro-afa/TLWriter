using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace QualityScenariosManager
{
	/// <summary>
	/// Interaction logic for Home.xaml
	/// </summary>
	public partial class Home : UserControl
	{
		public Home()
		{
			InitializeComponent();
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			LoadTestSuites();
		}

		public void LoadTestSuites()
		{
			DButils tsdb = DButils.Instance;
			List<TestSuite> TSinfo = tsdb.GetAllTestSuites();
			TestSuiteDG.ItemsSource = TSinfo;
		}

		private void TestSuiteDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
