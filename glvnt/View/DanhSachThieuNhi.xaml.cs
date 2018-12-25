using System;
using System.Windows;
using glvnt.Model;
using glvnt.Controller;
/*
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
using System.Windows.Shapes;*/
//using glvnt.Controller;

namespace glvnt.View
{
    /// <summary>
    /// Interaction logic for DanhSachThieuNhi.xaml
    /// </summary>
    public partial class DanhSachThieuNhi : Window
    {
        Glv glv;
        DanhSachThieuNhiController dstnController = new DanhSachThieuNhiController();
        public DanhSachThieuNhi(Glv _glv)
        {
            InitializeComponent();

            glv = new Glv();
            glv = _glv;

            PupilLoad();
        }

        private void PupilLoad()
        {
            //ListViewCurrentClass.Visibility = Visibility.Hidden;
            try
            {
                DanhSachGrid.ItemsSource = dstnController.PupilLoad().DefaultView;
                DSParentGrid.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Utils.showError(ex.Message);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            //PupilLoad();
        }
    }
}
