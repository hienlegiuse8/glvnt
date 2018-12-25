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
        public static string CONNSTRING = "server=146.66.103.232;database=leohien4_glvnt;uid=leohien4_tnnt;pwd=testingtesting;Convert Zero Datetime=True;";
        public static void showError(string ErrMessage)
        {
            MessageBox.Show("Exception Error: " + ErrMessage, Utils.ERROR, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        
    }
}
