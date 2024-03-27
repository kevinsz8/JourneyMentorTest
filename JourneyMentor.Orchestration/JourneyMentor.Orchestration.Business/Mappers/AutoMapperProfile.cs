using AutoMapper;
using JourneyMentor.Orchestration.Business.Messages.Query.Request;
using JourneyMentor.Orchestration.Business.Messages.Query.Response;
using JourneyMentor.Orchestration.ServiceClients.Messages.Request;
using JourneyMentor.Orchestration.ServiceClients.Messages.Response;

namespace JourneyMentor.Orchestration.Business.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetAirportsHandlerRequest, GetAirportRequest>();
            CreateMap<GetAirportResponse, GetAirportsHandlerResponse>();
        }
    }
}
