using JourneyMentor.FlightService.Business.Messages.Common;

namespace JourneyMentor.FlightService.Business.Messages.Query.Response
{
    public class GetFlightsHandlerResponse : BaseResponse
    {
        public List<Flight> Flights { get; set; }
    }
}
