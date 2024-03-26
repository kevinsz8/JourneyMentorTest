using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentor.AirportService.Models.Config
{
    public class AviationStackOptions
    {
        public const string AviationStackSettings = "AviationStackSettings";
        public string ApiUrl { get; set; }
        public string AccessKey { get; set; }
    }
}
