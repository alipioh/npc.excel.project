﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace com.npc.desktop.pro
{
    class Mwh
    {
        private String name;
        private String column;
        private String keyWord = "Mwh";

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

       
        public String Keyword
        {
            get { return keyWord; }
            set { keyWord = value; }
        }
    }
}
