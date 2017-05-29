CREATE TABLE [dbo].[TestSuites] (
    [Id]           INT        IDENTITY (1, 1) NOT NULL,
    [Name]         CHAR (100) NULL,
    [JiraLink]     CHAR (100) NULL,
    [Brand]        CHAR (20)  NULL,
    [Version]      CHAR (10)  NULL,
    [CreationDate] DATE       DEFAULT (getdate()) NULL,
    [UploadDate]   DATE       NULL,
    [UpdateDate]   DATE       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

