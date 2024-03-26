using AutoMapper;
using JourneyMentor.AirportService.Business.Messages.Query.Request;
using JourneyMentor.AirportService.Business.Messages.Query.Response;
using JourneyMentor.AirportService.Business.Messages.Common;
using JourneyMentor.AirportService.Models.Config;
using JourneyMentor.AirportService.ServiceClients.Messages.Request;
using JourneyMentor.AirportService.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JourneyMentor.AirportService.Business.Handlers
{
    public class GetAirportsHandler : IRequestHandler<GetAirportsHandlerRequest, GetAirportsHandlerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAirportsHandler> _logger;
        private readonly IAirportInterface _airportInterface;
        private readonly AviationStackOptions _apiSettings;

        public GetAirportsHandler(IMapper mapper, ILogger<GetAirportsHandler> logger, IAirportInterface airportInterface, IOptions<AviationStackOptions> apiSettings)
        {
            _mapper = mapper;
            _logger = logger;
            _airportInterface = airportInterface;
            _apiSettings = apiSettings.Value;
        }

        public async Task<GetAirportsHandlerResponse> Handle(GetAirportsHandlerRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var requestI = _mapper.Map<GetAirPortsRequest>(request);
                var AirportsResponse = await _airportInterface.GetAirPorts(requestI);

                var response = new GetAirportsHandlerResponse()
                {
                    StatusMessage = "Success",
                    AirPorts = _mapper.Map<List<Airport>>(AirportsResponse),
                    Success = true
                };

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling the request.");

                var errorResponse = new GetAirportsHandlerResponse
                {
                    StatusMessage = "Error",
                    ErrorMessage = "An error occurred while processing your request. Please try again later.",
                    Success = false
                };

                return errorResponse;
            }
        }
    }
}
