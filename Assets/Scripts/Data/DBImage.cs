using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Data
{
    class DBImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] MemoryImage { get; set; }

        //public bool IsBack = false;
    }
}
