/**
 *  Author: HERNAN JOHN B. ALIPIO 
 *  Description : Access for Area
 *  Date Created: November 2, 2013  
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    [Serializable]
    class AreaSessionData : BaseSession
    {

        public IList<Area> getAllRegionsByArea(String area)
        {
            try
            {
                using (var data = new Dbase())
                {
                    data.Configuration.LazyLoadingEnabled = true;

                    IList<Area> areas = data.areas.Include(s => s.regions)
                        .Where(a => a.name == area)
                        .ToList<Area>();

                    return areas;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message.ToString());
            }
            return null;
        }

        public IList<Area> getAllAreas()
        {
            return Dbase.getCurrentInstance().areas
                    .Include(a => a.regions)   
                    .ToList<Area>();
        }

        public Hashtable getAllAreasByHashtable() {
            Hashtable hashAllArea = new Hashtable();

            foreach (Area area in getAllAreas()) {
                hashAllArea.Add(area.name, area);
            }

            return hashAllArea;
        }

        public Area getAreaByName(String areaName)
        {
            Area area = new Area();
            area.name = areaName;

            return getAreaByName(area);
        }

        public Area getAreaByName(Area area) {
            return Dbase.getCurrentInstance().areas
                        .Where(a => a.name == area.name)
                        .FirstOrDefault<Area>();
        }

        public Area getLuzonArea()
        {
            return getAreaByName(Area.LUZON);
        }

        public Area getMindanaoArea()
        {
            return getAreaByName(Area.MINDANAO);
        }

        public Area getVisayasArea()
        {
            return getAreaByName(Area.VISAYAS);
        }
    
        public IList<Area> getAllRegionsByLuzonArea() {
            return getAllRegionsByArea(Area.LUZON);
        }
        
        public IList<Area> getAllRegionsByMindanaoArea(){
            return getAllRegionsByArea(Area.MINDANAO);
        }

        public IList<Area> getAllRegionsByVisayasArea(){
            return getAllRegionsByArea(Area.VISAYAS);
        }
    }
}
