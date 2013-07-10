using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile
{
    public class BinaryParser : BinaryReader {

        DataStream memoryStream = null;

        public BinaryParser(DataStream stream)
            : base(stream)
        {
            memoryStream = stream;
        }

        public UInt16 ParseUInt16(long dest)
        {
            memoryStream.Position = dest;
            return (UInt16)(memoryStream.Position = this.ReadUInt16());
        }

        public UInt32 ParseUInt32(long dest)
        {
            memoryStream.Position = dest;
            return (UInt32)(memoryStream.Position = this.ReadUInt32());
        }

        public UInt64 ParseUInt64(long dest)
        {
            memoryStream.Position = dest;
            return (UInt64)(this.ReadInt64());
        }

        public byte[] ParseBytes(long dest, int size)
        {
            memoryStream.Position = dest;
            return (byte[])(this.ReadBytes(size));
        }

        public byte ParseByte(long dest)
        {
            memoryStream.Position = dest;
            return (byte)(memoryStream.Position = this.ReadByte());
        }
    }
}
