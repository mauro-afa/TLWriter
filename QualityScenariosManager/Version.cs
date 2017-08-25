using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QualityScenariosManager
{
	public class Versions
	{
		public string VersionName { get; set; }
		public ComboBoxItem cbItem;

		public Versions(string Name)
		{
			this.VersionName = Name;
			this.cbItem = new ComboBoxItem();
			this.cbItem.Content = Name;
			this.cbItem.Tag = Name.Replace("v","");
		}
	}
}
