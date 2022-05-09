using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;


namespace Backend.Accessors
{
    public class AnswerAccessor : Models.IAnswerRepository
    {

        public List<Models.Answer> GetAnswers(String pollId)
        {
            Properties.Config c = new Properties.Config();
            string connstr = c.connStr();

            string query = @"select answerId, choice, pollId from Answer where pollId = @pollId;";
            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(connstr))
            {
                mycon.Open();
                using (MySqlCommand mycmd = new MySqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@pollId", pollId);
                    myReader = mycmd.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            List<Models.Answer> answers = new List<Models.Answer>();

            string ansId = String.Empty;
            string choice = String.Empty;
            string pId = String.Empty;

            foreach (DataRow row in table.Rows)
            {
                ansId = row["answerId"].ToString();
                choice = row["choice"].ToString();
                pId = row["pollId"].ToString();
                Models.Answer answer = new Models.Answer();
                try
                {
                    answer.answerId = Int32.Parse(ansId);
                    answer.choice = choice;
                    answer.pollId = Int32.Parse(pId);
                    answers.Add(answer);
                } catch(FormatException fe)
                {
                    Console.Write(fe.Message);
                }
            }
            return answers;
        }
    }
}
