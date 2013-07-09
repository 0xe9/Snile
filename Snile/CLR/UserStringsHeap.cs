using Snile.Snile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.CLR
{
    public class UserStringsHeap : Stream
    {
        private BinaryParser binaryParser;

        public string name;
        public uint offset;
        public uint size;

        public UserStringsHeap(Reader reader, string name, uint offset, uint size)
            : base(name, offset, size)
        {
            this.binaryParser = reader.GetBinaryParser();
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
