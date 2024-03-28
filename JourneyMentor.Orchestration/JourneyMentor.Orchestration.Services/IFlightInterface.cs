using JourneyMentor.Orchestration.ServiceClients.Messages.Request;
using JourneyMentor.Orchestration.ServiceClients.Messages.Response;

namespace JourneyMentor.Orchestration.Services
{
    public interface IFlightInterface
    {
        Task<GetFlightResponse> GetFlights(GetFlightRequest request);
    }
}
