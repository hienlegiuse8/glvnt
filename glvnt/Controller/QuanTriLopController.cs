/*
using System;
using System.Collections.Generic;
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

            MySqlConnection cnn;
            string connectionString = Utils.CONNSTRING;
            cnn = new MySqlConnection(connectionString);

            cnn.Open();
            string sql = "";
            if (_hocky1)
            {
                sql = "SELECT id_thieunhi, ten, ho, ngay_sinh, hk1_kt_mieng, hk1_kt_15phut, hk1_1tiet, hk1_hocky, hk1_vang, hk1_tre, hk1_co_mat," +
                    " hk1_hoc_luc, hk1_chuyen_can, hk1_dao_duc, hk1_xep_loai, hk1_thu_hang" +
                    " FROM leohien4_glvnt.DSTNCurrentlopHK1 where id_lopnamhoc = " + lopid;
            }
            else
            {
                sql = "SELECT id_thieunhi, ten, ho, ngay_sinh, hk2_kt_mieng, hk2_kt_15phut, hk2_1tiet, hk2_hocky, hk2_vang, hk2_tre, hk2_co_mat," +
                    " hk2_hoc_luc, hk2_chuyen_can, hk2_dao_duc, hk2_xep_loai, cn_thu_hang," +
                    " cn_hoc_luc, cn_chuyen_can, cn_dao_duc, cn_xep_loai" +
                    " FROM leohien4_glvnt.DSTNCurrentlopHK2 where id_lopnamhoc = " + lopid;
            }
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            msda.Fill(dt);
            return dt;
        }
    }
}
