CREATE TABLE refHR.EmploymentStatus(
	EmploymentStatusID INT NOT NULL
		CONSTRAINT PK_EmploymentStatus
		PRIMARY KEY IDENTITY
	,EmploymentStatus NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_EmploymentStatus_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO refHR.EmploymentStatus
VALUES
('Active', GETDATE())
,('Terminated', GETDATE())
,('Resigned', GETDATE())

CREATE TABLE refHR.EmployeeTitle(
	EmployeeTitleID INT NOT NULL
		CONSTRAINT PK_EmployeeTitle
		PRIMARY KEY IDENTITY
	,EmployeeTitle NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_EmployeeTitle_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO refHR.EmployeeTitle
VALUES
('President', GETDATE())
,('Director', GETDATE())
,('CSR', GETDATE())

CREATE TABLE hr.Employee(
	EmployeeID INT NOT NULL
		CONSTRAINT PK_Employee
		PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(255)
	,LastName NVARCHAR(255)
)

INSERT INTO hr.Employee
VALUES
('Zachary', 'Curry')

CREATE TABLE hr.EmployeeRecord(
	EmployeeRecordID  INT NOT NULL
		CONSTRAINT PK_EmployeeRecord
		PRIMARY KEY IDENTITY
	,EmployeeID INT NOT NULL
		CONSTRAINT FK_EmployeeRecord_EmployeeID
		REFERENCES hr.Employee(EmployeeID)	
	,EmployeeTitleID INT NOT NULL
		CONSTRAINT FK_Employee_EmployeeTitleID
		REFERENCES refHR.EmployeeTitle(EmployeeTitleID)
	,HireDate DATETIME NOT NULL
	,EmploymentStatusID INT NOT NULL
		CONSTRAINT FK_Employee_EmploymentStatusID
		REFERENCES refHR.EmploymentStatus(EmploymentStatusID)
	,Terminated BIT NOT NULL
		CONSTRAINT DF_EmployeeRecord_Terminated
		DEFAULT 0
	,TerminationDate DATETIME NULL
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_EmployeeRecord_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO hr.EmployeeRecord
VALUES
(1, 1, GETDATE(), 1, 0, null, GETDATE());

/*

DROP TABLE hr.EmployeeRecord
DROP TABLE hr.Employee
DROP TABLE refHR.EmployeeTitle
DROP TABLE refHR.EmploymentStatus

*/