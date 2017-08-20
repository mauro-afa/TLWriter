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
			List<TestCase> lTestCases = new List<TestCase>();
			string sSQL = "SELECT * FROM TestSuite WHERE TestSuiteID = '"+TSID+"'";
			SqlDataReader reader = m_oDBConn.Execute(sSQL);
			while(reader.Read())
			{
				lTestCases = new List<TestCase>(GetTestCases((string)reader[5]));
			}
			reader.Close();

			return lTestCases;
		}

		public List<TestCase> GetTestCases(string TSD)
		{
			List<TestCase> temp = new List<TestCase>();
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(TSD);
			XmlNode TestCaseNodes = doc.SelectNodes("TestSuite")[0];

			foreach (XmlNode child in TestCaseNodes)
			{
				TestCase nTestCase = new TestCase();
				nTestCase.TestCaseName = child.Attributes["Name"].Value;
				foreach (XmlNode step in child)
				{
					switch(step.Name)
					{
						case "Summary":
							nTestCase.Objective = step.InnerText;
							break;
						case "Preconditions":
							nTestCase.Preconditions = step.InnerText;
							break;
						case "Execution_type":
							nTestCase.Execution = Int32.Parse(step.InnerText);
							break;
						case "Keywords":
							List<string> Keywords = new List<string>();
							foreach (XmlNode keyword in step)
							{;
								Keywords.Add(keyword.Attributes["Name"].Value);
							}
							nTestCase.Keywords = new List<string>(Keywords);
							break;
						case "Steps":
							foreach(XmlNode steps in step.FirstChild)
							{
								switch(steps.Name)
								{
									case "Actions":
										nTestCase.Actions = steps.InnerText;
										break;
									case "expectedresults":
										nTestCase.ExpectedResult = steps.InnerText;
										break;
								}
							}
							break;
					}
				}
				temp.Add(nTestCase);
			}
			return temp;
		}
		public int getLastID()
		{
			string sSQL = "SELECT MAX(TestSuiteID) FROM TestSuite";
			SqlDataReader reader = m_oDBConn.Execute(sSQL);
			reader.Read();
			if (reader[0] is DBNull)
			{
				return 0;
			}
			else
				if ((int)reader[0] == 0)
					return 0;
				else
					return (int)reader[0];
		}

        public List<String> GetAllKeywords()
        {
            List<string> cKeywords = new List<string>();

            string sSQL = "SELECT * FROM St_Keywords";
            SqlDataReader reader = m_oDBConn.Execute(sSQL);
            while (reader.Read())
            {
                cKeywords.Add((string)reader[1]);
            }
            reader.Close();

            return cKeywords;
        }

        public List<String> GetAllVersions()
        {
            List<string> cVersions = new List<string>();

            string sSQL = "SELECT * FROM St_Versions";
            SqlDataReader reader = m_oDBConn.Execute(sSQL);
            while (reader.Read())
            {
                cVersions.Add((string)reader[1]);
            }
            reader.Close();

            return cVersions;
        }
    }
}
