using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;

namespace RepositoryLayer.Context
{
    public class DbContextBook : DbContext
    {
        public DbContextBook(DbContextOptions<DbContextBook> options) : base(options) { }

        public DbSet<UserContactBook> UserContactBooks { get; set; }

        public DbSet<AddressBookEntity> AddressBookEntities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //  Define primary keys explicitly
            modelBuilder.Entity<UserContactBook>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<AddressBookEntity>()
                .HasKey(a => a.AddressBookEntityId);
            // Configure the relationship between User and AddressBookEntry
            modelBuilder.Entity<AddressBookEntity>()
                .HasOne(abe => abe.UserContactBooks)
                .WithMany(u => u.AddressBookEntities)
                .HasForeignKey(abe => abe.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}
