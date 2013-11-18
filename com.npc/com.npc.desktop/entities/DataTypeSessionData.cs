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
            DataType dataType = new DataType();
            dataType.name = dataTypeName;
            return getDataTypeByName(dataType);
        }

        public DataType getDataTypeByName(DataType dataType)
        {
            return Dbase.getCurrentInstance().dataTypes
                        .Where(dt => dt.name == dataType.name)
                        .FirstOrDefault<DataType>();
        }
    }
}
