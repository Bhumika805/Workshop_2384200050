using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public class DbContextBook : DbContext
    {
        public DbSet<UserContactBooks> Users { get; set; }
        public DbSet<AddressBookEntity> AddressBookEntries { get; set; }

        public DbContextBook(DbContextOptions<DbContextBook> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressBookEntity>()
                .HasOne(ab => ab.UserContactBooks)
                .WithMany(u => u.AddressBookEntries)
                .HasForeignKey(ab => ab.UserId);
        }
    }
}
