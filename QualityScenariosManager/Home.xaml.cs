using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
