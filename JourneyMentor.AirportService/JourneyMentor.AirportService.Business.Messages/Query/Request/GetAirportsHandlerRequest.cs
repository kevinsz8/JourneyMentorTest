using JourneyMentor.AirportService.Business.Messages.Query.Response;
using MediatR;

namespace JourneyMentor.AirportService.Business.Messages.Query.Request
{
    public class GetAirportsHandlerRequest : IRequest<GetAirportsHandlerResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
