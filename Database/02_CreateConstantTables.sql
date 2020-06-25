CREATE TABLE const.DaysOfWeek(
	DayOfWeekID INT NOT NULL
		CONSTRAINT PK_DaysOfWeekID
		PRIMARY KEY IDENTITY
	,DayOfWeekName NVARCHAR(10)
	,DayOfWeekAbbreviation NVARCHAR(5)
	,DayOfWeekLetterAbbreviation NVARCHAR(2)
	,Weekend BIT NOT NULL
	)

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

*/