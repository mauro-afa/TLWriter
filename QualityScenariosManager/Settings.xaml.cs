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
        List<Keyword> Keywords = new List<Keyword>();
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

        private void KeywordLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void VersionLB_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CancelKeyword_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNetwork_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VersionLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddKeyword_Click(object sender, RoutedEventArgs e)
        {
            Keyword newKey = new Keyword() { KeywordName = KeywordTB.Text };
            bool bSuccess = st.SaveKeword(newKey);
            if (bSuccess)
            {
                Keywords.Add(newKey);
                KeywordLB.Items.Refresh();
            }
            else
            {
            }
        }
    }
}
