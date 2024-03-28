using JourneyMentor.Orchestration.Business.Messages.Query.Response;
using MediatR;

namespace JourneyMentor.Orchestration.Business.Messages.Query.Request
{
    public class GetFlightsHandlerRequest : IRequest<GetFlightsHandlerResponse>
    {
        public string? DepartureAirport { get; set; }
        public string? ArrivalAirport { get; set; }
    }
}
