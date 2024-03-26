using JourneyMentor.AirportService.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace JourneyMentor.AirportService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CheckDatabaseConnectionController : ControllerBase
    {


        private readonly ILogger<CheckDatabaseConnectionController> _logger;
        private readonly ApplicationDbContext _context;

        public CheckDatabaseConnectionController(ILogger<CheckDatabaseConnectionController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "CheckConnection")]
        public async Task<bool> Get()
        {

            try
            {
                return await _context.Database.CanConnectAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
