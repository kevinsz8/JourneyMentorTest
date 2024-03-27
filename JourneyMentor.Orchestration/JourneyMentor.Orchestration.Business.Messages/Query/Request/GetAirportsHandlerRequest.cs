using JourneyMentor.Orchestration.Business.Messages.Query.Response;
using MediatR;

namespace JourneyMentor.Orchestration.Business.Messages.Query.Request
{
    public class GetAirportsHandlerRequest : IRequest<GetAirportsHandlerResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
