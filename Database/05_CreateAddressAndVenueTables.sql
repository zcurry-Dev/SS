--
USE SceneSwarm01

CREATE TABLE dbo.SSAddress(
	AddressID INT NOT NULL
		CONSTRAINT PK_AddressID
		PRIMARY KEY IDENTITY
	,StreetAddress NVARCHAR(255) NOT NULL
	,StreetAddress2 NVARCHAR(255)
	,CityID INT NOT NULL
		CONSTRAINT FK_Address_CityID
		REFERENCES const.City(CityID)
	,ZipCodeID INT NOT NULL
		CONSTRAINT FK_Address_ZipCodeID
		REFERENCES const.ZipCode(ZipCodeID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Address_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO dbo.SSAddress
VALUES
('7500 S I35', 'Apt 542', 1, 1, GETDATE())
,('450 Thornless Circle', null, 2, 54, GETDATE())

CREATE TABLE ref.VenueType(
	VenueTypeID INT NOT NULL
		CONSTRAINT PK_VenueType
		PRIMARY KEY IDENTITY
	,VenueType NVARCHAR(255)
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_VenueType_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_VenueType_CreatedDate
		DEFAULT GETDATE()
	)
	
INSERT INTO ref.VenueType
VALUES
('Concert Venue', 1, GETDATE())
,('Bar', 1, GETDATE())
,('House Show', 1, GETDATE())

CREATE TABLE dbo.Venue(
	VenueID INT NOT NULL
		CONSTRAINT PK_Venue
		PRIMARY KEY IDENTITY
	,VenueName NVARCHAR(255)
	,VenueAddressID INT NOT NULL
		CONSTRAINT FK_Venue_VenueAddressID
		REFERENCES dbo.SSAddress(AddressID)
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Venue_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME
		CONSTRAINT DF_Venue_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.VenueTypeXRef(
	VenueTypeXRefID INT NOT NULL
		CONSTRAINT PK_VenueTypeXRef
		PRIMARY KEY IDENTITY
	,VenueID INT NOT NULL
		CONSTRAINT FK_VenueTypeXRef_VenueID
		REFERENCES dbo.Venue(VenueID)
	,VenueTypeID INT NOT NULL
		CONSTRAINT FK_VenueTypeXRef_VenueTypeID
		REFERENCES ref.VenueType(VenueTypeID)
	,MainType BIT NOT NULL
		CONSTRAINT DF_VenueTypeXRef_MainType
		DEFAULT 0
	)

CREATE TABLE dbo.VenueHoursOpen(
	VenueHoursOpenID INT NOT NULL
		CONSTRAINT PK_VenueHoursOpen
		PRIMARY KEY IDENTITY
	,VenueID INT NOT NULL
		CONSTRAINT FK_VenueHoursOpen_VenueID
		REFERENCES dbo.Venue(VenueID)
	,DayOfWeekID INT NOT NULL
		CONSTRAINT FK_VenueHoursOpen_DayOfWeekID
		REFERENCES const.DaysOfWeek(DayOfWeekID)
	,HourOpen TIME NOT NULL
	,HourClose TIME NOT NULL
	)

/*

DROP TABLE dbo.VenueHoursOpen
DROP TABLE dbo.VenueTypeXRef
DROP TABLE dbo.Venue
DROP TABLE ref.VenueType
DROP TABLE dbo.SSAddress

*/