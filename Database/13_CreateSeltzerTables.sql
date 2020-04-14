--
USE SceneSwarm01

CREATE TABLE ref.SeltzerFlavor(
	SeltzerFlavorID INT NOT NULL
		CONSTRAINT PK_SeltzerFlavor
		PRIMARY KEY IDENTITY
	,SeltzerFlavor NVARCHAR(255) NOT NULL
	)

INSERT INTO ref.SeltzerFlavor
VALUES
('Apple')
,('Pear')
,('Rosé')
,('Blood Orange')
,('Black Cherry')
,('Peach')
,('Watermelon')

CREATE TABLE dbo.Seltzery(
	SeltzeryID INT NOT NULL
		CONSTRAINT PK_Seltzery
		PRIMARY KEY IDENTITY
	,SeltzeryName NVARCHAR(255) NOT NULL
	,VenueID INT NOT NULL
		CONSTRAINT FK_Seltzery_VenueID
		REFERENCES dbo.Venue(VenueID)
	,OpeningDate DATETIME NOT NULL
	,ClosingDate DATETIME
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Seltzery_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Seltzery_CreatedDate
		DEFAULT GETDATE()
	)

CREATE TABLE dbo.Seltzer(
	SeltzerID INT NOT null
		CONSTRAINT PK_Seltzer
		PRIMARY KEY IDENTITY
	,SeltzerName NVARCHAR(255) NOT NULL
	,SeltzerFlavorID INT NOT NULL
		CONSTRAINT FK_Seltzer_SeltzerFlavorID
		REFERENCES ref.SeltzerFlavor(SeltzerFlavorID)
	,SeltzeryID INT NULL
		CONSTRAINT FK_Seltzer_SeltzeryID
		REFERENCES dbo.Seltzer(SeltzerID)
	,BreweryID INT NULL
		CONSTRAINT FK_Seltzer_BreweryID
		REFERENCES dbo.Brewery(BreweryID)
	,CideryID INT NULL
		CONSTRAINT FK_Seltzer_CideryID
		REFERENCES dbo.Cidery(CideryID)
	,MeaderyID INT NULL
		CONSTRAINT FK_Seltzer_MeaderyID
		REFERENCES dbo.Meadery(MeaderyID)
	,CreatedBy INT NOT NULL
		CONSTRAINT Seltzer_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Seltzer_CreatedDate
		DEFAULT GETDATE()
	)

/*

DROP TABLE dbo.Seltzer
DROP TABLE dbo.Seltzery
DROP TABLE ref.SeltzerFlavor

*/