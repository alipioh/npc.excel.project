using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    class PlantDataSession : BaseSession
    {
        public Plant getPlantByName(String plantName){
            return Dbase.getCurrentInstance()
                .plants.Where(p => p.name == plantName)
                .FirstOrDefault<Plant>();
        }

        public IList<Plant> getAllPlantsByCoopName(String cooperativeName)
        {
            return new CooperativeSessionData().getAllPlantsByCoopName(cooperativeName);
        }

        public IList<DataValues> getAllDataValuesByPlant(Plant plant)
        {
            return Dbase.getCurrentInstance().dataValues
                        .Where(dv => dv.plant == plant)
                        .ToList<DataValues>();
        }
    }
}
