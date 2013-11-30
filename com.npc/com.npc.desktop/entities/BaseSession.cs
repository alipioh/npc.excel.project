using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    abstract class BaseSession
    {
        private AreaSessionData areaSessionData;
        private CooperativeSessionData cooperativeSessionData;
        private PlantDataSession plantSessionData;
        private RegionSessionData regionSessionData;
        private DataTypeSessionData dataTypeSessionData;

        public Object createIfNotExist(Object obj) {
            object resultObj = null;

            if (!isExist(obj))
            {
                resultObj = add(obj);
            }
            else {
                if (obj.GetType() == typeof(DataType)) {
                    resultObj = (DataType)search(obj);
                }
                else if (obj.GetType() == typeof(Area)) {
                    resultObj = (Area)search(obj);
                }
                else if (obj.GetType() == typeof(Regions))
                {
                    resultObj = (Regions)search(obj);
                }
                else if (obj.GetType() == typeof(Cooperative))
                {
                    resultObj = (Cooperative)search(obj);
                }
                else if (obj.GetType() == typeof(Plant))
                {
                    resultObj = (Plant)search(obj);
                }
                
            }

            return resultObj;
        }

        public Object search(Object obj) {
            object resultObj = null;
            if (obj.GetType() == typeof(Area))
            {
                areaSessionData = new AreaSessionData();
                Area area = areaSessionData.getAreaByName((Area)obj);
                resultObj = area;
            }
            else if (obj.GetType() == typeof(Cooperative))
            {
                Cooperative cooperative = (Cooperative) obj;

                cooperativeSessionData = new CooperativeSessionData();
                Cooperative coop = cooperativeSessionData.getCooperativeByNameAndRegionId(cooperative, cooperative.regionId);
                resultObj = coop;
            }
            else if (obj.GetType() == typeof(Plant))
            {
                Plant planta = (Plant)obj;

                plantSessionData = new PlantDataSession();
                Plant plant = plantSessionData.getPlantByNameAndCooperative(planta); // plantSessionData.getPlantByName((Plant)obj);
                resultObj = plant;
            }
            else if (obj.GetType() == typeof(Regions))
            {
                regionSessionData = new RegionSessionData();
                Regions region = regionSessionData.getRegionByName((Regions)obj);
                resultObj = region;
            }
            else if (obj.GetType() == typeof(DataType))
            {
                dataTypeSessionData = new DataTypeSessionData();
                DataType dataType = dataTypeSessionData.getDataTypeByName((DataType)obj);
                resultObj = dataType;
            }
            return resultObj;
        }

        public void deleteIfExist(Object obj) {
            if (isExist(obj)) {
                delete(obj);
            }
        }

        public Boolean isExist(Object obj) {
            bool exist = false;

            if (obj.GetType() == typeof(Area)) {
                areaSessionData = new AreaSessionData();
                Area area = areaSessionData.getAreaByName((Area)obj);
                exist = (area != null) ? true : false;
            }
            else if (obj.GetType() == typeof(Cooperative)) {
                cooperativeSessionData = new CooperativeSessionData();
                Cooperative coop = cooperativeSessionData.getCooperativeByName((Cooperative)obj);
                exist = (coop != null) ? true : false;
            }
            else if (obj.GetType() == typeof(Plant)) {
                plantSessionData = new PlantDataSession();
                Plant plant = plantSessionData.getPlantByNameAndCooperative((Plant)obj);
                exist = (plant != null) ? true : false;
            }
            else if (obj.GetType() == typeof(Regions)) {
                regionSessionData = new RegionSessionData();
                Regions region = regionSessionData.getRegionByName((Regions)obj);
                exist = (region != null) ? true : false;
            }
            else if (obj.GetType() == typeof(DataType))
            {
                exist = ((DataType)search(obj) != null) ? true : false;
            }

            return exist;
        }

        public Object add(Object obj)
        {
            object resultObj = null;
            using (var db = new Dbase())
            {
                if (obj.GetType() == typeof(Area))
                {
                    Area area = (Area) obj;
                    db.areas.Add(area);
                    db.SaveChanges();

                    resultObj = area;
                }
                else if (obj.GetType() == typeof(Cooperative))
                {
                    Cooperative cooperative = (Cooperative)obj;
                    db.cooperatives.Add(cooperative);
                    db.SaveChanges();

                    resultObj = cooperative;
                }
                else if (obj.GetType() == typeof(Plant))
                {
                    Plant plant = (Plant)obj;
                    db.plants.Add(plant);
                    db.SaveChanges();

                    resultObj = plant;
                }else if(obj.GetType() == typeof(Regions))
                {
                    Regions region = (Regions)obj;
                    db.regions.Add(region);
                    db.SaveChanges();

                    resultObj = region;
                }
                else if (obj.GetType() == typeof(DataValues)) {
                    DataValues dataValue = (DataValues)obj;
                    db.dataValues.Add(dataValue);
                    db.SaveChanges();

                    resultObj = dataValue;
                }
                else if (obj.GetType() == typeof(DataContent))
                {
                    DataContent dataContent = (DataContent)obj;
                    db.dataContents.Add(dataContent);
                    db.SaveChanges();

                    resultObj = dataContent;
                }
                else if (obj.GetType() == typeof(CooperativeDataValues))
                {
                    CooperativeDataValues cooperativeDataValues = (CooperativeDataValues)obj;
                    db.cooperativeDataValues.Add(cooperativeDataValues);
                    db.SaveChanges();

                    resultObj = cooperativeDataValues;
                }else if(obj.GetType() == typeof(CooperativeDataContent)){
                    CooperativeDataContent cooperativeDataContent = (CooperativeDataContent)obj;
                    db.cooperativeDataContent.Add(cooperativeDataContent);
                    db.SaveChanges();

                    resultObj = cooperativeDataContent;
                }
                else if (obj.GetType() == typeof(DataType))
                {
                    DataType dataType = (DataType)obj;
                    db.dataTypes.Add(dataType);
                    db.SaveChanges();

                    resultObj = dataType;
                }

                return resultObj;
            }
        }

        public void delete(Object obj)
        {
            using (var db = new Dbase())
            {
                if (obj.GetType() == typeof(Area))
                {
                    Area area = (Area)obj;
                    Area areaDelete = db.areas.Where(a => a.name == area.name).FirstOrDefault<Area>();

                    db.areas.Remove(areaDelete);
                }
                else if (obj.GetType() == typeof(Cooperative))
                {
                    Cooperative cooperative = (Cooperative)obj;
                    Cooperative cooperativeDelete = db.cooperatives.Where(c => c.name == cooperative.name).FirstOrDefault<Cooperative>();

                    db.cooperatives.Remove(cooperativeDelete);
                }
                else if (obj.GetType() == typeof(Plant))
                {
                    Plant plant = (Plant)obj;
                    Plant plantDelete = db.plants.Where(p => p.name == plant.name).FirstOrDefault<Plant>();

                    db.plants.Remove(plantDelete);
                }
                else if (obj.GetType() == typeof(Regions)) {
                    Regions region = (Regions)obj;
                    Regions regionDelete = db.regions.Where(r => r.name == region.name).FirstOrDefault<Regions>();

                    db.regions.Remove(regionDelete);
                }
                else if (obj.GetType() == typeof(CooperativeDataValues)) {
                    CooperativeDataValues cooperativeDataValues = (CooperativeDataValues)obj;
                    db.cooperativeDataValues.Remove(cooperativeDataValues);
                }else if(obj.GetType() == typeof(CooperativeDataContent)){
                    CooperativeDataContent cooperativeDataContent = (CooperativeDataContent)obj;
                    db.cooperativeDataContent.Remove(cooperativeDataContent);
                }


                db.SaveChanges();
            }
        }
    }
}
