using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class SpacecraftContext: DbContext
    {
        public DbSet<Spacecraft> Spacecrafts { get;set; }
        public DbSet<Combat> Combats { get;set; }
        public DbSet<Research> Researchs { get;set; }
        public DbSet<Logistic> Logistics { get;set; }

        public SpacecraftContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Spacecraft;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=SSW-WSA-9220;Database=Spacecraft;Trusted_Connection=True;TrustServerCertificate=True");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Combat>().ToTable(nameof(Combat));
            modelBuilder.Entity<Research>().ToTable(nameof(Research));
            modelBuilder.Entity<Logistic>().ToTable(nameof(Logistic));
        }
    }
}
