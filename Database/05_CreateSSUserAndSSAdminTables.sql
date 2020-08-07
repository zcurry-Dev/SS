CREATE TABLE ident.[SSRole] (
    [RoleID] int NOT NULL IDENTITY
    ,[Name] nvarchar(256) NULL
    ,[NormalizedName] nvarchar(256) NULL
    ,[ConcurrencyStamp] nvarchar(max) NULL
    ,CONSTRAINT [PK_SSRole] PRIMARY KEY ([RoleID])
);

INSERT INTO ident.[SSRole]
VALUES
('User', 'user', NEWID())
,('Admin', 'admin', NEWID())
,('Artist', 'artist', NEWID())
,('Venue Manager', 'venue manager', NEWID())
,('Promoter', 'promoter', NEWID())
,('Artist Manager', 'artist manager', NEWID())

GO

CREATE TABLE ident.SSUserStatus(
	UserStatusID INT NOT NULL
		CONSTRAINT PK_SSUserStatus
		PRIMARY KEY IDENTITY
	,UserStatus NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_SSUserStatus_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO ident.SSUserStatus
VALUES
('Active', GETDATE())
,('Inactive', GETDATE())

CREATE TABLE ident.[SSUser] (
    [UserID] int NOT NULL IDENTITY
    ,[UserName] nvarchar(256) NULL
    ,[NormalizedUserName] nvarchar(256) NULL
	,FirstName NVARCHAR(255) NOT NULL
	,LastName NVARCHAR(255) NOT NULL
    ,[Email] nvarchar(256) NULL
    ,[NormalizedEmail] nvarchar(256) NULL
    ,[EmailConfirmed] bit NOT NULL
    ,[PasswordHash] nvarchar(max) NULL
    ,[SecurityStamp] nvarchar(max) NULL
    ,[ConcurrencyStamp] nvarchar(max) NULL
    ,[PhoneNumber] nvarchar(max) NULL
    ,[PhoneNumberConfirmed] bit NOT NULL
    ,[TwoFactorEnabled] bit NOT NULL
    ,[LockoutEnd] datetimeoffset NULL
    ,[LockoutEnabled] bit NOT NULL
    ,[AccessFailedCount] int NOT NULL
	,DisplayName NVARCHAR(255) NOT NULL
	,DateOfBirth DATETIME NOT NULL
		CONSTRAINT DF_User_DateOfBirth
		DEFAULT GETDATE()
	,UserStatusID INT NOT NULL
		CONSTRAINT FK_User_UserStatusID
		REFERENCES ident.SSUserStatus(UserStatusID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_User_CreatedDate
		DEFAULT GETDATE()
	,LastActive	DATETIME NOT NULL
		CONSTRAINT DF_User_LastActive
		DEFAULT GETDATE()
    ,CONSTRAINT [PK_SSUser] PRIMARY KEY ([UserID])
);

INSERT INTO ident.SSUSER
VALUES
(
'z', 'z', 'zach', 'curry', 'z@ss.com', 'z@ss.com',
 1,
 'AQAAAAEAACcQAAAAEJvRXEbwhdhrlRHBQ0QvszTOJwoWbUyyKi6Nicq92EmmjJ1xf6xzINPtWExAFUU16A==',
 'E2XVSLUAZYY3SGKQ3KKPLNNDSXEPXO7X',
 'a66eff1f-8bbd-4520-b50c-8424e43e68d9',
 null, 0, 0, null, 0,
 0, 'Zach', '05-18-1994', 1, GETDATE(), GETDATE()
)

GO

CREATE TABLE ident.[SSRoleClaim] (
    [RoleClaimID] int NOT NULL IDENTITY
    ,[RoleId] int NOT NULL
    ,[ClaimType] nvarchar(max) NULL
    ,[ClaimValue] nvarchar(max) NULL
    ,CONSTRAINT [PK_SSRoleClaim] PRIMARY KEY ([RoleClaimID])
    ,CONSTRAINT [FK_SSRoleClaim_SSRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES ident.[SSRole] ([RoleID]) ON DELETE CASCADE
);

GO

CREATE TABLE ident.[SSUserClaim] (
    [UserClaimID] int NOT NULL IDENTITY
    ,[UserId] int NOT NULL
    ,[ClaimType] nvarchar(max) NULL
    ,[ClaimValue] nvarchar(max) NULL
    ,CONSTRAINT [PK_SSUserClaim] PRIMARY KEY ([UserClaimID])
    ,CONSTRAINT [FK_SSUserClaim_SSUser_UserId] FOREIGN KEY ([UserId]) REFERENCES ident.[SSUser] ([UserID]) ON DELETE CASCADE
);

GO

CREATE TABLE ident.[SSUserLogin] (
    [LoginProvider] nvarchar(128) NOT NULL
    ,[ProviderKey] nvarchar(128) NOT NULL
    ,[ProviderDisplayName] nvarchar(max) NULL
    ,[UserId] int NOT NULL
    ,CONSTRAINT [PK_SSUserLogin] PRIMARY KEY ([LoginProvider], [ProviderKey])
    ,CONSTRAINT [FK_SSUserLogin_SSUser_UserId] FOREIGN KEY ([UserId]) REFERENCES ident.[SSUser] ([UserID]) ON DELETE CASCADE
);

GO

CREATE TABLE ident.[SSUserRole] (
    [UserId] int NOT NULL
    ,[RoleId] int NOT NULL
    ,CONSTRAINT [PK_SSUserRole] PRIMARY KEY ([UserId], [RoleId])
    ,CONSTRAINT [FK_SSUserRole_SSRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES ident.[SSRole] ([RoleID]) ON DELETE CASCADE
    ,CONSTRAINT [FK_SSUserRole_SSUser_UserId] FOREIGN KEY ([UserId]) REFERENCES ident.[SSUser] ([UserID]) ON DELETE CASCADE
);


INSERT INTO ident.[SSUserRole]
VALUES
(1,1)
,(1,2)
,(1,4)

GO

CREATE TABLE ident.[SSUserToken] (
    [UserId] int NOT NULL
    ,[LoginProvider] nvarchar(128) NOT NULL
    ,[Name] nvarchar(128) NOT NULL
    ,[Value] nvarchar(max) NULL
    ,CONSTRAINT [PK_SSUserToken] PRIMARY KEY ([UserId], [LoginProvider], [Name])
    ,CONSTRAINT [FK_SSUserToken_SSUser_UserId] FOREIGN KEY ([UserId]) REFERENCES ident.[SSUser] ([UserID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_SSRoleClaim_RoleId] ON ident.[SSRoleClaim] ([RoleId]);

GO

SET QUOTED_IDENTIFIER ON;
GO
CREATE UNIQUE INDEX [RoleNameIndex] ON ident.[SSRole] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO
SET QUOTED_IDENTIFIER OFF;
GO

CREATE INDEX [IX_SSUserClaim_UserId] ON ident.[SSUserClaim] ([UserId]);

GO

CREATE INDEX [IX_SSUserLogin_UserId] ON ident.[SSUserLogin] ([UserId]);

GO

CREATE INDEX [IX_SSUserRole_RoleId] ON ident.[SSUserRole] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON ident.[SSUser] ([NormalizedEmail]);

GO

SET QUOTED_IDENTIFIER ON;
GO
CREATE UNIQUE INDEX [UserNameIndex] ON ident.[SSUser] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;       
GO
SET QUOTED_IDENTIFIER OFF;
GO


/*

DROP TABLE ident.SSUserToken
DROP TABLE ident.SSUserRole
DROP TABLE ident.SSUserLogin
DROP TABLE ident.SSUserClaim
DROP TABLE ident.SSRoleClaim
DROP TABLE ident.SSUser
DROP TABLE ident.SSUserStatus
DROP TABLE ident.SSRole

*/

