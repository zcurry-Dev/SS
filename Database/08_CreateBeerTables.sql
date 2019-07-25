--
USE SceneSwarm01

CREATE TABLE ref.BeerFamilies(
	BeerFamilyID INT NOT NULL
		CONSTRAINT PK_BeerFamilies
		PRIMARY KEY IDENTITY
	,BeerFamily NVARCHAR(255) NOT NULL
	)

CREATE TABLE ref.BeerTypes(
	BeerTypeID INT NOT NULL
		CONSTRAINT PK_BeerTypes
		PRIMARY KEY IDENTITY
	,BeerType NVARCHAR(255) NOT NULL
	,BeerFamilyID INT NOT NULL
		CONSTRAINT FK_BeerTypes_BeerFamilyID
		REFERENCES ref.BeerFamilies(BeerFamilyID)
	)

CREATE TABLE dbo.Breweries(
	BreweryID INT NOT NULL
		CONSTRAINT PK_Breweries
		PRIMARY KEY IDENTITY
	,BreweryName NVARCHAR(255) NOT NULL
	,AddressID INT NOT NULL
		CONSTRAINT FK_Breweries_AddressID
		REFERENCES dbo.Addresses(AddressID)
	,VenueID INT NOT NULL
		CONSTRAINT FK_Breweries_VenueID
		REFERENCES dbo.Venues(VenueID)
	,OpeningDate DATETIME NOT NULL
	,ClosingDate DATETIME
	)

CREATE TABLE dbo.Beers(
	BeerID INT NOT null
		CONSTRAINT PK_Beers
		PRIMARY KEY IDENTITY
	,BeerName NVARCHAR(255) NOT NULL
	,BeerTypeID INT NOT NULL
		CONSTRAINT FK_Beers_BeerTypeID
		REFERENCES ref.BeerTypes(BeerTypeID)
	)

/*

DROP TABLE dbo.Beers
DROP TABLE dbo.Breweries
DROP TABLE ref.BeerTypes
DROP TABLE ref.BeerFamilies

*/