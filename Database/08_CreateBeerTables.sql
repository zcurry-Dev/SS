--
USE SceneSwarm01

CREATE TABLE ref.BeerFamily(
	BeerFamilyID INT NOT NULL
		CONSTRAINT PK_BeerFamily
		PRIMARY KEY IDENTITY
	,BeerFamily NVARCHAR(255) NOT NULL
	)

INSERT INTO ref.BeerFamily
VALUES
('Ale')
,('Lager')
,('Hybrid')

CREATE TABLE ref.BeerType(
	BeerTypeID INT NOT NULL
		CONSTRAINT PK_BeerType
		PRIMARY KEY IDENTITY
	,BeerType NVARCHAR(255) NOT NULL
	,BeerFamilyID INT NOT NULL
		CONSTRAINT FK_BeerType_BeerFamilyID
		REFERENCES ref.BeerFamily(BeerFamilyID)
	)

INSERT INTO ref.BeerType
VALUES
('Ale', 1)
,('Lager', 2)
,('Stout', 1)
,('IPA', 1)
,('Pilsner', 2)
,('Porter', 1)
,('Session', 3)
,('Bock', 2)

CREATE TABLE ref.BeerTypeSpecific(
	BeerTypeSpecificID INT NOT NULL
		CONSTRAINT PK_BeerTypeSpecific
		PRIMARY KEY IDENTITY
	,BeerTypeSpecific NVARCHAR(255) NOT NULL
	,BeerTypeID INT NOT NULL
		CONSTRAINT FK_BeerTypeSpecific_BeerTypeID
		REFERENCES ref.BeerType(BeerTypeID)
	)

INSERT INTO ref.BeerTypeSpecific
VALUES
('Ale', 1)
,('Lager', 2)
,('Stout', 3)
,('IPA', 4)
,('Pilsner', 5)
,('Porter', 6)
,('Session', 7)
,('Bock', 8)

CREATE TABLE dbo.Brewery(
	BreweryID INT NOT NULL
		CONSTRAINT PK_Brewery
		PRIMARY KEY IDENTITY
	,BreweryName NVARCHAR(255) NOT NULL
	,AddressID INT NOT NULL
		CONSTRAINT FK_Brewery_AddressID
		REFERENCES dbo.SSAddress(AddressID)
	,VenueID INT NOT NULL
		CONSTRAINT FK_Brewery_VenueID
		REFERENCES dbo.Venue(VenueID)
	,OpeningDate DATETIME NOT NULL	
	,ClosingDate DATETIME
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Brewery_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Brewery_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.Beer(
	BeerID INT NOT null
		CONSTRAINT PK_Beer
		PRIMARY KEY IDENTITY
	,BeerName NVARCHAR(255) NOT NULL
	,BeerTypeSpecificID INT NOT NULL
		CONSTRAINT FK_Beer_BeerTypeSpecificID
		REFERENCES ref.BeerTypeSpecific(BeerTypeSpecificID)
	,BreweryID INT NOT NULL
		CONSTRAINT FK_Beer_BreweryID
		REFERENCES dbo.Brewery(BreweryID)
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Beer_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Beer_CreatedDate
		DEFAULT GETDATE()
	)

/*

DROP TABLE dbo.Beer
DROP TABLE dbo.Brewery
DROP TABLE ref.BeerTypeSpecific
DROP TABLE ref.BeerType
DROP TABLE ref.BeerFamily

*/