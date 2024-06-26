﻿using JourneyMentor.Orchestration.Business.Messages.Common;

namespace JourneyMentor.Orchestration.ServiceClients.Messages.Response
{
    public class GetAirportResponse : BaseResponse
    {
        public List<Airport> Airports { get; set; }
    }
}
