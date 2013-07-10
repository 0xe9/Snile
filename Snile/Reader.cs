using Snile.PE;
using Snile.CLR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.Snile
{
    public class Reader
    {
        public DataStream memStream = null;
        public BinaryParser binaryParser = null;
        private byte[] data = null;

        public Reader(byte[] data)
        {
            if(data == null)
                throw new Exception("Parameter is null");

            this.memStream = new DataStream(data);
            this.binaryParser = new BinaryParser(memStream);
        }

        private Reader(DataStream memorySteam)
        {
            if (memStream == null)
                throw new Exception("Stream is null");
            this.memStream = memorySteam;
            this.binaryParser = new BinaryParser(memStream);
        }

        public Reader(string filePath)
        {
            if (filePath.Length < 0)
                throw new Exception("File path is empty");

            data = File.ReadAllBytes(filePath);
            this.memStream = new DataStream(data);
            this.binaryParser = new BinaryParser(memStream);
        }

        public void Read(byte[] data)
        {
            if (data == null)
                throw new Exception("Parameter is null");

            this.memStream = new DataStream(data);
            this.binaryParser = new BinaryParser(memStream);
        }

        public void Write(string path)
        {
            File.WriteAllBytes(path, this.data);
        }

        public bool isValidFile()
        {
            memStream.Position = 0x3C;

            return false;
        }

        public uint RVAtoOffset(uint rva)
        {
            uint b = 0x0;
            for (int i = 0; i < this.GetSections().Count; i++)
            {
                Section section = this.GetSections()[i];

                if (rva > section.GetVirtualAddress() && rva < (section.GetVirtualAddress() + section.GetVirtualSize()))
                {
                    uint a = rva - section.GetVirtualAddress();
                    b = a + section.GetDataAddress();
                }
            }
            return b;
        }

        public BinaryParser GetBinaryParser()
        {
            if (this.binaryParser == null)
                throw new Exception("Stream is null");
            return this.binaryParser;
        }

        public MemoryStream GetMemoryStream()
        {
            if(this.memStream == null)
                throw new Exception("Stream is null");
            return this.memStream;
        }

        public DOSHeader GetDOSHeader()
        {
            return new DOSHeader(this);
        }

        public NTHeader GetNTHeader()
        {
            return new NTHeader(this);
        }

        public FileHeader GetFileHeader()
        {
            return new FileHeader(this);
        }

        public OptionalHeader GetOptionalHeader()
        {
            return new OptionalHeader(this);
        }

        public DataDirectories GetDataDirectories()
        {
            return new DataDirectories(this);
        }

        public List<Section> GetSections()
        {
            return new Sections(this).GetAllSections();
        }

        public CLRHeader GetCLRHeader()
        {
            return new CLRHeader(this);
        }

        public MetadataHeader GetMetadataHeader()
        {
            return new MetadataHeader(this);
        }

        public StreamParser GetStreamParser()
        {
            return new StreamParser(this);
        }
    }
}
