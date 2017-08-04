using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public bool SaveTestSuite(TestSuite oTestSuite)
		{ 
			string sSQL = "Insert INTO TestSuite (TestSuiteID, TestSuiteName, JiraLink, Brand, Version) values ('" + oTestSuite.TestSuiteID + "','" + oTestSuite.TestSuiteName + "', '" + oTestSuite.JiraLink + "', '" + oTestSuite.Brand + "', '" + oTestSuite.Version + "')";
			return m_oDBConn.ExecuteNonQuery(sSQL);
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
					TestSuiteName = (string)reader[1],
					JiraLink = (string)reader[2],
					Brand = (string)reader[3],
					Version = (string)reader[4]
				};
				lTestSuite.Add(oTestSuite);
			}
			reader.Close();
			return lTestSuite;
		}
	}
}
