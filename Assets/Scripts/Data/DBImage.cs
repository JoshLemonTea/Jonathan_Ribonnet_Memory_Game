using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Data
{
    // Define a class called DBImage
    class DBImage
    {
        // Define public properties for the DBImage class
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] MemoryImage { get; set; }

        // Uncommented code line, which is a public field declaration
        // public bool IsBack = false;
    }
}
