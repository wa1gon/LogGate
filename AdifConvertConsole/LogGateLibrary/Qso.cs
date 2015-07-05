using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace LogGateLibrary
{
    public class Qso
    {
        public SortedList<string,string> Fields { get; set; }
        public Qso()
        {
            Fields = new SortedList<string, string>();
            DocType = this.GetType().Name;
        }

        public string GetCallSign()
        {
            string call;
            call = Fields["call"];
            return call;
        }

        private string call;

        public string Call
        {
            get { return call; }
            set { call = value; }
        }

        private string band;

        public string Band
        {
            get { return band; }
            set { band = value; }
        }

        private string mode;

        public string Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        private string time_on;
        public string Time_on
        {
            get { return time_on; }
            set { time_on = value; }
        }
        private string freq;

        public string Freq
        {
            get { return freq; }
            set { freq = value; }
        }
        private string freq_rx;

        public string Freq_rx
        {
            get { return freq_rx; }
            set { freq_rx = value; }
        }

        private string band_rx;

        public string Band_rx
        {
            get { return band_rx; }
            set { band_rx = value; }
        }

        private string sat_Name;

        public string Sat_Name
        {
            get { return sat_Name; }
            set { sat_Name = value; }
        }
        
        
        public string DocType { get; set; }
        public string _id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string _rev { get; set; }
    }

}
