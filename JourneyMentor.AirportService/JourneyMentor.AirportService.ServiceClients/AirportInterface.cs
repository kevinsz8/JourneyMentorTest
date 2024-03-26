using JourneyMentor.AirportService.DataAccess;
using JourneyMentor.AirportService.Models;
using JourneyMentor.AirportService.Services;
using Org.BouncyCastle.Crypto;
using System.Net.Http;
using System.Text.Json;

namespace JourneyMentor.AirportService.ServiceClients
{
    public class AirportInterface : IAirportInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public AirportInterface(ApplicationDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task ImportItems(string apiUrl, string accessKey)
        {
            try
            {
                List<Airport> airports = await GetAllAirportsAsync(apiUrl, accessKey);
                _context.Airports.AddRange(airports);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<List<Airport>> GetAllAirportsAsync(string apiUrl, string accessKey)
        {
            List<Airport> allAirports = new List<Airport>();
            int offset = 0;
            int limit = 100;

            while (true)
            {
                string requestUrl = $"{apiUrl}?access_key={accessKey}&offset={offset}&limit={limit}";

                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var jsonDocument = JsonDocument.Parse(responseBody);
                    var data = jsonDocument.RootElement.GetProperty("data");

                    foreach (var airportElement in data.EnumerateArray())
                    {
                        var airport = new Airport
                        {
                            IataCode = airportElement.GetProperty("iata_code").GetString(),
                            AirportName = airportElement.GetProperty("airport_name").GetString()
                            
                        };
                        allAirports.Add(airport);
                    }

                    var pagination = jsonDocument.RootElement.GetProperty("pagination");
                    int total = pagination.GetProperty("total").GetInt32();
                    offset += limit;
                    if (offset >= total)
                    {
                        break; 
                    }
                }
                else
                {
                    throw new Exception($"Failed to get data. Status code: {response.StatusCode}");
                }
            }

            return allAirports;
        }
    }
}