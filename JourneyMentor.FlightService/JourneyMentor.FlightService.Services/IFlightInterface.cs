namespace JourneyMentor.FlightService.Services
{
    public interface IFlightInterface
    {
        Task ImportFlights(string apiUrl, string accessKey);
    }
}