using JourneyMentor.Orchestration.Business.Messages.Command.Request;
using JourneyMentor.Orchestration.Business.Messages.Query.Request;
using JourneyMentor.Orchestration.Business.Messages.Query.Response;
using JourneyMentor.Orchestration.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentor.Orchestration.Tests.ControllersTests
{
    public class AirportControllerTests
    {
        [Fact]
        public async Task ImportAirportHandler_Returns_OkResult()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<ImportAirportHandlerRequest>(), default)).ReturnsAsync(Unit.Value);
            var controller = new AirportController(mockMediator.Object);

            var result = await controller.ImportAirportHandler();

            Assert.Equal(Unit.Value, result);
        }

        [Fact]
        public async Task GetAirports_Returns_GetAirportsHandlerResponse()
        {
            var pageNumber = 1;
            var pageSize = 10;
            var mockMediator = new Mock<IMediator>();
            var expectedResponse = new GetAirportsHandlerResponse();
            mockMediator.Setup(m => m.Send(It.IsAny<GetAirportsHandlerRequest>(), default)).ReturnsAsync(expectedResponse);
            var controller = new AirportController(mockMediator.Object);

            var result = await controller.GetAirports(pageNumber, pageSize);

            Assert.IsType<GetAirportsHandlerResponse>(result);
        }
    }
}
