using AutoMapper;
using JourneyMentor.Orchestration.Business.Messages.Query.Request;
using JourneyMentor.Orchestration.Business.Messages.Query.Response;
using JourneyMentor.Orchestration.ServiceClients.Messages.Request;
using JourneyMentor.Orchestration.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JourneyMentor.Orchestration.Business.Handlers
{
    public class GetFlightsHandler : IRequestHandler<GetFlightsHandlerRequest, GetFlightsHandlerResponse>
    {
        private readonly IFlightInterface _FlightInterface;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetFlightsHandler(IFlightInterface FlightInterface, IMapper mapper, ILogger<GetFlightsHandler> logger)
        {
            _FlightInterface = FlightInterface;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetFlightsHandlerResponse> Handle(GetFlightsHandlerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var requestI = _mapper.Map<GetFlightRequest>(request);
                var res = await _FlightInterface.GetFlights(requestI);

                var response = _mapper.Map<GetFlightsHandlerResponse>(res);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling the request.");

                var errorResponse = new GetFlightsHandlerResponse
                {
                    StatusMessage = "Error",
                    ErrorMessage = ex.InnerException.Message,
                    Success = false
                };

                return errorResponse;
            }
        }
    }
}
