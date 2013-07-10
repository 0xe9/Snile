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
    public class TableHeap : MetadataStream
    {
        private Reader reader;

        private long metadataStreamAddress;

        private int tableCount;
        private MetadataTable[] tables;

        struct MetadataTable
        {
            public uint offset;
            public uint length;
            public uint size;
        }

        public TableHeap(Reader reader, string name, uint offset, uint size)
            : base(name, offset, size)
        {
            this.reader = reader;
            this.metadataStreamAddress = StreamParser.tableHeapOffset + 0x18;
            this.reader.binaryParser.BaseStream.Position = metadataStreamAddress;

            //Gets table count
            //BitArray bits = new BitArray(this.GetStreamHeader().GetValidTables());
            //for (int i = 0; i < 64; i++)
            //{
            //    if (bits.Get(i) == true)
            //        this.tableCount++;
            //}

            //this.tables = new MetadataTable[this.GetTableCount()];
            Read();
        }

        private void Init()
        {
            
        }

        private void Read()
        {
            //byte majorVersion = this.GetStreamHeader().GetMajorVersion();
            //byte minorVersion = this.GetStreamHeader().GetMinorVersion();
            //ulong validMask = this.reader.binaryParser.ParseUInt64(metadataStreamAddress - 0x10);

            //int maxPresentTables = (majorVersion == 1 && minorVersion == 0) ? (int)MetadataTableFlags.NestedClass + 1 : (int)MetadataTableFlags.GenericParamConstraint + 1;

            //uint[] sizes = new uint[64];
            //this.reader.binaryParser.BaseStream.Position = metadataStreamAddress;
            //for (int i = 0; i < 64; validMask >>= 1, i++)
            //{
            //    uint rows = (validMask & 1) == 0 ? 0 : this.reader.binaryParser.ReadUInt32();
            //    if (i >= maxPresentTables)
            //        rows = 0;
            //    sizes[i] = rows;
            //    if (i == 0)
            //        Console.WriteLine(i + " - " + rows);
                    //this.tables[i].length = rows;
                //Console.WriteLine(i + " - " + rows);
            //}





            //Console.WriteLine("0x{0:X6}", majorVersion);

            //for (int i = 0; i < this.tableCount; i++)
            //{
            //    if (!HasTable((MetadataTableFlags)i))
            //        continue;

            //    Console.WriteLine("0x{0:X6}", this.reader.binaryParser.BaseStream.Position);
            //    this.tables[i].length = this.reader.binaryParser.ReadUInt32();
            //}

            //for (int i = 0; i < this.tableCount; i++)
            //{
            //    MetadataTable table = this.tables[i];
            //    Console.WriteLine(i + " - " + table.length);
            //}

            //Console.WriteLine("a 0x{0:X6}", metadataStreamAddress);
            //BitArray bits = new BitArray(this.GetStreamHeader().GetValidTables());

            //this.reader.binaryParser.BaseStream.Position = metadataStreamAddress;

            //for (int i = 0; i < tableCount; i++)
            //{
            //    if (bits.Get(i) == true)
            //    {
            //        Console.WriteLine("0x{0:X6}", reader.binaryParser.BaseStream.Position);
            //        this.tables[i].length = reader.binaryParser.ReadUInt32();
            //    }
            //}

            //for (int i = 0; i < this.GetTableCount(); i++)
            //{
            //    MetadataTable table = this.tables[i];
            //    Console.WriteLine(i + " | " + table.length);
            //}


        }

        public byte[] GetData()
        {
            CLRHeader clr = reader.GetCLRHeader();
            uint metadataRVA = clr.GetMetaDataRVA();
            uint tableRVA = metadataRVA + this.offset;
            uint tableFileOffset = reader.RVAtoOffset(tableRVA);
            return reader.binaryParser.ParseBytes(tableFileOffset, (int)size);
        }

        public int GetTableCount()
        {
            return this.tableCount;
        }

        public MetadataStreamHeader GetStreamHeader()
        {
            return new MetadataStreamHeader(this.reader, metadataStreamAddress - 0x18);
        }


        public enum MetadataTableFlags : byte
        {
            Module = 0x00,
            TypeRef = 0x01,
            TypeDef = 0x02,
            FieldPtr = 0x03,
            Field = 0x04,
            MethodPtr = 0x05,
            Method = 0x06,
            ParamPtr = 0x07,
            Param = 0x08,
            InterfaceImpl = 0x09,
            MemberRef = 0x0a,
            Constant = 0x0b,
            CustomAttribute = 0x0c,
            FieldMarshal = 0x0d,
            DeclSecurity = 0x0e,
            ClassLayout = 0x0f,
            FieldLayout = 0x10,
            StandAloneSig = 0x11,
            EventMap = 0x12,
            EventPtr = 0x13,
            Event = 0x14,
            PropertyMap = 0x15,
            PropertyPtr = 0x16,
            Property = 0x17,
            MethodSemantics = 0x18,
            MethodImpl = 0x19,
            ModuleRef = 0x1a,
            TypeSpec = 0x1b,
            ImplMap = 0x1c,
            FieldRVA = 0x1d,
            EncLog = 0x1e,
            EncMap = 0x1f,
            Assembly = 0x20,
            AssemblyProcessor = 0x21,
            AssemblyOS = 0x22,
            AssemblyRef = 0x23,
            AssemblyRefProcessor = 0x24,
            AssemblyRefOS = 0x25,
            File = 0x26,
            ExportedType = 0x27,
            ManifestResource = 0x28,
            NestedClass = 0x29,
            GenericParam = 0x2a,
            MethodSpec = 0x2b,
            GenericParamConstraint = 0x2c,
        }
    }
}
