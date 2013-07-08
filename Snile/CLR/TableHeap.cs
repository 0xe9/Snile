using Snile.Snile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.CLR
{
    public class TableHeap
    {
        public string name;
        public uint offset;
        public uint size;

        public TableHeap(string name, uint offset, uint size)
        {
            this.name = name;
            this.offset = offset;
            this.size = size;
        }
    }
}
