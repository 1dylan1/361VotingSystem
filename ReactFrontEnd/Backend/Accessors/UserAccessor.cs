using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;


namespace Backend.Accessors
{
    public class UserAccessor : Models.IUserRepository
    {
        public Models.User GetUser(String voterId, String password)
        {
            Properties.Config c = new Properties.Config();
            string connstr = c.connStr();

            string query = @"select accountId, voterId, password, account_type from Person where voterId = @vid and password = @password;";
            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using(MySqlConnection mycon = new MySqlConnection(connstr))
            {
                mycon.Open();
                using(MySqlCommand mycmd = new MySqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@vid", voterId);
                    mycmd.Parameters.AddWithValue("@password", password);
                    myReader = mycmd.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            Models.User user = new Models.User();
            string vId = String.Empty;
            string aId = String.Empty;
            string pw = String.Empty;
            string at = String.Empty;
            foreach (DataRow row in table.Rows)
            {
                vId = row["voterId"].ToString();
                aId = row["accountId"].ToString();
                pw = row["password"].ToString();
                at = row["account_type"].ToString();
            }

            if (aId != null)
            {
                try
                {
                    user.Id = Int32.Parse(aId);
                    user.voterId = vId;
                    user.password = pw;
                    user.accountType = at;

                }
                catch (FormatException fe)
                {
                    user.Id = -1;
                    user.voterId = "null";
                    user.password = "null";
                    user.accountType = "null";
                }
            }
            return user;
        }
    }
}
