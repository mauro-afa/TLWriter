﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QualityScenariosManager
{
	class DBConnection
	{
		private static DBConnection m_instance;
		private SqlConnection m_oSQLConn;
		private string m_sErrorDescription;

		public static DBConnection Instance
		{
			get
			{
				if (m_instance == null)
				{
					m_instance = new DBConnection();
				}
				return m_instance;
			}
		}

		public DBConnection() { }

		public bool Connect()
		{
			bool bResult = false;

			if (m_oSQLConn != null)
			{
				Disconnect();
			}
#if DEBUG
			string connectionString = QualityScenariosManager.Properties.Settings.Default.TestsConnectionString;
#else
			AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			string connectionString = QualityScenariosManager.Properties.Settings.Default.TestsConnectionString;
#endif

			m_oSQLConn = new SqlConnection(connectionString);
			try
			{
				m_oSQLConn.Open();
				bResult = true;
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("Can't open connection! Error: " + ex.Message);
			}
			return bResult;
		}

		public void Disconnect()
		{
			if (m_oSQLConn != null)
			{
				m_oSQLConn.Close();
				m_oSQLConn = null;
			}
		}

		public bool IsConnected()
		{
			bool bResult = false;
			if (m_oSQLConn != null)
			{
				bResult = (m_oSQLConn.State == ConnectionState.Open);
			}
			return bResult;
		}

		public bool ExecuteNonQuery(string strSQL)
		{
			m_sErrorDescription = "";
			if (!IsConnected())
				Connect();

			try
			{
				SqlCommand oSQLCommand = new SqlCommand(strSQL, m_oSQLConn);
				oSQLCommand.ExecuteNonQuery();
				oSQLCommand.Dispose();
				Disconnect();
				return true;
			}
			catch (SqlException ex)
			{
				MessageBox.Show(m_sErrorDescription = "Can't execute query! SQL: Incorrect syntax, a not allowed character may be written in a test case");
			}
			return false;
		}

		public SqlDataReader Execute(string strSQL)
		{
			if (!IsConnected())
				Connect();

			using (SqlCommand command = new SqlCommand(strSQL, m_oSQLConn))
			{
				return command.ExecuteReader(CommandBehavior.CloseConnection);
			}
		}
	}
}
