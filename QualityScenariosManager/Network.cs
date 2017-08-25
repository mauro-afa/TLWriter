using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QualityScenariosManager
{
	public class Network
	{
		public string NetworkName { get; set; }
		public ComboBoxItem cbItem = new ComboBoxItem();

		public Network(string Name)
		{
			this.NetworkName = Name;
			this.cbItem = new ComboBoxItem();
			this.cbItem.Content = Name;
			this.cbItem.Tag = Name.Replace("v", "");
		}
		public ComboBoxItem setCBItem()
		{
			ComboBoxItem cbi = new ComboBoxItem();
			cbi.Name = NetworkName;
			cbi.Tag = NetworkName;
			return cbi;
		}
	}
}
