using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.PE
{
    public class DataDirectory
    {
        private UInt32 address;
        private UInt32 size;

        public DataDirectory(UInt32 virtualAddress, UInt32 size)
        {
            this.address = virtualAddress;
            this.size = size;
        }

        public UInt32 GetAddress()
        {
            return this.address;
        }

        public UInt32 GetSize()
        {
            return this.size;
        }

        public override String ToString()
        {
            return (String.Format("Address: 0x{0:X6}  Size: 0x{1:X6}", address, size));
        }
    }
}
