using Snile.Snile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.CLR
{
    public class MetadataHeader
    {
        private DataStream memStream = null;
        private BinaryParser binaryParser = null;

        private long metaDataHeaderAddress;

        private int versionLength = 0;

        public MetadataHeader(Reader reader)
        {
            this.memStream = reader.memStream;
            this.binaryParser = reader.binaryParser;
            uint metaDataRVA = reader.GetCLRHeader().GetMetaDataRVA();
            this.metaDataHeaderAddress = (long)reader.RVAtoOffset(metaDataRVA);
            this.versionLength = (int)(binaryParser.ParseUInt32(metaDataHeaderAddress + 0xC));
        } 

        public UInt32 GetSignature()
        {
            return (UInt32)(binaryParser.ParseUInt32(metaDataHeaderAddress));
        }

        public UInt16 GetMajorVersion()
        {
            return (UInt16)(binaryParser.ParseUInt16(metaDataHeaderAddress + 0x4));
        }

        public UInt16 GetMinorVersion()
        {
            return (UInt16)(binaryParser.ParseUInt16(metaDataHeaderAddress + 0x6));
        }

        public UInt32 GetVersionLength()
        {
            return (UInt32)(binaryParser.ParseUInt32(metaDataHeaderAddress + 0xC));
        }

        public String GetVersion()
        {
            //memStream.Position = metaDataHeaderAddress + 0x10;
            return (String)(Encoding.Default.GetString(binaryParser.ReadBytes(versionLength)));
        }

        public UInt16 GetFlags()
        {
            return (UInt16)(binaryParser.ParseUInt16(metaDataHeaderAddress + 0x1c));
        }

        public UInt16 GetNumberOfStreams()
        {
            return (UInt16)(binaryParser.ParseUInt16(metaDataHeaderAddress + 0x1e));
        }
    }
}
