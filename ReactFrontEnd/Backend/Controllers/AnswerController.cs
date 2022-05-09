using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    public class AnswerController : ControllerBase
    {
        private readonly ILogger<AnswerController> _logger;
        private readonly IConfiguration _configuration;

        public AnswerController(ILogger<AnswerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/answers/{pollId}")]
        public List<Models.Answer> GetAnswers(string pollId)
        {
            var c = new Accessors.AnswerAccessor();
            List<Models.Answer> result = c.GetAnswers(pollId);
            return result;
        }
 
    }
}
