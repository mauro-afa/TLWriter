
namespace QualityScenariosManager
{
    public class Configuration
    {
        public Versions versionList;
        public Network networkList;
        public Keyword keywordList;
    }

    public class Network
    {
        public string NetworkName { get; set; }
        public string NetworkTag { get; set; }

        public Network(string Name)
        {
            this.NetworkName = Name;
            this.NetworkTag = Name.Replace("v", "");
        }
    }

    public class Versions
    {
        public string VersionName { get; set; }
        public string VersionTag { set; get; }

        public Versions(string Name)
        {
            this.VersionName = Name;
            this.VersionTag = Name.Replace("v", "");
        }
    }

    public class Keyword
    {
        public bool IsChecked { get; set; }
        public string KeywordName { get; set; }
    }
}
