--
USE SceneSwarm01

-- DROP MEAD TABLES
DROP TABLE dbo.Meads
DROP TABLE dbo.Meaderies
DROP TABLE ref.MeadTypes
DROP TABLE ref.MeadFamilies

-- DROP CIDER TABLES
DROP TABLE dbo.Ciders
DROP TABLE dbo.Cideries
DROP TABLE ref.CiderTypes
DROP TABLE ref.CiderFamilies

-- DROP SPIRIT TABLES
DROP TABLE dbo.Spirits
DROP TABLE dbo.Distilleries
DROP TABLE ref.SpiritTypes
DROP TABLE ref.SpiritFamiles

-- DROP WINE TABLES
DROP TABLE dbo.Wines
DROP TABLE dbo.Wineries
DROP TABLE ref.WineTypes
DROP TABLE ref.WineFamilies

-- DROP BEER TABLES
DROP TABLE dbo.Beers
DROP TABLE dbo.Breweries
DROP TABLE ref.BeerTypes
DROP TABLE ref.BeerFamilies

-- DROP ARTISTS TABLES
DROP TABLE dbo.ArtistGroupMemberRolesXRef
DROP TABLE ref.ArtistGroupMemberRoles
DROP TABLE dbo.ArtistGroupMembers
DROP TABLE dbo.ArtistTypeXRef
DROP TABLE dbo.Artists
DROP TABLE ref.ArtistStatuses
DROP TABLE ref.ArtistTypes

-- DROP EVENTS TABLES
DROP TABLE dbo.SSEvents
DROP TABLE ref.SSEventTypes

-- DROP ADDRESSES/VENUE TABLES
DROP TABLE dbo.VenueHoursOpen
DROP TABLE dbo.VenueTypeXRef
DROP TABLE dbo.Venues
DROP TABLE ref.VenueTypes
DROP TABLE dbo.Addresses

-- DROP USER/ADMIN TABLES
DROP TABLE ssAdmin.AdminRolesXRef
DROP TABLE ssAdmin.Admins
DROP TABLE refSSAdmin.AdminRoles
DROP TABLE ssUser.UserRolesXRef
DROP TABLE hr.SSUsersEmployeeXRef
DROP TABLE ssUser.SSUsers
DROP TABLE refSSUser.UserRoles
DROP TABLE refSSUser.UserStatuses

-- DROP EMPLOYEE TABLES
DROP TABLE hr.EmployeeRecords
DROP TABLE hr.Employees
DROP TABLE refHR.EmployeeTitles
DROP TABLE refHR.EmploymentStatuses

-- DROP CONSTANT TABLES
DROP TABLE const.ssDays
DROP TABLE const.CityZipcodeXRef
DROP TABLE const.Cities
DROP TABLE const.ZipCodes
DROP TABLE const.States

-- DROP SCHEMAS
DROP SCHEMA const
GO
DROP SCHEMA hr
GO
DROP SCHEMA ref
GO
DROP SCHEMA refHR
GO
DROP SCHEMA refSSAdmin
GO
DROP SCHEMA refSSUser
GO
DROP SCHEMA ssAdmin
GO
DROP SCHEMA ssUser	
GO

