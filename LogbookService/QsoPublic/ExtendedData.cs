using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ExtendedData
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }
        public virtual QsoDb Parent { get; set; }
    }
}
