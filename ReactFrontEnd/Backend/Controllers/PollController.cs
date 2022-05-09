using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PollController : ControllerBase
    {
        private readonly ILogger<PollController> _logger;
        private readonly IConfiguration _configuration;


        public PollController(ILogger<PollController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/polls")]
        public List<Models.Poll> GetPolls()
        {
            var c = new Accessors.PollAccessor();
            List<Models.Poll> result = c.GetAllPolls();
            return result;
        }
    }
}