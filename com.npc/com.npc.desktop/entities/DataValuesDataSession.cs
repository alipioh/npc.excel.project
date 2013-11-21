using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    class DataValuesDataSession : BaseSession
    {
        public DataValues findDataValuesByPlantId(Plant plant, DataType dataType)
        {
            return (DataValues)Dbase.getCurrentInstance().dataValues
                    .Where(dv => dv.plantId == plant.plantId)
                    .Where(dv => dv.dataTypeId == dataType.dataTypeId)
                    .SingleOrDefault<DataValues>();
        }

        public List<DataValues> findDataValuesByPlant(Plant plant) {
            return (List<DataValues>)Dbase.getCurrentInstance().dataValues
                        .Where(dv => dv.plantId == plant.plantId)
                        .ToList<DataValues>();
        }
    }
}
