CREATE TABLE [dbo].[TestCases]
(
	[TestSuiteID] INT NOT NULL PRIMARY KEY, 
    [TestCaseID] INT NULL, 
    [TestCaseName] NVARCHAR(MAX) NULL, 
    [TestCaseDefinition] NVARCHAR(MAX) NULL 
)
