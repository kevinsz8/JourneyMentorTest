namespace JourneyMentor.Orchestration.Models
{
    public class ServiceConfigOptions
    {
        public const string MicroserviceUrls = "MicroserviceUrls";
        public string GetAirportsEndpoint { get; set; }
        public string ImportAirportEndpoint { get; set; }
        public string GetFlightsEndpoint { get; set; }
    }
}