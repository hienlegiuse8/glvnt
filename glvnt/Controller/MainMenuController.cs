using System;
/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using glvnt.Model;
using System.Configuration;
*/
using MySql.Data.MySqlClient;
using glvnt.Model;


namespace glvnt.Controller
{
    class MainMenuController
    {
        public MainMenuController() { }

        //DataSet have multiple DataTables. If use only single table, let select DataTable
        //public System.Data.DataSet ClassLoad()
        public System.Data.DataTable ClassLoad()
        {
            //string connetionString = ConfigurationManager.ConnectionStrings["tnntsiteground"].ConnectionString;
            string connectionString = CONNSTRING.connstring;
            MySqlConnection cnn = new MySqlConnection(connectionString);
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                cnn.Open();
                string sql = "SELECT id_lopnamhoc, ten_lop,ten_namhoc,phong FROM leohien4_glvnt.LopNamHocView where isCurrent=1;";
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                //System.Data.DataSet ds = new System.Data.DataSet();
                //msda.Fill(ds);
                //return ds;
                msda.Fill(dt);
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
            finally { cnn.Close(); }
            return dt;            
        }

    }
}
