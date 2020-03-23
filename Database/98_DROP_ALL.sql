--
USE SceneSwarm01

-- DROP MEAD TABLES
DROP TABLE dbo.Mead
DROP TABLE dbo.Meadery
DROP TABLE ref.MeadType
DROP TABLE ref.MeadFamily

-- DROP CIDER TABLES
DROP TABLE dbo.Cider
DROP TABLE dbo.Cidery
DROP TABLE ref.CiderType
DROP TABLE ref.CiderFamily

-- DROP SPIRIT TABLES
DROP TABLE dbo.Spirit
DROP TABLE dbo.Distillery
DROP TABLE ref.SpiritType
DROP TABLE ref.SpiritFamily

-- DROP WINE TABLES
DROP TABLE dbo.Wine
DROP TABLE dbo.Winery
DROP TABLE ref.WineType
DROP TABLE ref.WineFamily

-- DROP BEER TABLES
DROP TABLE dbo.Beer
DROP TABLE dbo.Brewery
DROP TABLE ref.BeerType
DROP TABLE ref.BeerFamily

-- DROP ARTISTS TABLES
DROP TABLE dbo.ArtistGroupMemberRolesXRef
DROP TABLE ref.ArtistGroupMemberRole
DROP TABLE dbo.ArtistGroupMember
DROP TABLE dbo.ArtistTypeXRef
DROP TABLE dbo.Artist
DROP TABLE ref.ArtistStatus
DROP TABLE ref.ArtistType

-- DROP EVENTS TABLES
DROP TABLE dbo.SSEvent
DROP TABLE ref.EventType

-- DROP ADDRESSES/VENUE TABLES
DROP TABLE dbo.VenueHoursOpen
DROP TABLE dbo.VenueTypeXRef
DROP TABLE dbo.Venue
DROP TABLE ref.VenueType
DROP TABLE dbo.SSAddress

-- DROP USER/ADMIN TABLES
DROP TABLE AdminSS.AdminRolesXRef
DROP TABLE AdminSS.SSAdmin
DROP TABLE refAdminSS.AdminRole
DROP TABLE UserSS.UserRolesXRef
DROP TABLE hr.UserEmployeeXRef
DROP TABLE UserSS.SSUser
DROP TABLE refUserSS.UserRole
DROP TABLE refUserSS.UserStatus

-- DROP EMPLOYEE TABLES
DROP TABLE hr.EmployeeRecord
DROP TABLE hr.Employee
DROP TABLE refHR.EmployeeTitle
DROP TABLE refHR.EmploymentStatus

-- DROP CONSTANT TABLES
DROP TABLE const.DaysOfWeek
DROP TABLE const.ZipCode
DROP TABLE const.City
DROP TABLE const.USState

-- DROP SCHEMAS
DROP SCHEMA const
GO
DROP SCHEMA hr
GO
DROP SCHEMA ref
GO
DROP SCHEMA refHR
GO
DROP SCHEMA refAdminSS
GO
DROP SCHEMA refUserSS
GO
DROP SCHEMA AdminSS
GO
DROP SCHEMA UserSS	
GO

