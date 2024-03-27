using JourneyMentor.Orchestration.Business.Messages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentor.Orchestration.ServiceClients.Messages.Response
{
    public class GetAirportResponse : BaseResponse
    {
        public List<Airport> Airports { get; set; }
    }
}
