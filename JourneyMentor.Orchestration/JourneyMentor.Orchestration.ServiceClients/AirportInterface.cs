using AutoMapper;
using JourneyMentor.Orchestration.Models;
using JourneyMentor.Orchestration.ServiceClients.Messages.Request;
using JourneyMentor.Orchestration.ServiceClients.Messages.Response;
using JourneyMentor.Orchestration.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentor.Orchestration.ServiceClients
{
    public class AirportInterface : IAirportInterface
    {
        private readonly IMapper _mapper;
        private readonly HttpService _httpService;
        private readonly ServiceConfigOptions _options;

        public AirportInterface(IMapper mapper, HttpService httpService, IOptions<ServiceConfigOptions> options)
        {
            _mapper = mapper;
            _options = options.Value;
            _httpService = httpService;
        }

        public async Task<GetAirportResponse> GetAirports(GetAirportRequest request)
        {
            var url = _options.GetAirportsEndpoint
                .Replace("{pageNumber}", request.PageNumber.ToString())
                .Replace("{pageSize}", request.PageSize.ToString());
            return await _httpService.GetAsync<GetAirportResponse>(url);
        }
    }
}
