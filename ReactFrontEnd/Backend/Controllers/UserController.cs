using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class UserController : ControllerBase
        {
            private readonly ILogger<UserController> _logger;
            private readonly IConfiguration _configuration;

            public UserController(ILogger<UserController> logger)
            {
                _logger = logger;
            }

            [HttpGet]
            [Route("api/users/{voterId}/{password}")]
            public Models.User GetUser(string voterId, string password)
            {
            var c = new Accessors.UserAccessor();
            Models.User result = c.GetUser(voterId, password);
            return result;
            }


        }
    
}
