﻿namespace JourneyMentor.FlightService.ServiceClients.Messages.Request
{
    public class GetFlightsRequest
    {
        public string? DepartureAirport { get; set; }
        public string? ArrivalAirport { get; set; }
    }
}
