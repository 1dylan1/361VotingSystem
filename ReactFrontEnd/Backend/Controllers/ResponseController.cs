using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
// todo: add config class 
namespace Backend.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class ResponseController : ControllerBase
    {
        private readonly ILogger<ResponseController> _logger;
        private readonly IConfiguration _configuration;


        public ResponseController(ILogger<ResponseController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("api/response/{answerId}/{pollId}/{accountId}")]
        public String SendResponse(int answerId, int pollId, int accountId)
        {
            Properties.Config c = new Properties.Config();
            string connstr = c.connStr();

            string query = @"insert into Response(answerId, pollId, accountId) values (@answerId,@pollId,@accountId);";
            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(connstr))
            {
                mycon.Open();
                using(MySqlCommand mycmd = new MySqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@answerId", answerId);
                    mycmd.Parameters.AddWithValue("@pollId", pollId);
                    mycmd.Parameters.AddWithValue("@accountId", accountId);
                    myReader = mycmd.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            String jsonResult = "Added Vote Successfully.";
            return jsonResult;
        }

        [HttpGet]
        [Route("api/hasCompleted/{pollId}/{accountId}")] 
        public String GetCompletedResponse(int pollId, int accountId)
        {
            string query = @"select responseId, answerId from Response where pollId = @pollId and accountId = @accountId;";
            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection("SERVER NOT CONFIGURED HERE")) 
            {
                mycon.Open();
                using(MySqlCommand mycmd = new MySqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@pollId", pollId);
                    mycmd.Parameters.AddWithValue("@accountId", accountId);
                    myReader = mycmd.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            String jsonResult = String.Empty;
            jsonResult = JsonConvert.SerializeObject(table);
            return jsonResult;
        }

        [HttpGet]
        [Route("api/getCount/{pollId}")]
        public String GetCount(int pollId, int answerId)
        {
            string query = @"select a.choice, r.responseId, count(a.choice) as sum from Response r join Answer a where a.answerId = r.answerId and r.pollId = @pollId group by a.choice;";
            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using(MySqlConnection mycon = new MySqlConnection("CONFIG SERVER STRING HERE -- GETCOUNT "))
            {
                mycon.Open();
                using(MySqlCommand mycmd = new MySqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@pollId", pollId);
                    myReader = mycmd.ExecuteReader(0);
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            String jsonResult = String.Empty;
            jsonResult = JsonConvert.SerializeObject(table);
            return jsonResult;
        }
    }
}
