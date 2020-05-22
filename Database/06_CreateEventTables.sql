CREATE TABLE ref.EventType(
	EventTypeID INT NOT NULL
		CONSTRAINT PK_EventType
		PRIMARY KEY IDENTITY
	,EventType NVARCHAR(255) NOT NULL
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_EventType_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_EventType_CreatedDate
		DEFAULT GETDATE()
)

INSERT INTO ref.EventType
VALUES
('Concert', 1, GETDATE())
,('Comedy', 1, GETDATE())

CREATE TABLE dbo.SSEvent(
	EventID INT NOT NULL
		CONSTRAINT PK_EventID
		PRIMARY KEY IDENTITY
	,EventTypeID INT NOT NULL
		CONSTRAINT FK_Event_EventTypeID
		REFERENCES ref.EventType(EventTypeID)
	,EventDate DATETIME NOT NULL
	,EventTime DATETIME
	,EventVenueID INT NULL
		CONSTRAINT FK_Event_EventVenueID
		REFERENCES dbo.Venue(VenueID)
	,Fundraiser BIT NOT NULL
		CONSTRAINT DF_SSEvent_Fundraiser
		DEFAULT 0
	,CreatedBy INT NOT NULL
		CONSTRAINT FK_Event_CreatedBy
		REFERENCES ident.SSUser(UserID)
	,CreatedDate DATETIME NOT NULL
		CONSTRAINT DF_Event_CreatedDate
		DEFAULT GETDATE()
)

/*

DROP TABLE dbo.SSEvent
DROP TABLE ref.EventType

*/