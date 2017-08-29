using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QualityScenariosManager
{
	public class XMLCreator
	{ 
		List<XmlDocument> xmls = new List<XmlDocument>();
		XmlDocument doc = new XmlDocument();
		XmlDocument regressionDoc = new XmlDocument();
		XmlDocument smokeDoc = new XmlDocument();

		public List<XmlDocument> CreateXML(TestSuite oTS)
		{
			XmlNode nodeDecl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
			doc.AppendChild(nodeDecl);

			XmlNode nTestSuite = doc.CreateElement("TestSuite");
			doc.AppendChild(nTestSuite);

			XmlAttribute attName = doc.CreateAttribute("Name");
			attName.Value = oTS.TestSuiteName;
			nTestSuite.Attributes.Append(attName);

			XmlAttribute attInstance = doc.CreateAttribute("xmlns:xsi");
			attInstance.Value = "http://www.w3.org/2001/XMLSchema-instance";
			nTestSuite.Attributes.Append(attInstance);

			XmlNode nDetails = doc.CreateElement("Details");
			nDetails.InnerText = oTS.JiraLink;
			nTestSuite.AppendChild(nDetails);

			regressionDoc = ExtraDoc("REGRESSION");
			smokeDoc = ExtraDoc("SMOKE");

			foreach(TestCase cTC in oTS.TestCases)
			{
				nTestSuite.AppendChild(AppendTestCase(doc, cTC));
			}
			xmls.Add(doc);
			xmls.Add(regressionDoc);
			xmls.Add(smokeDoc);

			return xmls;
		}

		public XmlDocument ExtraDoc(string FileName)
		{
			XmlDocument regressionDoc = new XmlDocument();

			XmlNode extraDecl = regressionDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
			regressionDoc.AppendChild(extraDecl);

			XmlNode eTestSuite = regressionDoc.CreateElement("TestSuite");
			regressionDoc.AppendChild(eTestSuite);

			XmlAttribute attName = regressionDoc.CreateAttribute("Name");
			attName.Value = FileName;
			eTestSuite.Attributes.Append(attName);

			XmlAttribute attInstance = regressionDoc.CreateAttribute("xmlns:xsi");
			attInstance.Value = "http://www.w3.org/2001/XMLSchema-instance";
			eTestSuite.Attributes.Append(attInstance);

			return regressionDoc;
		}

		public XmlNode AppendTestCase (XmlDocument _doc, TestCase lTestCase)
		{
			//Creates the TestCase node
			XmlNode nNode = _doc.CreateElement("TestCase");
			XmlAttribute attTestCase = _doc.CreateAttribute("Name");
			attTestCase.Value = lTestCase.TestCaseName;
			nNode.Attributes.Append(attTestCase);

			//Creates the TestCase information node.
			GetDefinition(_doc, lTestCase, nNode);
			return nNode;
		}

		public XmlNode AppendTestCase(XmlDocument _doc, TestCase lTestCase, XmlNode TestCaseNode)
		{
			//Creates the TestCase node
			XmlNode nNode = _doc.CreateElement("TestCase");
			XmlAttribute attTestCase = _doc.CreateAttribute("Name");
			attTestCase.Value = lTestCase.TestCaseName;
			nNode.Attributes.Append(attTestCase);

			//Creates the TestCase information node.
			XmlNode RegressionNode = TestCaseNode.Clone();
			_doc.AppendChild(RegressionNode);
			return nNode;
		}

		public void GetDefinition(XmlDocument _doc, TestCase lTestCase, XmlNode nNode)
		{
			bool bRegression = false, bSmoke = false;


			XmlNode nSummary = _doc.CreateElement("Summary");
			nSummary.InnerText = lTestCase.Objective;
			nNode.AppendChild(nSummary);

			XmlNode nPreconditions = _doc.CreateElement("Preconditions");
			nPreconditions.InnerText = lTestCase.Preconditions;
			nNode.AppendChild(nPreconditions);

			XmlNode nExecutionType = _doc.CreateElement("Execution_type");
			nExecutionType.InnerText = lTestCase.Execution.ToString();
			nNode.AppendChild(nExecutionType);

			XmlNode nImportance = _doc.CreateElement("Importance");
			nImportance.InnerText = lTestCase.Importance.ToString();
			nNode.AppendChild(nImportance);

			XmlNode nStatus = _doc.CreateElement("Status");
			nStatus.InnerText = "1";
			nNode.AppendChild(nStatus);

			XmlNode nKeywordList = _doc.CreateElement("Keywords");
			nNode.AppendChild(nKeywordList);

			foreach(String keyword in lTestCase.Keywords)
			{
				if (keyword == "ADD2REGRESSION")
					bRegression = true;
				if (keyword == "SMOKE TEST")
					bSmoke = true;
				XmlNode nKeyword = _doc.CreateElement("Keyword");
				XmlAttribute attKeyword = _doc.CreateAttribute("Name");
				attKeyword.Value = keyword;
				nKeyword.Attributes.Append(attKeyword);
				nKeywordList.AppendChild(nKeyword);
			}

			XmlNode nStepList = _doc.CreateElement("Steps");
			nNode.AppendChild(nStepList);

			XmlNode nSteps = _doc.CreateElement("Step");
			nStepList.AppendChild(nSteps);

			//This should be changed whne the steps are numbered correctly

			XmlNode nStep = _doc.CreateElement("Step_Number");
			nStep.InnerText = "1";
			nSteps.AppendChild(nStep);

			XmlNode nAction = _doc.CreateElement("Actions");
			nAction.InnerText = lTestCase.Actions;
			nSteps.AppendChild(nAction);

			XmlNode nExpectedResults = _doc.CreateElement("expectedresults");
			nExpectedResults.InnerText = lTestCase.ExpectedResult;
			nSteps.AppendChild(nExpectedResults);

			XmlNode nStepExecutionType = _doc.CreateElement("Execution_type");
			nStepExecutionType.InnerText = lTestCase.Execution.ToString();
			nSteps.AppendChild(nStepExecutionType);

			if (bRegression)
			{
				XmlNode newNode = regressionDoc.ImportNode(nNode, true);
				regressionDoc.DocumentElement.AppendChild(newNode);
			}

			if(bSmoke)
			{
				XmlNode newNode = smokeDoc.ImportNode(nNode, true);
				smokeDoc.DocumentElement.AppendChild(newNode);
			}
		}
	}

}
