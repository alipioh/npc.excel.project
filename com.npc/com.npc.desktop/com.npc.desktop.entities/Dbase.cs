/**
 *  Author: HERNAN JOHN B. ALIPIO 
 *  Description : Data repositories for Dbase
 *  Date Created: November 1, 2013 
 */
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace com.npc.desktop.com.npc.desktop.entities
{
    class Dbase : DbContext
    {
        public Dbase() : base() {
            Database.SetInitializer<Dbase>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Region>().HasRequired(r => r.area).WithMany(e => e.regions);
            Console.WriteLine("Created Entity");
        }

        public DbSet<Area> areas { get; set; }
        public DbSet<DataType> dataTypes { get; set; }
        public DbSet<DataValues> dataValues { get; set; }
        public DbSet<Plant> plants { get; set; }
        public DbSet<Region> regions { get; set; }
    }
}
