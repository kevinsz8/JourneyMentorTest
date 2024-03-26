using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyMentor.AirportService.Models
{
    [Table("item")]
    public class Airport
    {
        [Column("id")]
        public string Id { get; set; }

        [Column("gmt")]
        public string Gmt { get; set; }

        [Column("airport_id")]
        public string AirportId { get; set; }

        [Column("iata_code")]
        public string IataCode { get; set; }

        [Column("city_iata_code")]
        public string CityIataCode { get; set; }

        [Column("icao_code")]
        public string IcaoCode { get; set; }

        [Column("country_iso2")]
        public string CountryIso2 { get; set; }

        [Column("geoname_id")]
        public string GeonameId { get; set; }

        [Column("latitude")]
        public string Latitude { get; set; }

        [Column("longitude")]
        public string Longitude { get; set; }

        [Column("airport_name")]
        public string AirportName { get; set; }

        [Column("country_name")]
        public string CountryName { get; set; }

        [Column("phone_number")]
        public object PhoneNumber { get; set; }

        [Column("timezone")]
        public string Timezone { get; set; }
    }
}