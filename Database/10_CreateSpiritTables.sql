--
USE SceneSwarm01

CREATE TABLE ref.SpiritFamily(
	SpiritFamilyID INT NOT NULL
		CONSTRAINT PK_SpiritFamily
		PRIMARY KEY IDENTITY
	,SpiritFamily NVARCHAR(255) NOT NULL
	)

CREATE TABLE ref.SpiritType(
	SpiritTypeID INT NOT NULL
		CONSTRAINT PK_SpiritType
		PRIMARY KEY IDENTITY
	,SpiritType NVARCHAR(255) NOT NULL
	,SpiritFamilyID INT NOT NULL
		CONSTRAINT FK_SpiritType_SpiritFamilyID
		REFERENCES ref.SpiritFamily(SpiritFamilyID)
	)

CREATE TABLE dbo.Distillery(
	DistilleryID INT NOT NULL
		CONSTRAINT PK_Distillery
		PRIMARY KEY IDENTITY
	,DistilleryName NVARCHAR(255) NOT NULL
	,AddressID INT NOT NULL
		CONSTRAINT FK_Distillery_AddressID
		REFERENCES dbo.SSAddress(AddressID)
	,VenueID INT NOT NULL
		CONSTRAINT FK_Distillery_VenueID
		REFERENCES dbo.Venue(VenueID)
	,OpeningDate DATETIME NOT NULL
	,ClosingDate DATETIME
	)

CREATE TABLE dbo.Spirit(
	SpiritID INT NOT null
		CONSTRAINT PK_Spirit
		PRIMARY KEY IDENTITY
	,SpiritName NVARCHAR(255) NOT NULL
	,SpiritTypeID INT NOT NULL
		CONSTRAINT FK_Spirit_SpiritTypeID
		REFERENCES ref.SpiritType(SpiritTypeID)
	)

/*

DROP TABLE dbo.Spirit
DROP TABLE dbo.Distillery
DROP TABLE ref.SpiritType
DROP TABLE ref.SpiritFamily

*/