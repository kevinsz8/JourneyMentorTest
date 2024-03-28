using JourneyMentor.Orchestration.Business.Messages.Command.Request;
using JourneyMentor.Orchestration.Business.Messages.Query.Request;
using JourneyMentor.Orchestration.Business.Messages.Query.Response;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JourneyMentor.Orchestration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAll")]
    public class FlightController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("importFlights")]
        [ProducesResponseType(typeof(Unit), 200)]
        public async Task<Unit> ImportFlightHandler()
        {
            var request = new ImportFlightHandlerRequest();
            var response = await _mediator.Send(request);

            return response;
        }


        [HttpGet]
        [Route("getFlights")]
        [ProducesResponseType(typeof(GetFlightsHandlerResponse), 200)]
        public async Task<GetFlightsHandlerResponse> GetFlights([FromQuery] string? DepartureAirport = null, [FromQuery] string? ArrivalAirport = null)
        {
            var request = new GetFlightsHandlerRequest()
            {
                DepartureAirport = DepartureAirport,
                ArrivalAirport = ArrivalAirport
            };

            var response = await _mediator.Send(request);

            return response;
        }
    }
}
