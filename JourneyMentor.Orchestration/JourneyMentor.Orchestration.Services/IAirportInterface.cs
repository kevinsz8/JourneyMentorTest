using JourneyMentor.Orchestration.ServiceClients.Messages.Request;
using JourneyMentor.Orchestration.ServiceClients.Messages.Response;

namespace JourneyMentor.Orchestration.Services
{
    public interface IAirportInterface
    {
        Task<GetAirportResponse> GetAirports(GetAirportRequest request);
    }
}