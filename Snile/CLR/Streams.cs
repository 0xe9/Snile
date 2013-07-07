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
        private List<Stream> streams = new List<Stream>();

        private DataStream memStream = null;
        private BinaryParser binaryParser = null;

        private long streamHeaderAddress;

        private int streamCount = 0;

        private long streamAddress;

        public Streams(Reader reader)
        {
            this.memStream = reader.memStream;
            this.binaryParser = reader.binaryParser;
            uint metaDataRVA = reader.GetCLRHeader().GetMetaDataRVA();
            long metaDataHeaderAddress = (long)reader.RVAtoOffset(metaDataRVA);
            this.streamHeaderAddress = (long)(metaDataHeaderAddress + 0x20);
            this.streamCount = (int)reader.GetMetadataHeader().GetNumberOfStreams();

            for (int i = 0; i < streamCount; i++)
            {

            }
        }
    }
}
