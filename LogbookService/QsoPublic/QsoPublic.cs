using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QsoPublic
    {
        public long Id { get; set; }
        public string MyCall { get; set; }
        public string TheirCall { get; set; }
        public string Dxcc { get; set; }
        public string ContestId { get; set; }
        public string Comments { get; set; }
        public string Computer { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string TheirCounty { get; set; }
        public string MyCounty { get; set; }
        public string CQZone { get; set; }
        public DateTime StartDTG { get; set; }
        public string Fist { get; set; }
        public decimal Frequency { get; set; }
        public string MyGrid { get; set; }
        public string TheirGrid { get; set; }
        public string ITUZone { get; set; }
        public string Operator { get; set; }
        public string IOTA { get; set; }
        public string LightHouse { get; set; }
        public string Mode { get; set; }
        public string ContestMode { get; set; }
        public string TheirName { get; set; }
        public int Power { get; set; }
        public string Precedence { get; set; }
        public string PropMode { get; set; }
        public string LoTWQsl { get; set; }
        public string EQsl { get; set; }
        public string RecRST { get; set; }
        public string SentRst { get; set; }
        public string SatName { get; set; }
        public string Section { get; set; }
        public string SerialNum { get; set; }
        public string USState { get; set; }
        public string TenTen { get; set; }
        public string LotwSig { get; set; }

    }
}
