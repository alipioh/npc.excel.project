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
        }

        public DbSet<Area> areas { get; set; }
        public DbSet<DataType> dataTypes { get; set; }
        public DbSet<DataValues> dataValues { get; set; }
        public DbSet<Plant> plants { get; set; }
        public DbSet<Region> regions { get; set; }
    }
}
