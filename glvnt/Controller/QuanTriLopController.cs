using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
using MySql.Data.MySqlClient;
using glvnt.Model;

namespace glvnt.Controller
{
    class QuanTriLopController
    {
        public System.Data.DataTable LoadClassWithId(string _lopid, bool _hocky1)
        {
            string lopid = _lopid.Substring(1);
            string connectionString = CONNSTRING.connstring;
            MySqlConnection cnn = new MySqlConnection(connectionString);
            System.Data.DataTable dt = null;
            try
            {
                cnn.Open();
                string sql = "";
                if (_hocky1)
                {
                    sql = "SELECT id_thieunhi as id, ten, ho, ngay_sinh, hk1_mieng, hk1_15phut, hk1_1tiet, hk1_hocky, hk1_vang, hk1_tre, hk1_co_mat," +
                        " hk1_hoc_luc, hk1_chuyen_can, hk1_dao_duc, hk1_xep_loai, hk1_thu_hang" +
                        " FROM leohien4_glvnt.DSTNCurrentlopHK1 where id_lopnamhoc = " + lopid +
                        " order by ten, ho, id_thieunhi";
                }
                else
                {
                    sql = "SELECT id_thieunhi as id, ten, ho, ngay_sinh, hk2_mieng, hk2_15phut, hk2_1tiet, hk2_hocky, hk2_vang, hk2_tre, hk2_co_mat, " +
                        " hk2_hoc_luc, hk2_chuyen_can, hk2_dao_duc, hk2_xep_loai, " +
                        " cn_hoc_luc, cn_chuyen_can, cn_dao_duc, cn_xep_loai, cn_thu_hang " +
                        " FROM leohien4_glvnt.DSTNCurrentlopHK2 where id_lopnamhoc = " + lopid +
                        " order by ten, ho, id_thieunhi";
                }
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                dt = new System.Data.DataTable();

                msda.Fill(dt);
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
            finally { cnn.Close(); }
            return dt;
        }

        public void updateHK(ThieuNhiLopNamHoc bangdiem, bool _hocky1)
        {
            string connectionString = CONNSTRING.connstring;
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sql = "";

                if (_hocky1)
                {
                    sql = "UPDATE ThieuNhiLopNamHoc SET " +
                        "hk1_mieng = " + bangdiem.hk1_mieng +
                        "hk1_15phut = " + bangdiem.hk1_15phut +
                        "hk1_1tiet = " + bangdiem.hk1_1tiet +
                        "hk1_hocky = " + bangdiem.hk1_hocky +
                        "hk1_vang = " + bangdiem.hk1_vang +
                        "hk1_tre = " + bangdiem.hk1_tre +
                        "hk1_co_mat = " + bangdiem.hk1_co_mat +
                        "hk1_hoc_luc = " + bangdiem.hk1_hoc_luc +
                        "hk1_chuyen_can = " + bangdiem.hk1_chuyen_can +
                        "hk1_dao_duc = " + bangdiem.hk1_dao_duc +
                        "hk1_xep_loai = " + bangdiem.hk1_xep_loai +
                        "WHERE id_thieunhilopnamhoc = " + bangdiem.id_thieunhilopnamhoc;
                }
                else
                {
                    sql = "UPDATE ThieuNhiLopNamHoc SET " +
                        "hk2_mieng = " + bangdiem.hk2_mieng +
                        "hk2_15phut = " + bangdiem.hk2_15phut +
                        "hk2_1tiet = " + bangdiem.hk2_1tiet +
                        "hk2_hocky = " + bangdiem.hk2_hocky +
                        "hk2_vang = " + bangdiem.hk2_vang +
                        "hk2_tre = " + bangdiem.hk2_tre +
                        "hk2_co_mat = " + bangdiem.hk2_co_mat +
                        "hk2_hoc_luc = " + bangdiem.hk2_hoc_luc +
                        "hk2_chuyen_can = " + bangdiem.hk2_chuyen_can +
                        "hk2_dao_duc = " + bangdiem.hk2_dao_duc +
                        "hk2_xep_loai = " + bangdiem.hk2_xep_loai +
                        "WHERE id_thieunhilopnamhoc = " + bangdiem.id_thieunhilopnamhoc;
                }

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
