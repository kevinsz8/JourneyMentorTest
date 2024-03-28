using JourneyMentor.Orchestration.ServiceClients.Messages.Request;
using JourneyMentor.Orchestration.ServiceClients.Messages.Response;
using MediatR;

namespace JourneyMentor.Orchestration.Services
{
    public interface IAirportInterface
    {
        Task<GetAirportResponse> GetAirports(GetAirportRequest request);
        Task<Unit> ImportAirport(ImportAirportRequest request);
    }
}