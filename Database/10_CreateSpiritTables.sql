--
USE SceneSwarm01

CREATE TABLE ref.SpiritFamiles(
	SpiritFamilyID INT NOT NULL
		CONSTRAINT PK_SpiritFamiles
		PRIMARY KEY IDENTITY
	,SpiritFamily NVARCHAR(255) NOT NULL
	)

CREATE TABLE ref.SpiritTypes(
	SpiritTypeID INT NOT NULL
		CONSTRAINT PK_SpiritTypes
		PRIMARY KEY IDENTITY
	,SpiritType NVARCHAR(255) NOT NULL
	,SpiritFamilyID INT NOT NULL
		CONSTRAINT FK_SpiritTypes_SpiritFamilyID
		REFERENCES ref.SpiritFamiles(SpiritFamilyID)
	)

CREATE TABLE dbo.Distilleries(
	DistilleryID INT NOT NULL
		CONSTRAINT PK_Distilleries
		PRIMARY KEY IDENTITY
	,DistilleryName NVARCHAR(255) NOT NULL
	,AddressID INT NOT NULL
		CONSTRAINT FK_Distilleries_AddressID
		REFERENCES dbo.Addresses(AddressID)
	,VenueID INT NOT NULL
		CONSTRAINT FK_Distilleries_VenueID
		REFERENCES dbo.Venues(VenueID)
	,OpeningDate DATETIME NOT NULL
	,ClosingDate DATETIME
	)

CREATE TABLE dbo.Spirits(
	SpiritID INT NOT null
		CONSTRAINT PK_Spirits
		PRIMARY KEY IDENTITY
	,SpiritName NVARCHAR(255) NOT NULL
	,SpiritTypeID INT NOT NULL
		CONSTRAINT FK_Spirits_SpiritTypeID
		REFERENCES ref.SpiritTypes(SpiritTypeID)
	)

/*

DROP TABLE dbo.Spirits
DROP TABLE dbo.Distilleries
DROP TABLE ref.SpiritTypes
DROP TABLE ref.SpiritFamilesS

*/