--
USE SceneSwarm01

CREATE TABLE refUserSS.UserStatus(
	UserStatusID INT NOT NULL
		CONSTRAINT PK_UserStatus
		PRIMARY KEY IDENTITY
	,UserStatus NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_UserStatus_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO refUserSS.UserStatus
VALUES
('Active', GETDATE())


CREATE TABLE refUserSS.UserRole(
	UserRoleID INT NOT NULL
		CONSTRAINT PK_UserRole
		PRIMARY KEY IDENTITY
	,UserRole NVARCHAR(255) NOT NULL
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_UserRole_CreatedDate
		DEFAULT GETDATE()
)

CREATE TABLE UserSS.SSUser(
	UserID INT NOT NULL
		CONSTRAINT PK_UserID
		PRIMARY KEY IDENTITY
	,UserName NVARCHAR(255) NOT NULL
	,FirstName NVARCHAR(255) NOT NULL
	,LastName NVARCHAR(255) NOT NULL
	,Email NVARCHAR(255) NOT NULL
	,UserStatusID INT NOT NULL
		CONSTRAINT FK_User_UserStatusID
		REFERENCES refUserSS.UserStatus(UserStatusID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_User_CreatedDate
		DEFAULT GETDATE()
	,PwHash VARBINARY(64) NOT NULL
	,PwSalt VARBINARY(128) NOT NULL
)

INSERT INTO UserSS.SSUser
VALUES
('ssAdmin', 'admin', 'admin', 'admin@ss.com', 1, GETDATE(), 0, 0)

CREATE TABLE hr.UserEmployeeXRef(
	UserEmployeeXRefID INT NOT NULL
		CONSTRAINT PK_UserEmployeeXRef
		PRIMARY KEY IDENTITY
	,UserID INT NOT NULL
		CONSTRAINT FK_UserEmployeeXRef_UserID
		REFERENCES UserSS.SSUser(UserID)	
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_UserEmployeeXRef_CreatedDate
		DEFAULT GETDATE()
	,Zapped BIT
		CONSTRAINT DF_UserEmployeeXRef_Zapped
		DEFAULT 0
)

CREATE TABLE UserSS.UserRolesXRef(
	UserRoleXRefID INT NOT NULL
		CONSTRAINT PK_UserRolesXRef
		PRIMARY KEY IDENTITY
	,UserID INT NOT NULL
		CONSTRAINT FK_UserRolesXRef_UserID
		REFERENCES UserSS.SSUser(UserID)
	,UserRoles INT NOT NULL
		CONSTRAINT FK_UserRolesXRef_UserRoleID
		REFERENCES refUserSS.UserRole(UserRoleID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_UserRolesXRef_CreatedDate
		DEFAULT GETDATE()
)

CREATE TABLE refAdminSS.AdminRole(
	AdminRoleID INT NOT NULL
		CONSTRAINT PK_AdminRole
		PRIMARY KEY IDENTITY
	,AdminRole NVARCHAR(255)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_AdminRole_CreatedDate
		DEFAULT GETDATE()
)

CREATE TABLE AdminSS.SSAdmin(
	AdminID INT NOT NULL
		CONSTRAINT PK_AdminID
		PRIMARY KEY IDENTITY
	,UserID INT NOT NULL
		CONSTRAINT FK_Admin_UserID
		REFERENCES UserSS.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Admin_CreatedDate
		DEFAULT GETDATE()
)

CREATE TABLE AdminSS.AdminRolesXRef(
	AdminRolesXRefID INT NOT NULL
		CONSTRAINT PK_AdminRolesXRef
		PRIMARY KEY IDENTITY
	,AdminID INT NOT NULL
		CONSTRAINT FK_AdminRolesXRef_AdminID
		REFERENCES AdminSS.SSAdmin(AdminID)
	,UserRoles INT NOT NULL
		CONSTRAINT FK_AdminRolesXRef_AdminRoleID
		REFERENCES refAdminSS.AdminRole(AdminRoleID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_AdminRolesXRef_CreatedDate
		DEFAULT GETDATE()
)


/*

DROP TABLE AdminSS.AdminRolesXRef
DROP TABLE AdminSS.SSAdmin
DROP TABLE refAdminSS.AdminRole
DROP TABLE UserSS.UserRolesXRef
DROP TABLE hr.UserEmployeeXRef
DROP TABLE UserSS.SSUser
DROP TABLE refUserSS.UserRole
DROP TABLE refUserSS.UserStatus

*/