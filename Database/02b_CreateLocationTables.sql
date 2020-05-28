CREATE TABLE loc.WorldRegion(
	WorldRegionID INT NOT NULL
		CONSTRAINT PK_WorldRegion
		PRIMARY KEY IDENTITY
	,WorldRegionCountry INT NOT NULL
		CONSTRAINT FK_WorldRegion_WorldRegionCountry
		REFERENCES const.Country(CountryID)
	,WorldRegionAbbreviation NVARCHAR(10) NULL
	,WorldRegionName NVARCHAR(255) NOT NULL
	,WorldRegionType NVARCHAR(255) NOT NULL
)

INSERT INTO loc.WorldRegion
VALUES
(41, 'ON','Ontario', 'Province')
,(77, NULL,'Île-de-France', 'Region')

CREATE TABLE loc.City(
	CityID INT NOT NULL
		CONSTRAINT PK_City
		PRIMARY KEY IDENTITY
	,CityName NVARCHAR(255) NOT NULL
	,ClosestMajorCityID INT NULL
		CONSTRAINT FK_City_ClosestMajorCityID
		REFERENCES loc.City(CityID)
	,StateID INT NOT NULL
		CONSTRAINT FK_City_StateID
		REFERENCES const.USState(StateID)
	,MajorCity BIT NOT NULL
		CONSTRAINT DF_City_MajorCity
		DEFAULT 0
)

INSERT INTO loc.City
VALUES
('Austin', 1, 43, 1)
,('Buda', 1, 43, 0)
,('Columbus', 3, 35, 0)
,('Walnut Creek', NULL, 5, 0)
,('Roswell', NULL, 31, 0)

CREATE TABLE loc.WorldCity(
	WorldCityID INT NOT NULL
		CONSTRAINT PK_WorldCity
		PRIMARY KEY IDENTITY
	,CityName NVARCHAR(255) NOT NULL
	,ClosestMajorCityID INT NULL
		CONSTRAINT FK_WorldRegion_ClosestMajorCityID
		REFERENCES loc.WorldCity(WorldCityID)
	,WorldRegionID INT NOT NULL
		CONSTRAINT FK_WorldCity_WorldRegion
		REFERENCES loc.WorldRegion(WorldRegionID)
	,MajorCity BIT NOT NULL
		CONSTRAINT DF_WorldCity_MajorCity
		DEFAULT 0
)

INSERT INTO loc.WorldCity
VALUES
('Toronto', 1, 1, 1)
,('Burlington', 1, 1, 0)
,('Paris', 3, 2, 1)

CREATE TABLE loc.ZipCode(
	ZipCodeID INT NOT NULL
		CONSTRAINT PK_ZipCodeID		
		PRIMARY KEY IDENTITY
	,ZipCode INT NOT NULL
	,CityID INT NOT NULL
		CONSTRAINT FK_ZipCode_CityID
		REFERENCES loc.City(CityID)
)

INSERT INTO loc.ZipCode
VALUES
(78610,1)
,(78613,1)
,(78617,1)
,(78641,1)
,(78652,1)
,(78653,1)
,(78660,1)
,(78664,1)
,(78681,1)
,(78701,1)
,(78702,1)
,(78703,1)
,(78704,1)
,(78705,1)
,(78712,1)
,(78717,1)
,(78719,1)
,(78721,1)
,(78722,1)
,(78723,1)
,(78724,1)
,(78725,1)
,(78726,1)
,(78727,1)
,(78728,1)
,(78729,1)
,(78730,1)
,(78731,1)
,(78732,1)
,(78733,1)
,(78734,1)
,(78735,1)
,(78736,1)
,(78737,1)
,(78738,1)
,(78739,1)
,(78741,1)
,(78742,1)
,(78744,1)
,(78745,1)
,(78746,1)
,(78747,1)
,(78748,1)
,(78749,1)
,(78750,1)
,(78751,1)
,(78752,1)
,(78753,1)
,(78754,1)
,(78756,1)
,(78757,1)
,(78758,1)
,(78759,1)
,(78610,2)

/*

DROP TABLE loc.ZipCode
DROP TABLE loc.WorldCity
DROP TABLE loc.City
DROP TABLE loc.WorldRegion

*/