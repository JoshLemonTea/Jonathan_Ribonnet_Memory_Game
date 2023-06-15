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

        public string Name { get; set; } = null!;
        public byte[] Image1 { get; set; } = null!;
        public bool IsBack { get; set; }

        
    }
}
