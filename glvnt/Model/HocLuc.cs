using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glvnt.Model
{
    public class HocLuc
    {
        public string id { get; set; }
        public string xeploai { get; set; }

        public HocLuc(string _id_hocluc, string _xeploaihocluc)
        {
            id = _id_hocluc;
            xeploai = _xeploaihocluc;
        }

    }
}
