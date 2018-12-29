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
using glvnt.Model;
using glvnt.Controller;
using static glvnt.Model.Utils;

namespace glvnt.View
{
    /// <summary>
    /// Interaction logic for CapNhapThieuNhi.xaml
    /// </summary>
    public partial class CapNhapThieuNhi : Window
    {
        CapNhapThieuNhiController capnhapController = new CapNhapThieuNhiController();
        DanhSachThieuNhi dstn = null;
        QuanTriLop qtl = null;
        string viewtype;
        public CapNhapThieuNhi(Window _view, string _viewtype, string _id_thieunhi = "")
        {
            InitializeComponent();
            viewtype = _viewtype;
            if (viewtype == DSTNVIEW)
            {
                dstn = (DanhSachThieuNhi)_view;
            }
            if (viewtype == QTLOPVIEW)
            {
                qtl = (QuanTriLop)_view;
            }

            if (_id_thieunhi != "")
            {
                ThieuNhi thieunhi = capnhapController.LoadThieuNhi(_id_thieunhi);

                txt_id_thieunhi.Text = thieunhi.id_thieunhi;
                txt_ten_thanh.Text = thieunhi.ten_thanh;
                txt_ten.Text = thieunhi.ten;
                txt_ho.Text = thieunhi.ho;
                date_ngay_sinh.SelectedDate = DateTime.Parse(thieunhi.ngay_sinh);
                txt_cha.Text = thieunhi.cha;
                txt_me.Text = thieunhi.me;
                txt_dia_chi.Text = thieunhi.dia_chi;
                txt_dt1.Text = thieunhi.dt1;
                txt_khu.Text = thieunhi.khu;
                txt_ghi_chu.Text = thieunhi.ghi_chu;

                btn_add.IsEnabled = false;
                btn_update.IsEnabled = true;
            }
            else
            {
                btn_add.IsEnabled = false;
                btn_update.IsEnabled = false;
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            ThieuNhi thieunhi = new ThieuNhi();

            thieunhi.id_thieunhi = txt_id_thieunhi.Text;
            thieunhi.ten_thanh = txt_ten_thanh.Text;
            thieunhi.ten = txt_ten.Text;
            thieunhi.ho = txt_ho.Text;
            thieunhi.ngay_sinh = date_ngay_sinh.Text;
            thieunhi.cha = txt_cha.Text;
            thieunhi.me = txt_me.Text;
            thieunhi.dia_chi = txt_dia_chi.Text;
            thieunhi.dt1 = txt_dt1.Text;
            thieunhi.khu = txt_khu.Text;
            thieunhi.ghi_chu = txt_ghi_chu.Text;

            capnhapController.updateThieuNhi(thieunhi);
            if (viewtype == DSTNVIEW)
            {
                dstn.PupilLoad();
            }
            if (viewtype == QTLOPVIEW)
            {
                qtl.loadbangdiem();
            }
            MessageBox.Show("Cập Nhập Thiếu Nhi thành công!");
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
