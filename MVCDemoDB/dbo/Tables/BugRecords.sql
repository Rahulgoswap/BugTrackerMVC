CREATE TABLE [dbo].[BugRecords]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Source] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(50) NULL, 
    [Priority] INT NOT NULL, 
    [DeadLine1] NVARCHAR(50) NOT NULL, 
    [DeadLine2] NVARCHAR(50) NULL, 
    [DeadLineFinal] NVARCHAR(50) NOT NULL, 
    [ErrorMsg] NVARCHAR(50) NULL, 
    [AssignTeam] NVARCHAR(50) NOT NULL, 
    [PatchDetails] NVARCHAR(50) NULL, 
    [IsResolved] NVARCHAR(50) NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL
)
