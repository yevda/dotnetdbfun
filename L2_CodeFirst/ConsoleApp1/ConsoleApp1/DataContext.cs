using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DataContext: DbContext
    {
        public DataContext() 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<Tree> Tree { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(@"Server=SSW-WSA-9220;Database=CodeFirstTree;Trusted_Connection=True;TrustServerCertificate=True");
            
            if (!optionsBuilder.IsConfigured) 
            {
                string connectionString = @"Server=SSW-WSA-9220;Database=CodeFirstTree;Trusted_Connection=True;TrustServerCertificate=True";
                optionsBuilder.UseSqlServer(connectionString, conf => conf.UseHierarchyId());

            }
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tree>().HasKey(t => t.TreeId);
            modelBuilder.Entity<Tree>().Property(t => t.Name).HasMaxLength(30);
            modelBuilder.Entity<Tree>().HasIndex(t => t.Name).IsUnique();
        }
    }
}
