CREATE DATABASE IF NOT EXISTS JourneyMentor;
USE JourneyMentor;


CREATE TABLE IF NOT EXISTS `Airport` (
  `Id` INT AUTO_INCREMENT NOT NULL,
  `Gmt` VARCHAR(10),
  `AirportId` INT,
  `IataCode` VARCHAR(25),
  `CityIataCode` VARCHAR(25),
  `IcaoCode` VARCHAR(25),
  `CountryIso2` VARCHAR(20),
  `GeonameId` VARCHAR(100),
  `Latitude` VARCHAR(25),
  `Longitude` VARCHAR(25),
  `AirportName` VARCHAR(250),
  `CountryName` VARCHAR(250),
  `PhoneNumber` VARCHAR(50) NULL,
  `Timezone` VARCHAR(150),
  primary key (Id)
);

INSERT INTO `Airport` (`AirportName`,`IataCode`,`IcaoCode`,`Latitude`,`Longitude`,`GeonameId`,`Timezone`,`Gmt`,`PhoneNumber`,`CountryName`,`CountryIso2`,`CityIataCode`)
VALUES
('Anaa','AAA','NTGA','-17.05','-145.41667','6947726','Pacific/Tahiti','-10',NULL,'French Polynesia','PF','AAA'),
('Los Angeles International Airport', 'LAX', 'KLAX', '33.9425', '-118.4072', '5368361', 'America/Los_Angeles', '-7', '+1-855-463-5252', 'United States', 'US', 'LAX'),
('Heathrow Airport', 'LHR', 'EGLL', '51.4700', '-0.4543', '2643743', 'Europe/London', '0', '+44 (0)844 335 1801', 'United Kingdom', 'GB', 'LHR'),
('Charles de Gaulle Airport', 'CDG', 'LFPG', '49.0097', '2.5479', '2968815', 'Europe/Paris', '1', '+33 1 70 36 39 50', 'France', 'FR', 'CDG'),
('Beijing Capital International Airport', 'PEK', 'ZBAA', '40.0799', '116.6031', '1816670', 'Asia/Shanghai', '8', '+86 10 96158', 'China', 'CN', 'PEK');

select * from `Airport`;

CREATE TABLE IF NOT EXISTS Flight (
	Id INT AUTO_INCREMENT NOT NULL,
    FlightDate DATE,
    FlightStatus VARCHAR(50),
    DepartureAirport VARCHAR(255),
    DepartureTimezone VARCHAR(50),
    DepartureIata VARCHAR(3),
    DepartureIcao VARCHAR(4),
    DepartureTerminal VARCHAR(10),
    DepartureGate VARCHAR(10),
    DepartureDelay INT,
    DepartureScheduled varchar(30),
    DepartureEstimated varchar(30),
    DepartureActual varchar(30),
    DepartureEstimatedRunway varchar(30),
    DepartureActualRunway varchar(30),
    ArrivalAirport VARCHAR(255),
    ArrivalTimezone VARCHAR(50),
    ArrivalIata VARCHAR(3),
    ArrivalIcao VARCHAR(4),
    ArrivalTerminal VARCHAR(10),
    ArrivalGate VARCHAR(10),
    ArrivalBaggage VARCHAR(10),
    ArrivalDelay INT,
    ArrivalScheduled varchar(30),
    ArrivalEstimated varchar(30),
    ArrivalActual varchar(30),
    ArrivalEstimatedRunway varchar(30),
    ArrivalActualRunway varchar(30),
    AirlineName VARCHAR(100),
    AirlineIata VARCHAR(3),
    AirlineIcao VARCHAR(4),
    FlightNumber VARCHAR(10),
    FlightIata VARCHAR(10),
    FlightIcao VARCHAR(10),
    AircraftRegistration VARCHAR(20),
    AircraftIata VARCHAR(10),
    AircraftIcao VARCHAR(10),
    AircraftIcao24 VARCHAR(10),
    LiveUpdated varchar(30),
    LiveLatitude FLOAT,
    LiveLongitude FLOAT,
    LiveAltitude FLOAT,
    LiveDirection FLOAT,
    LiveSpeedHorizontal FLOAT,
    LiveSpeedVertical FLOAT,
    LiveIsGround BIT,
    primary key (Id)
);

INSERT INTO `Flight` (
    FlightDate, FlightStatus, 
    DepartureAirport, DepartureTimezone, DepartureIata, DepartureIcao, DepartureTerminal, DepartureGate, DepartureDelay, DepartureScheduled, DepartureEstimated, DepartureActual, DepartureEstimatedRunway, DepartureActualRunway, 
    ArrivalAirport, ArrivalTimezone, ArrivalIata, ArrivalIcao, ArrivalTerminal, ArrivalGate, ArrivalBaggage, ArrivalDelay, ArrivalScheduled, ArrivalEstimated, ArrivalActual, ArrivalEstimatedRunway, ArrivalActualRunway, 
    AirlineName, AirlineIata, AirlineIcao, 
    FlightNumber, FlightIata, FlightIcao, 
    AircraftRegistration, AircraftIata, AircraftIcao, AircraftIcao24, 
    LiveUpdated, LiveLatitude, LiveLongitude, LiveAltitude, LiveDirection, LiveSpeedHorizontal, LiveSpeedVertical, LiveIsGround
) 
VALUES (
    '2019-12-12', 'active', 
    'San Francisco International', 'America/Los_Angeles', 'SFO', 'KSFO', '2', 'D11', 13, '2019-12-12T04:20:00+00:00', '2019-12-12T04:20:00+00:00', '2019-12-12T04:20:13+00:00', '2019-12-12T04:20:13+00:00', '2019-12-12T04:20:13+00:00', 
    'Dallas/Fort Worth International', 'America/Chicago', 'DFW', 'KDFW', 'A', 'A22', 'A17', 0, '2019-12-12T04:20:00+00:00', '2019-12-12T04:20:00+00:00', NULL, NULL, NULL, 
    'American Airlines', 'AA', 'AAL', 
    '1004', 'AA1004', 'AAL1004', 
    'N160AN', 'A321', 'A321', 'A0F1BB', 
    '2019-12-12T10:00:00+00:00', 36.2856, -106.807, 8846.82, 114.34, 894.348, 1.188, FALSE
);

