using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.CLR
{
    public class Stream
    {
        private string name;
        private UInt32 offset;
        private UInt32 size;

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

        public UInt32 GetOffset()
        {
            return this.offset;
        }

        public UInt32 GetSize()
        {
            return this.size;
        }
    }
}
