CREATE TABLE ref.ArtistType(
	ArtistTypeID INT NOT NULL
		CONSTRAINT PK_ArtistType
		PRIMARY KEY IDENTITY
	,ArtistType NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistType_CreatedDate
		DEFAULT GETDATE()
	)

INSERT INTO ref.ArtistType
VALUES
('Band', GETDATE())
,('Solo Artist', GETDATE())

CREATE TABLE ref.ArtistStatus(
	ArtistStatusID INT NOT NULL
		CONSTRAINT PK_ArtistStatus
		PRIMARY KEY IDENTITY
	,ArtistStatus NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistStatus_CreatedDate
		DEFAULT GETDATE()
	)

INSERT INTO ref.ArtistStatus
VALUES
('Active', GETDATE())
,('Inactive', GETDATE())
,('Hiatus', GETDATE())

CREATE TABLE dbo.Artist(
	ArtistID INT NOT NULL
		CONSTRAINT PK_Artist
		PRIMARY KEY IDENTITY
	,ArtistName NVARCHAR(255)
	,ArtistStatusID INT
		CONSTRAINT FK_Artist_ArtistStatusID
		REFERENCES ref.ArtistStatus(ArtistStatusID)
	,CareerBeginDate DATETIME NOT NULL
	,CareerEndDate DATETIME NULL
	,ArtistGroup BIT NOT NULL
		CONSTRAINT DF_Artist_ArtistGroup
		DEFAULT 0
	,UserID INT NULL
		CONSTRAINT FK_Artist_UserID
		REFERENCES ident.SSUser(UserID)
	,Verified BIT NOT NULL
		CONSTRAINT DF_Artist_Verified
		DEFAULT 0
	,HomeCountryID INT NOT NULL
		CONSTRAINT FK_Artist_HomeCountryID
		REFERENCES loc.Country(CountryID)
	,HomeUSStateID INT NULL
		CONSTRAINT FK_Artist_HomeUSStateID
		REFERENCES loc.USState(StateID)
	,HomeUSCityID INT NULL
		CONSTRAINT FK_Artist_HomeUSCityID
		REFERENCES loc.City(CityID)
	,HomeUSZipCodeID INT NULL
		CONSTRAINT FK_Artist_HomeUSZipCodeID
		REFERENCES loc.ZipCode(ZipCodeID)
	,HomeWorldRegionID INT NULL
		CONSTRAINT FK_Artist_HomeWorldRegionID
		REFERENCES loc.WorldRegion(WorldRegionID)
	,HomeWorldCityID INT NULL
		CONSTRAINT FK_Artist_HomeWorldCityID
		REFERENCES loc.WorldCity(WorldCityID)
	,CurrentCountryID INT NOT NULL
		CONSTRAINT FK_Artist_CurrentCountryID
		REFERENCES loc.Country(CountryID)
	,CurrentUSCityID INT NULL
		CONSTRAINT FK_Artist_CurrentUSCityID
		REFERENCES loc.City(CityID)
	,CurrentWorldCityID INT NULL
		CONSTRAINT FK_Artist_CurrentWorldCityID
		REFERENCES loc.WorldCity(WorldCityID)
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Artist_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Artist_CreatedDate
		DEFAULT GETDATE()
	)

Declare @Now datetime = GETDATE()

