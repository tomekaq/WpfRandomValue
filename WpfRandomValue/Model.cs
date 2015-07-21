using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfRandomValue
{
    class Model
    {
        public int REF { get; set; }
        public int NUMBER { get; set; }

        public Model(int Ref, int Value)
        {
            REF = Ref;
            NUMBER = Value;
        }
    }
}
