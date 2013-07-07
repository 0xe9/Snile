using Snile.Snile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.PE
{
    public class DOSHeader
    {
        public DataStream memStream = null;
        public BinaryParser binaryParser = null;

        public DOSHeader(Reader reader)
        {
            this.memStream = reader.memStream;
            this.binaryParser = reader.binaryParser;
        }

        public UInt16 GetMagicNumber()
        {
            return binaryParser.ParseUInt16(0x00);
        }

        public UInt16 GetLastSize()
        {
            return binaryParser.ParseUInt16(0x02);
        }

        public UInt16 GetPageCount()
        {
            return binaryParser.ParseUInt16(0x04);
        }

        public UInt16 GetRelocations()
        {
            return binaryParser.ParseUInt16(0x06);
        }

        public UInt16 GetParagraphHeaderSize()
        {
            return binaryParser.ParseUInt16(0x08);
        }

        public UInt16 GetMinExtraParagraphs()
        {
            return binaryParser.ParseUInt16(0x0A);
        }

        public UInt16 GetMaxExtraParagraphs()
        {
            return binaryParser.ParseUInt16(0x0C);
        }

        public UInt16 GetInitialSS()
        {
            return binaryParser.ParseUInt16(0x0E);
        }

        public UInt16 GetInitialSP()
        {
            return binaryParser.ParseUInt16(0x10);
        }

        public UInt16 GetChecksum()
        {
            return binaryParser.ParseUInt16(0x12);
        }

        public UInt16 GetInitialIP()
        {
            return binaryParser.ParseUInt16(0x14);
        }

        public UInt16 GetInitialCS()
        {
            return binaryParser.ParseUInt16(0x16);
        }

        public UInt16 GetRelocFileAddress()
        {
            return binaryParser.ParseUInt16(0x18);
        }

        public UInt16 GetOverlayNumber()
        {
            return binaryParser.ParseUInt16(0x1A);
        }

        public UInt16 GetOEMid()
        {
            return binaryParser.ParseUInt16(0x24);
        }

        public UInt16 GetOEMInfo()
        {
            return binaryParser.ParseUInt16(0x26);
        }

        public UInt32 GetFileAddress()
        {
            return binaryParser.ParseUInt32(0x3c);
        }
    }
}
