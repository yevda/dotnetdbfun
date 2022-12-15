using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XML_CodeFirst
{
    internal class XML_Context: DbContext

    {
        public DbSet<XML_Data> XML_Data { get; set; }
        public XML_Context() 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=SSW-WSA-9220;Database=MyXMLDB;Trusted_Connection=True;TrustServerCertificate=True");

            //if (!optionsBuilder.IsConfigured) 
            //{
            //    string connectionString = @"Server=SSW-WSA-9220;Database=MyXMLDB;Trusted_Connection=True;TrustServerCertificate=True";
            //    optionsBuilder.UseSqlServer(connectionString, conf => conf.UseHierarchyId());

            //}
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Tree>().HasKey(t => t.TreeId);
            modelBuilder.Entity<XML_Data>().Property(x => x.XML_String).HasColumnType("xml");
            modelBuilder.Entity<XML_Data>().Property(x => x.XML_XElement).HasColumnType("xml");
            modelBuilder.Entity<XML_Data>().Property(x => x.XML_XElement).HasConversion(
                xml => xml.ToString(),
                xml => xml != null ? XElement.Parse(xml) : null);
        }
    }
}
