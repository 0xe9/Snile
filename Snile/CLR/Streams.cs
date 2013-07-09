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
        public Stream[] streams;

        private DataStream memStream = null;
        private BinaryParser binaryParser = null;

        private long streamHeaderAddress;

        private int streamCount = 0;

        public TableHeap tableHeap;
        public StringsHeap stringsHeap;
        public UserStringsHeap userStringsHeap;
        public GUIDHeap guidHeap;
        public BlobHeap blobHeap;

        public Streams(Reader reader)
        {
            this.memStream = reader.memStream;
            this.binaryParser = reader.binaryParser;
            uint metaDataRVA = reader.GetCLRHeader().GetMetaDataRVA();
            long metaDataHeaderAddress = (long)reader.RVAtoOffset(metaDataRVA);
            this.streamHeaderAddress = (long)(metaDataHeaderAddress + 0x20);
            this.streamCount = (int)reader.GetMetadataHeader().GetNumberOfStreams();

            binaryParser.BaseStream.Position = streamHeaderAddress;

            streams = new Stream[this.streamCount];

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

                if(((name.Equals("#-")) || ((name.Equals("#~")))))
                {
                    this.tableHeap = new TableHeap(reader, name, offset, size);
                }

                if (name.Equals("#Strings"))
                {
                    this.stringsHeap = new StringsHeap(reader, name, offset, size);
                }

                if (name.Equals("#US"))
                {
                    this.userStringsHeap = new UserStringsHeap(reader, name, offset, size);
                }

                if (name.Equals("#GUID"))
                {
                    this.guidHeap = new GUIDHeap(reader, name, offset, size);
                }

                if (name.Equals("#Blob"))
                {
                    this.blobHeap = new BlobHeap(reader, name, offset, size);
                }
                this.streams[i] = new Stream(name, offset, size);
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

        public Stream[] GetStreams()
        {
            return this.streams;
        }
    }
}
