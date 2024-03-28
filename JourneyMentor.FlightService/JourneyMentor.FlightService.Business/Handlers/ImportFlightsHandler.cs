using AutoMapper;
using JourneyMentor.FlightService.Business.Messages.Command.Request;
using JourneyMentor.FlightService.Models.Config;
using JourneyMentor.FlightService.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JourneyMentor.FlightService.Business.Handlers
{
    public class ImportFlightsHandler : IRequestHandler<ImportFlightsHandlerRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ImportFlightsHandler> _logger;
        private readonly IFlightInterface _FlightInterface;
        private readonly AviationStackOptions _apiSettings;

        public ImportFlightsHandler(IMapper mapper, ILogger<ImportFlightsHandler> logger, IFlightInterface FlightInterface, IOptions<AviationStackOptions> apiSettings)
        {
            _mapper = mapper;
            _logger = logger;
            _FlightInterface = FlightInterface;
            _apiSettings = apiSettings.Value;
        }

        public async Task<Unit> Handle(ImportFlightsHandlerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                string apiUrl = _apiSettings.ApiUrl;
                string accessKey = _apiSettings.AccessKey;

                await _FlightInterface.ImportFlights(apiUrl, accessKey);
                return new Unit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
