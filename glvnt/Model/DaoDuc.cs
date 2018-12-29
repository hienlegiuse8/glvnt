using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glvnt.Model
{
    public class DaoDuc
    {
        public string id { get; set; }
        public string xeploai { get; set; }
        public DaoDuc(string _id_daoduc, string _xeploaidaoduc)
        {
            id = _id_daoduc;
            xeploai = _xeploaidaoduc;
        }
    }
}
