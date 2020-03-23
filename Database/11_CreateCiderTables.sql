--
USE SceneSwarm01

CREATE TABLE ref.CiderFamily(
	CiderFamilyID INT NOT NULL
		CONSTRAINT PK_CiderFamilies
		PRIMARY KEY IDENTITY
	,CiderFamily NVARCHAR(255) NOT NULL
	)

CREATE TABLE ref.CiderType(
	CiderTypeID INT NOT NULL
		CONSTRAINT PK_CiderType
		PRIMARY KEY IDENTITY
	,CiderType NVARCHAR(255) NOT NULL
	,CiderFamilyID INT NOT NULL
		CONSTRAINT FK_CiderType_CiderFamilyID
		REFERENCES ref.CiderFamily(CiderFamilyID)
	)

CREATE TABLE dbo.Cidery(
	CideryID INT NOT NULL
		CONSTRAINT PK_Ciderie
		PRIMARY KEY IDENTITY
	,CideryName NVARCHAR(255) NOT NULL
	,AddressID INT NOT NULL
		CONSTRAINT FK_Cidery_AddressID
		REFERENCES dbo.SSAddress(AddressID)
	,VenueID INT NOT NULL
		CONSTRAINT FK_Cidery_VenueID
		REFERENCES dbo.Venue(VenueID)
	,OpeningDate DATETIME NOT NULL
	,ClosingDate DATETIME
	)

CREATE TABLE dbo.Cider(
	CiderID INT NOT null
		CONSTRAINT PK_Cider
		PRIMARY KEY IDENTITY
	,CiderName NVARCHAR(255) NOT NULL
	,CiderTypeID INT NOT NULL
		CONSTRAINT FK_Cider_CiderTypeID
		REFERENCES ref.CiderType(CiderTypeID)
	)

/*

DROP TABLE dbo.Cider
DROP TABLE dbo.Cidery
DROP TABLE ref.CiderType
DROP TABLE ref.CiderFamily

*/