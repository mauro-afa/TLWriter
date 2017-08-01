CREATE TABLE [dbo].[Table]
(
	[TesteSuiteID] INT NOT NULL PRIMARY KEY, 
    [TestSuiteName] NVARCHAR(MAX) NULL, 
    [JiraLink] NVARCHAR(MAX) NULL, 
    [Brand] NVARCHAR(50) NULL, 
    [Version] NVARCHAR(50) NULL
)
