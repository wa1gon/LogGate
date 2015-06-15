using Adiflib;
using Shows.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdifConvertConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var prog = new Program();
            ProcessAdif();
        }

        private static void ProcessAdif()
        {
            var adifReader = new AdifReader();

            var log = adifReader.ReadAdifFile(@"D:\DShare\AClogADIF.adi");
            foreach (var qso in log.QSOList)
            {
                CouchDbHandler.SaveQSO(qso);
            }
        }
    }
}
