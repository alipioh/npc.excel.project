using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.exceptions
{
    class WorksheetNotFoundException : Exception
    {
        public WorksheetNotFoundException() { 
        
        }

        public WorksheetNotFoundException(String message) : base(message)
        {

        }

        public WorksheetNotFoundException(String message, Exception inner) : base(message, inner)
        {

        }
    }
}
