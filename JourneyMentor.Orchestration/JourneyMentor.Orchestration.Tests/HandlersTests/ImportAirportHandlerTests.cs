using AutoMapper;
using JourneyMentor.Orchestration.Business.Handlers;
using JourneyMentor.Orchestration.Business.Messages.Command.Request;
using JourneyMentor.Orchestration.ServiceClients.Messages.Request;
using JourneyMentor.Orchestration.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentor.Orchestration.Tests.HandlersTests
{
    public class ImportAirportHandlerTests
    {
        [Fact]
        public async Task Handle_Success()
        {
            var airportInterfaceMock = new Mock<IAirportInterface>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<ImportAirportHandler>>();

            var request = new ImportAirportHandlerRequest();
            var cancellationToken = CancellationToken.None;

            var importAirportRequest = new ImportAirportRequest();

            mapperMock.Setup(x => x.Map<ImportAirportRequest>(request))
                      .Returns(importAirportRequest);

            var handler = new ImportAirportHandler(airportInterfaceMock.Object, mapperMock.Object, loggerMock.Object);

            var result = await handler.Handle(request, cancellationToken);

            Assert.Equal(Unit.Value, result);
        }

        [Fact]
        public async Task Handle_Exception()
        {
            var airportInterfaceMock = new Mock<IAirportInterface>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<ImportAirportHandler>>();

            var request = new ImportAirportHandlerRequest();
            var cancellationToken = CancellationToken.None;

            var importAirportRequest = new ImportAirportRequest();

            mapperMock.Setup(x => x.Map<ImportAirportRequest>(request))
                      .Returns(importAirportRequest);

            airportInterfaceMock.Setup(x => x.ImportAirport(importAirportRequest))
                                .ThrowsAsync(new Exception("Test exception"));

            var handler = new ImportAirportHandler(airportInterfaceMock.Object, mapperMock.Object, loggerMock.Object);

            await Assert.ThrowsAsync<Exception>(() => handler.Handle(request, cancellationToken));
        }
    }
}
