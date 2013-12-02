using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    class CooperativeDataContentSessionData : BaseSession
    {
        public void deleteByDataValueId(Int32 dataValueId)
        {
            Dbase.getCurrentInstance()
                 .Database
                 .ExecuteSqlCommand("DELETE FROM " + CooperativeDataContent.ENTITY_NAME + " WHERE cooperativeDataValuesId=" + dataValueId);
        }

        public List<CooperativeDataContent> findAllDataContentByDataValue(CooperativeDataValues dataValue) {
            return (List<CooperativeDataContent>)Dbase.getCurrentInstance().cooperativeDataContent
                    .Where(dc => dc.cooperativeDataValuesId == dataValue.cooperativeDataValuesId)
                    .ToList<CooperativeDataContent>();
        }

        public List<string> findDataContentValueByDataValuesId(CooperativeDataValues dataValue)
        {
            return Dbase.getCurrentInstance().cooperativeDataContent
                 .Where(d => d.cooperativeDataValuesId == dataValue.cooperativeDataValuesId)
                 .Select(d => d.value)
                 .ToList();
        }
    }
}
