using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace glvnt.Model
{
    public class Utils
    {
        public static string ERROR = "error";
        
        public static void showError(string ErrMessage)
        {
            MessageBox.Show("Exception Error: " + ErrMessage, Utils.ERROR, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        
    }
}
