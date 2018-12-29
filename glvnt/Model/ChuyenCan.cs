using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glvnt.Model
{
    public class ChuyenCan
    {
        public string id { get; set; }
        public string xeploai { get; set; }
        public ChuyenCan(string _id_chuyencan, string _xeploaichuyencan)
        {
            id = _id_chuyencan;
            xeploai = _xeploaichuyencan;
        }
    }
}
