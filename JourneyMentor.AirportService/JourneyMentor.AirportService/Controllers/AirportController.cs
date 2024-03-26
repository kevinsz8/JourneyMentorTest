using JourneyMentor.AirportService.Business.Messages.Command.Request;
using JourneyMentor.AirportService.Business.Messages.Query.Request;
using JourneyMentor.AirportService.Business.Messages.Query.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JourneyMentor.AirportService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly ILogger<AirportController> _logger;
        private readonly IMediator _mediator;

        public AirportController(ILogger<AirportController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("importAirports")]
        [ProducesResponseType(typeof(Unit), 200)]
        public async Task<Unit> ImportAirports()
        {
            var request = new ImportAirportsHandlerRequest();
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Route("getAirports")]
        [ProducesResponseType(typeof(GetAirportsHandlerResponse), 200)]
        public async Task<GetAirportsHandlerResponse> GetAirports([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var request = new GetAirportsHandlerRequest()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return await _mediator.Send(request);
        }
    }
}
