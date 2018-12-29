using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using glvnt.Controller;
using glvnt.Model;
using static glvnt.Model.Utils;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
//using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel;

namespace glvnt.View
{
    /// <summary>
    /// Interaction logic for QuanTriLop.xaml
    /// </summary>
    public partial class QuanTriLop : System.Windows.Window
    {
        QuanTriLopController qtlController = new QuanTriLopController();
        DataRowView dr;
        string lopid;
        bool hk1;
        List<HocLuc> listhocluc;
        List<ChuyenCan> listchuyencan;
        List<DaoDuc> listdaoduc;
        List<XepLoai> listxeploai;

        List<HocLuc> list_cnhocluc;
        List<ChuyenCan> list_cnchuyencan;
        List<DaoDuc> list_cndaoduc;
        List<XepLoai> list_cnxeploai;

        public QuanTriLop(string _lopid, bool _hocky1)
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized;
            txt_hocky.Text = _hocky1 ? "1" : "2";
            lopid = _lopid;
            hk1 = _hocky1;
            loadbangdiem();
        }

        public void loadbangdiem()
        {
            QuanLyLopDataGrid.ItemsSource = qtlController.LoadClassWithLopId(lopid, hk1).DefaultView;
            
            listhocluc = Utils.getListHocLuc();
            setcombobox(listhocluc, cb_hocluc);
            //cb_hocluc.DisplayMemberPath = "xeploaihocluc";
            //cb_hocluc.SelectedValue = "id_hocluc";
            //cb_hocluc.ItemsSource = listhocluc;

            listchuyencan = Utils.getListChuyenCan();
            setcombobox(listchuyencan, cb_chuyencan);
            //cb_chuyencan.DisplayMemberPath = "xeploaichuyencan";
            //cb_chuyencan.SelectedValue = "id_chuyencan";
            //cb_chuyencan.ItemsSource = listchuyencan;

            listdaoduc = Utils.getListDaoDuc();
            setcombobox(listdaoduc, cb_daoduc);
            //cb_daoduc.DisplayMemberPath = "xeploaidaoduc";
            //cb_daoduc.SelectedValue = "id_daoduc";
            //cb_daoduc.ItemsSource = listdaoduc;

            listxeploai = Utils.getListXepLoai();
            setcombobox(listxeploai, cb_xeploai);
            //cb_xeploai.DisplayMemberPath = "xeploai";
            //cb_xeploai.SelectedValue = "id_xeploai";
            //cb_xeploai.ItemsSource = listxeploai;

            list_cnhocluc = Utils.getListHocLuc();
            setcombobox(list_cnhocluc, cb_cnhocluc);
            //cb_cnhocluc.DisplayMemberPath = "xeploaihocluc";
            //cb_cnhocluc.SelectedValue = "id_hocluc";
            //cb_cnhocluc.ItemsSource = list_cnhocluc;

            list_cnchuyencan = Utils.getListChuyenCan();
            setcombobox(list_cnchuyencan, cb_cnchuyencan);
            //cb_cnchuyencan.DisplayMemberPath = "xeploaichuyencan";
            //cb_cnchuyencan.SelectedValue = "id_chuyencan";
            //cb_cnchuyencan.ItemsSource = list_cnchuyencan;

            list_cndaoduc = Utils.getListDaoDuc();
            setcombobox(list_cndaoduc, cb_cndaoduc);
            //cb_cndaoduc.DisplayMemberPath = "xeploaidaoduc";
            //cb_cndaoduc.SelectedValue = "id_daoduc";
            //cb_cndaoduc.ItemsSource = list_cndaoduc;

            list_cnxeploai = Utils.getListXepLoai();
            setcombobox(list_cnxeploai, cb_cnxeploai);
            //cb_cnxeploai.DisplayMemberPath = "xeploai";
            //cb_cnxeploai.SelectedValue = "id_xeploai";
            //cb_cnxeploai.ItemsSource = list_cnxeploai;
        }

