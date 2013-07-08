using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.CLR
{
    public class Stream
    {
        public string name;
        public uint offset;
        public uint size;

        public Stream(string name, uint offset, uint size)
        {
            this.name = name;
            this.offset = offset;
            this.size = size;
        }

        public String GetName()
        {
            return this.name;
        }

        public uint GetOffset()
        {
            return this.offset;
        }

        public uint GetSize()
        {
            return this.size;
        }
    }
}
