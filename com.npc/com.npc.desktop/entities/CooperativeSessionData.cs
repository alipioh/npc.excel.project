using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    class CooperativeSessionData : BaseSession
    {
        public Cooperative getCooperativeByName(String cooperativeName) {
            return Dbase.getCurrentInstance().cooperatives
                    .Where(c => c.name == cooperativeName)
                    .FirstOrDefault<Cooperative>();
        }

        public IList<Plant> getAllPlantsByCoopName(String cooperativeName)
        {
            return (IList<Plant>) Dbase.getCurrentInstance().cooperatives
                                    .Where(c => c.name == cooperativeName)
                                    .ToList<Cooperative>()[0].plants;
        }
    }
}
