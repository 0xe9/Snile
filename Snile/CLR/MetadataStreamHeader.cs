using Snile.Snile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.CLR
{
    public class MetadataStreamHeader
    {
        private Reader reader;
        private long metadataStreamAddress;

        public MetadataStreamHeader(Reader reader, long metadataAddress)
        {
            this.reader = reader;
            this.metadataStreamAddress = metadataAddress;
        }

        public byte GetMajorVersion()
        {
            return reader.binaryParser.ParseByte(this.metadataStreamAddress + 0x4);
        }

        public byte GetMinorVersion()
        {
            return reader.binaryParser.ParseByte(this.metadataStreamAddress + 0x5);
        }

        public byte GetHeapOffsetSizes()
        {
            return (byte)reader.binaryParser.ParseByte(this.metadataStreamAddress + 0x6);
        }

        public byte[] GetValidTables()
        {
            reader.binaryParser.BaseStream.Position = this.metadataStreamAddress + 0x8;
            return (byte[])(reader.binaryParser.ReadBytes(8));
        }

        public ulong GetValidTablesAsLong()
        {
            reader.binaryParser.BaseStream.Position = this.metadataStreamAddress + 0x8;
            return (ulong)(reader.binaryParser.ReadInt64());
        }

        public byte[] GetSortedTables()
        {
            reader.binaryParser.BaseStream.Position = this.metadataStreamAddress + 0x10;
            return (byte[])(reader.binaryParser.ReadBytes(8));
        }
    }
}
