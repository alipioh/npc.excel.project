using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop
{
    interface IReaderSettings
    {
       
        Int32 StartRowIndex {get; set;}
        Int32 EndRowIndex { get; set; }

        String StartColumnIndex {get; set;}
        String EndColumnIndex { get; set; }
    }
}
