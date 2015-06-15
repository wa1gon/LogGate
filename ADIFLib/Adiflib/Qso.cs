using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace Adiflib
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

        public string DocType { get; set; }
        public string _id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string _rev { get; set; }
    }
}
