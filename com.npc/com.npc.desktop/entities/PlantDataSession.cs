using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace com.npc.desktop.entities
{
    [Serializable]
    class PlantDataSession : BaseSession
    {

        public Hashtable getAllPlantByHashtable() {
            Hashtable hashAllPlant = new Hashtable();
            foreach (Plant plant in getAllPlant()) {
                hashAllPlant.Add(plant.name, plant);
            }

            return hashAllPlant;
        }

        public Plant getPlantByNameAndCooperative(Plant plant) {
            return Dbase.getCurrentInstance().plants
                .Where(p => p.name == plant.name && p.cooperativeId == plant.cooperativeId)
                .FirstOrDefault<Plant>();
        }

        public Plant getPlantByName(String plantName){
            Plant plant = new Plant();
            plant.name = plantName;

            return getPlantByName(plant);
        }

        public Plant getPlantByName(Plant plant) {
            return Dbase.getCurrentInstance()
                .plants.Where(p => p.name == plant.name)
                .FirstOrDefault<Plant>();
        }

        public Plant getPlantByCoop(Cooperative coop) {
            return getPlantByCoop(coop.name);
        }

        public Plant getPlantByCoop(String coopName) {
            return Dbase.getCurrentInstance().plants
                    .Where(p => p.cooperative.name == coopName)
                    .FirstOrDefault<Plant>();
        }

        public Plant getPlantByCoopId(Int32 coopId)
        {
            var db = new Dbase();
            db.Configuration.LazyLoadingEnabled = false;

            return db.plants
                    .Where(p => p.cooperative.cooperativeId == coopId)
                    .FirstOrDefault<Plant>();
        }

        public Plant getPlantByPlantNCoop(String plantName, String coopName)
        {
            return Dbase.getCurrentInstance().plants
                    .Where(p => p.name == plantName)
                    .Where(p => p.cooperative.name == coopName)
                    .FirstOrDefault<Plant>();
        }

        

        public IList<Plant> getAllPlantByCoop(Int32 coopId) {
            return Dbase.getCurrentInstance().plants
                .Where(p => p.cooperativeId == coopId)
                .Include(p => p.dataValues)
                .ToList<Plant>();
        }

        public IList<Plant> getAllPlantsByCoopName(String cooperativeName)
        {
            return new CooperativeSessionData().getAllPlantsByCoopName(cooperativeName);
        }

        public IList<Plant> getAllPlant()
        {
            return Dbase.getCurrentInstance()
                .plants.ToList<Plant>();
        }

        public IList<DataValues> getAllDataValuesByPlant(Plant plant)
        {
            return Dbase.getCurrentInstance().dataValues
                        .Where(dv => dv.plant == plant)
                        .ToList<DataValues>();
        }

        public IList<DataValues> getAllDataValues() {
            return Dbase.getCurrentInstance().dataValues.ToList<DataValues>();
        }

        public IList<Plant> getAllPlantData()
        {
            return Dbase.getCurrentInstance().plants
                    .Include(p => p.dataValues)
                    .Include(p => p.cooperative)
                    .Include(p => p.cooperative.region)
                    .Include(p => p.cooperative.region.area)
                    .ToList<Plant>();
        }
    }
}
