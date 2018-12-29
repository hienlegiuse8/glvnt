using System;
using System.Data;
using System.Collections.Generic;
/*
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
using MySql.Data.MySqlClient;
using glvnt.Model;
using static glvnt.Model.Utils;


namespace glvnt.Controller
{
    class QuanTriLopController
    {
        
        public System.Data.DataTable LoadClassWithLopId(string _lopid, bool _hocky1)
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
                    sql = "SELECT id_thieunhilopnamhoc, id_thieunhi, ten, ho, ngay_sinh, hkmieng, hk15phut," +
                        " hk1tiet, hkhocky, hkvang, hktre, hkcomat," +
                        " hkhocluc, hkchuyencan, hkdaoduc, hkxeploai, hkthuhang," +
                        " hk1diemtb," +
                        " xeploaihocluc, xeploaichuyencan, xeploaidaoduc, xeploaihk," +
                        " ' ' as cnhocluc, ' ' as cnchuyencan, ' ' as cndaoduc, ' ' as cnxeploai, ' ' as cnthuhang," +
                        " ' ' as cnxeploaihocluc, ' ' as cnxeploaichuyencan, ' ' as cnxeploaidaoduc, ' ' as xeploaicn" +
                        " FROM leohien4_glvnt.DSTNCurrentlopHK1 where id_lopnamhoc = " + lopid +
                        " order by ten, ho, id_thieunhi";
                }
                else
                {
                    sql = "SELECT id_thieunhilopnamhoc, id_thieunhi, ten, ho, ngay_sinh, hkmieng, hk15phut," +
                        " hk1tiet, hkhocky, hkvang, hktre, hkcomat, " +
                        " hkhocluc, hkchuyencan, hkdaoduc, hkxeploai, ' ' as hkthuhang," +
                        " hk1diemtb, hk2diemtb, cndiemtb," +
                        " xeploaihocluc, xeploaichuyencan, xeploaidaoduc, xeploaihk," +
                        " cnhocluc, cnchuyencan, cndaoduc, cnxeploai, cnthuhang," +
                        " cnxeploaihocluc, cnxeploaichuyencan, cnxeploaidaoduc, xeploaicn" +
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

        public System.Data.DataTable LoadClassXepHang(string _lopid, bool _hocky1)
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
                    sql = "SELECT id_thieunhilopnamhoc, ten, ho, hk1_diemtb as dtb" +
                        " FROM leohien4_glvnt.DanhSachThieuNhiCurrentLop where id_lopnamhoc = " + lopid +
                        " order by hk1_diemtb desc, ten, ho, id_thieunhi";
                }
                else
                {
                    sql = "SELECT id_thieunhilopnamhoc, cn_diemtb as dtb" +
                        " FROM leohien4_glvnt.DanhSachThieuNhiCurrentLop where id_lopnamhoc = " + lopid +
                        " order by cn_diemtb desc, ten, ho, id_thieunhi";
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
                        " hk1_mieng = " + bangdiem.hk_mieng +
                        " ,hk1_15phut = " + bangdiem.hk_15phut +
                        " ,hk1_1tiet = " + bangdiem.hk_1tiet +
                        " ,hk1_hocky = " + bangdiem.hk_hocky +
                        " ,hk1_vang = " + bangdiem.hk_vang +
                        " ,hk1_tre = " + bangdiem.hk_tre +
                        " ,hk1_co_mat = " + bangdiem.hk_co_mat +
                        " ,hk1_vang = " + bangdiem.hk_hoc_luc +
                        " ,hk1_tre = " + bangdiem.hk_chuyen_can +
                        " ,hk1_co_mat = " + bangdiem.hk_dao_duc +
                        " ,hk1_hoc_luc = " + bangdiem.hk_hoc_luc +
                        " ,hk1_chuyen_can = " + bangdiem.hk_chuyen_can +
                        " ,hk1_dao_duc = " + bangdiem.hk_dao_duc +
                        " ,hk1_xep_loai = " + bangdiem.hk_xep_loai;
                    if (Utils.isCoDiem(bangdiem.hk1_diemtb)) { sql += " ,hk1_diemtb = " + bangdiem.hk1_diemtb; }
                    sql += " WHERE id_thieunhilopnamhoc = " + bangdiem.id_thieunhilopnamhoc;
                }
                else
                {
                    sql = "UPDATE ThieuNhiLopNamHoc SET" +
                        " hk2_mieng = " + bangdiem.hk_mieng +
                        " ,hk2_15phut = " + bangdiem.hk_15phut +
                        " ,hk2_1tiet = " + bangdiem.hk_1tiet +
                        " ,hk2_hocky = " + bangdiem.hk_hocky +
                        " ,hk2_vang = " + bangdiem.hk_vang +
                        " ,hk2_tre = " + bangdiem.hk_tre +
                        " ,hk2_co_mat = " + bangdiem.hk_co_mat +
                        " ,hk2_hoc_luc = " + bangdiem.hk_hoc_luc +
                        " ,hk2_chuyen_can = " + bangdiem.hk_chuyen_can +
                        " ,hk2_dao_duc = " + bangdiem.hk_dao_duc +
                        " ,hk2_xep_loai = " + bangdiem.hk_xep_loai +
                        " ,cn_hoc_luc = " + bangdiem.cn_hoc_luc +
                        " ,cn_chuyen_can = " + bangdiem.cn_chuyen_can +
                        " ,cn_dao_duc = " + bangdiem.cn_dao_duc +
                        " ,cn_xep_loai = " + bangdiem.cn_xep_loai;
                    if (Utils.isCoDiem(bangdiem.hk2_diemtb)) { sql += " ,hk2_diemtb = " + bangdiem.hk2_diemtb; }
                    if (Utils.isCoDiem(bangdiem.cn_diemtb)) { sql += " ,cn_diemtb = " + bangdiem.cn_diemtb; }
                    sql += " WHERE id_thieunhilopnamhoc = " + bangdiem.id_thieunhilopnamhoc;
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

        public void updateHang(string _lopid, bool _hocky1)
        {
            DataTable dtxh = LoadClassXepHang(_lopid, _hocky1);
            int previous_thuhang = 0;
            int thuhang = 0;
            double previous_dtb = 0;
            string sql = "";
            string HANG_COL = _hocky1 ? HK1HANG : CNHANG;

            // set sql
            foreach (DataRow row in dtxh.Rows)
            {
                string dtbstr = row[DTB].ToString();
                string id_thieunhibd = row[ID_THIEUNHILOPNAMHOC].ToString();
                thuhang++;
                string set;
                if (isCoDiem(dtbstr))
                {
                    if (previous_dtb == Double.Parse(dtbstr))
                    {
                        set = HANG_COL + " = " + previous_thuhang.ToString();
                    }
                    else
                    {
                        set = HANG_COL + " = " + thuhang.ToString();
                        previous_thuhang = thuhang;
                    }
                    sql += "UPDATE ThieuNhiLopNamHoc SET " + set + " WHERE id_thieunhilopnamhoc= '" + id_thieunhibd + "';";
                    previous_dtb = Double.Parse(dtbstr);
                }
            }

            string connectionString = CONNSTRING.connstring;
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
            finally { cnn.Close(); }
        }

        public System.Data.DataTable LoadDataForExcel(string _lopid, bool _hocky1)
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
                    sql = "SELECT id_thieunhi as ID, ho as 'Họ', ten as 'Tên', ngay_sinh as 'Ngày Sinh', hkmieng as 'Miệng', hk15phut as '15 Phút'," +
                        " hk1tiet as '1 Tiết', hkhocky as 'KT Học Kỳ', hkvang as 'Vắng', hktre as 'Trễ', hkcomat as 'Có Mặt'," +
                        " hk1diemtb as 'ĐTB Học Kỳ', hkthuhang as 'Hạng'," +
                        " xeploaihocluc as 'Học Lực', xeploaichuyencan as 'Chuyên Cần', xeploaidaoduc as 'Đạo Đức', xeploaihk as 'Xếp Loại'" +
                        " FROM leohien4_glvnt.DSTNCurrentlopHK1 where id_lopnamhoc = " + lopid +
                        " order by ten, ho, id_thieunhi";
                }
                else
                {
                    sql = "SELECT id_thieunhi as ID, ho as 'Họ', ten as 'Tên', ngay_sinh as 'Ngày Sinh', hkmieng as 'Miệng', hk15phut as '15 Phút'," +
                        " hk1tiet as '1 Tiết', hkhocky as 'KT Học Kỳ', hkvang as 'Vắng', hktre as 'Trễ', hkcomat as 'Có Mặt'," +
                        " hk1diemtb as 'ĐTB Học Kỳ 1', hk2diemtb as 'ĐTB Học Kỳ 2', cndiemtb as 'ĐTB Cả Năm', cnthuhang as 'Hạng'," +
                        " xeploaihocluc as 'Học Lực HK2', xeploaichuyencan as 'Chuyên Cần HK2', xeploaidaoduc as 'Đạo Đức HK2', xeploaihk as 'Xếp Loại HK2'," +
                        " cnxeploaihocluc as 'Học Lực CN', cnxeploaichuyencan as 'Chuyên Cần CN', cnxeploaidaoduc as 'Đạo Đức CN', xeploaicn as 'Xếp Loại CN'" +
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


    }
}
