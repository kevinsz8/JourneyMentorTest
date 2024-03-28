using AutoMapper;
using JourneyMentor.FlightService.DataAccess;
using JourneyMentor.FlightService.Models;
using JourneyMentor.FlightService.ServiceClients;
using JourneyMentor.FlightService.ServiceClients.Messages.Request;
using JourneyMentor.FlightService.ServiceClients.Messages.Response;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Net;

namespace JourneyMentor.FlightService.Tests.ServiceClientsTests
{
    public class FlightInterfaceTests
    {
        [Fact]
        public async Task GetFlights_Returns_Flights()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "JourneyMentorTestDb")
                .Options;
            var context = new ApplicationDbContext(options);
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var mapperMock = new Mock<IMapper>();
            var flight = new Flight();

            context.Flights.Add(flight);
            await context.SaveChangesAsync();

            var flightResponse = new List<GetFlightsResponse>();

            mapperMock.Setup(x => x.Map<List<GetFlightsResponse>>(It.IsAny<List<Flight>>()))
                      .Returns(flightResponse);

            var request = new GetFlightsRequest();
            var flightInterface = new FlightInterface(context, httpClientFactoryMock.Object.CreateClient(), mapperMock.Object);

            var result = await flightInterface.GetFlights(request);

            Assert.NotNull(result);
        }

    }
}
