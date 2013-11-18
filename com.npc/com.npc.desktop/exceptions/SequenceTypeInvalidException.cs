using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.exceptions
{
    class SequenceTypeInvalidException : Exception
    {
        public SequenceTypeInvalidException() : base() { }
        public SequenceTypeInvalidException(String message) : base(message) { }
        public SequenceTypeInvalidException(String message, Exception inner) : base(message, inner) { }
    }
}
