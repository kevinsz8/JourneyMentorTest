namespace JourneyMentor.AirportService.Services
{
    public interface IAirportInterface
    {
        Task ImportItems(string apiUrl, string accessKey);
    }
}