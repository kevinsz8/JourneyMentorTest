﻿using AutoMapper;
using JourneyMentor.FlightService.DataAccess;
using JourneyMentor.FlightService.Models;
using JourneyMentor.FlightService.ServiceClients.Messages.Request;
using JourneyMentor.FlightService.ServiceClients.Messages.Response;
using JourneyMentor.FlightService.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JourneyMentor.FlightService.ServiceClients
{
    public class FlightInterface : IFlightInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public FlightInterface(ApplicationDbContext context, HttpClient httpClient, IMapper mapper)
        {
            _context = context;
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<List<GetFlightsResponse>> GetFlights(GetFlightsRequest request)
        {
            var flightsQuery = _context.Flights.AsQueryable();

            if (request.DepartureAirport != null || request.ArrivalAirport != null)
            {
                flightsQuery = flightsQuery.Where(x =>
                    (request.DepartureAirport == null || x.DepartureAirport == request.DepartureAirport) &&
                    (request.ArrivalAirport == null || x.ArrivalAirport == request.ArrivalAirport));
            }

            var flights = await flightsQuery.ToListAsync();

            return _mapper.Map<List<GetFlightsResponse>>(flights);
        }

        public async Task ImportFlights(string apiUrl, string accessKey)
        {
            try
            {
                List<Flight> Flights = await GetAllFlightsAsync(apiUrl, accessKey);
                _context.Flights.AddRange(Flights);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<List<Flight>> GetAllFlightsAsync(string apiUrl, string accessKey)
        {
            List<Flight> allFlights = new List<Flight>();
            int offset = 0;
            int limit = 100;

            while (true)
            {
                string requestUrl = $"{apiUrl}?access_key={accessKey}&offset={offset}&limit={limit}";

                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<FlightResponseModel>(responseBody);
                    var flightsData = responseModel.Data;

                    foreach (var flightData in flightsData)
                    {
                        var flight = MapToFlight(flightData);
                        allFlights.Add(flight);
                    }


                    var total = responseModel.Pagination.Total;
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

            return allFlights;
        }

        private Flight MapToFlight(FlightData flightData)
        {
            return new Flight
            {
                FlightDate = flightData.FlightDate,
                FlightStatus = flightData.FlightStatus,
                DepartureAirport = flightData.Departure.Airport,
                DepartureTimezone = flightData.Departure.Timezone,
                DepartureIata = flightData.Departure.Iata,
                DepartureIcao = flightData.Departure.Icao,
                DepartureTerminal = flightData.Departure.Terminal,
                DepartureGate = flightData.Departure.Gate,
                DepartureDelay = flightData.Departure.Delay,
                DepartureScheduled = flightData.Departure.Scheduled,
                DepartureEstimated = flightData.Departure.Estimated,
                DepartureActual = flightData.Departure.Actual ?? default(string),
                DepartureEstimatedRunway = flightData.Departure.EstimatedRunway ?? default(string),
                DepartureActualRunway = flightData.Departure.ActualRunway ?? default(string),
                ArrivalAirport = flightData.Arrival.Airport,
                ArrivalTimezone = flightData.Arrival.Timezone,
                ArrivalIata = flightData.Arrival.Iata,
                ArrivalIcao = flightData.Arrival.Icao,
                ArrivalTerminal = flightData.Arrival.Terminal,
                ArrivalGate = flightData.Arrival.Gate,
                ArrivalBaggage = flightData.Arrival.Baggage,
                ArrivalDelay = flightData.Arrival.Delay,
                ArrivalScheduled = flightData.Arrival.Scheduled,
                ArrivalEstimated = flightData.Arrival.Estimated,
                ArrivalActual = flightData.Arrival.Actual ?? default(string),
                ArrivalEstimatedRunway = flightData.Arrival.EstimatedRunway ?? default(string),
                ArrivalActualRunway = flightData.Arrival.ActualRunway ?? default(string),
                AirlineName = flightData.Airline.Name,
                AirlineIata = flightData.Airline.Iata,
                AirlineIcao = flightData.Airline.Icao,
                FlightNumber = flightData.Flight.Number,
                FlightIata = flightData.Flight.Iata,
                FlightIcao = flightData.Flight.Icao,
                AircraftRegistration = flightData.Aircraft.Registration,
                AircraftIata = flightData.Aircraft.Iata,
                AircraftIcao = flightData.Aircraft.Icao,
                AircraftIcao24 = flightData.Aircraft.Icao24,
                LiveUpdated = flightData.Live.Updated,
                LiveLatitude = flightData.Live.Latitude,
                LiveLongitude = flightData.Live.Longitude,
                LiveAltitude = flightData.Live.Altitude,
                LiveDirection = flightData.Live.Direction,
                LiveSpeedHorizontal = flightData.Live.SpeedHorizontal,
                LiveSpeedVertical = flightData.Live.SpeedVertical,
                LiveIsGround = flightData.Live.IsGround
            };
        }
    }
}