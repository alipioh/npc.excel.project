using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.pro
{
    class TotalPeakDemand
    {
        private String name;
        private String column;

        public String Name
        {
            set { name = value; }
            get { return name; }
        }

        public String Column
        {
            set { column = value; }
            get { return column; }
        }
    }
}
