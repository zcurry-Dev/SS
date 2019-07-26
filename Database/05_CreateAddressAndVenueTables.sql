--
USE SceneSwarm01

CREATE TABLE dbo.Addresses(
	AddressID INT NOT NULL
		CONSTRAINT PK_Addresses
		PRIMARY KEY IDENTITY
	,StreetAddress NVARCHAR(255)
	,StreetAddress2 NVARCHAR(255)
	,CityID INT NOT NULL
		CONSTRAINT FK_Addresses_CityID
		REFERENCES const.Cities(CityID)
	,ZipCode INT NOT NULL
		CONSTRAINT FK_Addresses_ZipCode
		REFERENCES const.ZipCodes(ZipCode)
	,StateID INT NOT NULL
		CONSTRAINT FK_Addresses_StateID
		REFERENCES const.States(StateID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Addresses_CreatedDate
		DEFAULT GETDATE()
)

CREATE TABLE ref.VenueTypes(
	VenueTypeID INT NOT NULL
		CONSTRAINT PK_VenueTypes
		PRIMARY KEY IDENTITY
	,VenueType NVARCHAR(255)
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_VenueTypes_CreatedBy
		REFERENCES hr.Employees(EmployeeID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_VenueTypes_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.Venues(
	VenueID INT NOT NULL
		CONSTRAINT PK_Venues
		PRIMARY KEY IDENTITY
	,VenueName NVARCHAR(255)
	,VenueAddressID INT NOT NULL
		CONSTRAINT FK_Venues_VenueAddressID
		REFERENCES dbo.Addresses(AddressID)
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Venues_CreatedBy
		REFERENCES UserSS.Users(UserID)
	,CreatedDate DATETIME
		CONSTRAINT DF_Venues_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.VenueTypeXRef(
	VenueTypeXRefID INT NOT NULL
		CONSTRAINT PK_VenueTypeXRef
		PRIMARY KEY IDENTITY
	,VenueID INT NOT NULL
		CONSTRAINT FK_VenueTypeXRef_VenueID
		REFERENCES dbo.Venues(VenueID)
	,VenueTypeID INT NOT NULL
		CONSTRAINT FK_VenueTypeXRef_VenueTypeID
		REFERENCES ref.VenueTypes(VenueTypeID)
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
		REFERENCES dbo.Venues(VenueID)
	,DayOfWeekID INT NOT NULL
		CONSTRAINT FK_VenueHoursOpen_DayOfWeekID
		REFERENCES const.DaysOfWeek(DayOfWeekID)
	,HourOpen TIME NOT NULL
	,HourClose TIME NOT NULL
	)


/*

DROP TABLE dbo.VenueHoursOpen
DROP TABLE dbo.VenueTypeXRef
DROP TABLE dbo.Venues
DROP TABLE ref.VenueTypes
DROP TABLE dbo.Addresses

*/