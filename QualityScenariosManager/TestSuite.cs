using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


		public void AddTestCase(TestCase oTestCase)
		{
			TestCases.Add(oTestCase);
		}
	}

	public class TestCase
	{
		public string TestCaseName { get; set; }
		public string Objective { get; set; }
		public string Preconditions { get; set; }
		public string Actions { get; set; }
		public string ExpectedResult { get; set; }
		public string Execution { get; set; }
		public string Importance { get; set; }
		public List<String> Keywords { get; set; }
	}
}
