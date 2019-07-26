--
USE SceneSwarm01

CREATE TABLE ref.ArtistTypes(
	ArtistTypeID INT NOT NULL
		CONSTRAINT PK_ArtistTypes
		PRIMARY KEY IDENTITY
	,ArtistType NVARCHAR(255)	
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_ArtistTypes_CreatedBy
		REFERENCES hr.Employees(EmployeeID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistTypes_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE ref.ArtistStatuses(
	ArtistStatusID INT NOT NULL
		CONSTRAINT PK_ArtistStatuses
		PRIMARY KEY IDENTITY
	,ArtistStatus NVARCHAR(255)		
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_ArtistStatuses_CreatedBy
		REFERENCES hr.Employees(EmployeeID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistStatuses_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.Artists(
	ArtistID INT NOT NULL
		CONSTRAINT PK_Artists
		PRIMARY KEY IDENTITY
	,ArtistName NVARCHAR(255)
	--,ArtistStatusID INT
	--	CONSTRAINT FK_Artists_ArtistStatusID
	--	REFERENCES ref.ArtistStatuses(ArtistStatusID)
	,CareerBeginDate DATETIME NOT NULL
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Artists_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.ArtistTypeXRef(
	ArtistTypeXRefID INT NOT NULL
		CONSTRAINT PK_ArtistTypeXRef
		PRIMARY KEY IDENTITY
	,ArtistID INT NOT NULL
		CONSTRAINT FK_ArtistTypeXRef_ArtistID
		REFERENCES dbo.ArtistS(ArtistID)
	,ArtistTypeID INT NOT NULL
		CONSTRAINT FK_ArtistTypeXRef_ArtistTypeID
		REFERENCES ref.ArtistTypes(ArtistTypeID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistTypeXRef_CreatedDate
		DEFAULT GETDATE()
)

CREATE TABLE dbo.ArtistGroupMembers(
	ArtistGroupMemberID INT NOT NULL
		CONSTRAINT PK_ArtistGroupMembers
		PRIMARY KEY IDENTITY
	,ArtistID INT NOT NULL	
		CONSTRAINT FK_ArtistGroupMembers_ArtistTypeID
		REFERENCES ref.ArtistTypes(ArtistTypeID)
	,JoinDate DATETIME NOT NULL
	,LeaveDate DATETIME NULL
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistGroupMembers_CreatedDate
		DEFAULT GETDATE()
)

CREATE TABLE ref.ArtistGroupMemberRoles(
	ArtistGroupMemberRoleID INT NOT NULL
		CONSTRAINT PK_ArtistGroupMemberRoles
		PRIMARY KEY IDENTITY
	,ArtistGroupMemberRole NVARCHAR(255) NOT NULL
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_ArtistGroupMemberRoles_CreatedBy
		REFERENCES hr.Employees(EmployeeID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistGroupMemberRoles_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.ArtistGroupMemberRolesXRef(
	ArtistGroupMemberRolesXRefID INT NOT NULL
		CONSTRAINT PK_ArtistGroupMemberRolesXRef
		PRIMARY KEY IDENTITY
	,ArtistGroupMemberID INT NOT NULL
		CONSTRAINT FK_ArtistGroupMemberRolesXRef_ArtistGroupMemberID
		REFERENCES dbo.ArtistGroupMembers(ArtistGroupMemberID)
	,ArtistGroupMemberRoleID INT NOT NULL
		CONSTRAINT FK_ArtistGroupMemberRolesXRef_ArtistGroupMemberRoleID
		REFERENCES ref.ArtistGroupMemberRoles(ArtistGroupMemberRoleID)
	,StartDate DATETIME NOT NULL
	,EndDate DATETIME NULL
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistGroupMemberRolesXRef_CreatedDate
		DEFAULT GETDATE()
	)

/*

DROP TABLE dbo.ArtistGroupMemberRolesXRef
DROP TABLE ref.ArtistGroupMemberRoles
DROP TABLE dbo.ArtistGroupMembers
DROP TABLE dbo.ArtistTypeXRef
DROP TABLE dbo.Artists
DROP TABLE ref.ArtistStatuses
DROP TABLE ref.ArtistTypes

*/