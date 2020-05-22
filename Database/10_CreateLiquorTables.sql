CREATE TABLE ref.LiquorFamily(
	LiquorFamilyID INT NOT NULL
		CONSTRAINT PK_LiquorFamily
		PRIMARY KEY IDENTITY
	,LiquorFamily NVARCHAR(255) NOT NULL
	)

INSERT INTO ref.LiquorFamily
VALUES
('Whiskey')
,('Vodka')
,('Tequila')
,('Rum')
,('Gin')
,('Brandy')
,('Mezcal')

CREATE TABLE ref.LiquorType(
	LiquorTypeID INT NOT NULL
		CONSTRAINT PK_LiquorType
		PRIMARY KEY IDENTITY
	,LiquorType NVARCHAR(255) NOT NULL
	,LiquorFamilyID INT NOT NULL
		CONSTRAINT FK_LiquorType_LiquorFamilyID
		REFERENCES ref.LiquorFamily(LiquorFamilyID)
	)

INSERT INTO ref.LiquorType
VALUES
('Scotch Whiskey', 1)
,('Japanese Whiskey', 1)
,('Irish Whiskey', 1)
,('Canadian Whiskey', 1)
,('American Whiskey', 1)
,('Welsh Whiskey', 1)
,('Indian Whiskey', 1)
,('Vodka', 2)
,('Tequila', 3)
,('Rum', 4)
,('Gin', 5)
,('Brandy', 6)
,('Mezcal', 7)

CREATE TABLE ref.AmericanWhiskeyType(
	AmericanWhiskeyTypeID INT NOT NULL
		CONSTRAINT PK_AmericanWhiskeyType
		PRIMARY KEY IDENTITY
	,AmericanWhiskeyType NVARCHAR(255) NOT NULL
	)

INSERT INTO ref.AmericanWhiskeyType
VALUES
('Bourbon')
,('Tennessee')
,('Rye')
,('Corn')

CREATE TABLE ref.ScotchWhiskeyType(
	ScotchWhiskeyTypeID INT NOT NULL
		CONSTRAINT PK_ScotchWhiskeyType
		PRIMARY KEY IDENTITY
	,ScotchWhiskeyType NVARCHAR(255) NOT NULL
	)

INSERT INTO ref.ScotchWhiskeyType
VALUES
('Malt')
,('Grain')
,('Vatted Malt')
,('Single Malt')
,('Blend')

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
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Distillery_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Distillery_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.Liquor(
	LiquorID INT NOT null
		CONSTRAINT PK_Liquor
		PRIMARY KEY IDENTITY
	,LiquorName NVARCHAR(255) NOT NULL
	,LiquorTypeID INT NOT NULL
		CONSTRAINT FK_Liquor_LiquorTypeID
		REFERENCES ref.LiquorType(LiquorTypeID)
	,AmericanWhiskeyTypeID INT NULL
		CONSTRAINT FK_Liquor_AmericanWhiskeyTypeID
		REFERENCES ref.AmericanWhiskeyType(AmericanWhiskeyTypeID)
	,ScotchWhiskeyTypeID INT NULL
		CONSTRAINT FK_Liquor_ScotchWhiskeyTypeID
		REFERENCES ref.ScotchWhiskeyType(ScotchWhiskeyTypeID)
	,DistilleryID INT NULL
		CONSTRAINT FK_Liquor_DistilleryID
		REFERENCES dbo.Distillery(DistilleryID)
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Liquor_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Liquor_CreatedDate
		DEFAULT GETDATE()
	)

/*

DROP TABLE dbo.Liquor
DROP TABLE dbo.Distillery
DROP TABLE ref.ScotchWhiskeyType
DROP TABLE ref.AmericanWhiskeyType
DROP TABLE ref.LiquorType
DROP TABLE ref.LiquorFamily

*/