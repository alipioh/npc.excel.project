using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.exceptions
{
    class CollectionNullException : Exception
    {
        public CollectionNullException() { }
        public CollectionNullException(String message) : base(message) { }
        public CollectionNullException(String message, Exception inner) : base(message, inner) { }
    }
}
