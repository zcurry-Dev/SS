--
USE SceneSwarm01

CREATE TABLE ref.CiderType(
	CiderTypeID INT NOT NULL
		CONSTRAINT PK_CiderType
		PRIMARY KEY IDENTITY
	,CiderType NVARCHAR(255) NOT NULL
	)

INSERT INTO ref.CiderType
VALUES
('Dry')
,('Off-Dry')
,('Semi-Dry')

CREATE TABLE ref.CiderFlavor(
	CiderFlavorID INT NOT NULL
		CONSTRAINT PK_CiderFlavor
		PRIMARY KEY IDENTITY
	,CiderFlavor NVARCHAR(255) NOT NULL
	)

INSERT INTO ref.CiderFlavor
VALUES
('Apple')
,('Pear')
,('Rosé')
,('Blood Orange')
,('Black Cherry')
,('Peach')
,('Watermelon')

CREATE TABLE dbo.Cidery(
	CideryID INT NOT NULL
		CONSTRAINT PK_Cidery
		PRIMARY KEY IDENTITY
	,CideryName NVARCHAR(255) NOT NULL
	,AddressID INT NOT NULL
		CONSTRAINT FK_Cidery_AddressID
		REFERENCES dbo.SSAddress(AddressID)
	,VenueID INT NOT NULL
		CONSTRAINT FK_Cidery_VenueID
		REFERENCES dbo.Venue(VenueID)
	,OpeningDate DATETIME NOT NULL
	,ClosingDate DATETIME
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Cidery_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Cidery_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.Cider(
	CiderID INT NOT null
		CONSTRAINT PK_Cider
		PRIMARY KEY IDENTITY
	,CiderName NVARCHAR(255) NOT NULL
	,CiderTypeID INT NOT NULL
		CONSTRAINT FK_Cider_CiderTypeID
		REFERENCES ref.CiderType(CiderTypeID)
	,CiderFlavorID INT NOT NULL
		CONSTRAINT FK_Cider_CiderFlavorID
		REFERENCES ref.CiderFlavor(CiderFlavorID)
	,CideryID INT NOT NULL
		CONSTRAINT FK_Cider_CideryID
		REFERENCES dbo.Cidery(CideryID)
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Cider_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Cider_CreatedDate
		DEFAULT GETDATE()
	)

/*

DROP TABLE dbo.Cider
DROP TABLE dbo.Cidery
DROP TABLE ref.CiderFlavor
DROP TABLE ref.CiderType

*/