﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentor.AirportService.Business.Messages.Common
{
    public class Airport
    {
        public string AirportId { get; set; }

        public string IataCode { get; set; }
        public string AirportName { get; set; }

        public string CountryName { get; set; }
    }
}
