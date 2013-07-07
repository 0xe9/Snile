using Snile.Snile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.PE
{
    public class NTHeader
    {
        private DataStream memStream = null;
        private BinaryParser binaryParser = null;

        public NTHeader(Reader reader)
        {
            this.memStream = reader.memStream;
            this.binaryParser = reader.binaryParser;
        }

        public UInt32 GetMagicNumber()
        {
            return (UInt32)(binaryParser.ParseUInt32(0x80));
        }

    }
}
