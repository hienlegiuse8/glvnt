using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Configuration;
using MySql.Data.MySqlClient;
using glvnt.Model;

namespace glvnt.Controller
{
    class DanhSachThieuNhiController
    {
        public DanhSachThieuNhiController() { }
        public System.Data.DataTable PupilLoad()
        {
            //string connetionString = ConfigurationManager.ConnectionStrings["tnntsiteground"].ConnectionString;
            string connectionString = CONNSTRING.connstring;
            MySqlConnection cnn = new MySqlConnection(connectionString);
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                cnn.Open();
                string sql = "SELECT id_thieunhi, ten_thanh as 'Tên Thánh', ten as 'Tên', ho as 'Họ', ngay_sinh as 'Ngày Sinh'," +
                    " cha as 'Cha', me as 'Mẹ', dia_chi as 'Địa Chỉ', dt1 as 'ĐT'," +
                    " khu as 'Khu', ace as 'ACE', ghi_chu as 'Ghi Chú' FROM leohien4_glvnt.ThieuNhi";
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
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
