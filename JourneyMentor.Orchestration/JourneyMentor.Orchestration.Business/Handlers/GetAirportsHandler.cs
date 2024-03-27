using AutoMapper;
using JourneyMentor.Orchestration.Business.Messages.Query.Request;
using JourneyMentor.Orchestration.Business.Messages.Query.Response;
using JourneyMentor.Orchestration.ServiceClients.Messages.Request;
using JourneyMentor.Orchestration.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JourneyMentor.Orchestration.Business.Handlers
{
    public class GetAirportsHandler : IRequestHandler<GetAirportsHandlerRequest, GetAirportsHandlerResponse>
    {
        private readonly IAirportInterface _AirportInterface;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetAirportsHandler(IAirportInterface AirportInterface, IMapper mapper, ILogger<GetAirportsHandler> logger)
        {
            _AirportInterface = AirportInterface;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetAirportsHandlerResponse> Handle(GetAirportsHandlerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var requestI = _mapper.Map<GetAirportRequest>(request);
                var res = await _AirportInterface.GetAirports(requestI);

                var response = _mapper.Map<GetAirportsHandlerResponse>(res);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling the request.");

                var errorResponse = new GetAirportsHandlerResponse
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
