using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.PE
{
    public class Section
    {
        private string name;
        private UInt32 virtualAddress;
        private UInt32 virtualSize;
        private UInt32 dataSize;
        private UInt32 dataAddress;
        private UInt32 relocAddress;
        private UInt32 lineAddress;
        private UInt16 relocCount;
        private UInt16 lineCount;

        public Section(String name, UInt32 address, UInt32 size, UInt32 dataSize, UInt32 dataAddress,
            UInt32 relocAddress, UInt32 lineAddress, UInt16 relocCount, UInt16 lineCount)
        {
            this.name = name;
            this.virtualAddress = address;
            this.virtualSize = size;
            this.dataSize = dataSize;
            this.dataAddress = dataAddress;
            this.relocAddress = relocAddress;
            this.lineAddress = lineAddress;
            this.relocCount = relocCount;
            this.lineCount = lineCount;
        }

        public String GetName()
        {
            return this.name;
        }

        public UInt32 GetVirtualAddress()
        {
            return this.virtualAddress;
        }

        public UInt32 GetVirtualSize()
        {
            return this.virtualSize;
        }

        public UInt32 GetDataSize()
        {
            return this.dataSize;
        }

        public UInt32 GetDataAddress()
        {
            return this.dataAddress;
        }

        public UInt32 GetRelocationsAddress()
        {
            return this.relocAddress;
        }

        public UInt16 GetRelocationsCount()
        {
            return this.relocCount;
        }

        public UInt32 GetLineNumbersAddress()
        {
            return this.lineAddress;
        }

        public UInt16 GetLineNumbersCount()
        {
            return this.lineCount;
        }

        public override String ToString()
        {
            return (String.Format("Name: {0}  RVA: 0x{0:X6} Size:  0x{0:X6}", name, virtualAddress, virtualSize));
        }
    }
}
