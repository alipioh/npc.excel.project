using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    class DataContentSessionData : BaseSession
    {
        public void deleteByDataValueId(Int32 dataValueId)
        {
            Dbase.getCurrentInstance()
                 .Database
                 .ExecuteSqlCommand("DELETE FROM " + DataContent.ENTITY_NAME + " WHERE dataValuesId=" + dataValueId);
        }

        public List<DataContent> findDataContentByDataValuesId(DataValues dataValue) {
            return (List<DataContent>)Dbase.getCurrentInstance().dataContents
                    .Where(dc => dc.dataValuesId == dataValue.dataValuesId)
                    .ToList<DataContent>();
        }
    }
}
