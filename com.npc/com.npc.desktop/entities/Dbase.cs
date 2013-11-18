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

namespace com.npc.desktop.entities
{
    class Dbase : DbContext
    {
        public Dbase() : base() {
            Database.SetInitializer<Dbase>(new DbaseInitializer());
        }

        public static Dbase getCurrentInstance()
        {
            return new Dbase();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Regions>()
                .HasRequired<Area>(a => a.area)
                .WithMany(a => a.regions)
                .HasForeignKey(a => a.areaId);

            modelBuilder.Entity<Cooperative>()
                .HasRequired<Regions>(r => r.region)
                .WithMany(r => r.cooperatives)
                .HasForeignKey(r => r.regionId);

            modelBuilder.Entity<Plant>()
                .HasRequired<Cooperative>(c => c.cooperative)
                .WithMany(c => c.plants)
                .HasForeignKey(c => c.cooperativeId);

            modelBuilder.Entity<DataValues>()
                .HasRequired<DataType>(dt => dt.dataType)
                .WithMany(dt => dt.dataValues)
                .HasForeignKey(dt => dt.dataTypeId);

            modelBuilder.Entity<DataValues>()
                .HasRequired<Plant>(p => p.plant)
                .WithMany(p => p.dataValues)
                .HasForeignKey(p => p.plantId);

            modelBuilder.Entity<DataContent>()
                .HasRequired<DataValues>(dv => dv.dataValues)
                .WithMany(dv => dv.contents)
                .HasForeignKey(dv => dv.dataValuesId);

            modelBuilder.Entity<CooperativeDataValues>()
                .HasRequired<Cooperative>(c => c.cooperative)
                .WithMany(c => c.cooperativeDataValues)
                .HasForeignKey(c => c.cooperativeId);

            modelBuilder.Entity<CooperativeDataValues>()
                .HasRequired<DataType>(dt => dt.dataType)
                .WithMany(dt => dt.cooperativeDataValues)
                .HasForeignKey(dt => dt.dataTypeId);

            modelBuilder.Entity<CooperativeDataContent>()
                .HasRequired<CooperativeDataValues>(cdv => cdv.cooperativeDataValues)
                .WithMany(cdv => cdv.contents)
                .HasForeignKey(cdv => cdv.cooperativeDataValuesId);

            Console.WriteLine("Created Entities");
        }

        public DbSet<Area> areas { get; set; }
        public DbSet<DataType> dataTypes { get; set; }
        public DbSet<DataValues> dataValues { get; set; }

        public DbSet<DataContent> dataContents { get; set; }

        public DbSet<Plant> plants { get; set; }
        public DbSet<Regions> regions { get; set; }
        public DbSet<Cooperative> cooperatives { get; set; }
        public DbSet<DataCategory> dataCategories { get; set; }

        public DbSet<CooperativeDataValues> cooperativeDataValues { get; set; }
        public DbSet<CooperativeDataContent> cooperativeDataContent { get; set; }
    }
}
