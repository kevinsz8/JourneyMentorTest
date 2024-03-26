using JourneyMentor.AirportService.ServiceClients.Messages.Request;
using JourneyMentor.AirportService.ServiceClients.Messages.Response;

namespace JourneyMentor.AirportService.Services
{
    public interface IAirportInterface
    {
        Task ImportAirports(string apiUrl, string accessKey);
        Task<List<GetAirPortsResponse>> GetAirPorts(GetAirPortsRequest request);
    }
}