using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace com.npc.desktop.pro
{
    [SerializableAttribute]
    [TypeConverterAttribute(typeof(SizeConverter))]
    [ComVisibleAttribute(true)]
    class RowSequenceRange
    {
        private Int32 from;
        private Int32 to;
        public RowSequenceRange(Int32 from, Int32 to) {
            this.from = from;
            this.to = to;
        }

        public Int32 From {
            get { return from; }
            set { from = value; }
        }

        public Int32 To {
            get { return to; }
            set { to = value; }
        }
    }
}
