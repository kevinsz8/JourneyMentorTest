using AutoMapper;
using JourneyMentor.AirportService.Business.Messages.Command.Request;
using JourneyMentor.AirportService.Models.Config;
using JourneyMentor.AirportService.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentor.AirportService.Business.Handlers
{
    public class ImportAirportsHandler : IRequestHandler<ImportAirportsHandlerRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ImportAirportsHandler> _logger;
        private readonly IAirportInterface _airportInterface;
        private readonly AviationStackOptions _apiSettings;

        public ImportAirportsHandler(IMapper mapper, ILogger<ImportAirportsHandler> logger, IAirportInterface airportInterface, IOptions<AviationStackOptions> apiSettings)
        {
            _mapper = mapper;
            _logger = logger;
            _airportInterface = airportInterface;
            _apiSettings = apiSettings.Value;
        }

        public async Task<Unit> Handle(ImportAirportsHandlerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                string apiUrl = _apiSettings.ApiUrl;
                string accessKey = _apiSettings.AccessKey;

                await _airportInterface.ImportAirports(apiUrl, accessKey);
                return new Unit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
