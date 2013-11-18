using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.pro
{
    class BaseData
    {
        private String name;
        private String column;
        
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Column
        {
            get { return column; }
            set { column = value; }
        }

    }
}
