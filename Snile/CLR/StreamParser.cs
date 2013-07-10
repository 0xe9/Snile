using Snile.Snile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.CLR
{

    public class StreamParser
    {
        public MetadataStream[] streams;

        private DataStream memStream = null;
        private BinaryParser binaryParser = null;
        private Reader reader;

        private long streamHeaderAddress;

        private int streamCount = 0;

        public static long tableHeapOffset;


        public TableHeap tableHeap;
        public StringsHeap stringsHeap;
        public UserStringsHeap userStringsHeap;
        public GUIDHeap guidHeap;
        public BlobHeap blobHeap;

        public StreamParser(Reader reader)
        {
            this.reader = reader;
            this.memStream = reader.memStream;
            this.binaryParser = reader.binaryParser;

            uint metaDataRVA = reader.GetCLRHeader().GetMetaDataRVA();
            long metaDataHeaderAddress = (long)reader.RVAtoOffset(metaDataRVA);
            this.streamHeaderAddress = (long)(metaDataHeaderAddress + 0x20);

            this.streamCount = (int)reader.GetMetadataHeader().GetNumberOfStreams();

            binaryParser.BaseStream.Position = streamHeaderAddress;

            streams = new MetadataStream[this.streamCount];

            int count = 0;

            for (int i = 0; i < this.streamCount; i++)
            {
                string name;
                long start = streamHeaderAddress + count;
                long streamStart = start + (i * 4);

                binaryParser.BaseStream.Position = streamStart;
                uint offset = binaryParser.ReadUInt32();
                uint size = binaryParser.ReadUInt32();

                List<char> buff = new List<char>();
                char next;
                do
                {
                    next = this.binaryParser.ReadChar();
                    buff.Add(next);
                } while (this.binaryParser.BaseStream.Position % 4 != 0 || next != '\0');

                name = new string(buff.TakeWhile(sName => !sName.Equals('\0')).ToArray());

                //gets tableheap offset
                if (i == this.streamCount -1)
                {
                    tableHeapOffset = binaryParser.BaseStream.Position;
                }

                if (name.Length >= 8)
                {
                    count += 16;
                }
                else if (name.Length >= 4)
                {
                    count += 12;
                }
                else
                {
                    count += 8;
                }

                this.streams[i] = new MetadataStream(name, offset, size);
            }
            InitStreams();
        }

        private void InitStreams()
        {
            foreach (MetadataStream stream in this.streams)
            {
                if (((stream.name.Equals("#-")) || ((stream.name.Equals("#~")))))
                {
                    this.tableHeap = new TableHeap(reader, stream.name, stream.offset, stream.size);
                }

                if (stream.name.Equals("#Strings"))
                {
                    this.stringsHeap = new StringsHeap(reader, stream.name, stream.offset, stream.size);
                }

                if (stream.name.Equals("#US"))
                {
                    this.userStringsHeap = new UserStringsHeap(reader, stream.name, stream.offset, stream.size);
                }

                if (stream.name.Equals("#GUID"))
                {
                    this.guidHeap = new GUIDHeap(reader, stream.name, stream.offset, stream.size);
                }

                if (stream.name.Equals("#Blob"))
                {
                    this.blobHeap = new BlobHeap(reader, stream.name, stream.offset, stream.size);
                }
            }

        }

        public TableHeap GetTableHeap()
        {
            return this.tableHeap;
        }

        public StringsHeap GetStringsHeap()
        {
            return this.stringsHeap;
        }

        public UserStringsHeap GetUserStringsHeap()
        {
            return this.userStringsHeap;
        }

        public GUIDHeap GetGUIDHeap()
        {
            return this.guidHeap;
        }

        public BlobHeap GetBlobHeap()
        {
            return this.blobHeap;
        }

        public MetadataStream[] GetStreams()
        {
            return this.streams;
        }
    }
}
