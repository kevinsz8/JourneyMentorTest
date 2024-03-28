using AutoMapper;
using JourneyMentor.Orchestration.Models;
using JourneyMentor.Orchestration.ServiceClients.Messages.Request;
using JourneyMentor.Orchestration.ServiceClients.Messages.Response;
using JourneyMentor.Orchestration.Services;
using Microsoft.Extensions.Options;

namespace JourneyMentor.Orchestration.ServiceClients
{
    public class FlightInterface : IFlightInterface
    {
        private readonly IMapper _mapper;
        private readonly HttpService _httpService;
        private readonly ServiceConfigOptions _options;

        public FlightInterface(IMapper mapper, HttpService httpService, IOptions<ServiceConfigOptions> options)
        {
            _mapper = mapper;
            _options = options.Value;
            _httpService = httpService;
        }
        public async Task<GetFlightResponse> GetFlights(GetFlightRequest request)
        {
            var url = _options.GetFlightsEndpoint
                .Replace("{DepartureAirport}", request?.DepartureAirport?.ToString())
                .Replace("{ArrivalAirport}", request?.ArrivalAirport?.ToString());
            return await _httpService.GetAsync<GetFlightResponse>(url);
        }
    }
}
