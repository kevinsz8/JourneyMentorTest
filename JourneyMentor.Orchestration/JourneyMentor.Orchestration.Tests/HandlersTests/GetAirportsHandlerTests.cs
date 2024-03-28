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
    public class GetAirportsHandlerTests
    {
        [Fact]
        public async Task Handle_Success_Returns_Response()
        {
            var airportInterfaceMock = new Mock<IAirportInterface>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<GetAirportsHandler>>();

            var request = new GetAirportsHandlerRequest();
            var cancellationToken = CancellationToken.None;

            var airportRequest = new GetAirportRequest();
            var airportResponse = new GetAirportResponse();

            airportInterfaceMock.Setup(x => x.GetAirports(airportRequest))
                                .ReturnsAsync(airportResponse);

            var expectedResponse = new GetAirportsHandlerResponse();
            mapperMock.Setup(x => x.Map<GetAirportRequest>(request))
                      .Returns(airportRequest);
            mapperMock.Setup(x => x.Map<GetAirportsHandlerResponse>(airportResponse))
                      .Returns(expectedResponse);

            var handler = new GetAirportsHandler(airportInterfaceMock.Object, mapperMock.Object, loggerMock.Object);

            var result = await handler.Handle(request, cancellationToken);

            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task Handle_Exception_Returns_AirportNull()
        {
            var airportInterfaceMock = new Mock<IAirportInterface>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<GetAirportsHandler>>();

            var request = new GetAirportsHandlerRequest();
            var cancellationToken = CancellationToken.None;

            var airportRequest = new GetAirportRequest();

            airportInterfaceMock.Setup(x => x.GetAirports(airportRequest))
                                .ThrowsAsync(new Exception("Airport response is null."));

            var handler = new GetAirportsHandler(airportInterfaceMock.Object, mapperMock.Object, loggerMock.Object);

            var result = await handler.Handle(request, cancellationToken);

            Assert.False(result.Success);
            Assert.Equal("Error", result.StatusMessage);
            Assert.Equal("Airport response is null.", result.ErrorMessage);
        }
    }
}
