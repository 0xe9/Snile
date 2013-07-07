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

        public byte ParseByte(long dest)
        {
            memoryStream.Position = dest;
            return (byte)(memoryStream.Position = this.ReadByte());
        }
    }
}
