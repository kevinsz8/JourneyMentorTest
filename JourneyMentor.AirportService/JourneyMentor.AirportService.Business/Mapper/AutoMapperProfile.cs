using AutoMapper;
using JourneyMentor.AirportService.Business.Messages.Common;
using JourneyMentor.AirportService.Business.Messages.Query.Request;
using JourneyMentor.AirportService.ServiceClients.Messages.Request;
using JourneyMentor.AirportService.ServiceClients.Messages.Response;

namespace JourneyMentor.AirportService.Business.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetAirportsHandlerRequest, GetAirPortsRequest>();
            CreateMap<GetAirPortsResponse, Airport>();
        }
    }
}
