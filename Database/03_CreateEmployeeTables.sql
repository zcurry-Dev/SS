--
USE SceneSwarm01

CREATE TABLE refHR.EmploymentStatuses(
	EmploymentStatusID INT NOT NULL
		CONSTRAINT PK_EmploymentStatuses
		PRIMARY KEY IDENTITY
	,EmploymentStatus NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_EmploymentStatuses_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO refHR.EmploymentStatuses
VALUES
('Active', GETDATE())
,('Terminated', GETDATE())
,('Resigned', GETDATE())

CREATE TABLE refHR.EmployeeTitles(
	EmployeeTitleID INT NOT NULL
		CONSTRAINT PK_EmployeeTitles
		PRIMARY KEY IDENTITY
	,EmployeeTitle NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_EmployeeTitles_CreatedDate
		DEFAULT GETDATE()
)

CREATE TABLE hr.Employees(
	EmployeeID INT NOT NULL
		CONSTRAINT PK_Employees
		PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(255)
	,LastName NVARCHAR(255)
)

CREATE TABLE hr.EmployeeRecords(
	EmployeeRecordID  INT NOT NULL
		CONSTRAINT PK_EmployeeRecords
		PRIMARY KEY IDENTITY
	,EmployeeID INT NOT NULL
		CONSTRAINT FK_EmployeeRecords_EmployeeID
		REFERENCES hr.Employees(EmployeeID)	
	,EmployeeTitleID INT NOT NULL
		CONSTRAINT FK_Employees_EmployeeTitleID
		REFERENCES refHR.EmployeeTitles(EmployeeTitleID)
	,HireDate DATETIME NOT NULL
	,EmploymentStatusID INT NOT NULL
		CONSTRAINT FK_Employees_EmploymentStatusID
		REFERENCES refHR.EmploymentStatuses(EmploymentStatusID)
	,Terminated BIT NOT NULL
		CONSTRAINT DF_EmployeeRecords_Terminated
		DEFAULT 0
	,TerminationDate DATETIME NULL
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_EmployeeRecords_CreatedDate
		DEFAULT GETDATE()
)

/*

DROP TABLE hr.EmployeeRecords
DROP TABLE hr.Employees
DROP TABLE refHR.EmployeeTitles
DROP TABLE refHR.EmploymentStatuses

*/