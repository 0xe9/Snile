using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile
{
    public class DataStream : MemoryStream
    {
        private byte[] data;

        public DataStream (byte[] data)
            :base(data)
        {
            this.data = data;
        }

        public void add(int len)
        {
            this.Position = (long)(this.Position + len);
        }

        public byte[] GetData()
        {
            return this.data;
        }
    }
}
