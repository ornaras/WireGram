using Microsoft.EntityFrameworkCore;
using WireGram.Abstractions;
using WireGram.Attributes;
using WireGram.Storage.Converters;
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
            EncryptByAttribute(modelBuilder);
        }

        private void EncryptByAttribute(ModelBuilder modelBuilder)
        {
            var stringType = typeof(string);
            var encryptedAttribute = typeof(EncryptedAttribute);
            var converter = new EncryptedConverter(cryptor);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == stringType
                        && property.PropertyInfo is not null)
                    {
                        var attributes = property.PropertyInfo.GetCustomAttributes(encryptedAttribute, false);

                        if (attributes.Length != 0)
                        {
                            property.SetValueConverter(converter);
                        }
                    }
                }
            }
        }
    }
}
