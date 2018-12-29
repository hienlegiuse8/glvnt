using System;
using System.Data;
using System.Windows;
using glvnt.Model;
using glvnt.Controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static glvnt.Model.Utils;

namespace glvnt.View
{
    /// <summary>
    /// Interaction logic for DanhSachThieuNhi.xaml
    /// </summary>
    public partial class DanhSachThieuNhi : Window
    {
        Glv glv;
        DanhSachThieuNhiController dstnController = new DanhSachThieuNhiController();
        CapNhapThieuNhiController capnhapthieunhiController = new CapNhapThieuNhiController();
        DataRowView dr;
        
        public DanhSachThieuNhi(Glv _glv)
        {
            InitializeComponent();

            glv = new Glv();
            glv = _glv;

            PupilLoad();
        }

        public void PupilLoad()
        {
            //ListViewCurrentClass.Visibility = Visibility.Hidden;
            DanhSachGrid.ItemsSource = dstnController.PupilLoad().DefaultView;
            DSParentGrid.Visibility = Visibility.Visible;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            PupilLoad();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //CapNhapThieuNhi cntn = new CapNhapThieuNhi(this, DSTNVIEW);
            //App.Current.MainWindow = cntn;
            //cntn.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            string idthieunhi = dr[IDTHIEUNHI].ToString();

            CapNhapThieuNhi cntn = new CapNhapThieuNhi(this, DSTNVIEW, idthieunhi);
            App.Current.MainWindow = cntn;
            cntn.ShowDialog();
        }

        private void ThieuNhi_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            dr = dg.SelectedItem as DataRowView;
        }

        private void window_Activated(object sender, EventArgs e)
        {
            
        }
    }
}
