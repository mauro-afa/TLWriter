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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        DButils st = DButils.Instance;
        public Settings()
        {
            InitializeComponent();
        }

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateKeywords();
            PopulateVersions();
			PopulateNetworks();

		}

        public void PopulateKeywords()
        {
            List<Keyword> Keywords = new List<Keyword>(st.GetAllKeywords());
            KeywordLB.ItemsSource = Keywords;
        }

        public void PopulateVersions()
        {
            List<Versions> Versions = new List<Versions>(st.GetAllVersions());
            VersionLB.ItemsSource = Versions;
        }

		public void PopulateNetworks()
		{
			List<Network> Networks = new List<Network>(st.GetAllNetworks());
			NetworkLB.ItemsSource = Networks;
		}
    }
}
