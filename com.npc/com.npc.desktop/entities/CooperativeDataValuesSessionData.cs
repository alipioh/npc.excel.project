using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    class CooperativeDataValuesSessionData : BaseSession
    {
        public CooperativeDataValues findDataValuesByCoopertiveId(Cooperative coop, DataType dataType) {
            return (CooperativeDataValues)Dbase.getCurrentInstance().cooperativeDataValues
                    .Where(cdv => cdv.cooperative.cooperativeId == coop.cooperativeId)
                    .Where(cdv => cdv.dataTypeId == dataType.dataTypeId)
                    .SingleOrDefault<CooperativeDataValues>();
        }  
    }
}
