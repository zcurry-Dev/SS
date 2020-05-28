--
USE SceneSwarm01

-- DROP SELTZER TABLES
DROP TABLE dbo.Seltzer
DROP TABLE dbo.Seltzery
DROP TABLE ref.SeltzerFlavor

-- DROP MEAD TABLES
DROP TABLE dbo.Mead
DROP TABLE dbo.Meadery
DROP TABLE ref.MeadType

-- DROP CIDER TABLES
DROP TABLE dbo.Cider
DROP TABLE dbo.Cidery
DROP TABLE ref.CiderFlavor
DROP TABLE ref.CiderType

-- DROP LIQUOR TABLES
DROP TABLE dbo.Liquor
DROP TABLE dbo.Distillery
DROP TABLE ref.ScotchWhiskeyType
DROP TABLE ref.AmericanWhiskeyType
DROP TABLE ref.LiquorType
DROP TABLE ref.LiquorFamily

-- DROP WINE TABLES
DROP TABLE dbo.Wine
DROP TABLE dbo.Winery
DROP TABLE ref.WineTypeSpecific
DROP TABLE ref.WineType
DROP TABLE ref.WineFamily

-- DROP BEER TABLES
DROP TABLE dbo.Beer
DROP TABLE dbo.Brewery
DROP TABLE ref.BeerTypeSpecific
DROP TABLE ref.BeerType
DROP TABLE ref.BeerFamily

-- DROP ARTISTS TABLES
DROP TABLE dbo.ArtistGroupMemberRolesXRef
DROP TABLE ref.ArtistGroupMemberRole
DROP TABLE dbo.ArtistGroupMember
DROP TABLE dbo.ArtistTypeXRef
DROP TABLE dbo.ArtistPhoto
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
DROP TABLE ident.SSUserToken
DROP TABLE ident.SSUserRole
DROP TABLE ident.SSUserLogin
DROP TABLE ident.SSUserClaim
DROP TABLE ident.SSRoleClaim
DROP TABLE ident.SSUser
DROP TABLE ident.SSUserStatus
DROP TABLE ident.SSRole

-- DROP EMPLOYEE TABLES
DROP TABLE hr.EmployeeRecord
DROP TABLE hr.Employee
DROP TABLE refHR.EmployeeTitle
DROP TABLE refHR.EmploymentStatus

-- DROP LOCATION TABLES
DROP TABLE loc.ZipCode
DROP TABLE loc.WorldCity
DROP TABLE loc.City
DROP TABLE loc.WorldRegion

-- DROP CONSTANT TABLES
DROP TABLE const.DaysOfWeek
DROP TABLE const.USState
DROP TABLE const.Country

-- DROP SCHEMAS
DROP SCHEMA const
GO
DROP SCHEMA loc
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
DROP SCHEMA ident
GO

