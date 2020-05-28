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
('Band', GETDATE())
,('Solo Artist', GETDATE())

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
,('Hiatus', GETDATE())

CREATE TABLE dbo.Artist(
	ArtistID INT NOT NULL
		CONSTRAINT PK_Artist
		PRIMARY KEY IDENTITY
	,ArtistName NVARCHAR(255)
	,ArtistStatusID INT
		CONSTRAINT FK_Artist_ArtistStatusID
		REFERENCES ref.ArtistStatus(ArtistStatusID)
	,CareerBeginDate DATETIME NOT NULL
	,ArtistGroup BIT NOT NULL
		CONSTRAINT DF_Artist_ArtistGroup
		DEFAULT 0
	,UserID INT NULL
		CONSTRAINT FK_Artist_UserID
		REFERENCES ident.SSUser(UserID)
	,Verified BIT NOT NULL
		CONSTRAINT DF_Artist_Verified
		DEFAULT 0
	,HomeCountryID INT NOT NULL
		CONSTRAINT FK_Artist_HomeCountryID
		REFERENCES const.Country(CountryID)
	,USHomeCityID INT NULL
		CONSTRAINT FK_Artist_USHomeCityID
		REFERENCES loc.City(CityID)
	,WorldHomeCityID INT NULL
		CONSTRAINT FK_Artist_WorldHomeCityID
		REFERENCES loc.WorldCity(WorldCityID)
	,CurrentCityID INT NULL
		CONSTRAINT FK_Artist_CurrentCityID
		REFERENCES loc.City(CityID)
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Artist_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Artist_CreatedDate
		DEFAULT GETDATE()
	)

INSERT INTO dbo.Artist
VALUES						
('Silverstein',	1, '02-01-2000', 1, NULL, 1, 41, NULL, 2, NULL, 1, GETDATE())
,('Beartooth',	1, '01-01-2012', 1, NULL, 1, 1,  3, NULL, NULL, 1, GETDATE())
,('Chunk! No, Captain Chunk!',	1, '01-01-2007', 1, NULL, 1, 77, NULL, 1, NULL, 1, GETDATE())
,('The Story So Far', 1, '01-01-2007', 1, NULL, 1, 1, 4, NULL, NULL, 1, GETDATE())
,('John Denver', 1, '01-01-1965', 0, NULL, 1, 1, 5, NULL, NULL, 1, GETDATE())

CREATE TABLE dbo.ArtistPhoto(	
	ArtistPhotoID INT NOT NULL
		CONSTRAINT PK_ArtistPhoto
		PRIMARY KEY IDENTITY
	,ArtistID INT NOT NULL
		CONSTRAINT FK_ArtistPhoto_ArtistID
		REFERENCES dbo.Artist(ArtistID)
	,PhotoPath NVARCHAR(255) NOT NULL
	,PhotoDescription NVARCHAR(255) NOT NULL
	,PhotoFileContentType NVARCHAR(255) NOT NULL
	,PhotoFileExt NVARCHAR(255) NOT NULL
	,PhotoFileName NVARCHAR(255) NOT NULL
	,DateAdded DATETIME NOT NULL
		CONSTRAINT DF_ArtistPhoto_DateAdded
		DEFAULT GETDATE()
	,IsMain BIT NOT NULL
		CONSTRAINT DF_ArtistPhoto_IsMain
		DEFAULT 0
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
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_ArtistGroupMember_CreatedBy
		REFERENCES ident.SSUser(UserID)
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
		REFERENCES ident.SSUser(UserID)
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