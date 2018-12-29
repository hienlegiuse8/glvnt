using System;
using System.Windows;
using System.Windows.Controls;
using glvnt.Model;
using glvnt.Controller;
using System.Reflection;
using System.IO;
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
using System.Windows.Shapes;
*/
namespace glvnt.View
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        Glv glv;
        MainMenuController mainmenuController;
        bool hocky1 = true;
        public MainMenu(Glv _glv)
        //public MainMenu()
        {
            InitializeComponent();

            glv = new Glv();
            glv = _glv;

            yourname.Header = "Hi " + glv.Ho + " " + glv.Ten + ",";
            convertCurrentMonthToHocKy();

            mainmenuController = new MainMenuController();
            LoadCurrentClass();

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Title += " - " + version;
        }

        private void convertCurrentMonthToHocKy()
        {
            int month = DateTime.Now.Month;
            hocky1 = (9 <= month || month <= 12 || month <=1) ? true : false;
            HK1.IsChecked = hocky1;
            HK2.IsChecked = !hocky1;
        }

        private void PupilList_Click(object sender, RoutedEventArgs e)
        {
            DanhSachThieuNhi dstn = new DanhSachThieuNhi(glv);
            App.Current.MainWindow = dstn;
            dstn.ShowDialog();
        }

        private void CurrentClass_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadCurrentClass()
        {
            System.Data.DataTable dtCurClass = mainmenuController.ClassLoad();
            double width = this.Width * 0.3;

            foreach (System.Data.DataRow row in dtCurClass.Rows)
            {
                string id = row["id_lopnamhoc"] == null ? "" : row["id_lopnamhoc"].ToString();
                string ten_lop = row["ten_lop"] == null ? "" : row["ten_lop"].ToString();
                string ten_namhoc = row["ten_namhoc"] == null ? "" : row["ten_namhoc"].ToString();
                string phong = row["phong"] == null ? "" : row["phong"].ToString();

                Button btn = new Button();
                btn.Name = "_" + id;
                btn.Content = ten_lop + " - " + ten_namhoc + " - " + phong;
                btn.Margin = new Thickness(5);
                btn.Width = width;
                btn.Click += ButtonOnClick;
                CurrentClasses.Children.Add(btn);
           }
        }

        private void ButtonOnClick(Object sender, RoutedEventArgs args)
        {
            Button btn = args.Source as Button;

            QuanTriLop qtl = new QuanTriLop(btn.Name, hocky1);
            App.Current.MainWindow = qtl;
            qtl.ShowDialog();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            hocky1 = (HK1.IsChecked == true) ? true : false;
        }
    }
}
