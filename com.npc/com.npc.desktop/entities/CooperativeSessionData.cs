using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace com.npc.desktop.entities
{
    class CooperativeSessionData : BaseSession
    {
        
        public List<Cooperative> getCooperativeByRegion(Int32 regionId) {
            return Dbase.getCurrentInstance().cooperatives
                    .Include(c => c.plants)
                    .Where(c => c.regionId == regionId)
                    .ToList<Cooperative>();
        }

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
