using AutoMapper;
using JourneyMentor.FlightService.Business.Messages.Query.Request;
using JourneyMentor.FlightService.ServiceClients.Messages.Request;
using JourneyMentor.FlightService.ServiceClients.Messages.Response;

namespace JourneyMentor.FlightService.Business.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetFlightsHandlerRequest, GetFlightsRequest>();
            CreateMap<GetFlightsResponse, Messages.Common.Flight>();

            CreateMap<FlightService.Models.Flight, GetFlightsResponse>();
        }
    }
}
