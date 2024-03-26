using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyMentor.FlightService.Models
{
    [Table("Flight")]
    public class Flight
    {
        public int Id { get; set; }
        public DateTime FlightDate { get; set; }
        public string FlightStatus { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureTimezone { get; set; }
        public string DepartureIata { get; set; }
        public string DepartureIcao { get; set; }
        public string DepartureTerminal { get; set; }
        public string DepartureGate { get; set; }
        public int DepartureDelay { get; set; }
        public DateTime DepartureScheduled { get; set; }
        public DateTime DepartureEstimated { get; set; }
        public DateTime DepartureActual { get; set; }
        public DateTime DepartureEstimatedRunway { get; set; }
        public DateTime DepartureActualRunway { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalTimezone { get; set; }
        public string ArrivalIata { get; set; }
        public string ArrivalIcao { get; set; }
        public string ArrivalTerminal { get; set; }
        public string ArrivalGate { get; set; }
        public string ArrivalBaggage { get; set; }
        public int ArrivalDelay { get; set; }
        public DateTime ArrivalScheduled { get; set; }
        public DateTime ArrivalEstimated { get; set; }
        public DateTime ArrivalActual { get; set; }
        public DateTime ArrivalEstimatedRunway { get; set; }
        public DateTime ArrivalActualRunway { get; set; }
        public string AirlineName { get; set; }
        public string AirlineIata { get; set; }
        public string AirlineIcao { get; set; }
        public string FlightNumber { get; set; }
        public string FlightIata { get; set; }
        public string FlightIcao { get; set; }
        public string AircraftRegistration { get; set; }
        public string AircraftIata { get; set; }
        public string AircraftIcao { get; set; }
        public string AircraftIcao24 { get; set; }
        public DateTime LiveUpdated { get; set; }
        public float LiveLatitude { get; set; }
        public float LiveLongitude { get; set; }
        public float LiveAltitude { get; set; }
        public float LiveDirection { get; set; }
        public float LiveSpeedHorizontal { get; set; }
        public float LiveSpeedVertical { get; set; }
        public bool LiveIsGround { get; set; }
    }
}