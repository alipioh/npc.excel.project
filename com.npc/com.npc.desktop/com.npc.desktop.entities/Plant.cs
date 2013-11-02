using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.com.npc.desktop.entities
{
    class Plant
    {
        public Plant() { }

        public Int32 plantId { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public String prefix { get; set; }
        public DataType dataType { get; set; }
        public DataValues dataValues { get; set; }
    }
}
