using AutoMapper;
using JourneyMentor.Orchestration.Business.Handlers;
using JourneyMentor.Orchestration.Business.Messages.Query.Request;
using JourneyMentor.Orchestration.Business.Messages.Query.Response;
using JourneyMentor.Orchestration.ServiceClients.Messages.Request;
using JourneyMentor.Orchestration.ServiceClients.Messages.Response;
using JourneyMentor.Orchestration.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentor.Orchestration.Tests.HandlersTests
{
    public class GetFlightsHandlerTests
    {
        [Fact]
        public async Task Handle_Success_Returns_Response()
        {
            var flightInterfaceMock = new Mock<IFlightInterface>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<GetFlightsHandler>>();

            var request = new GetFlightsHandlerRequest();
            var cancellationToken = CancellationToken.None;

            var flightRequest = new GetFlightRequest();
            var flightResponse = new GetFlightResponse();

            flightInterfaceMock.Setup(x => x.GetFlights(flightRequest))
                               .ReturnsAsync(flightResponse);

            var expectedResponse = new GetFlightsHandlerResponse();
            mapperMock.Setup(x => x.Map<GetFlightRequest>(request))
                      .Returns(flightRequest);
            mapperMock.Setup(x => x.Map<GetFlightsHandlerResponse>(flightResponse))
                      .Returns(expectedResponse);

            var handler = new GetFlightsHandler(flightInterfaceMock.Object, mapperMock.Object, loggerMock.Object);

            var result = await handler.Handle(request, cancellationToken);

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task Handle_Exception_Returns_FlightNull()
        {
            var flightInterfaceMock = new Mock<IFlightInterface>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<GetFlightsHandler>>();

            var request = new GetFlightsHandlerRequest();
            var cancellationToken = CancellationToken.None;

            var flightRequest = new GetFlightRequest();

            flightInterfaceMock.Setup(x => x.GetFlights(flightRequest))
                               .ThrowsAsync(new Exception("Flight response is null."));

            var handler = new GetFlightsHandler(flightInterfaceMock.Object, mapperMock.Object, loggerMock.Object);

            var result = await handler.Handle(request, cancellationToken);

            Assert.False(result.Success);
            Assert.Equal("Error", result.StatusMessage);
            Assert.Equal("Flight response is null.", result.ErrorMessage);
        }
    }
}
