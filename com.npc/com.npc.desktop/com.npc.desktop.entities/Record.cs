using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.com.npc.desktop.entities
{
    class Record
    {
        public Int32 recordId { get; set; }
        public Plant plant { get; set; }
        public DataType dataTye { get; set; }
        public DataValues dataValues { get; set; }
    }
}
