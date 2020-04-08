--
USE SceneSwarm01

CREATE TABLE ref.ArtistType(
	ArtistTypeID INT NOT NULL
		CONSTRAINT PK_ArtistType
		PRIMARY KEY IDENTITY
	,ArtistType NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistType_CreatedDate
		DEFAULT GETDATE()
	)

INSERT INTO ref.ArtistType
VALUES
('ArtistType1', GETDATE())
,('ArtistType2', GETDATE())

CREATE TABLE ref.ArtistStatus(
	ArtistStatusID INT NOT NULL
		CONSTRAINT PK_ArtistStatus
		PRIMARY KEY IDENTITY
	,ArtistStatus NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistStatus_CreatedDate
		DEFAULT GETDATE()
	)

INSERT INTO ref.ArtistStatus
VALUES
('Active', GETDATE())
,('Inactive', GETDATE())

CREATE TABLE dbo.Artist(
	ArtistID INT NOT NULL
		CONSTRAINT PK_Artist
		PRIMARY KEY IDENTITY
	,ArtistName NVARCHAR(255)
	,ArtistStatusID INT
		CONSTRAINT FK_Artist_ArtistStatusID
		REFERENCES ref.ArtistStatus(ArtistStatusID)
	,CareerBeginDate DATETIME NOT NULL
	,Solo BIT NOT NULL
		CONSTRAINT DF_Artist_Solo
		DEFAULT 0
	,UserID INT NULL
		CONSTRAINT FK_Artist_UserID
		REFERENCES UserSS.SSUser(UserID)
	,Verified BIT NOT NULL
		CONSTRAINT DF_Artist_Verified
		DEFAULT 0
	,HomeCity INT NULL
		CONSTRAINT FK_Artist_HomeCity
		REFERENCES const.City(CityID)
	,CurrentCity INT NULL
		CONSTRAINT FK_Artist_CurrentCity
		REFERENCES const.City(CityID)
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Artist_CreatedBy
		REFERENCES UserSS.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Artist_CreatedDate
		DEFAULT GETDATE()
	)

INSERT INTO dbo.Artist
VALUES
('Test Artist1', 1, GETDATE(), 1, 2, 1, 1, 1, 1, GETDATE())
,('Test Artist2', 1, GETDATE(), 0, 2, 1, 1, 1, 1, GETDATE())
,('Test Artist3', 1, GETDATE(), 1, 2, 1, 1, 1, 1, GETDATE())
,('Test Artist4', 1, GETDATE(), 1, 2, 1, 1, 1, 1, GETDATE())
,('Test Artist5', 1, GETDATE(), 1, 2, 1, 1, 1, 1, GETDATE())


CREATE TABLE dbo.ArtistPhoto(	
	ArtistPhotoID INT NOT NULL
		CONSTRAINT PK_ArtistPhoto
		PRIMARY KEY IDENTITY
	,ArtistID INT NOT NULL
		CONSTRAINT FK_ArtistPhoto_ArtistID
		REFERENCES dbo.Artist(ArtistID)
	,PhotoPath NVARCHAR(255) NOT NULL
	,PhotoDescription NVARCHAR(255) NOT NULL
	,DateAdded DATETIME NOT NULL
		CONSTRAINT DF_ArtistPhoto_DateAdded
		DEFAULT GETDATE()
	,IsMain BIT NOT NULL
		CONSTRAINT DF_ArtistPhoto_IsMain
		DEFAULT 0
)

INSERT INTO dbo.ArtistPhoto
VALUES
(1, 'https://randomuser.me/api/portraits/men/23.jpg', 'Rocker1', GETDATE(), 1)
,(2, 'https://randomuser.me/api/portraits/men/24.jpg', 'Rocker2', GETDATE(), 1)
,(3, 'https://randomuser.me/api/portraits/men/25.jpg', 'Rocker3', GETDATE(), 1)
,(4, 'https://randomuser.me/api/portraits/men/26.jpg', 'Rocker4', GETDATE(), 1)
,(5, 'https://randomuser.me/api/portraits/men/27.jpg', 'Rocker5', GETDATE(), 1)
,(1, 'https://randomuser.me/api/portraits/men/28.jpg', 'Rocker1', GETDATE(), 0)
,(2, 'https://randomuser.me/api/portraits/men/29.jpg', 'Rocker2', GETDATE(), 0)
,(3, 'https://randomuser.me/api/portraits/men/30.jpg', 'Rocker3', GETDATE(), 0)
,(4, 'https://randomuser.me/api/portraits/men/31.jpg', 'Rocker4', GETDATE(), 0)
,(5, 'https://randomuser.me/api/portraits/men/32.jpg', 'Rocker5', GETDATE(), 0)

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
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_ArtistGroupMember_CreatedBy
		REFERENCES UserSS.SSUser(UserID)
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
DROP TABLE dbo.ArtistPhoto
DROP TABLE dbo.Artist
DROP TABLE ref.ArtistStatus
DROP TABLE ref.ArtistType

*/