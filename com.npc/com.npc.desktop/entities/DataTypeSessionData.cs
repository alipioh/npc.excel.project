using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    class DataTypeSessionData : BaseSession
    {
        public DataType getDataTypeByName(String dataTypeName)
        {
            return Dbase.getCurrentInstance().dataTypes
                        .Where(dt => dt.name == dataTypeName)
                        .FirstOrDefault<DataType>();
        }
    }
}
