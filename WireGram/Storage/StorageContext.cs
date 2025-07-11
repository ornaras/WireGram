using Microsoft.EntityFrameworkCore;
using WireGram.Abstractions;
using WireGram.Storage.Models;

namespace WireGram.Storage
{
    internal class StorageContext(ICryptographyService cryptor) : DbContext
    {
        public DbSet<Peer> Peers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=/etc/wiregram");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
