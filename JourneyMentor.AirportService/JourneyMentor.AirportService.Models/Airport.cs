using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyMentor.AirportService.Models
{
    [Table("Airport")]
    public class Airport
    {
        public int Id { get; set; }

        public string Gmt { get; set; }

        public int? AirportId { get; set; }

        public string IataCode { get; set; }

        public string CityIataCode { get; set; }

        public string IcaoCode { get; set; }

        public string CountryIso2 { get; set; }

        public string GeonameId { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string AirportName { get; set; }

        public string CountryName { get; set; }

        public string? PhoneNumber { get; set; }

        public string Timezone { get; set; }
    }
}