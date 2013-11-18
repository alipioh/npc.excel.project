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
    }
}
