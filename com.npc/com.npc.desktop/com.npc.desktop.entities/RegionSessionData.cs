using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.com.npc.desktop.entities
{
    class RegionSessionData
    {
        #region REGIONS METHOD
        /// <summary>
        /// All methods support for Region.cs
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>

        public Regions getRegion1()
        {
            return getAllPlantsByRegion(Regions._1)[0];
        }

        public Regions getRegion2()
        {
            return getAllPlantsByRegion(Regions._2)[0];
        }

        public Regions getRegion3()
        {
            return getAllPlantsByRegion(Regions._3)[0];
        }

        public Regions getRegion4A()
        {
            return getAllPlantsByRegion(Regions._4_A)[0];
        }

        public Regions getRegion4B()
        {
            return getAllPlantsByRegion(Regions._4_B)[0];
        }

        public Regions getRegion5()
        {
            return getAllPlantsByRegion(Regions._5)[0];
        }

        public Regions getRegion6() {
            return getAllPlantsByRegion(Regions._6)[0];
        }

        public Regions getRegion7()
        {
            return getAllPlantsByRegion(Regions._7)[0];
        }

        public Regions getRegion8()
        {
            return getAllPlantsByRegion(Regions._8)[0];
        }

        public Regions getRegion9()
        {
            return getAllPlantsByRegion(Regions._9)[0];
        }

        public Regions getRegion10()
        {
            return getAllPlantsByRegion(Regions._10)[0];
        }

        public Regions getRegion11()
        {
            return getAllPlantsByRegion(Regions._11)[0];
        }

        public Regions getRegion12()
        {
            return getAllPlantsByRegion(Regions._12)[0];
        }

        public IList<Regions> getAllRegionsInLuzon()
        {
            return (IList<Regions>)new AreaSessionData().getAllRegionsByLuzonArea()[0].regions;
        }

        public IList<Regions> getAllRegionsInMindanao()
        {
            return (IList<Regions>) new AreaSessionData().getAllRegionsByMindanaoArea()[0].regions;
        }

        public IList<Regions> getAllRegionsInVisayas()
        {
            return (IList<Regions>)new AreaSessionData().getAllRegionsByVisayasArea()[0].regions;
        }

        public IList<Regions> getAllRegions()
        {
            return Dbase.getCurrentInstance().regions.ToList<Regions>();
        }
        public IList<Regions> getAllPlantsByRegion(String region) {
            return Dbase.getCurrentInstance().regions.Where(r => r.name == region).ToList<Regions>();
        }
        public IList<Plant> getAllPlantsInRegion1()
        {
            return (IList<Plant>) getAllPlantsByRegion(Regions._1)[0].plants;
        }
        public IList<Regions> getAllPlantsInRegion2()
        {
            return getAllPlantsByRegion(Regions._2);
        }
        public IList<Regions> getAllPlantsInRegion3()
        {
            return getAllPlantsByRegion(Regions._3);
        }
        public IList<Regions> getAllPlantsInRegion4A()
        {
            return getAllPlantsByRegion(Regions._4_A);
        }
        public IList<Regions> getAllPlantsInRegion4B()
        {
            return getAllPlantsByRegion(Regions._4_B);
        }
        public IList<Regions> getAllPlantsInRegion5()
        {
            return getAllPlantsByRegion(Regions._5);
        }
        public IList<Regions> getAllPlantsInRegion6()
        {
            return getAllPlantsByRegion(Regions._6);
        }
        public IList<Regions> getAllPlantsInRegion7()
        {
            return getAllPlantsByRegion(Regions._7);
        }
        public IList<Regions> getAllPlantsInRegion8()
        {
            return getAllPlantsByRegion(Regions._8);
        }
        public IList<Regions> getAllPlantsInRegion9()
        {
            return getAllPlantsByRegion(Regions._9);
        }
        public IList<Regions> getAllPlantsInRegion10()
        {
            return getAllPlantsByRegion(Regions._10);
        }
        public IList<Regions> getAllPlantsInRegion11()
        {
            return getAllPlantsByRegion(Regions._11);
        }
        public IList<Regions> getAllPlantsInRegion12()
        {
            return getAllPlantsByRegion(Regions._12);
        }
        #endregion   
    }
}