        private void setcombobox<T>(List<T> lists, ComboBox cb)
        {
            cb.DisplayMemberPath = "xeploai";
            cb.SelectedValue = "id";
            cb.ItemsSource = lists;
        }

        private void danhsach_selectChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            dr = dg.SelectedItem as DataRowView;

            try
            {
                if (dr != null)
                {
                    txt_IDThieuNhiLopNamHoc.Text = dr[ID_THIEUNHILOPNAMHOC].ToString();
                    txt_ktmieng.Text = dr[MIENG].ToString();
                    txt_kt15phut.Text = dr[_15].ToString();
                    txt_kt1tiet.Text = dr[_1T].ToString();
                    txt_kthocky.Text = dr[HK].ToString();
                    txt_vang.Text = dr[VANG].ToString();
                    txt_tre.Text = dr[TRE].ToString();
                    txt_comat.Text = dr[CO].ToString();

                    HocLuc hl = findcombobox(dr[HKHLid].ToString(), listhocluc);
                    cb_hocluc.SelectedValue = hl;

                    ChuyenCan cc = findcombobox(dr[HKCCid].ToString(), listchuyencan);
                    cb_chuyencan.SelectedValue = cc;

                    DaoDuc dd = findcombobox(dr[HKDDid].ToString(), listdaoduc);
                    cb_daoduc.SelectedValue = dd;

                    XepLoai xl = findcombobox(dr[HKXLid].ToString(), listxeploai);
                    cb_xeploai.SelectedValue = xl;

                    if (txt_hocky.Text != "1")
                    {
                        HocLuc cnhl = findcombobox(dr[CNHLid].ToString(), list_cnhocluc);
                        cb_hocluc.SelectedValue = cnhl;

                        ChuyenCan cncc = findcombobox(dr[CNCCid].ToString(), list_cnchuyencan);
                        cb_chuyencan.SelectedValue = cncc;

                        DaoDuc cndd = findcombobox(dr[CNDDid].ToString(), list_cndaoduc);
                        cb_daoduc.SelectedValue = cndd;

                        XepLoai cnxl = findcombobox(dr[CNXLid].ToString(), list_cnxeploai);
                        cb_xeploai.SelectedValue = cnxl;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
        }

        private void UpdateDiem_Click(object sender, RoutedEventArgs e)
        {
            ThieuNhiLopNamHoc newbangdiem = new ThieuNhiLopNamHoc();

            try
            {
                if (dr == null)
                {
                    throw new Exception("Chọn một thiếu nhi để cập nhập điểm số!");
                }

                newbangdiem.id_thieunhilopnamhoc = txt_IDThieuNhiLopNamHoc.Text;
                newbangdiem.hk_mieng = txt_ktmieng.Text == "" ? "NULL" : txt_ktmieng.Text;
                newbangdiem.hk_15phut = txt_kt15phut.Text == "" ? "NULL" : txt_kt15phut.Text;
                newbangdiem.hk_1tiet = txt_kt1tiet.Text == "" ? "NULL" : txt_kt1tiet.Text;
                newbangdiem.hk_hocky = txt_kthocky.Text == "" ? "NULL" : txt_kthocky.Text;
                newbangdiem.hk_vang = txt_vang.Text == "" ? "NULL" : txt_vang.Text;
                newbangdiem.hk_tre = txt_tre.Text == "" ? "NULL" : txt_tre.Text;
                newbangdiem.hk_co_mat = txt_comat.Text == "" ? "NULL" : txt_comat.Text;

                newbangdiem.hk_hoc_luc = transferValueComboToDB((HocLuc)cb_hocluc.SelectedItem);
                newbangdiem.hk_chuyen_can = transferValueComboToDB((ChuyenCan)cb_chuyencan.SelectedItem);
                newbangdiem.hk_dao_duc = transferValueComboToDB((DaoDuc)cb_daoduc.SelectedItem);
                newbangdiem.hk_xep_loai = transferValueComboToDB((XepLoai)cb_xeploai.SelectedItem);
                //newbangdiem.hk_hoc_luc = (selected.id_hocluc == "" || selected.id_hocluc  == null) ? "NULL" : selected.id_hocluc;
                //newbangdiem.hk_chuyen_can = txt_chuyencan.Text == "" ? "NULL" : txt_chuyencan.Text;
                //newbangdiem.hk_dao_duc = txt_daoduc.Text == "" ? "NULL" : txt_daoduc.Text;
                //newbangdiem.hk_xep_loai = txt_xeploai.Text == "" ? "NULL" : txt_xeploai.Text;

                if (!hk1)
                {
                    newbangdiem.cn_hoc_luc = transferValueComboToDB((HocLuc)cb_cnhocluc.SelectedItem);
                    newbangdiem.cn_chuyen_can = transferValueComboToDB((ChuyenCan)cb_cnchuyencan.SelectedItem);
                    newbangdiem.cn_dao_duc = transferValueComboToDB((DaoDuc)cb_cndaoduc.SelectedItem);
                    newbangdiem.cn_xep_loai = transferValueComboToDB((XepLoai)cb_cnxeploai.SelectedItem);
                    newbangdiem.hk1_diemtb = dr[DTBHK1].ToString();
                }

                tinhdiemtrungbinh(newbangdiem, hk1);
                updateSelectedRow(newbangdiem, hk1);

                qtlController.updateHK(newbangdiem, hk1);
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
        }

        private string transferValueComboToDB<T>(T selected)
        {
            if (selected == null)
            {
                return "NULL";
            }
            string id = typeof(T).GetProperty("id").GetValue(selected).ToString();
            string value = (id == "" || id == null) ? "NULL" : id;
            return value;
        }


        private T findcombobox<T>(string id, List<T> lists)
        {
            if (id == "" || id == null)
            {
                return default(T);
            }
            foreach (T hl in lists)
            {
                var value = typeof(T).GetProperty("id").GetValue(hl).ToString();
                if (value == id)
                {
                    return hl;
                }
            }
            return default(T);
        }


        private void updateSelectedRow(ThieuNhiLopNamHoc bd, bool _hk1)
        {
            setTextBox(txt_ktmieng.Text, MIENG);
            setTextBox(txt_kt15phut.Text, _15);
            setTextBox(txt_kt1tiet.Text, _1T);
            setTextBox(txt_kthocky.Text, HK);
            setTextBox(txt_vang.Text, VANG);
            setTextBox(txt_tre.Text, TRE);
            setTextBox(txt_comat.Text, CO);
            setValueCombo((HocLuc)cb_hocluc.SelectedItem, HKHLstr);
            setValueCombo((ChuyenCan)cb_chuyencan.SelectedItem, HKCCstr);
            setValueCombo((DaoDuc)cb_daoduc.SelectedItem, HKDDstr);
            setValueCombo((XepLoai)cb_xeploai.SelectedItem, HKXLstr);

            if (!_hk1)
            {
                setValueCombo((HocLuc)cb_cnhocluc.SelectedItem, CNHLstr);
                setValueCombo((ChuyenCan)cb_cnchuyencan.SelectedItem, CNCCstr);
                setValueCombo((DaoDuc)cb_cndaoduc.SelectedItem, CNDDstr);
                setValueCombo((XepLoai)cb_cnxeploai.SelectedItem, CNXLstr);
            }
        }

        private void setTextBox(string text, string colname)
        {
            if (text == "")
            {
                dr[colname] = DBNull.Value;
            }
            else
            {
                dr[colname] = text;
            }
        }

        private void setValueCombo<T>(T selected, string colname)
        {
            if (selected == null) return;
            string xeploai = typeof(T).GetProperty("xeploai").GetValue(selected).ToString();

            if (xeploai == "")
            {
                dr[colname] = DBNull.Value;
            }
            else
            {
                dr[colname] = xeploai;
            }
        }

        private void GradeValidation(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;
            char ch = (char)e.Text[0];

            if (ch == 46 && tb.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch !=8 && ch != 46)
            {
                e.Handled = true;
                return;
            }

            double d = double.Parse(tb.Text + ch);
            if (0 > d || d > 10)
            {
                e.Handled = true;
                return;
            }
        }

        private bool diemvalid(string diem)
        {
            double d;
            try
            {
                d = Double.Parse(diem);
            }
            catch (Exception ex)
            {
                return false;
            }
            return (0 <= 0 && d <= 10);
        }

        private void DiemDanhValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void refreshdata_Click(object sender, RoutedEventArgs e)
        {
            QuanLyLopDataGrid.ItemsSource = qtlController.LoadClassWithLopId(lopid, hk1).DefaultView;
        }

        private void tinhdiemtrungbinh(ThieuNhiLopNamHoc bd, bool hk1)
        {
            //HK
            Double tbhocky = -1;
            if (isCoDiem(bd.hk_mieng) && isCoDiem(bd.hk_15phut) && isCoDiem(bd.hk_1tiet) && isCoDiem(bd.hk_hocky))
            {
                tbhocky = (Double.Parse(bd.hk_mieng) + Double.Parse(bd.hk_15phut) + Double.Parse(bd.hk_1tiet) * 2 + Double.Parse(bd.hk_hocky) * 3) / 7;

                if (hk1)
                {
                    bd.hk1_diemtb = tbhocky.ToString("#.##");
                    setTextBox(bd.hk1_diemtb, DTBHK1);
                }
                else
                {
                    bd.hk2_diemtb = tbhocky.ToString("#.##");
                    setTextBox(bd.hk2_diemtb, DTBHK2);
                    if (isCoDiem(bd.hk1_diemtb))
                    {
                        Double tbcn = (Double.Parse(bd.hk2_diemtb) * 2 + Double.Parse(bd.hk1_diemtb)) / 3;
                        bd.cn_diemtb = tbcn.ToString("#.##");
                        setTextBox(bd.cn_diemtb, DTBCN);
                    }
                }
            }
            else
            {
                //bd.hk1_diemtb = dr[DTBHK1].ToString();
                //bd.hk2_diemtb = dr[DTBHK2].ToString();
                //bd.cn_diemtb = dr[DTBCN].ToString();
            }
        }

        private void UpdateXLXH_Click(object sender, RoutedEventArgs e)
        {
            qtlController.updateHang(lopid, hk1);
            QuanLyLopDataGrid.ItemsSource = qtlController.LoadClassWithLopId(lopid, hk1).DefaultView;
        }

        private void ExportExcel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook wb = null;

            object missing = Type.Missing;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            Microsoft.Office.Interop.Excel.Range rng = null;

            DataTable dt = qtlController.LoadDataForExcel(lopid, hk1);
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                wb = excel.Workbooks.Add();
                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;

                for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
                {
                    ws.Range["A1"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
                }

                for (int Idx = 0; Idx < dt.Rows.Count; Idx++)
                {  // <small>hey! I did not invent this line of code, 
                   // I found it somewhere on CodeProject.</small> 
                   // <small>It works to add the whole row at once, pretty cool huh?</small>
                    ws.Range["A2"].Offset[Idx].Resize[1, dt.Columns.Count].Value =
                    dt.Rows[Idx].ItemArray;
                }

                excel.Visible = true;
                wb.Activate();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("Error accessing Excel: " + ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (dr == null)
            {
                Utils.showError("Chọn một thiếu nhi để cập nhập điểm số!");
            }

            string idthieunhi = dr[IDTHIEUNHI].ToString();

            CapNhapThieuNhi cntn = new CapNhapThieuNhi(this, QTLOPVIEW, idthieunhi);
            App.Current.MainWindow = cntn;
            cntn.ShowDialog();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
