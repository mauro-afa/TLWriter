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
		List<Versions> Versions = new List<Versions>();
		List<Network> Networks = new List<Network>();

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
			Keywords = new List<Keyword>(st.GetAllKeywords());
            KeywordLB.ItemsSource = Keywords;
        }

        public void PopulateVersions()
        {
            Versions = new List<Versions>(st.GetAllVersions());
            VersionLB.ItemsSource = Versions;
        }

		public void PopulateNetworks()
		{
			Networks = new List<Network>(st.GetAllNetworks());
			NetworkLB.ItemsSource = Networks;
		}

        private void KeywordLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			Keyword currentKeyword = KeywordLB.SelectedItem as Keyword;
			if (currentKeyword is null)
			{

			}
			else
				KeywordTB.Text = currentKeyword.KeywordName;
		}

		private void VersionLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Versions currentVersion = VersionLB.SelectedItem as Versions;
			if (currentVersion is null)
			{

			}
			else
				VersionTB.Text = currentVersion.VersionName;
		}

        private void AddKeyword_Click(object sender, RoutedEventArgs e)
        {
            Keyword newKey = new Keyword() { KeywordName = KeywordTB.Text };
            bool bSuccess = st.SaveKeyword(newKey);
            if (bSuccess)
            {
                Keywords.Add(newKey);
                KeywordLB.Items.Refresh();
            }
            else
            {
            }
        }

		private void UpdateKeyword_Click(object sender, RoutedEventArgs e)
		{
			Keyword currentKeyword = KeywordLB.SelectedItem as Keyword;
			bool bSuccess = false;
			if (currentKeyword is null)
			{
				MessageBox.Show("Please select a keyword to be deleted.");
			}
			else
			{
				bSuccess = st.UpdateKeyword(currentKeyword, KeywordTB.Text);
				if (bSuccess)
				{
					MessageBox.Show("The keyword: " + currentKeyword.KeywordName + " has been updated to: " + KeywordTB.Text);
					Keywords.Where(name => name.KeywordName == currentKeyword.KeywordName).First().KeywordName = KeywordTB.Text;
					KeywordLB.Items.Refresh();
					KeywordTB.Clear();
				}
			}
		}

		private void RemoveKeyword_Click(object sender, RoutedEventArgs e)
		{
			Keyword currentKeyword = KeywordLB.SelectedItem as Keyword;
			bool bSuccess = false;
			if (currentKeyword is null)
			{
				MessageBox.Show("Please select a keyword to be deleted.");
			}
			else
			{
				bSuccess = st.DeleteKeyword(currentKeyword);
				if (bSuccess)
				{
					MessageBox.Show("The keyword: " + currentKeyword.KeywordName + " has been deleted from the keyword list");
					Keywords.Remove(currentKeyword);
					KeywordLB.Items.Refresh();
					KeywordTB.Clear();
				}
			}
		}

		private void AddVersion_Click(object sender, RoutedEventArgs e)
		{
			Versions newVersion = new Versions(VersionTB.Text);
			bool bSuccess = st.SaveVersion(newVersion);
			if (bSuccess)
			{
				Versions.Add(newVersion);
				VersionLB.Items.Refresh();
				VersionTB.Clear();
			}
			else
			{
			}
		}

		private void RemoveVersion_Click(object sender, RoutedEventArgs e)
		{
			Versions currentVersion = VersionLB.SelectedItem as Versions;
			bool bSuccess = false;
			if(currentVersion is null)
			{
				MessageBox.Show("Please select a version to be deleted.");
			}
			else
			{
				bSuccess = st.DeleteVersion(currentVersion);
				if(bSuccess)
				{
					MessageBox.Show("The version: " +currentVersion.VersionName + " has been deleted from the version list");
					Versions.Remove(currentVersion);
					VersionLB.Items.Refresh();
					VersionTB.Clear();
				}
			}
		}

		private void UpdateVersion_Click(object sender, RoutedEventArgs e)
		{
			Versions currentVersion = VersionLB.SelectedItem as Versions;
			bool bSuccess = false;
			if (currentVersion is null)
			{
				MessageBox.Show("Please select a version to be deleted.");
			}
			else
			{
				bSuccess = st.UpdateVersion(currentVersion, VersionTB.Text);
				if (bSuccess)
				{
					MessageBox.Show("The version: " + currentVersion.VersionName + " has been updated to: "+VersionTB.Text);
					Versions.Where(name => name.VersionName == currentVersion.VersionName).First().VersionName = VersionTB.Text;
					VersionLB.Items.Refresh();
					VersionTB.Clear();
				}
			}
		}

		private void CancelVersion_Click(object sender, RoutedEventArgs e)
		{
			VersionTB.Clear();
		}

		private void AddNetwork_Click(object sender, RoutedEventArgs e)
		{
			Network newNetwork = new Network(NetworkTB.Text);
			bool bSuccess = st.SaveNetwork(newNetwork);
			if (bSuccess)
			{
				Networks.Add(newNetwork);
				NetworkLB.Items.Refresh();
				NetworkTB.Clear();
			}
			else
			{
			}
		}

		private void UpdateNetwork_Click(object sender, RoutedEventArgs e)
		{
			Network currentNetwork = NetworkLB.SelectedItem as Network;
			bool bSuccess = false;
			if (currentNetwork is null)
			{
				MessageBox.Show("Please select a network to be deleted.");
			}
			else
			{
				bSuccess = st.UpdateNetwork(currentNetwork, NetworkTB.Text);
				if (bSuccess)
				{
					MessageBox.Show("The network: " + currentNetwork.NetworkName + " has been updated to: " + NetworkTB.Text);
					Networks.Where(name => name.NetworkName == currentNetwork.NetworkName).First().NetworkName = NetworkTB.Text;
					NetworkLB.Items.Refresh();
					NetworkTB.Clear();
				}
			}
		}

		private void RemoveNetwork_Click(object sender, RoutedEventArgs e)
		{
			Network currentNetwork = NetworkLB.SelectedItem as Network;
			bool bSuccess = false;
			if (currentNetwork is null)
			{
				MessageBox.Show("Please select a network to be deleted.");
			}
			else
			{
				bSuccess = st.DeleteNetwork(currentNetwork);
				if (bSuccess)
				{
					MessageBox.Show("The network: " + currentNetwork.NetworkName + " has been deleted from the network list");
					Networks.Remove(currentNetwork);
					NetworkLB.Items.Refresh();
					NetworkTB.Clear();
				}
			}
		}

		private void NetworkLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Network currentNetwork = NetworkLB.SelectedItem as Network;
			if (currentNetwork is null)
			{

			}
			else
				NetworkTB.Text = currentNetwork.NetworkName;
		}
	}
}
