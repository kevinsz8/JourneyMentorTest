using JourneyMentor.Orchestration.Business.Messages.Common;

namespace JourneyMentor.Orchestration.ServiceClients.Messages.Response
{
    public class GetFlightResponse : BaseResponse
    {
        public List<Flight> Flights { get; set; }
    }
}
