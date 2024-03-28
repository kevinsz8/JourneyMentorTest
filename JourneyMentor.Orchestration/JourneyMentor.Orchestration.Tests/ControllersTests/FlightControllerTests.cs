using JourneyMentor.Orchestration.Business.Messages.Command.Request;
using JourneyMentor.Orchestration.Business.Messages.Query.Request;
using JourneyMentor.Orchestration.Business.Messages.Query.Response;
using JourneyMentor.Orchestration.Controllers;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentor.Orchestration.Tests.ControllersTests
{
    public class FlightControllerTests
    {
        [Fact]
        public async Task ImportFlightHandler_Returns_Unit()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<ImportFlightHandlerRequest>(), default)).ReturnsAsync(Unit.Value);
            var controller = new FlightController(mockMediator.Object);

            var result = await controller.ImportFlightHandler();

            Assert.Equal(Unit.Value, result);
        }

        [Fact]
        public async Task GetFlights_Returns_GetFlightsHandlerResponse()
        {
            var departureAirport = "ABC";
            var arrivalAirport = "XYZ";
            var mockMediator = new Mock<IMediator>();
            var expectedResponse = new GetFlightsHandlerResponse();
            mockMediator.Setup(m => m.Send(It.IsAny<GetFlightsHandlerRequest>(), default)).ReturnsAsync(expectedResponse);
            var controller = new FlightController(mockMediator.Object);

            var result = await controller.GetFlights(departureAirport, arrivalAirport);

            Assert.IsType<GetFlightsHandlerResponse>(result);
        }
    }
}
