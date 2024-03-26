using JourneyMentor.AirportService.Business.Messages.Common;

namespace JourneyMentor.AirportService.Business.Messages.Query.Response
{
    public class GetAirportsHandlerResponse : BaseResponse
    {
        public List<Airport> AirPorts { get; set; }
    }
}
