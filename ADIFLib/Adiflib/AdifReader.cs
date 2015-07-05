using LogGateLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adiflib
{
    public class AdifReader
    {

        private class NameValuePair
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private int loc = 0;
        private string fileContent;
        public AdifReader()
        {

        }
        public AdifLog ReadAdifFile(string fileName)
        {
            var log = new AdifLog();
            
            bool foundHeader = false;

            using (StreamReader sr = File.OpenText(fileName))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(sr.ReadToEnd());
                fileContent = sb.ToString();
                //you then have to process the string
            }

            loc = 0;
            if (fileContent[0] != '<')
            {
                loc = ProcessHeader(log, ref foundHeader);

                int fieldStart=0;
                int fieldEnd = 0;

                Qso qso = new Qso();
                while (loc < fileContent.Length)
                {

                    if (fileContent[loc] == '<')
                    {
                        fieldStart = loc + 1;
                        loc++;
                    }
                    else if (fileContent[loc] == '>')
                    {
                        fieldEnd = loc;
                        string tag = fileContent.Substring(fieldStart, fieldEnd - fieldStart);
                        tag = tag.ToLower();
                        loc++;

                        if (tag.ToLower() == "eor")
                        {
                            log.QSOList.Add(qso);
                            qso = new Qso();
                            continue;
                        }
                        else
                        {
                            var nv = FindNextTagNameValuePair(tag);
                            switch (nv.Name)
                            {
                                default:
                                    qso.Fields.Add(nv.Name, nv.Value);
                                    break;
                            }
                        }

                    }
                    else
                    {
                        loc++;
                    }
                }
            }

            return log;
        }

        private int ProcessHeader(AdifLog log, ref bool foundHeader)
        {
            int loc;
            foundHeader = true;
            loc = fileContent.IndexOf("<EOH>", StringComparison.OrdinalIgnoreCase);
            if (loc >= 0)
            {
                loc = loc + 5;
                log.Header = fileContent.Substring(0, loc);
            }
            loc++;
            return loc;
        }

        private NameValuePair FindNextTagNameValuePair( string tag)
        {
            string[] tagSplit = tag.Split(':');
            int dataLen = int.Parse(tagSplit[1]);

            string val = fileContent.Substring(loc, dataLen);

            var nvPar = new NameValuePair();
            nvPar.Name = tagSplit[0];
            nvPar.Value = val;
            loc = loc + dataLen;
            return nvPar;
        }
    }
}
