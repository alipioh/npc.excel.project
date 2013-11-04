using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    class DataCategorySessionData : BaseSession
    {
        public DataCategory getDataCategoryByName(String dataCategoryName) {
            return Dbase.getCurrentInstance().dataCategories
                        .Where(dc => dc.name == dataCategoryName)
                        .FirstOrDefault<DataCategory>();
       }
    }
}
