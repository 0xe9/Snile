using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snile.Snile;
using System.IO;

namespace Snile.PE
{
    public class DataDirectories
    {
        List<DataDirectory> ret = new List<DataDirectory>();

        private DataStream memStream = null;
        private BinaryParser binaryParser = null;

        private long dataDirectoryAddress;

        long fileHeaderLength = 0x16;
        long optHeaderLength = 0x62;

        public DataDirectories(Reader reader)
        {
            this.memStream = reader.memStream;
            this.binaryParser = reader.binaryParser;
            long optHeaderAddress = reader.GetDOSHeader().GetFileAddress() + fileHeaderLength;
            dataDirectoryAddress = optHeaderAddress + optHeaderLength;
        }

        public DataDirectory GetExportDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x4));
        }

        public DataDirectory GetImportDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x8),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0xC));
        }

        public DataDirectory GetResourceDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x10),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x14));
        }

        public DataDirectory GetExceptionDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x18),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x1C));
        }

        public DataDirectory GetSecurityDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x20),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x24));
        }

        public DataDirectory GetRelocationDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x28),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x2C));
        }

        public DataDirectory GetDebugDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x30),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x34));
        }

        public DataDirectory GetArchitectureDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x38),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x3C));
        }

        public DataDirectory GetTLSDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x48),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x4C));
        }

        public DataDirectory GetConfigDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x50),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x54));
        }

        public DataDirectory GetBoundImportDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x58),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x5C));
        }

        public DataDirectory GetIATDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x60),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x64));
        }

        public DataDirectory GetDelayImportDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x68),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x6C));
        }

        public DataDirectory GetNETMetadataDirectory()
        {
            return new DataDirectory(binaryParser.ParseUInt32(dataDirectoryAddress + 0x70),
                binaryParser.ParseUInt32(dataDirectoryAddress + 0x74));
        }
    }
}
