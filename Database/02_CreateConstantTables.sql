--
USE SceneSwarm01

CREATE TABLE const.USState(
	StateID INT NOT NULL
		CONSTRAINT PK_USState
		PRIMARY KEY IDENTITY
	,StateAbbreviation NVARCHAR(2) NOT NULL
	,StateName NVARCHAR(255) NOT NULL
)

CREATE TABLE const.City(
	CityID INT NOT NULL
		CONSTRAINT PK_City
		PRIMARY KEY IDENTITY
	,CityName NVARCHAR(255) NOT NULL
	,StateID INT NOT NULL
		CONSTRAINT FK_City_StateID
		REFERENCES const.USState(StateID)
)

CREATE TABLE const.ZipCode(
	ZipCodeID INT NOT NULL
		CONSTRAINT PK_ZipCodeID		
		PRIMARY KEY IDENTITY
	,ZipCode INT NOT NULL
	,CityID INT NOT NULL
		CONSTRAINT FK_ZipCode_CityID
		REFERENCES const.City(CityID)
)

CREATE TABLE const.DaysOfWeek(
	DayOfWeekID INT NOT NULL
		CONSTRAINT PK_DaysOfWeekID
		PRIMARY KEY IDENTITY
	,DayOfWeekName NVARCHAR(10)
	,DayOfWeekAbbreviation NVARCHAR(5)
	,DayOfWeekLetterAbbreviation NVARCHAR(2)
	,Weekend BIT NOT NULL
	)

INSERT INTO const.USState
VALUES
('AL','Alabama')
,('AK','Alaska')
,('AZ','Arizona')
,('AR','Arkansas')
,('CA','California')
,('CO','Colorado')
,('CT','Connecticut')
,('DE','Delaware')
,('FL','Florida')
,('GA','Georgia')
,('HI','Hawaii')
,('ID','Idaho')
,('IL','Illinois')
,('IN','Indiana')
,('IA','Iowa')
,('KS','Kansas')
,('KY','Kentucky')
,('LA','Louisiana')
,('ME','Maine')
,('MD','Maryland')
,('MA','Massachusetts')
,('MI','Michigan')
,('MN','Minnesota')
,('MS','Mississippi')
,('MO','Missouri')
,('MT','Montana')
,('NE','Nebraska')
,('NV','Nevada')
,('NH','New Hampshire')
,('NJ','New Jersey')
,('NM','New Mexico')
,('NY','New York')
,('NC','North Carolina')
,('ND','North Dakota')
,('OH','Ohio')
,('OK','Oklahoma')
,('OR','Oregon')
,('PA','Pennsylvania')
,('RI','Rhode Island')
,('SC','South Carolina')
,('SD','South Dakota')
,('TN','Tennessee')
,('TX','Texas')
,('UT','Utah')
,('VT','Vermont')
,('VA','Virginia')
,('WA','Washington')
,('WV','West Virginia')
,('WI','Wisconsin')
,('WY','Wyoming')


INSERT INTO const.City
VALUES
('Austin',43)

INSERT INTO const.ZipCode
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

INSERT INTO const.DaysOfWeek
VALUES
('Monday','Mon','M',0)
,('Tuesday','Tue','T',0)
,('Wednesday','Wed','W',0)
,('Thursday','Thurs','Th',0)
,('Friday','Fri','F',1)
,('Saturday','Sat','Sa',1)
,('Sunday','Sun','Su',1)



/*

DROP TABLE const.DaysOfWeek
DROP TABLE const.ZipCode
DROP TABLE const.City
DROP TABLE const.USState

*/