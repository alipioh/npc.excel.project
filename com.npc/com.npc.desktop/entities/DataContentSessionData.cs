using System;
using System.Collections.Generic;
using System.Data.Objects;
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


        public List<string> findDataContentValueByDataValuesId(DataValues dataValue)
        {
            return Dbase.getCurrentInstance().dataContents
                 .Where(d => d.dataValuesId == dataValue.dataValuesId)
                 .Select(d => d.value)
                 .ToList();
        }
    }
}
