using Snile.Snile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.PE
{
    public class Sections
    {
        public List<Section> allSections = new List<Section>();

        private DataStream memStream = null;
        private BinaryParser binaryParser = null;

        long sectionAddress;

        long dataDirectorySize = 0x74;
        long fileHeaderLength = 0x16;
        long optHeaderLength = 0x62;

        long sectionPadding = 0x8;
        long sectionLength = 0x28;

        int sectionCount;

        public Sections(Reader reader)
        {
            this.memStream = reader.memStream;
            this.binaryParser = reader.binaryParser;
            this.sectionCount = (int)(reader.GetFileHeader().GetNumberOfSections());
            long optHeaderAddress = reader.GetDOSHeader().GetFileAddress() + fileHeaderLength;
            long dataDirectoryAddress = optHeaderAddress + optHeaderLength;
            sectionAddress = (dataDirectoryAddress + dataDirectorySize) + sectionPadding + 0x4;


            for (int i = 0; i < sectionCount; i++)
            {
                long count = sectionLength * i;
                long offset = sectionAddress + count;
                memStream.Position = offset;
                string name = Encoding.Default.GetString(binaryParser.ReadBytes(8));
                UInt32 virtualSize = (UInt32)(memStream.Position = binaryParser.ReadUInt32());
                memStream.Position = offset + 0xc;
                UInt32 virtualAddress = (UInt32)(memStream.Position = binaryParser.ReadUInt32());
                memStream.Position = offset + 0x10;
                UInt32 rawDataSize = (UInt32)(memStream.Position = binaryParser.ReadUInt32());
                memStream.Position = offset + 0x14;
                UInt32 rawDataAddress = (UInt32)(memStream.Position = binaryParser.ReadUInt32());
                memStream.Position = offset + 0x18;
                UInt32 relocAddress = (UInt32)(memStream.Position = binaryParser.ReadUInt32());
                memStream.Position = offset + 0x1c;
                UInt32 lineAddress = (UInt32)(memStream.Position = binaryParser.ReadUInt32());
                memStream.Position = offset + 0x20;
                UInt16 relocCount = (UInt16)(memStream.Position = binaryParser.ReadUInt16());
                memStream.Position = offset + 0x22;
                UInt16 lineCount = (UInt16)(memStream.Position = binaryParser.ReadUInt16());

                this.allSections.Add(new Section(name, virtualAddress, virtualSize, rawDataSize, rawDataAddress, relocAddress, lineAddress, relocCount, lineCount));
            }
        }

        public List<Section> GetAllSections()
        {
            return this.allSections;
        }
    }
}
