CREATE TABLE [dbo].[TestCases] (
    [TCID]          INT           NOT NULL,
    [TSID]          INT           NOT NULL,
    [TestCaseID]    VARCHAR (MAX) NULL,
    [TestObjective] VARCHAR (MAX) NULL,
    [Preconditions] VARCHAR (MAX) NULL,
    [Actions]       VARCHAR (MAX) NULL,
    [Expec_res]     VARCHAR (MAX) NULL,
    [Keyword]       VARCHAR (MAX) NULL,
    [Exec_type]     VARCHAR (MAX) NULL,
    [Importance]    VARCHAR (MAX) NULL,
    [Stat]          VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([TSID] ASC, [TCID] ASC)
);

