using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adiflib
{
    public class Qso
    {
        public SortedList<string,string> Fields { get; set; }
        public Qso()
        {
            Fields = new SortedList<string, string>();
        }
    }
}
