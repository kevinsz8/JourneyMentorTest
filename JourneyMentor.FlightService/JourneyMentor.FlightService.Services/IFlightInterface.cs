using JourneyMentor.FlightService.ServiceClients.Messages.Request;
using JourneyMentor.FlightService.ServiceClients.Messages.Response;

namespace JourneyMentor.FlightService.Services
{
    public interface IFlightInterface
    {
        Task ImportFlights(string apiUrl, string accessKey);
        Task<List<GetFlightsResponse>> GetFlights(GetFlightsRequest request);
    }
}