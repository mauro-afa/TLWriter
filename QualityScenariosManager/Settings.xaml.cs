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

		public class Keyword
		{
			public string KeywordName { get; set; }
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateKeywords();
            PopulateVersions();
        }

        public void PopulateKeywords()
        {
            List<string> Keywords = new List<string>(st.GetAllKeywords());
            KeywordLB.ItemsSource = Keywords;
        }

        public void PopulateVersions()
        {
            List<string> Versions = new List<string>(st.GetAllVersions());
            VersionLB.ItemsSource = Versions;
        }
    }
}
