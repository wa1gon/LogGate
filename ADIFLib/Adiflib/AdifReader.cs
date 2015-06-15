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

            int loc;
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
                            loc = AddNameValuePairToQsoList( loc, qso, tag);
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

        private int AddNameValuePairToQsoList( int loc, Qso qso, string tag)
        {
            string[] tagSplit = tag.Split(':');
            int dataLen = int.Parse(tagSplit[1]);

            string val = fileContent.Substring(loc, dataLen);
            qso.Fields.Add(tagSplit[0], val);
            loc = loc + dataLen;
            return loc;
        }
    }
}
