--
USE SceneSwarm01

CREATE TABLE ref.CiderFamilies(
	CiderFamilyID INT NOT NULL
		CONSTRAINT PK_CiderFamilies
		PRIMARY KEY IDENTITY
	,CiderFamily NVARCHAR(255) NOT NULL
	)

CREATE TABLE ref.CiderTypes(
	CiderTypeID INT NOT NULL
		CONSTRAINT PK_CiderTypes
		PRIMARY KEY IDENTITY
	,CiderType NVARCHAR(255) NOT NULL
	,CiderFamilyID INT NOT NULL
		CONSTRAINT FK_CiderTypes_CiderFamilyID
		REFERENCES ref.CiderFamilies(CiderFamilyID)
	)

CREATE TABLE dbo.Cideries(
	CideryID INT NOT NULL
		CONSTRAINT PK_Cideries
		PRIMARY KEY IDENTITY
	,CideryName NVARCHAR(255) NOT NULL
	,AddressID INT NOT NULL
		CONSTRAINT FK_Cideries_AddressID
		REFERENCES dbo.Addresses(AddressID)
	,VenueID INT NOT NULL
		CONSTRAINT FK_Cideries_VenueID
		REFERENCES dbo.Venues(VenueID)
	,OpeningDate DATETIME NOT NULL
	,ClosingDate DATETIME
	)

CREATE TABLE dbo.Ciders(
	CiderID INT NOT null
		CONSTRAINT PK_Ciders
		PRIMARY KEY IDENTITY
	,CiderName NVARCHAR(255) NOT NULL
	,CiderTypeID INT NOT NULL
		CONSTRAINT FK_Ciders_CiderTypeID
		REFERENCES ref.CiderTypes(CiderTypeID)
	)

/*

DROP TABLE dbo.Ciders
DROP TABLE dbo.Cideries
DROP TABLE ref.CiderTypes
DROP TABLE ref.CiderFamilies

*/