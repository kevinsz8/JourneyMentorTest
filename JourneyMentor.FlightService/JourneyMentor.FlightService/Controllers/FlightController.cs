using JourneyMentor.FlightService.Business.Messages.Command.Request;
using JourneyMentor.FlightService.Business.Messages.Query.Request;
using JourneyMentor.FlightService.Business.Messages.Query.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JourneyMentor.FlightService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly ILogger<FlightController> _logger;
        private readonly IMediator _mediator;

        public FlightController(ILogger<FlightController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("importFlights")]
        [ProducesResponseType(typeof(Unit), 200)]
        public async Task<Unit> ImportFlights()
        {
            var request = new ImportFlightsHandlerRequest();
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Route("getFlights")]
        [ProducesResponseType(typeof(GetFlightsHandlerResponse), 200)]
        public async Task<GetFlightsHandlerResponse> GetFlights([FromQuery] string DepartureAirport, [FromQuery] string ArrivalAirport)
        {
            var request = new GetFlightsHandlerRequest()
            {
                DepartureAirport = DepartureAirport,
                ArrivalAirport = ArrivalAirport
            };

            return await _mediator.Send(request);
        }

    }
}
