using AutoMapper;
using JourneyMentor.FlightService.Business.Handlers;
using JourneyMentor.FlightService.Business.Messages.Query.Request;
using JourneyMentor.FlightService.Models.Config;
using JourneyMentor.FlightService.ServiceClients.Messages.Request;
using JourneyMentor.FlightService.ServiceClients.Messages.Response;
using JourneyMentor.FlightService.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentor.FlightService.Tests.HandlerTests
{
    public class GetFlightsHandlerTests
    {
        [Fact]
        public async Task Handle_Success_Returns_Response()
        {
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<GetFlightsHandler>>();
            var flightInterfaceMock = new Mock<IFlightInterface>();
            var optionsMock = new Mock<IOptions<AviationStackOptions>>();

            var request = new GetFlightsHandlerRequest();
            var cancellationToken = CancellationToken.None;

            var flightResponse = new List<GetFlightsResponse>();

            optionsMock.Setup(x => x.Value).Returns(new AviationStackOptions());

            flightInterfaceMock.Setup(x => x.GetFlights(It.IsAny<GetFlightsRequest>()))
                              .ReturnsAsync(flightResponse);

            var handler = new GetFlightsHandler(mapperMock.Object, loggerMock.Object, flightInterfaceMock.Object, optionsMock.Object);

            var result = await handler.Handle(request, cancellationToken);

            Assert.NotNull(result);
            Assert.Equal("Success", result.StatusMessage);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Handle_Exception_Returns_ErrorResponse()
        {
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<GetFlightsHandler>>();
            var flightInterfaceMock = new Mock<IFlightInterface>();
            var optionsMock = new Mock<IOptions<AviationStackOptions>>();

            var request = new GetFlightsHandlerRequest();
            var cancellationToken = CancellationToken.None;

            optionsMock.Setup(x => x.Value).Returns(new AviationStackOptions());

            flightInterfaceMock.Setup(x => x.GetFlights(It.IsAny<GetFlightsRequest>()))
                               .ThrowsAsync(new Exception("throwing some test exception"));

            var handler = new GetFlightsHandler(mapperMock.Object, loggerMock.Object, flightInterfaceMock.Object, optionsMock.Object);

            var result = await handler.Handle(request, cancellationToken);

            Assert.NotNull(result);
            Assert.Equal("Error", result.StatusMessage);
            Assert.False(result.Success);
            Assert.Equal("An error occurred while processing your request. Please try again later.", result.ErrorMessage);
        }
    }
}
