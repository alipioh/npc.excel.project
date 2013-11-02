using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace com.npc.desktop.com.npc.desktop.entities
{
    class AreaSessionData
    {
        public IList<Area> getAllRegionsByArea(String area){
            try {
                using (var data = new Dbase())
                {
                    Console.WriteLine("Area:  " + area);
                    IList<Area> areas = data.areas.Where(a => a.name == area).ToList<Area>();
                    //IList<Area> areas = data.areas.Include(s => s.regions)
                    //    .Where(a => a.name == area)
                    //    .ToList<Area>();

                    Console.WriteLine(this.GetType().Name.ToString() + " Found");
                    return areas;
                }
            }
            catch (Exception ex){
                Console.WriteLine("ERROR: " + ex.Message.ToString());
            }
            return null;
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
