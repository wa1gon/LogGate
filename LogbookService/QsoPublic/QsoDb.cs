using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QsoDb
    {
        public long Id { get; set; }
        public string User { get; set; }
        public string TheirCall { get; set; }
        public string Dxcc { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string CQZone { get; set; }
        public DateTime StartDTG { get; set; }
        public DateTime EndDtg { get; set; }
        public decimal Frequency { get; set; }
        public string Mode { get; set; }
        public string LoTWQsl { get; set; }
        public string EQsl { get; set; }
        public string RecRST { get; set; }
        public string SentRst { get; set; }
        public string USState { get; set; }

        public virtual List<ExtendedData> Additional { get; set; }
        public virtual Station MyStation { get; set; }

    }
}
