CREATE TABLE [dbo].[DatabaseDiagnostics]
	(
	[DatabaseDiagnosticsID] [INT]				NOT NULL IDENTITY (100000, 1)
	,[ProcedureName]		[NVARCHAR] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
	,[Parameters]			[XML]				NULL
	,[TotalResultsReturned] [INT]			NULL
	,[ExecutedUser]			[NVARCHAR] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
	,[ErrorNum]				[INT]				NULL
	,[ErrorSeverity]		[INT]				NULL
	,[ErrorState]			[INT]				NULL
	,[ErrorLine]			[INT]				NULL
	,[ErrorMessage]			[NVARCHAR] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
	,[UpdatedDate]			[DATETIME2]			NOT NULL
		CONSTRAINT [DF__DatabaseD__Updat__664CEF44]
			DEFAULT(GETDATE())
	,[CreatedDate]			[DATETIME2]			NOT NULL
		CONSTRAINT [DF__DatabaseD__Creat__6741137D]
			DEFAULT(GETDATE())
	,[RowGUID]				[UNIQUEIDENTIFIER]	NOT NULL
		CONSTRAINT [DF__DatabaseD__RowGU__683537B6]
			DEFAULT(NEWID())
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
GO
ALTER	TABLE [dbo].[DatabaseDiagnostics]
ADD CONSTRAINT [PK_DatabaseDiagnostics]
	PRIMARY KEY CLUSTERED([DatabaseDiagnosticsID])ON [PRIMARY];
GO
