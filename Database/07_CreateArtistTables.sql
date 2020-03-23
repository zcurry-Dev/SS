--
USE SceneSwarm01

CREATE TABLE ref.ArtistType(
	ArtistTypeID INT NOT NULL
		CONSTRAINT PK_ArtistType
		PRIMARY KEY IDENTITY
	,ArtistType NVARCHAR(255)	
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_ArtistType_CreatedBy
		REFERENCES hr.Employee(EmployeeID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistType_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE ref.ArtistStatus(
	ArtistStatusID INT NOT NULL
		CONSTRAINT PK_ArtistStatus
		PRIMARY KEY IDENTITY
	,ArtistStatus NVARCHAR(255)		
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_ArtistStatus_CreatedBy
		REFERENCES hr.Employee(EmployeeID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistStatus_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.Artist(
	ArtistID INT NOT NULL
		CONSTRAINT PK_Artist
		PRIMARY KEY IDENTITY
	,ArtistName NVARCHAR(255)
	--,ArtistStatusID INT
	--	CONSTRAINT FK_Artist_ArtistStatusID
	--	REFERENCES ref.ArtistStatus(ArtistStatusID)
	,CareerBeginDate DATETIME NOT NULL
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Artist_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.ArtistTypeXRef(
	ArtistTypeXRefID INT NOT NULL
		CONSTRAINT PK_ArtistTypeXRef
		PRIMARY KEY IDENTITY
	,ArtistID INT NOT NULL
		CONSTRAINT FK_ArtistTypeXRef_ArtistID
		REFERENCES dbo.Artist(ArtistID)
	,ArtistTypeID INT NOT NULL
		CONSTRAINT FK_ArtistTypeXRef_ArtistTypeID
		REFERENCES ref.ArtistType(ArtistTypeID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistTypeXRef_CreatedDate
		DEFAULT GETDATE()
)

CREATE TABLE dbo.ArtistGroupMember(
	ArtistGroupMemberID INT NOT NULL
		CONSTRAINT PK_ArtistGroupMember
		PRIMARY KEY IDENTITY
	,ArtistID INT NOT NULL	
		CONSTRAINT FK_ArtistGroupMember_ArtistTypeID
		REFERENCES ref.ArtistType(ArtistTypeID)
	,JoinDate DATETIME NOT NULL
	,LeaveDate DATETIME NULL
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistGroupMember_CreatedDate
		DEFAULT GETDATE()
)

CREATE TABLE ref.ArtistGroupMemberRole(
	ArtistGroupMemberRoleID INT NOT NULL
		CONSTRAINT PK_ArtistGroupMemberRole
		PRIMARY KEY IDENTITY
	,ArtistGroupMemberRole NVARCHAR(255) NOT NULL
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_ArtistGroupMemberRole_CreatedBy
		REFERENCES UserSS.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistGroupMemberRole_CreatedDate
		DEFAULT GETDATE()
	)

INSERT INTO ref.ArtistGroupMemberRole 
VALUES
('Lead Vocals', 1, GETDATE())
,('Guitar', 1, GETDATE())
,('Bass', 1, GETDATE())
,('Drums',1, GETDATE())

CREATE TABLE dbo.ArtistGroupMemberRolesXRef(
	ArtistGroupMemberRolesXRefID INT NOT NULL
		CONSTRAINT PK_ArtistGroupMemberRolesXRef
		PRIMARY KEY IDENTITY
	,ArtistGroupMemberID INT NOT NULL
		CONSTRAINT FK_ArtistGroupMemberRolesXRef_ArtistGroupMemberID
		REFERENCES dbo.ArtistGroupMember(ArtistGroupMemberID)
	,ArtistGroupMemberRoleID INT NOT NULL
		CONSTRAINT FK_ArtistGroupMemberRolesXRef_ArtistGroupMemberRoleID
		REFERENCES ref.ArtistGroupMemberRole(ArtistGroupMemberRoleID)
	,StartDate DATETIME NOT NULL
	,EndDate DATETIME NULL
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistGroupMemberRolesXRef_CreatedDate
		DEFAULT GETDATE()
	)

/*

DROP TABLE dbo.ArtistGroupMemberRolesXRef
DROP TABLE ref.ArtistGroupMemberRole
DROP TABLE dbo.ArtistGroupMember
DROP TABLE dbo.ArtistTypeXRef
DROP TABLE dbo.Artist
DROP TABLE ref.ArtistStatus
DROP TABLE ref.ArtistType

*/