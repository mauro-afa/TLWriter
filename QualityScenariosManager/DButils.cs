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
	}
}
