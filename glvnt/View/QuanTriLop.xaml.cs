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
using System.Data;

namespace glvnt.View
{
    /// <summary>
    /// Interaction logic for QuanTriLop.xaml
    /// </summary>
    public partial class QuanTriLop : Window
    {
        QuanTriLopController qtlController = new QuanTriLopController();
        public QuanTriLop(string _lopid, bool _hocky1)
        {
            InitializeComponent();

            try
            {
                QuanLyLopDataGrid.ItemsSource = qtlController.LoadClassWithId(_lopid, _hocky1).DefaultView;
                txt_hocky.Text = _hocky1 ? "1" : "2";
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
        }

        private void danhsach_selectChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                if (txt_hocky.Text == "1")
                {
                    txt_ktmieng.Text = dr["hk1_kt_mieng"].ToString();
                    txt_kt15phut.Text = dr["hk1_kt_15phut"].ToString();
                    txt_kt1tiet.Text = dr["hk1_1tiet"].ToString();
                    txt_kthocky.Text = dr["hk1_hocky"].ToString();
                    txt_vang.Text = dr["hk1_vang"].ToString();
                    txt_tre.Text = dr["hk1_tre"].ToString();
                    txt_comat.Text = dr["hk1_co_mat"].ToString();
                    txt_hocluc.Text = dr["hk1_hoc_luc"].ToString();
                    txt_chuyencan.Text = dr["hk1_chuyen_can"].ToString();
                    txt_daoduc.Text = dr["hk1_dao_duc"].ToString();
                    txt_xeploai.Text = dr["hk1_xep_loai"].ToString();
                }
                else
                {
                    txt_ktmieng.Text = dr["hk2_kt_mieng"].ToString();
                    txt_kt15phut.Text = dr["hk2_kt_15phut"].ToString();
                    txt_kt1tiet.Text = dr["hk2_1tiet"].ToString();
                    txt_kthocky.Text = dr["hk2_hocky"].ToString();
                    txt_vang.Text = dr["hk2_vang"].ToString();
                    txt_tre.Text = dr["hk2_tre"].ToString();
                    txt_comat.Text = dr["hk2_co_mat"].ToString();
                    txt_hocluc.Text = dr["hk2_hoc_luc"].ToString();
                    txt_chuyencan.Text = dr["hk2_chuyen_can"].ToString();
                    txt_daoduc.Text = dr["hk2_dao_duc"].ToString();
                    txt_xeploai.Text = dr["hk2_xep_loai"].ToString();

                    txt_cnhocluc.Text = dr["cn_hoc_luc"].ToString();
                    txt_cnchuyencan.Text = dr["cn_chuyen_can"].ToString();
                    txt_cndaoduc.Text = dr["cn_dao_duc"].ToString();
                    txt_cnxeploai.Text = dr["cn_xep_loai"].ToString();
                }
            }
        }

        private void UpdateHK(object sender, RoutedEventArgs e)
        {

        }
    }
}
