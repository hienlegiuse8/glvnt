using System;
using MySql.Data.MySqlClient;
using glvnt.Model;
/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
 */
namespace glvnt.Controller
{
    class LogInController
    {
        public bool CheckLogIn(Glv glv, string user, string password)
        {
            //string connetionString = ConfigurationManager.ConnectionStrings["tnntsiteground"].ConnectionString;
            string connectionString = CONNSTRING.connstring;
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sql = "SELECT username, ten, ho, user_type FROM leohien4_glvnt.Glv where " +
                    "username='" + user + "' and " +
                    "password='" + password + "' and " +
                    "permission=1";
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                //cmd.CommandText = "";
                //cmd.Connection = cnn;
                //cmd.CommandType = CommandType.TableDirect;
                MySqlDataReader reader = cmd.ExecuteReader();
                int rowCount = 0;
                while (reader.Read())
                {
                    glv.Username = reader[0] == null ? "" : reader[0].ToString();
                    glv.Ten = reader[1] == null ? "" : reader[1].ToString();
                    glv.Ho = reader[2] == null ? "" : reader[2].ToString();
                    glv.User_type = reader[3] == null ? "" : reader[3].ToString();
                    rowCount++;
                }

                if (rowCount == 0)
                {
                    throw new Exception("The username/password is wrong or you do not have permission to sign in.");
                }
                else if (rowCount > 1)
                {
                    throw new Exception("There are 2 usernames. Please contact the administrator.");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
                return false;
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
