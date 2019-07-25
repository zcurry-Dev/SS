--
USE SceneSwarm01

CREATE TABLE ref.MeadFamilies(
	MeadFamilyID INT NOT NULL
		CONSTRAINT PK_MeadFamilies
		PRIMARY KEY IDENTITY
	,MeadFamily NVARCHAR(255) NOT NULL
	)

CREATE TABLE ref.MeadTypes(
	MeadTypeID INT NOT NULL
		CONSTRAINT PK_MeadTypes
		PRIMARY KEY IDENTITY
	,MeadType NVARCHAR(255) NOT NULL
	,MeadFamilyID INT NOT NULL
		CONSTRAINT FK_MeadFamilies_MeadFamilyID
		REFERENCES ref.MeadFamilies(MeadFamilyID)
	)

CREATE TABLE dbo.Meaderies(
	MeaderyID INT NOT NULL
		CONSTRAINT PK_Meaderies
		PRIMARY KEY IDENTITY
	,MeaderyName NVARCHAR(255) NOT NULL
	,AddressID INT NOT NULL
		CONSTRAINT FK_Meaderies_AddressID
		REFERENCES dbo.Addresses(AddressID)
	,VenueID INT NOT NULL
		CONSTRAINT FK_Meaderies_VenueID
		REFERENCES dbo.Venues(VenueID)
	,OpeningDate DATETIME NOT NULL
	,ClosingDate DATETIME
	)

CREATE TABLE dbo.Meads(
	MeadID INT NOT null
		CONSTRAINT PK_Meads
		PRIMARY KEY IDENTITY
	,MeadName NVARCHAR(255) NOT NULL
	,MeadTypeID INT NOT NULL
		CONSTRAINT FK_Meads_MeadTypeID
		REFERENCES ref.MeadTypes(MeadTypeID)
	,HoneyWine BIT
		CONSTRAINT DF_Meads_HoneyWine
		DEFAULT 0
	)

/*

DROP TABLE dbo.Meads
DROP TABLE dbo.Meaderies
DROP TABLE ref.MeadTypes
DROP TABLE ref.MeadFamilies

*/