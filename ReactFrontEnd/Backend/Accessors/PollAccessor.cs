using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;


namespace Backend.Accessors
{
    public class PollAccessor : Models.IPollRepository
    {
        public List<Models.Poll> GetAllPolls()
        {
            Properties.Config c = new Properties.Config();
            string connstr = c.connStr();

            string query = @"select pollId, question, description, accountId from Poll;";
            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(connstr))
            {
                mycon.Open();
                using (MySqlCommand mycmd = new MySqlCommand(query, mycon))
                {
                    myReader = mycmd.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            List<Models.Poll> polls = new List<Models.Poll>();

            
            string tle = String.Empty;
            string desc = String.Empty;
            string pollId = String.Empty;
            string accId = String.Empty;
            foreach (DataRow row in table.Rows)
            {
                tle = row["question"].ToString();
                desc = row["description"].ToString();
                pollId = row["pollId"].ToString();
                accId = row["accountId"].ToString();
                Models.Poll poll = new Models.Poll();
                try
                {
                    poll.title = tle;
                    poll.description = desc;
                    poll.pollId = Int32.Parse(pollId);
                    poll.accountId = Int32.Parse(accId);
                    polls.Add(poll);
                } catch(FormatException fnfe)
                {
                    Console.Write(fnfe.Message);
                }
            }
            return polls;
        }
    }
}
