using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace glvnt.Model
{
    public static class Utils
    {
        public static string ERROR = "error";

        public const string ID_THIEUNHILOPNAMHOC = "id_thieunhilopnamhoc";
        public const string MIENG = "hkmieng";
        public const string _15 = "hk15phut";
        public const string _1T = "hk1tiet";
        public const string HK = "hkhocky";
        public const string VANG = "hkvang";
        public const string TRE = "hktre";
        public const string CO = "hkcomat";
        public const string HKHLid = "hkhocluc";
        public const string HKHLstr = "xeploaihocluc";
        public const string HKCCid = "hkchuyencan";
        public const string HKCCstr = "xeploaichuyencan";
        public const string HKDDid = "hkdaoduc";
        public const string HKDDstr = "xeploaidaoduc";
        public const string HKXLid = "hkxeploai";
        public const string HKXLstr = "xeploaihk";

        public const string CNHLid = "cnhocluc";
        public const string CNHLstr = "cnxeploaihocluc";
        public const string CNCCid = "cnchuyencan";
        public const string CNCCstr = "cnxeploaichuyencan";
        public const string CNDDid = "cndaoduc";
        public const string CNDDstr = "cnxeploaidaoduc";
        public const string CNXLid = "cnxeploai";
        public const string CNXLstr = "xeploaicn";

        public const string DTBHK1 = "hk1diemtb";
        public const string DTBHK2 = "hk2diemtb";
        public const string DTBCN = "cndiemtb";

        public const string DTB = "dtb";
        public const string HK1HANG = "hk1_thu_hang";
        public const string CNHANG = "cn_thu_hang";

        public const string IDTHIEUNHI = "id_thieunhi";
        public const string TENTHANH = "ten_thanh";
        public const string TEN = "ten";
        public const string HO = "ho";
        public const string NGAYSINH = "ngay_sinh";
        public const string CHA = "cha";
        public const string ME = "me";
        public const string DIACHI = "dia_chi";
        public const string DT1 = "dt1";
        public const string DT2 = "dt2";
        public const string KHU = "khu";
        public const string ACE = "ace";
        public const string GHICHU = "ghi_chu";

        public const string DSTNVIEW = "DanhSachThieuNhi";
        public const string QTLOPVIEW = "QuanTriLopView";

        public static void showError(string ErrMessage)
        {
            MessageBox.Show("Exception Error: " + ErrMessage, Utils.ERROR, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static bool isCoDiem(string diem)
        {
            if (diem == "" || diem == null || diem == "NULL")
            {
                return false;
            }
            return true;
        }

        public static string convertMDYYYYtoYYYYMD(string date)
        {
            string[] sub = date.Split('/');
            if (sub.Length != 3)
            {
                return "";
            }
            else
            {
                return sub[2] + "/" + sub[0] + "/" + sub[1];
            }
        }

        public static List<HocLuc> getListHocLuc()
        {
            string connectionString = CONNSTRING.connstring;
            MySqlConnection cnn = new MySqlConnection(connectionString);
            List<HocLuc> listhocluc = new List<HocLuc>();
            try
            {
                cnn.Open();
                string sql = "SELECT * FROM HocLuc;";
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string id = dr["id_hocluc"].ToString() == null ? "" : dr["id_hocluc"].ToString();
                    string xl = dr["xeploaihocluc"].ToString() == null ? "" : dr["xeploaihocluc"].ToString();
                    listhocluc.Add(new HocLuc(id, xl));
                }
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
            finally { cnn.Close(); }
            return listhocluc;
        }

        public static List<ChuyenCan> getListChuyenCan()
        {
            string connectionString = CONNSTRING.connstring;
            MySqlConnection cnn = new MySqlConnection(connectionString);
            List<ChuyenCan> listchuyencan = new List<ChuyenCan>();
            try
            {
                cnn.Open();
                string sql = "SELECT * FROM ChuyenCan;";
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string id = dr["id_chuyencan"].ToString() == null ? "" : dr["id_chuyencan"].ToString();
                    string xl = dr["xeploaichuyencan"].ToString() == null ? "" : dr["xeploaichuyencan"].ToString();
                    listchuyencan.Add(new ChuyenCan(id, xl));
                }
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
            finally { cnn.Close(); }
            return listchuyencan;
        }

        public static List<DaoDuc> getListDaoDuc()
        {
            string connectionString = CONNSTRING.connstring;
            MySqlConnection cnn = new MySqlConnection(connectionString);
            List<DaoDuc> listdaoduc = new List<DaoDuc>();
            try
            {
                cnn.Open();
                string sql = "SELECT * FROM DaoDuc;";
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string id = dr["id_daoduc"].ToString() == null ? "" : dr["id_daoduc"].ToString();
                    string xl = dr["xeploaidaoduc"].ToString() == null ? "" : dr["xeploaidaoduc"].ToString();
                    listdaoduc.Add(new DaoDuc(id, xl));
                }
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
            finally { cnn.Close(); }
            return listdaoduc;
        }

        public static List<XepLoai> getListXepLoai()
        {
            string connectionString = CONNSTRING.connstring;
            MySqlConnection cnn = new MySqlConnection(connectionString);
            List<XepLoai> listxeploai = new List<XepLoai>();
            try
            {
                cnn.Open();
                string sql = "SELECT * FROM XepLoai;";
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string id = dr["id_xeploai"].ToString() == null ? "" : dr["id_xeploai"].ToString();
                    string xl = dr["xeploai"].ToString() == null ? "" : dr["xeploai"].ToString();
                    listxeploai.Add(new XepLoai(id, xl));
                }
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
            finally { cnn.Close(); }
            return listxeploai;
        }

    }
}
