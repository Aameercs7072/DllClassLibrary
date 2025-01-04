using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Model;

using MySql.Data.MySqlClient;

namespace ClassLibrary1
{
    
       

        public class UserDb
    {
        private string connectionString = "Server=localhost ;Port=3306;Database=dummy;Uid=root;Pwd=Aameer@2004;";
        public List<GetUser> Getuser()
            {
                List<GetUser> userList = new List<GetUser>();
                using (MySqlConnection connnect = new MySqlConnection(connectionString))
                {
                    connnect.Open();
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("GetUser", connnect);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                            GetUser User = new GetUser()
                                {

                                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Email = reader.GetString(reader.GetOrdinal("Email"))
                                };
                                userList.Add(User);
                            }
                            return userList;
                        }
                    }
                    catch (Exception)
                    {
                        return new List<GetUser>();
                    }
                }
                return new List<GetUser>();
            }

            public bool AddUser(NewUser newuser)
            {
                using (MySqlConnection connect = new MySqlConnection(connectionString))
                {
                    connect.Open();
                    try
                    {
                        //NewUser newuser = new NewUser();
                        Guid id = Guid.NewGuid();
                        MySqlCommand cmd = new MySqlCommand("AddUser", connect);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_id", id);
                        cmd.Parameters.AddWithValue("@p_name", newuser.Name);
                        cmd.Parameters.AddWithValue("@p_email", newuser.Email);
                        cmd.Parameters.AddWithValue("@p_password", newuser.Password);
                        cmd.Parameters.AddWithValue("@p_createdOn", DateTime.Now);
                        int response = cmd.ExecuteNonQuery();
                        return response > 0 ? true : false;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

            }
            public bool UpdateUser(User user)
            {
                using (MySqlConnection connect = new MySqlConnection(connectionString))
                {
                    connect.Open();
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("UpdateUser", connect);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_id", user.Id);
                        cmd.Parameters.AddWithValue("@p_name", user.Name);
                        cmd.Parameters.AddWithValue("@p_email", user.Email);
                        cmd.Parameters.AddWithValue("@p_password", user.Password);
                        cmd.Parameters.AddWithValue("@p_modifiedOn", DateTime.Now);
                        int response = cmd.ExecuteNonQuery();
                        return response > 0 ? true : false;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

            }
            public bool DeleteUser(Guid id)
            {
                using (MySqlConnection connect = new MySqlConnection(connectionString))
                {
                    connect.Open();
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("DeleteUser", connect);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_id", id);
                        int response = cmd.ExecuteNonQuery();
                        return response > 0 ? true : false;

                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

            }
        }
        
}
