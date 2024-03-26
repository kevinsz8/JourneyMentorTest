﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentor.FlightService.ServiceClients.Messages.Request
{
    public class GetFlightsRequest
    {
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
    }
}
