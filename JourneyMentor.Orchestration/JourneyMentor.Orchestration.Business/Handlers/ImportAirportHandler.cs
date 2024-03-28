using AutoMapper;
using JourneyMentor.Orchestration.Business.Messages.Command.Request;
using JourneyMentor.Orchestration.ServiceClients.Messages.Request;
using JourneyMentor.Orchestration.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace JourneyMentor.Orchestration.Business.Handlers
{
    public class ImportAirportHandler : IRequestHandler<ImportAirportHandlerRequest, Unit>
    {
        private readonly IAirportInterface _OrderInterface;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ImportAirportHandler(IAirportInterface OrderInterface, IMapper mapper, ILogger<ImportAirportHandler> logger)
        {
            _OrderInterface = OrderInterface;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(ImportAirportHandlerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var requestI = _mapper.Map<ImportAirportRequest>(request);
                await _OrderInterface.ImportAirport(requestI);

                return new Unit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling the request.");

                throw new Exception("An error occurred while processing the request. Please try again later.", ex);
            }
        }
    }
}
