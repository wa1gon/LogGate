using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Station
    {
        public long Id { get; set; }
        public string StationName { get; set; }
        public string CountryCode { get; set; }
        public string State { get; set; }
        public string Grid { get; set; }
        public string County { get; set; }
        public virtual List<QsoDb> Qsos { get; set; }
    
    }
}
