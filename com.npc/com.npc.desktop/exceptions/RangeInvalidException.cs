using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.exceptions
{
    class RangeInvalidException : Exception
    {
        public RangeInvalidException() { 
        }

        public RangeInvalidException(String message)
            : base(message)
        {

        }

        public RangeInvalidException(String message, Exception inner) : base(message,inner)
        {
        
        }
    }
}
