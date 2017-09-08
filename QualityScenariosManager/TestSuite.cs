using System;
using System.Collections.Generic;

namespace QualityScenariosManager
{
	public class TestSuite
	{
		public int TestSuiteID { get; set; }
		public string TestSuiteName { get; set; }
		public string JiraLink { get; set; }
		public string Brand { get; set; }
		public string Version { get; set; }
		public List<TestCase> TestCases { get; set; }
		public string TestSuiteDefinition { get; set; }
		public string RegressionDefinition { get; set; }
		public string SmokeDefinition { get; set; }

		public void AddTestCase(TestCase oTestCase)
		{
			TestCases.Add(oTestCase);
		}
	}

	public class TestCase
	{
		public int TestCaseID { get; set; }
		public string TestCaseName { get; set; }
		public string Objective { get; set; }
		public string Preconditions { get; set; }
		public string Actions { get; set; }
		public string ExpectedResult { get; set; }
		public int Execution { get; set; }
		public int Importance { get; set; }
		public List<String> Keywords { get; set; }
	}
}
