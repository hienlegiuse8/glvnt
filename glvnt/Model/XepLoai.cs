using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glvnt.Model
{
    public class XepLoai
    {
        public string id { get; set; }
        public string xeploai { get; set; }
        public XepLoai(string _id_xeploai, string _xeploai)
        {
            id = _id_xeploai;
            xeploai = _xeploai;
        }
    }
}
