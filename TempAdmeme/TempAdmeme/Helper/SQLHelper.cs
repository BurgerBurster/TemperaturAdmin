using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TempAdmeme.Models;

namespace TempAdmeme.Helper
{
    public class SQLHelper
    {
        private string connectionString = "server=mysql04.manitu.net;database=db25461;uid=u25461;pwd=wk3bwBmShWv5;";

        public List<User> getUsers()
        {
            try
            {
                List<User> users = new List<User>();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string SQL = "SELECT * FROM benutzer";

                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = SQL;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User()
                            {
                                ID = (int)reader[0],
                                Name = reader[1].ToString(),
                                LoginName = reader[2].ToString(),
                                Phone = reader[3].ToString()
                            }); ;
                        }
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                VarContainer.logger.Error($"{MethodBase.GetCurrentMethod().Name}: {ex.Message} {ex.StackTrace}");
                return new List<User>();
            }
        }
    }
}
