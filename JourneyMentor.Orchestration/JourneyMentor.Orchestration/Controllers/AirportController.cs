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
    public class AirportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AirportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("importAirports")]
        [ProducesResponseType(typeof(Unit), 200)]
        public async Task<Unit> ImportAirportHandler()
        {
            var request = new ImportAirportHandlerRequest();
            var response = await _mediator.Send(request);

            return response;
        }


        [HttpGet]
        [Route("getAirpots")]
        [ProducesResponseType(typeof(GetAirportsHandlerResponse), 200)]
        public async Task<GetAirportsHandlerResponse> GetAirports([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var request = new GetAirportsHandlerRequest()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var response = await _mediator.Send(request);

            return response;
        }
    }
}
