using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QualityScenariosManager
{
	class DButils
	{
		private static DButils m_instance;
		private DBConnection m_oDBConn = DBConnection.Instance;
		public static DButils Instance
		{
			get
			{
				if (m_instance == null)
				{
					m_instance = new DButils();
				}
				return m_instance;
			}
		}

		private DButils()
		{
			m_oDBConn = DBConnection.Instance;
		}

		public bool SaveTestSuite(TestSuite oTestSuite, bool bUpdate)
		{
			string sSQL;
			if (bUpdate)
				//fix the update
				sSQL = "UPDATE TestSuite Set TestSuiteName = '" + oTestSuite.TestSuiteName + "', JiraLink = '" + oTestSuite.JiraLink + "', Brand = '" + oTestSuite.Brand + "', Version = '" + oTestSuite.Version + "', TestCaseDefinition = '" + oTestSuite.TestSuiteDefinition + "', RegressionDefinition = '" + oTestSuite.RegressionDefinition + "', SmokeDefinition = '" + oTestSuite.SmokeDefinition + "' WHERE TestSuiteID = '" + oTestSuite.TestSuiteID + "'";
			else
				sSQL = "Insert INTO TestSuite (TestSuiteID, TestSuiteName, JiraLink, Brand, Version, TestCaseDefinition, RegressionDefinition, SmokeDefinition) values ('" + oTestSuite.TestSuiteID + "','" + oTestSuite.TestSuiteName + "', '" + oTestSuite.JiraLink + "', '" + oTestSuite.Brand + "', '" + oTestSuite.Version + "', '" + oTestSuite.TestSuiteDefinition + "', '"+oTestSuite.RegressionDefinition+"', '"+oTestSuite.SmokeDefinition+"')";
			return m_oDBConn.ExecuteNonQuery(sSQL);
		}

		public bool DeleteTestSuite(TestSuite oTestSuite)
		{
			string sSQL = "DELETE FROM TestSuite WHERE TestSuiteID = '" + oTestSuite.TestSuiteID + "'";
			m_oDBConn.ExecuteNonQuery(sSQL);
			sSQL = "exec FixTSIDNumber";
			m_oDBConn.ExecuteNonQuery(sSQL);
			return true;

		}
		public List<TestSuite> GetAllTestSuites()
		{
			List<TestSuite> lTestSuite = new List<TestSuite>();
			string sSQL = "SELECT * FROM TestSuite";
			SqlDataReader reader = m_oDBConn.Execute(sSQL);
			while(reader.Read())
			{
				TestSuite oTestSuite = new TestSuite()
				{
					TestSuiteID = (int)reader[0],
					TestSuiteName = (string)reader[1],
					JiraLink = (string)reader[2],
					Brand = (string)reader[3],
					Version = (string)reader[4],
					TestSuiteDefinition = (string)reader[5],
                    RegressionDefinition = (string)reader[6],
                    SmokeDefinition = (string)reader[7],
                };
				lTestSuite.Add(oTestSuite);
			}
			reader.Close();
			return lTestSuite;
		}

		public List<TestCase> GetAllTestCases(int TSID)
		{
			XMLCreator xCreator = new XMLCreator();
			List<TestCase> lTestCases = new List<TestCase>();
			string sSQL = "SELECT * FROM TestSuite WHERE TestSuiteID = '"+TSID+"'";
			SqlDataReader reader = m_oDBConn.Execute(sSQL);
			while(reader.Read())
			{
				XmlDocument doc = new XmlDocument();
				doc.LoadXml((string)reader[5]);
				lTestCases = new List<TestCase>(xCreator.GetTestCases(doc));
			}
			reader.Close();

			return lTestCases;
		}
		public int getLastID(string tableName)
		{
            string fieldName = "";
            switch(tableName)
            {
                case "St_Keywords":
                case "St_Versions":
                case "St_Networks":
                    fieldName = "Id";
                    break;
                case "TestSuite":
                    fieldName = "TestSuiteId";
                    break;
            }
			string sSQL = "SELECT MAX("+fieldName+") FROM "+tableName+"";
			SqlDataReader reader = m_oDBConn.Execute(sSQL);
			reader.Read();
			if (reader[0] is DBNull)
			{
                reader.Close();
				return 0;
			}
			else
            {
                if ((int)reader[0] == 0)
                {
                    reader.Close();
                    return 0;
                }
                else
                {
                    int id = (int)reader[0];
                    reader.Close();
                    return id;
                }
            }
		}

        public List<Keyword> GetAllKeywords()
        {
            List<Keyword> cKeywords = new List<Keyword>();

            string sSQL = "SELECT * FROM St_Keywords";
            SqlDataReader reader = m_oDBConn.Execute(sSQL);
            while (reader.Read())
            {
				cKeywords.Add(new Keyword() { KeywordName = (string)reader[1] });
            }
            reader.Close();
			return cKeywords;
        }

        public List<Versions> GetAllVersions()
        {
            List<Versions> cVersions = new List<Versions>();

            string sSQL = "SELECT * FROM St_Versions";
            SqlDataReader reader = m_oDBConn.Execute(sSQL);
            while (reader.Read())
            {
				cVersions.Add(new Versions((string)reader[1]));
            }
            reader.Close();

            return cVersions;
        }

		public List<Network> GetAllNetworks()
		{
			List<Network> cNetworks = new List<Network>();

			string sSQL = "SELECT * FROM St_Networks";
			SqlDataReader reader = m_oDBConn.Execute(sSQL);
			while (reader.Read())
			{
				cNetworks.Add(new Network((string)reader[1]));
			}
			reader.Close();

			return cNetworks;
		}

        public bool SaveKeyword(Keyword Name)
        {
            int lastID = getLastID("St_Keywords");
            string sSQL = "Insert INTO St_Keywords (Id, KeywordName) values ("+lastID+",'"+Name.KeywordName+"')";
            return m_oDBConn.ExecuteNonQuery(sSQL);
        }

		public bool DeleteKeyword(Keyword Name)
		{
			string sSQL = "DELETE FROM St_Keywords WHERE KeywordName = '" + Name.KeywordName + "'";
			return m_oDBConn.ExecuteNonQuery(sSQL);
		}

		public bool UpdateKeyword(Keyword oldKeyword, string newKeyword)
		{
			string sSQL = "UPDATE St_Keywords SET KeywordName = '" + newKeyword + "' WHERE KeywordName = '" + oldKeyword.KeywordName + "'";
			return m_oDBConn.ExecuteNonQuery(sSQL);
		}

		public bool SaveVersion(Versions Name)
		{
			int lastID = getLastID("St_Versions");
			string sSQL = "Insert INTO St_Versions (Id, Version) values (" + lastID + ",'" + Name.VersionName + "')";
			return m_oDBConn.ExecuteNonQuery(sSQL);
		}

		public bool DeleteVersion(Versions Name)
		{
			string sSQL = "DELETE FROM St_Versions WHERE Version = '"+Name.VersionName+"'";
			return m_oDBConn.ExecuteNonQuery(sSQL);
		}

		public bool UpdateVersion(Versions oldVersion, string newVersion)
		{
			string sSQL = "UPDATE St_Versions SET Version = '"+newVersion+"' WHERE Version = '" + oldVersion.VersionName + "'";
			return m_oDBConn.ExecuteNonQuery(sSQL);
		}

		public bool SaveNetwork(Network Name)
		{
			int lastID = getLastID("St_Networks");
			string sSQL = "Insert INTO St_Networks (Id, NetworkName) values (" + lastID + ",'" + Name.NetworkName + "')";
			return m_oDBConn.ExecuteNonQuery(sSQL);
		}

		public bool DeleteNetwork(Network Name)
		{
			string sSQL = "DELETE FROM St_Networks WHERE NetworkName = '" + Name.NetworkName + "'";
			return m_oDBConn.ExecuteNonQuery(sSQL);
		}

		public bool UpdateNetwork(Network oldVersion, string newNetwork)
		{
			string sSQL = "UPDATE St_Networks SET NetworkName = '" + newNetwork + "' WHERE NetworkName = '" + oldVersion.NetworkName + "'";
			return m_oDBConn.ExecuteNonQuery(sSQL);
		}
	}
}
