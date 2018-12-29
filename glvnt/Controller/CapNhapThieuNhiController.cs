using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using glvnt.Model;
using MySql.Data.MySqlClient;
using static glvnt.Model.Utils;

namespace glvnt.Controller
{
    class CapNhapThieuNhiController
    {
        public ThieuNhi LoadThieuNhi(string id)
        {
            ThieuNhi thieunhi = new ThieuNhi();
            string connectionString = CONNSTRING.connstring;
            MySqlConnection cnn = new MySqlConnection(connectionString);

            try
            {
                cnn.Open();
                string sql = "SELECT * FROM leohien4_glvnt.ThieuNhi where id_thieunhi = " + id + ";";
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    thieunhi.id_thieunhi = reader[IDTHIEUNHI] == null ? "" : reader[IDTHIEUNHI].ToString();
                    thieunhi.ten_thanh = reader[TENTHANH] == null ? "" : reader[TENTHANH].ToString();
                    thieunhi.ten = reader[TEN] == null ? "" : reader[TEN].ToString();
                    thieunhi.ho = reader[HO] == null ? "" : reader[HO].ToString();
                    thieunhi.ngay_sinh = reader[NGAYSINH] == null ? "" : reader[NGAYSINH].ToString();
                    thieunhi.cha = reader[CHA] == null ? "" : reader[CHA].ToString();
                    thieunhi.me = reader[ME] == null ? "" : reader[ME].ToString();
                    thieunhi.dia_chi = reader[DIACHI] == null ? "" : reader[DIACHI].ToString();
                    thieunhi.dt1 = reader[DT1] == null ? "" : reader[DT1].ToString();
                    thieunhi.dt2 = reader[DT2] == null ? "" : reader[DT2].ToString();
                    thieunhi.khu = reader[KHU] == null ? "" : reader[KHU].ToString();
                    thieunhi.ace = reader[ACE] == null ? "" : reader[ACE].ToString();
                    thieunhi.ghi_chu = reader[GHICHU] == null ? "" : reader[GHICHU].ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
            finally
            {
                cnn.Close();
            }

            return thieunhi;
        }

        public void updateThieuNhi(ThieuNhi thieunhi)
        {
            string connectionString = CONNSTRING.connstring;
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sql = "";

                sql = "UPDATE ThieuNhi SET " +
                    TENTHANH + " = '" + thieunhi.ten_thanh + "'" +
                    " ," + TEN + " = '" + thieunhi.ten + "'" +
                    " ," + HO + " = '" + thieunhi.ho + "'" +
                    " ," + NGAYSINH + " = '" + convertMDYYYYtoYYYYMD(thieunhi.ngay_sinh) + "'" +
                    " ," + CHA + " = '" + thieunhi.cha + "'" +
                    " ," + ME + " = '" + thieunhi.me + "'" +
                    " ," + DIACHI + " = '" + thieunhi.dia_chi + "'" +
                    " ," + DT1 + " = '" + thieunhi.dt1 + "'" +
                    " ," + GHICHU + " = '" + thieunhi.ghi_chu + "'" +
                    " WHERE " + IDTHIEUNHI + " = " + thieunhi.id_thieunhi;

                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
            finally { cnn.Close(); }
        }
    }
}
