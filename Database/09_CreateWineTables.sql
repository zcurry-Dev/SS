--
USE SceneSwarm01

CREATE TABLE ref.WineFamilies(
	WineFamilyID INT NOT NULL
		CONSTRAINT PK_WineFamilies
		PRIMARY KEY IDENTITY
	,WineFamily NVARCHAR(255) NOT NULL
	)

CREATE TABLE ref.WineTypes(
	WineTypeID INT NOT NULL
		CONSTRAINT PK_WineTypes
		PRIMARY KEY IDENTITY
	,WineType NVARCHAR(255) NOT NULL
	,WineFamilyID INT NOT NULL
		CONSTRAINT FK_WineTypes_WineFamilyID
		REFERENCES ref.WineFamilies(WineFamilyID)
	)

CREATE TABLE dbo.Wineries(
	WineryID INT NOT NULL
		CONSTRAINT PK_Wineries
		PRIMARY KEY IDENTITY
	,WineryName NVARCHAR(255) NOT NULL
	,AddressID INT NOT NULL
		CONSTRAINT FK_Wineries_AddressID
		REFERENCES dbo.Addresses(AddressID)
	,VenueID INT NOT NULL
		CONSTRAINT FK_Wineries_VenueID
		REFERENCES dbo.Venues(VenueID)
	,OpeningDate DATETIME NOT NULL
	,ClosingDate DATETIME
	,Vinyard BIT NOT NULL		
		CONSTRAINT DF_Wineries_Vinyard
		DEFAULT 0
	)

CREATE TABLE dbo.Wines(
	WineID INT NOT null
		CONSTRAINT PK_Wines
		PRIMARY KEY IDENTITY
	,WineName NVARCHAR(255) NOT NULL
	,WineTypeID INT NOT NULL
		CONSTRAINT FK_Wines_WineTypeID
		REFERENCES ref.WineTypes(WineTypeID)
	)

/*

DROP TABLE dbo.Wines
DROP TABLE dbo.Wineries
DROP TABLE ref.WineTypes
DROP TABLE ref.WineFamilies

*/