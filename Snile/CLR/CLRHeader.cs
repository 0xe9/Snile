using Snile.Snile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.CLR
{
    public class CLRHeader
    {
        private DataStream memStream = null;
        private BinaryParser binaryParser = null;

        private long clrHeaderAddress;

        public CLRHeader(Reader reader)
        {
            this.memStream = reader.memStream;
            this.binaryParser = reader.binaryParser;
            uint netDirectoryAddress = reader.GetDataDirectories().GetNETMetadataDirectory().GetAddress();
            this.clrHeaderAddress = (long)reader.RVAtoOffset(netDirectoryAddress);
        }

        public UInt32 GetMagicNumber()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress));
        }

        public UInt16 GetMajorRuntimeVersion()
        {
            return (UInt16)(binaryParser.ParseUInt16(clrHeaderAddress + 0x4));
        }

        public UInt16 GetMinorRuntimeVersion()
        {
            return (UInt16)(binaryParser.ParseUInt16(clrHeaderAddress + 0x6));
        }

        public UInt32 GetMetaDataRVA()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x8));
        }

        public UInt32 GetMetaDataSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0xC));
        }

        public UInt32 GetFlags()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x10));
        }

        public UInt32 GetEntryPointToken()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x14));
        }

        public UInt32 GetResourcesRVA()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x18));
        }

        public UInt32 GetResourcesSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x1c));
        }

        public UInt32 GetStrongNameSigRVA()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x24));
        }

        public UInt32 GetStrongNameSigSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x28));
        }

        public UInt32 GetCodeManagerTableRVA()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x2c));
        }

        public UInt32 GetCodeManagerTableSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x30));
        }

        public UInt32 GetVTableFixRVA()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x34));
        }

        public UInt32 GetVTableFixSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x38));
        }

        public UInt32 GetExportAddressTableJumpsRVA()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x3c));
        }

        public UInt32 GetExportAddressTableJumpsSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x40));
        }

        public UInt32 GetManagedNativeHeaderRVA()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x44));
        }

        public UInt32 GetManagedNativeHeaderSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(clrHeaderAddress + 0x48));
        }
    }
}
