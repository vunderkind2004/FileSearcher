using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Core
{
    public static class Constants
    {
        public static List<Encoding> AvailableEncoding = new List<Encoding> { Encoding.ASCII, Encoding.UTF8, Encoding.Unicode };
        public static int BufferSize = 10*1024;
    }
}
