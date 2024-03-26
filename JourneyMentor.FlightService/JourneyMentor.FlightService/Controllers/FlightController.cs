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

        //[HttpPost]
        //[Route("importFlights")]
        //[ProducesResponseType(typeof(Unit), 200)]
        //public async Task<Unit> ImportFlights()
        //{
        //    var request = new ImportFlightsHandlerRequest();
        //    return await _mediator.Send(request);
        //}
    }
}
