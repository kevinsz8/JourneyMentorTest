﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentor.Orchestration.ServiceClients.Messages.Request
{
    public class GetAirportRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
