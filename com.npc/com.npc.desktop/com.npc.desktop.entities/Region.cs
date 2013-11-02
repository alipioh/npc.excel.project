using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.com.npc.desktop.entities
{
    class Region
    {
        public Region() { }
        public Int32 regionId { get; set; }
        public String name { get; set; }
        public Plant plant { get; set; }
        public Area area { get; set; }
    }
}
