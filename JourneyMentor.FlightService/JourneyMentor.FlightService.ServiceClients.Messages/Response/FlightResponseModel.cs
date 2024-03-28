namespace JourneyMentor.FlightService.ServiceClients.Messages.Response
{
    public class FlightResponseModel
    {
        public Pagination Pagination { get; set; }
        public FlightData[] Data { get; set; }
    }

    public class Pagination
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }

    public class FlightData
    {
        public string? FlightDate { get; set; }
        public string FlightStatus { get; set; }
        public Departure Departure { get; set; }
        public Arrival Arrival { get; set; }
        public Airline Airline { get; set; }
        public FlightDetails Flight { get; set; }
        public Aircraft Aircraft { get; set; }
        public Live Live { get; set; }
    }

    public class Departure
    {
        public string Airport { get; set; }
        public string Timezone { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
        public string Terminal { get; set; }
        public string Gate { get; set; }
        public int Delay { get; set; }
        public string? Scheduled { get; set; }
        public string? Estimated { get; set; }
        public string? Actual { get; set; }
        public string? EstimatedRunway { get; set; }
        public string? ActualRunway { get; set; }
    }

    public class Arrival
    {
        public string Airport { get; set; }
        public string Timezone { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
        public string Terminal { get; set; }
        public string Gate { get; set; }
        public string Baggage { get; set; }
        public int Delay { get; set; }
        public string? Scheduled { get; set; }
        public string? Estimated { get; set; }
        public string? Actual { get; set; }
        public string? EstimatedRunway { get; set; }
        public string? ActualRunway { get; set; }
    }

    public class Airline
    {
        public string Name { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
    }

    public class FlightDetails
    {
        public string Number { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
        public object Codeshared { get; set; }
    }

    public class Aircraft
    {
        public string Registration { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
        public string Icao24 { get; set; }
    }

    public class Live
    {
        public string? Updated { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Altitude { get; set; }
        public float Direction { get; set; }
        public float SpeedHorizontal { get; set; }
        public float SpeedVertical { get; set; }
        public bool IsGround { get; set; }
    }
}
