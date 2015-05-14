using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adiflib
{
    public class AdifLog
    {
        public AdifLog()
        {
            QSOList = new List<Qso>();
        }
        public List<Qso> QSOList { get; set; }
        public string Header { get; set; }

    }
}