INSERT INTO dbo.Artist
VALUES						
('Silverstein',					1, '02-01-2000',	NULL, 1, NULL, 1, 41,	NULL,	NULL,	NULL,	2,		2,		1, NULL,	NULL, 1, @Now)
,('Beartooth',					1, '01-01-2012',	NULL, 1, NULL, 1, 1,	35,		3,		NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Chunk! No, Captain Chunk!',	1, '01-01-2007',	NULL, 1, NULL, 1, 77,	NULL,	NULL,	NULL,	1,		1,		1, NULL,	NULL, 1, @Now)
,('The Story So Far',			1, '01-01-2007',	NULL, 1, NULL, 1, 1,	5,		4,		NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('John Denver',				1, '01-01-1965',	NULL, 0, NULL, 1, 1,	31,		5,		NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)

--
--
,('68',                                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('1208',                                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('3OH!3',                                1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('A Loss For Words',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('A Lot Like Birds',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('A Wilhelm Scream',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Action Item',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Against All Authority',                1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Against Me',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Air Dubai',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Alesana',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Alison Weiss',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Alive Like Me',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Alkaline Trio',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('All Time Low',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Allister',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Amber Pacific',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('American Eyes',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('American Pinup',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Amity Affliction',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Anarbor',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Anberlin',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Andrew W.K.',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Anti-Flag',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Antifreeze',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Armor For Sleep',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Artist Vs. Poet',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('As It Is',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Assuming We Survive',                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Atmosphere',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Atreyu',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Attack! Attack!',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Audio Karate',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('August Burns Red',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Authority Zero',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Autopilot Off',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Avenged Sevenfold',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Avoid One Thing',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Avoid One Thing; Matt Skiba',          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Baby Baby',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Bad Religion',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Ballyhoo!',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Bayside',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Beautiful Bodies',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Bedouin Soundclash',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Beebs and Her Money Maker',            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Being As An Ocean',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Big Chocolate',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Big D and the Kids Table',             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Black Veil Brides',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Blacklist Royals',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Bleed The Dream',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Bleeding Through',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('blessthefall',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Blink 182',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Born Of Osiris',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Bouncing Souls',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Boys Night Out',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Brain Marquis',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Breathe Carolina',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Breathe In',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Brian Marquis',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Bring Me The Horizon',                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Broadway Calls',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Candy Hearts',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Cane Hill',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Chase Long Beach',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Chelsea Grin',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Chiodos',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Chronic Future',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Chuck Ragan',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Citizen',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Closure In Moscow',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Cobra Skulls',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Coheed and Cambria',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Cold Forty Three',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Coldrain',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Color Morale, The',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Confide',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Cordalene',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Crash Romeo',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Crown The Empire',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Cruel Hand',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Dag Nasty',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Dangerkids',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Daytrader',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Deals Gone Bad',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Death by Stereo',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Death On Wednesday',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Defeater',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Denver Harbor',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Descendents',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Destruction Made Simple',              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Divided By Friday',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Divit',                                1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Down To Earth Approach',               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Driver Friendly',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Dropkick Murphys',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Eight Fingers Down',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Elder Brother',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Emarosa',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Escape The Fate',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Every Time I Die',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Face to Face',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Fake Problems',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Fall Out Boy',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Falling In Reverse',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Fear Before The March Of Flames',      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Fight Fair',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Finch',                                1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Fireworks',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Fit For A King',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Five Knives',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Flatfoot 56',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Flogging Molly',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('For The Foxes',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('For Today',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Forever Came Calling',                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Forever The Sickest Kids',             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Four Year Strong',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('From Autumn to Ashes',                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('From First To Last',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Front Porch Step',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('G.B.H.',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Gatsby''s American Dream',             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Get Scared',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Ghost Town',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Glassjaw',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Go Betty Go',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Go Radio',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Gogol Bordello',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Goldhouse',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Good Charlotte',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Good Riddance',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Greely Estates',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Gym Class Heroes',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('H2O',                                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Halifax',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Handguns',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Hands Like Houses',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Have Mercy',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Hawthorne Heights',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Hazen Street',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Hellogoodbye',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Helmet',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Hidden In Plain View',                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Hopesfall',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Hostage Calm',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Hot Water Music',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Hundredth',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('I Am Ghost',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('I Am The Avalanche',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('I Call Fives',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('I Fight Dragons',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('I Killed The Prom Queen',              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('I See Stars',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('I The Mighty',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('I Wrestled A Bear Once',               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Ice Nine Kills',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('In Fear And Faith',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Into It. Over It.',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Issues',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Itch',                                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Jackson United',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Jersey',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Joan Jett And The Blackhearts',        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Jukebox Romantics',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Kicked in the Head',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Kill Your Idols',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Knuckle Puck',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Koji',                                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Koo Koo Kanga Roo',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Kosha Dillz',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Lagwagon',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Lee Corey Oswald',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Left Alone',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Less Than Jake',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Letlive',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Letter Kills',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Lightweight Holiday',                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Like Pacific',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Longway',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Los Kung-Fu Monkeys',                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Lost In Society',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Love Equals Death',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Mad Caddies',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Madcap',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Mae',                                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Major League',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Make Do And Mend',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Man Overboard',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Manic Hispanic',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Marmozets',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Masked Intruder',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Matchbook Romance',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Maxeen',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Mayday Parade',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('MC Lars',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Me First and the Gimme Gimmes',        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Mêlée',                                1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Memphis May Fire',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Mest',                                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Metro Station',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Mi6',                                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Middle Finger Salute',                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Midtown',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Mighty Mongo',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Millencolin',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Miss May I',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Missing 23rd',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Mistapes',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Mixtapes',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Mod Sun',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Moneen',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Moose Blood',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Motion City Soundtrack',               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Motionless In White',                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Murderland',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Murphy''s Law',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('MXPX',                                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Name Taken',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Nathen Maxwell',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Near Miss',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Neck Deep',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Neo Geo',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Never Shout Never',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('New Beat Fund',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('New Found Glory',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('No Bragging Rights',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('No Use For A Name',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('NOFX',                                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('None More Black',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Northington',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Not On Tour',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Nural',                                1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Of Mice & Men',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Of Mice And Men',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('One Man Army',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Our Last Night',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Ozma',                                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Paramore',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Parkway Drive',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Pennywise',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Pepper',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Piebald',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Pierce The Veil',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Pink Slips, The',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Pistol Grip',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Plain White T''s',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Poison the Well',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Polar Bear Club',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Protest The Hero',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Pulley',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('PUP',                                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Pvris',                                1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Reach the Sky',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Real Friends',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Relient K',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Riff Raff',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Rise Against',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Riverboat Gamblers',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Roam',                                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Rob Lynch',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Roses Are Red',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Rotting Out',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Royden',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Rufio',                                1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('S.T.U.N.',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Safe to Say',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Saves the Day',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('SayWeCanFly',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Scotch Greens',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Seaway',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('SECRETS',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Senses Fail',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Set It Off',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Set Your Goals',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Sharks',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Shiragirl',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Shy Kidx',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Simple Plan',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Skip The Foreplay',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Slaves',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Sleeping With Sirens',                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Slick Shoes',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Slightly Stoopid',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Sloppy Meateaters',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('So They Say',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Somerset',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Sparks The Rescue',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Stairwell',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('State Champs',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Story of the Year',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Strawberry Blondes',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Stray from the Path',                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Street Dogs',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Strike Anywhere',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Strung Out',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Stutterfly',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Sugarcult',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Sum 41',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Swingin'' Utters',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('SYKES',                                1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Taking Back Sunday',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Teenage Bottlerocket',                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Terror',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Academy Is...',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The American Scene',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Ataris',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Banner',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Beautiful Bodies',                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Black Dahlia Murder',              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Bouncing Souls',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Briggs',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Casualties',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Damned',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Devil Wears Prada',                1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Dirty Nil',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Early November',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Expendables',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Exposed',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Eyeliners',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The F Ups',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Flatliners',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Ghost Inside',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Interrupters',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Jukebox Romantics',                1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Lawrence Arms',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Maine',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Matches',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Menzingers',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Mighty Mighty Bosstones',          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Movielife',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Offspring',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Phenomenauts',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Protomen',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Real McKenzies',                   1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Reverend Peyton''s Big Damn Band', 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Suicide Machines',                 1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Summer Set',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Sunstreak',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Swellers',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Unseen',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Used',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Wonder Years',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('The Word Alive',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('This Time Next Year',                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('This Wild Life',                       1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Thrice',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Throw Rag',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Throwdown',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Thursday',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Time Again',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Title Fight',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Tonight Alive',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Too Rude',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Transit',                              1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Trophy Eyes',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Tsunami Bomb',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('U.S. Bombs',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Underminded',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Underoath',                            1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Unsung Zeros',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Useless I.D.',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Valient Thor',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Vanna',                                1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('VCR',                                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Veil of Maya',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Vendetta Red',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Versa Emerge',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('VersaEmerge',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Wage War',                             1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Waterparks',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Watsky',                               1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('We Are The In Crowd',                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('We Are The Ocean',                     1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('We Came As Romans',                    1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Well Hung Heart',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Western Waste',                        1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Whitechapel',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('With Confidence',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Woe, Is Me',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Word Alive, The',                      1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Yellowcard',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Young Guns',                           1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Young London',                         1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Youth Group',                          1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Zao',                                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)
,('Zox',                                  1, @Now,		NULL, 1, NULL, 1, 1,	NULL,	NULL,	NULL,	NULL,	NULL,	1, NULL,	NULL, 1, @Now)








CREATE TABLE dbo.ArtistPhoto(	
	ArtistPhotoID INT NOT NULL
		CONSTRAINT PK_ArtistPhoto
		PRIMARY KEY IDENTITY
	,ArtistID INT NOT NULL
		CONSTRAINT FK_ArtistPhoto_ArtistID
		REFERENCES dbo.Artist(ArtistID)
	,PhotoPath NVARCHAR(255) NOT NULL
	,PhotoDescription NVARCHAR(255) NOT NULL
	,PhotoFileContentType NVARCHAR(255) NOT NULL
	,PhotoFileExt NVARCHAR(255) NOT NULL
	,PhotoFileName NVARCHAR(255) NOT NULL
	,DateAdded DATETIME NOT NULL
		CONSTRAINT DF_ArtistPhoto_DateAdded
		DEFAULT GETDATE()
	,IsMain BIT NOT NULL
		CONSTRAINT DF_ArtistPhoto_IsMain
		DEFAULT 0
)

CREATE TABLE dbo.ArtistTypeXRef(
	ArtistTypeXRefID INT NOT NULL
		CONSTRAINT PK_ArtistTypeXRef
		PRIMARY KEY IDENTITY
	,ArtistID INT NOT NULL
		CONSTRAINT FK_ArtistTypeXRef_ArtistID
		REFERENCES dbo.Artist(ArtistID)
	,ArtistTypeID INT NOT NULL
		CONSTRAINT FK_ArtistTypeXRef_ArtistTypeID
		REFERENCES ref.ArtistType(ArtistTypeID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistTypeXRef_CreatedDate
		DEFAULT GETDATE()
)

CREATE TABLE dbo.ArtistGroupMember(
	ArtistGroupMemberID INT NOT NULL
		CONSTRAINT PK_ArtistGroupMember
		PRIMARY KEY IDENTITY
	,ArtistID INT NOT NULL	
		CONSTRAINT FK_ArtistGroupMember_ArtistTypeID
		REFERENCES ref.ArtistType(ArtistTypeID)
	,JoinDate DATETIME NOT NULL
	,LeaveDate DATETIME NULL
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_ArtistGroupMember_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistGroupMember_CreatedDate
		DEFAULT GETDATE()
)

CREATE TABLE ref.ArtistGroupMemberRole(
	ArtistGroupMemberRoleID INT NOT NULL
		CONSTRAINT PK_ArtistGroupMemberRole
		PRIMARY KEY IDENTITY
	,ArtistGroupMemberRole NVARCHAR(255) NOT NULL
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_ArtistGroupMemberRole_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistGroupMemberRole_CreatedDate
		DEFAULT GETDATE()
	)

INSERT INTO ref.ArtistGroupMemberRole 
VALUES
('Lead Vocals', 1, GETDATE())
,('Guitar', 1, GETDATE())
,('Bass', 1, GETDATE())
,('Drums',1, GETDATE())

CREATE TABLE dbo.ArtistGroupMemberRolesXRef(
	ArtistGroupMemberRolesXRefID INT NOT NULL
		CONSTRAINT PK_ArtistGroupMemberRolesXRef
		PRIMARY KEY IDENTITY
	,ArtistGroupMemberID INT NOT NULL
		CONSTRAINT FK_ArtistGroupMemberRolesXRef_ArtistGroupMemberID
		REFERENCES dbo.ArtistGroupMember(ArtistGroupMemberID)
	,ArtistGroupMemberRoleID INT NOT NULL
		CONSTRAINT FK_ArtistGroupMemberRolesXRef_ArtistGroupMemberRoleID
		REFERENCES ref.ArtistGroupMemberRole(ArtistGroupMemberRoleID)
	,StartDate DATETIME NOT NULL
	,EndDate DATETIME NULL
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_ArtistGroupMemberRolesXRef_CreatedDate
		DEFAULT GETDATE()
	)

/*

DROP TABLE dbo.ArtistGroupMemberRolesXRef
DROP TABLE ref.ArtistGroupMemberRole
DROP TABLE dbo.ArtistGroupMember
DROP TABLE dbo.ArtistTypeXRef
DROP TABLE dbo.ArtistPhoto
DROP TABLE dbo.Artist
DROP TABLE ref.ArtistStatus
DROP TABLE ref.ArtistType

*/