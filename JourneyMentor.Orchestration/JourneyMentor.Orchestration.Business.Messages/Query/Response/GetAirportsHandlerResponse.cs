﻿using JourneyMentor.Orchestration.Business.Messages.Common;

namespace JourneyMentor.Orchestration.Business.Messages.Query.Response
{
    public class GetAirportsHandlerResponse : BaseResponse
    {
        public List<Airport> Airports { get; set; }
    }
}
