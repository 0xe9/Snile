using Snile.Snile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.PE
{
    public class FileHeader
    {
        private DataStream memStream = null;
        private BinaryParser binaryParser = null;

        private long fileHeaderAddress;

        public FileHeader(Reader reader)
        {
            this.memStream = reader.memStream;
            this.binaryParser = reader.binaryParser;
            this.fileHeaderAddress = reader.GetDOSHeader().GetFileAddress();
        }

        public UInt16 GetMachine()
        {
            return (UInt16)(binaryParser.ParseUInt16(this.fileHeaderAddress + 0x4));
        }

        public UInt16 GetNumberOfSections()
        {
            return (UInt16)(binaryParser.ParseUInt16(this.fileHeaderAddress + 0x6));
        }

        public UInt32 GetTimpDateStamp()
        {
            return (UInt32)(binaryParser.ParseUInt32(this.fileHeaderAddress + 0x8));
        }

        public UInt32 GetSymbolTableAddress()
        {
            return (UInt32)(binaryParser.ParseUInt32(this.fileHeaderAddress + 0xc));
        }

        public UInt32 GetNumberOfSymbols()
        {
            return (UInt32)(binaryParser.ParseUInt32(this.fileHeaderAddress + 0x10));
        }

        public UInt16 GetOptionalHeaderSize()
        {
            return (UInt16)(binaryParser.ParseUInt16(this.fileHeaderAddress + 0x14));
        }

        public UInt16 GetCharacteristics()
        {
            return (UInt16)(binaryParser.ParseUInt16(this.fileHeaderAddress + 0x16));
        }
    }
}
