namespace JourneyMentor.Orchestration.ServiceClients.Messages.Request
{
    public class GetFlightRequest
    {
        public string? DepartureAirport { get; set; }
        public string? ArrivalAirport { get; set; }
    }
}
