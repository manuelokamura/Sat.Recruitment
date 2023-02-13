using Sat.Recruitment.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Diagnostics.CodeAnalysis;

namespace Sat.Recruitment
{
    [ExcludeFromCodeCoverage]
    public class SATContext : DbContext
    {

        public SATContext(DbContextOptions<SATContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Address { get; set; }
        public DbSet<UserType> UserTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<User>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<UserType>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<UserType>().HasData(

                new UserType { Id = 1, Name = "Normal", percentage = 0.8m },
                new UserType { Id = 2, Name = "SuperUser", percentage = 0.20m },
                new UserType { Id = 3, Name = "Premium", percentage = 2m }
                );
        }
    }
}
