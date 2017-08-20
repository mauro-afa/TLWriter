CREATE TABLE [dbo].[TestSuite] (
    [TestSuiteID]          INT            NOT NULL,
    [TestSuiteName]        NVARCHAR (MAX) NULL,
    [JiraLink]             NVARCHAR (MAX) NULL,
    [Brand]                NVARCHAR (50)  NULL,
    [Version]              NVARCHAR (50)  NULL,
    [TestCaseDefinition]   NVARCHAR (MAX) NULL,
    [RegressionDefinition] NVARCHAR (MAX) NULL,
    [SmokeDefinition]      NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([TestSuiteID] ASC)
);

