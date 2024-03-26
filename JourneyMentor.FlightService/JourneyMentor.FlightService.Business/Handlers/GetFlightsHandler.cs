using AutoMapper;
using JourneyMentor.FlightService.Business.Messages.Common;
using JourneyMentor.FlightService.Business.Messages.Query.Request;
using JourneyMentor.FlightService.Business.Messages.Query.Response;
using JourneyMentor.FlightService.Models.Config;
using JourneyMentor.FlightService.ServiceClients.Messages.Request;
using JourneyMentor.FlightService.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JourneyMentor.FlightService.Business.Handlers
{
    public class GetFlightsHandler : IRequestHandler<GetFlightsHandlerRequest, GetFlightsHandlerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetFlightsHandler> _logger;
        private readonly IFlightInterface _FlightInterface;
        private readonly AviationStackOptions _apiSettings;

        public GetFlightsHandler(IMapper mapper, ILogger<GetFlightsHandler> logger, IFlightInterface FlightInterface, IOptions<AviationStackOptions> apiSettings)
        {
            _mapper = mapper;
            _logger = logger;
            _FlightInterface = FlightInterface;
            _apiSettings = apiSettings.Value;
        }

        public async Task<GetFlightsHandlerResponse> Handle(GetFlightsHandlerRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var requestI = _mapper.Map<GetFlightsRequest>(request);
                var FlightsResponse = await _FlightInterface.GetFlights(requestI);

                var response = new GetFlightsHandlerResponse()
                {
                    StatusMessage = "Success",
                    Flights = _mapper.Map<List<Flight>>(FlightsResponse),
                    Success = true
                };

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling the request.");

                var errorResponse = new GetFlightsHandlerResponse
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
