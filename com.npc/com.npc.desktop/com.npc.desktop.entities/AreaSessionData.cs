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

namespace com.npc.desktop.com.npc.desktop.entities
{
    [Serializable]
    class AreaSessionData
    {
        public IList<Area> getAllRegionsByArea(String area)
        {
            try
            {
                using (var data = new Dbase())
                {
                    data.Configuration.LazyLoadingEnabled = false;

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
            return Dbase.getCurrentInstance().areas.ToList<Area>();
        }

        public Area getLuzonArea()
        {
            return getAllRegionsByArea(Area.LUZON)[0];
        }

        public Area getMindanaoArea()
        {
            return getAllRegionsByArea(Area.MINDANAO)[0];
        }

        public Area getVisayasArea()
        {
            return getAllRegionsByArea(Area.VISAYAS)[0];
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
