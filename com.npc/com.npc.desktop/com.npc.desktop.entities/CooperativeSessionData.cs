using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.com.npc.desktop.entities
{
    class CooperativeSessionData
    {
        public Cooperative getCooperativeByName(String cooperativeName) {
            return Dbase.getCurrentInstance().cooperatives
                    .Where(c => c.name == cooperativeName)
                    .ToList<Cooperative>()[0];
        }

        public IList<Plant> getAllPlantsByCoopName(String cooperativeName)
        {
            return (IList<Plant>) Dbase.getCurrentInstance().cooperatives
                                    .Where(c => c.name == cooperativeName)
                                    .ToList<Cooperative>()[0].plants;
        }
    }
}
