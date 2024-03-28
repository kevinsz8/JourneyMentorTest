using JourneyMentor.Orchestration.Business.Messages.Common;

namespace JourneyMentor.Orchestration.Business.Messages.Query.Response
{
    public class GetFlightsHandlerResponse : BaseResponse
    {
        public List<Flight> Flights { get; set; }
    }
}
