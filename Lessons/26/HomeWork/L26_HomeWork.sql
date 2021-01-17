CREATE DATABASE AirportInfo

CREATE TABLE [dbo].[DepartureBoard](
	[FlightNumber] [varchar](10) NOT NULL,
	[DepartureCountry] [varchar](60) NOT NULL,
	[DepartureCity] [varchar](50) NOT NULL,
	[DepartureDate] [date] NOT NULL,
	[DepartureTime] [time] NOT NULL,
	[ArrivalCountry] [varchar](60) NOT NULL,
	[ArrivalCity] [varchar](50) NOT NULL,
	[ArrivalDate] [date] NOT NULL,
	[ArrivalTime] [time] NOT NULL,
	[FlightTime] [time] NOT NULL,
	[Airline] [varchar](50) NOT NULL,
	[ModelAirplane] [varchar](50) NOT NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[DepartureBoard]
([FlightNumber], [DepartureCountry], [DepartureCity], 
[DepartureDate], [DepartureTime], [ArrivalCountry], 
[ArrivalCity], [ArrivalDate], [ArrivalTime], 
[FlightTime], [Airline], [ModelAirplane])
VALUES 
('SU0250', 'Russia', 'Moscow', 
'2021-01-21', '22:05', 
'South Korea', 'Seoul', 
'2021-01-22', '12:45',
'8:30', 'AEROFLOT', 'Airbus A330-300'),
('SU0106', 'Russia', 'Moscow', 
'2021-01-18', '20:00', 
'USA', 'Los Angeles', 
'2021-01-18', '21:35', 
'12:35', 'AEROFLOT', 'Boeing 777-300ER')

SELECT *
FROM [dbo].[DepartureBoard] 

DROP TABLE [dbo].[DepartureBoard]

ALTER DATABASE [AirportInfo]
SET SINGLE_USER 
WITH ROLLBACK IMMEDIATE;
GO

DROP DATABASE [AirportInfo]