using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glvnt.Model
{
    public class Glv
    {
        public string Username { set; get; }
        public string Ten_thanh { set; get; }
        public string Ten { set; get; }
        public string Ho { set; get; }
        public string User_type { set; get; }

        public Glv()
        {
            Username = "";
            Ten_thanh = "";
            Ten = "";
            Ho = "";
            User_type = "";
        }
    }
}
