using Memory.Models;

using System.Collections.Generic;

namespace Memory.Data
{
    public class MemoryContext : DbContext
    {
        public DbSet<DBImage> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database connection
            optionsBuilder.UseSqlServer("Your_Connection_String");
        }
    }
}
