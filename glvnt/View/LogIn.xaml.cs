using System;
using System.Windows;
using glvnt.Model;
using glvnt.Controller;
using glvnt.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
*/


namespace glvnt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        LogInController login = new LogInController();
        public LogIn()
        {
            InitializeComponent();
            passwordBox.Focusable = true;
            passwordBox.Focus();
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            CheckLogIn();
        }

        private void LogIn_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            CheckLogIn();
        }

        private void CheckLogIn()
        {
            string user = username.Text;
            string password = passwordBox.Password;
            Glv glv = new Glv();
            if (user.Length == 0)
            {
                Utils.showError("Please enter username.");
                return;
            }
            if (password.Length == 0)
            {
                Utils.showError("Please enter password.");
                return;
            }

            bool check = login.CheckLogIn(glv, user, password);

            if (check)
            {
                MainMenu mainmenu = new MainMenu(glv);
                App.Current.MainWindow = mainmenu;
                this.Close();
                mainmenu.Show();
            }
        }
    }
}
