--
USE SceneSwarm01

CREATE TABLE ref.WineFamily(
	WineFamilyID INT NOT NULL
		CONSTRAINT PK_WineFamily
		PRIMARY KEY IDENTITY
	,WineFamily NVARCHAR(255) NOT NULL
	)

INSERT INTO ref.WineFamily
VALUES
('Red')
,('White')
,('Rosé')
,('Sparkling')
,('Dessert')

CREATE TABLE ref.WineType(
	WineTypeID INT NOT NULL
		CONSTRAINT PK_WineType
		PRIMARY KEY IDENTITY
	,WineType NVARCHAR(255) NOT NULL
	,WineFamilyID INT NOT NULL
		CONSTRAINT FK_WineType_WineFamilyID
		REFERENCES ref.WineFamily(WineFamilyID)
	)

INSERT INTO ref.WineType
VALUES
('Sweet Red', 1)
,('Fruity Dry Red', 1)
,('Herbal Dry Red', 1)
,('Red Blend', 1)
,('Dry White', 2)
,('Sweet White', 2)
,('White Blend', 2)
,('Off-Dry Rosé', 3)
,('Dry Rosé', 3)
,('Rosé Blend', 3)
,('White Sparkling', 4)
,('Red Sparkling', 4)
,('Rosé Sparkling', 4)
,('Sparkling Blend', 4)
,('Nutty Oxidized Fortified', 5)
,('White Fortified', 5)
,('Red Fortified', 5)
,('Dessert Blend', 5)


CREATE TABLE ref.WineTypeSpecific(
	WineTypeSpecificID INT NOT NULL
		CONSTRAINT PK_WineTypeSpecific
		PRIMARY KEY IDENTITY
	,WineTypeSpecific NVARCHAR(255) NOT NULL
	,WineTypeID INT NOT NULL
		CONSTRAINT FK_WineTypeSpecific_WineTypeID
		REFERENCES ref.WineType(WineTypeID)
	)

INSERT INTO ref.WineTypeSpecific
VALUES
('Sweet Red', 1)
,('Fruity Dry Red', 2)
,('Herbal Dry Red', 3)
,('Red Blend', 4)
,('Dry White', 5)
,('Sweet White', 6)
,('White Blend', 7)
,('Off-Dry Rosé', 8)
,('Dry Rosé', 9)
,('Rosé Blend', 10)
,('White Sparkling', 11)
,('Red Sparkling', 12)
,('Rosé Sparkling', 13)
,('Sparkling Blend', 14)
,('Nutty Oxidized Fortified', 15)
,('White Fortified', 16)
,('Red Fortified', 17)
,('Dessert Blend', 18)

CREATE TABLE dbo.Winery(
	WineryID INT NOT NULL
		CONSTRAINT PK_Winery
		PRIMARY KEY IDENTITY
	,WineryName NVARCHAR(255) NOT NULL
	,AddressID INT NOT NULL
		CONSTRAINT FK_Winery_AddressID
		REFERENCES dbo.SSAddress(AddressID)
	,VenueID INT NOT NULL
		CONSTRAINT FK_Winery_VenueID
		REFERENCES dbo.Venue(VenueID)
	,OpeningDate DATETIME NOT NULL
	,ClosingDate DATETIME
	,Vinyard BIT NOT NULL		
		CONSTRAINT DF_Winery_Vinyard
		DEFAULT 0	
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Winery_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Winery_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.Wine(
	WineID INT NOT null
		CONSTRAINT PK_Wine
		PRIMARY KEY IDENTITY
	,WineName NVARCHAR(255) NOT NULL
	,WineTypeID INT NOT NULL
		CONSTRAINT FK_Wine_WineTypeID
		REFERENCES ref.WineType(WineTypeID)
	,WineryID INT NOT NULL
		CONSTRAINT FK_Wine_WineryID
		REFERENCES dbo.Winery(WineryID)
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Wine_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Wine_CreatedDate
		DEFAULT GETDATE()
	)

/*

DROP TABLE dbo.Wine
DROP TABLE dbo.Winery
DROP TABLE ref.WineTypeSpecific
DROP TABLE ref.WineType
DROP TABLE ref.WineFamily

*/