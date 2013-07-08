using Snile.Snile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.CLR
{

    public class Streams
    {
        private DataStream memStream = null;
        private BinaryParser binaryParser = null;

        private long streamHeaderAddress;

        private int streamCount = 0;

        public TableHeap tableHeap;

        public Streams(Reader reader)
        {
            this.memStream = reader.memStream;
            this.binaryParser = reader.binaryParser;
            uint metaDataRVA = reader.GetCLRHeader().GetMetaDataRVA();
            long metaDataHeaderAddress = (long)reader.RVAtoOffset(metaDataRVA);
            this.streamHeaderAddress = (long)(metaDataHeaderAddress + 0x20);
            this.streamCount = (int)reader.GetMetadataHeader().GetNumberOfStreams();

            binaryParser.BaseStream.Position = streamHeaderAddress;

            uint offset = binaryParser.ReadUInt32();
            uint size = binaryParser.ReadUInt32();
            string name;

            char[] chars = new char[32];
            int index = 0;
            byte character = 0;
            while ((character = binaryParser.ReadByte()) != 0)
                chars[index++] = (char)character;

            index++;
            int padding = ((index % 4) != 0) ? (4 - (index % 4)) : 0;
            binaryParser.ReadBytes(padding);

            name = new String(chars).Trim(new Char[] { '\0' });

            if (name == "#~")
            {
                this.tableHeap = new TableHeap(name, offset, size);
            }

        }

        public TableHeap GetTableHeap()
        {
            return this.tableHeap;
        }
    }
}
