using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;

namespace RepositoryLayer.Context
{
    public class DbContextBook : DbContext
    {
        public DbContextBook(DbContextOptions<DbContextBook> options) : base(options) { }

        public DbSet<UserContactBook> UserContactBooks { get; set; }

        public DbSet<AddressBookEntry> AddressBookEntries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //  Define primary keys explicitly
            modelBuilder.Entity<UserContactBook>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<AddressBookEntry>()
                .HasKey(a => a.AddressBookEntryId);
            // Configure the relationship between User and AddressBookEntry
            modelBuilder.Entity<AddressBookEntry>()
                .HasOne(abe => abe.UserContactBooks)
                .WithMany(u => u.AddressBookEntries)
                .HasForeignKey(abe => abe.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}
