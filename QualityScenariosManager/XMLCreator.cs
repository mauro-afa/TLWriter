using System;
using System.Collections.Generic;
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

			XmlNode nTestSuite = doc.CreateElement("testsuite");
			doc.AppendChild(nTestSuite);

			XmlAttribute attName = doc.CreateAttribute("name");
			attName.Value = oTS.TestSuiteName;
			nTestSuite.Attributes.Append(attName);

			XmlAttribute attInstance = doc.CreateAttribute("xmlns:xsi");
			attInstance.Value = "http://www.w3.org/2001/XMLSchema-instance";
			nTestSuite.Attributes.Append(attInstance);

			XmlNode nDetails = doc.CreateElement("details");
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

			XmlNode eTestSuite = regressionDoc.CreateElement("testsuite");
			regressionDoc.AppendChild(eTestSuite);

			XmlAttribute attName = regressionDoc.CreateAttribute("name");
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
			XmlNode nNode = _doc.CreateElement("testcase");
			XmlAttribute attTestCase = _doc.CreateAttribute("name");
			attTestCase.Value = lTestCase.TestCaseName;
			nNode.Attributes.Append(attTestCase);

			//Creates the TestCase information node.
			GetDefinition(_doc, lTestCase, nNode);
			return nNode;
		}

		public XmlNode AppendTestCase(XmlDocument _doc, TestCase lTestCase, XmlNode TestCaseNode)
		{
			//Creates the TestCase node
			XmlNode nNode = _doc.CreateElement("testcase");
			XmlAttribute attTestCase = _doc.CreateAttribute("name");
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


			XmlNode nSummary = _doc.CreateElement("summary");
			nSummary.InnerText = lTestCase.Objective.Replace(System.Environment.NewLine, "<BR>");
			nNode.AppendChild(nSummary);

			XmlNode nPreconditions = _doc.CreateElement("preconditions");
			nPreconditions.InnerText = lTestCase.Preconditions.Replace(System.Environment.NewLine, "<BR>");
			nNode.AppendChild(nPreconditions);

			XmlNode nExecutionType = _doc.CreateElement("execution_type");
			nExecutionType.InnerText = lTestCase.Execution.ToString();
			nNode.AppendChild(nExecutionType);

			XmlNode nImportance = _doc.CreateElement("importance");
			nImportance.InnerText = lTestCase.Importance.ToString();
			nNode.AppendChild(nImportance);

			XmlNode nStatus = _doc.CreateElement("status");
			nStatus.InnerText = "1";
			nNode.AppendChild(nStatus);

			XmlNode nKeywordList = _doc.CreateElement("keywords");
			nNode.AppendChild(nKeywordList);

			foreach(String keyword in lTestCase.Keywords)
			{
				if (keyword == "ADD2REGRESSION")
					bRegression = true;
				if (keyword == "SMOKE TEST")
					bSmoke = true;
				XmlNode nKeyword = _doc.CreateElement("keyword");
				XmlAttribute attKeyword = _doc.CreateAttribute("name");
				attKeyword.Value = keyword;
				nKeyword.Attributes.Append(attKeyword);
				nKeywordList.AppendChild(nKeyword);
			}

			XmlNode nStepList = _doc.CreateElement("steps");
			nNode.AppendChild(nStepList);

			XmlNode nSteps = _doc.CreateElement("step");
			nStepList.AppendChild(nSteps);

			//This should be changed whne the steps are numbered correctly

			XmlNode nStep = _doc.CreateElement("step_number");
			nStep.InnerText = "1";
			nSteps.AppendChild(nStep);

			XmlNode nAction = _doc.CreateElement("actions");
			nAction.InnerText = lTestCase.Actions.Replace(System.Environment.NewLine, "<BR>");
			nSteps.AppendChild(nAction);

			XmlNode nExpectedResults = _doc.CreateElement("expectedresults");
			nExpectedResults.InnerText = lTestCase.ExpectedResult.Replace(System.Environment.NewLine, "<BR>");
			nSteps.AppendChild(nExpectedResults);

			XmlNode nStepExecutionType = _doc.CreateElement("execution_type");
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

		public List<TestCase> GetTestCases(XmlDocument TSD)
		{
			List<TestCase> temp = new List<TestCase>();
			XmlNode TestCaseNodes = TSD.SelectNodes("testsuite")[0];
			foreach (XmlNode child in TestCaseNodes)
			{
				if (child.Name != "details")
				{
					TestCase nTestCase = new TestCase();
					nTestCase.TestCaseName = child.Attributes["name"].Value;
					foreach (XmlNode step in child)
					{
						switch (step.Name)
						{
							case "summary":
								nTestCase.Objective = step.InnerText;
								break;
							case "preconditions":
								nTestCase.Preconditions = step.InnerText;
								break;
							case "execution_type":
								nTestCase.Execution = Int32.Parse(step.InnerText);
								break;
							case "keywords":
								List<string> Keywords = new List<string>();
								foreach (XmlNode keyword in step)
								{
									;
									Keywords.Add(keyword.Attributes["name"].Value);
								}
								nTestCase.Keywords = new List<string>(Keywords);
								break;
							case "steps":
								foreach (XmlNode steps in step.FirstChild)
								{
									switch (steps.Name)
									{
										case "actions":
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
			}
			return temp;
		}

		public TestSuite GetTestSuiteInformation(XmlDocument importedXML)
		{
			TestSuite nTestSuite = new TestSuite();

			XmlNode TestCaseNodes = importedXML.SelectNodes("testsuite")[0];
			nTestSuite.TestSuiteName = TestCaseNodes.Attributes[1].Value;
			TestCaseNodes = TestCaseNodes.FirstChild;
			nTestSuite.JiraLink = TestCaseNodes.InnerText;
			nTestSuite.TestCases = new List<TestCase>(GetTestCases(importedXML));
			nTestSuite.TestSuiteDefinition = importedXML.InnerXml;
			return nTestSuite;
		}
	}

}
