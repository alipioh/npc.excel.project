﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    abstract class BaseSession
    {
        public void add(Object obj)
        {
            using (var db = new Dbase())
            {
                if (obj.GetType() == typeof(Area))
                {
                    Area area = (Area) obj;
                    db.areas.Add(area);
                }
                else if (obj.GetType() == typeof(Cooperative))
                {
                    Cooperative cooperative = (Cooperative)obj;
                    db.cooperatives.Add(cooperative);
                }
                else if (obj.GetType() == typeof(Plant))
                {
                    Plant plant = (Plant)obj;
                    db.plants.Add(plant);
                }else if(obj.GetType() == typeof(Regions))
                {
                    Regions region = (Regions)obj;
                    db.regions.Add(region);
                }
                else if (obj.GetType() == typeof(DataCategory))
                {
                    DataCategory dataCategory = (DataCategory)obj;
                    db.dataCategories.Add(dataCategory);
                }
                else if (obj.GetType() == typeof(DataValues)) {
                    DataValues dataValue = (DataValues)obj;
                    db.dataValues.Add(dataValue);
                }

                int x = db.SaveChanges();
                Console.WriteLine("No. of rows affected : " + x);
                Console.WriteLine("Database Save!");
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
                else if (obj.GetType() == typeof(DataCategory))
                {
                    DataCategory dataCategory = (DataCategory)obj;
                    DataCategory dataCategoryDelete = db.dataCategories.Where(dc => dc.name == dataCategory.name).FirstOrDefault<DataCategory>();

                    db.dataCategories.Remove(dataCategoryDelete);
                }

                db.SaveChanges();
            }
        }
    }
}