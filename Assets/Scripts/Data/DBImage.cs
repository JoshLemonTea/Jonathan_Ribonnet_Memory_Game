
namespace Memory.Models
{
    public class DBImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] MemoryImage { get; set; }
        public string MemoryImageUrl { get; set; } // Add this property
    }
}
