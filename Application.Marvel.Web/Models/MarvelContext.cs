using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Application.Marvel.Web.Models
{
    public class MarvelContext:DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Comics> Comics { get; set; }
        public DbSet<Thumbnail> Thumbnails { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Fasciculos> Fasciculos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}