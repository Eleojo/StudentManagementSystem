using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Model;
using System.Threading.Tasks;

namespace Data.AppDbContext
{

    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<AcademicInfo> AcademicInfos { get; set; }
        public DbSet<AdvisorInfo> AdvisorInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships if necessary
            modelBuilder.Entity<Student>()
                .HasOne(s => s.ContactInfo)
                .WithOne()
                .HasForeignKey<Student>(ci => ci.ContactInfoId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.AcademicInfo)
                .WithOne()
                .HasForeignKey<Student>(ai => ai.AcademicInfoId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.AdvisorInfo)
                .WithOne()
                .HasForeignKey<Student>(ai => ai.AdvisorInfoId);

        }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    // Configure your database provider (e.g., SQL Server, SQLite, etc.)
    //    optionsBuilder.UseSqlServer("YourConnectionString");
    //}
}

}
