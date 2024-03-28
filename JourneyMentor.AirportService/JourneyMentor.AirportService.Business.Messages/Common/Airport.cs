namespace JourneyMentor.AirportService.Business.Messages.Common
{
    public class Airport
    {
        public int? AirportId { get; set; }

        public string IataCode { get; set; }
        public string AirportName { get; set; }

        public string CountryName { get; set; }
    }
}
