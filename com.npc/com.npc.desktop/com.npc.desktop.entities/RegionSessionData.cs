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
            return getAllCoopsByRegion(Regions._1)[0];
        }

        public Regions getRegion2()
        {
            return getAllCoopsByRegion(Regions._2)[0];
        }

        public Regions getRegion3()
        {
            return getAllCoopsByRegion(Regions._3)[0];
        }

        public Regions getRegion4A()
        {
            return getAllCoopsByRegion(Regions._4_A)[0];
        }

        public Regions getRegion4B()
        {
            return getAllCoopsByRegion(Regions._4_B)[0];
        }

        public Regions getRegion5()
        {
            return getAllCoopsByRegion(Regions._5)[0];
        }

        public Regions getRegion6() {
            return getAllCoopsByRegion(Regions._6)[0];
        }

        public Regions getRegion7()
        {
            return getAllCoopsByRegion(Regions._7)[0];
        }

        public Regions getRegion8()
        {
            return getAllCoopsByRegion(Regions._8)[0];
        }

        public Regions getRegion9()
        {
            return getAllCoopsByRegion(Regions._9)[0];
        }

        public Regions getRegion10()
        {
            return getAllCoopsByRegion(Regions._10)[0];
        }

        public Regions getRegion11()
        {
            return getAllCoopsByRegion(Regions._11)[0];
        }

        public Regions getRegion12()
        {
            return getAllCoopsByRegion(Regions._12)[0];
        }

        public Regions getRegionCAR()
        {
            return getAllCoopsByRegion(Regions._CAR)[0];
        }

        public Regions getRegionARMM()
        {
            return getAllCoopsByRegion(Regions._ARMM)[0];
        }

        public Regions getRegionCARAGA()
        {
            return getAllCoopsByRegion(Regions._CARAGA)[0];
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

        private IList<Regions> getAllCoopsByRegion(String region) {
            return Dbase.getCurrentInstance().regions.Where(r => r.name == region).ToList<Regions>();
        }

        public IList<Cooperative> getAllCoopByRegion(String region)
        {
            return (IList<Cooperative>)getAllCoopsByRegion(region)[0].cooperatives;
        }

        public IList<Cooperative> getAllCoopInRegion1()
        {
            return getAllCoopByRegion(Regions._1);
        }

        public IList<Cooperative> getAllCoopInRegion2()
        {
            return getAllCoopByRegion(Regions._2);
        }

        public IList<Cooperative> getAllCoopInRegion3()
        {
            return getAllCoopByRegion(Regions._3);
        }

        public IList<Cooperative> getAllCoopInRegion4A()
        {
            return getAllCoopByRegion(Regions._4_A);
        }

        public IList<Cooperative> getAllCoopInRegion4B()
        {
            return getAllCoopByRegion(Regions._4_B);
        }

        public IList<Cooperative> getAllCoopInRegion5()
        {
            return getAllCoopByRegion(Regions._5);
        }

        public IList<Cooperative> getAllCoopInRegion6()
        {
            return getAllCoopByRegion(Regions._6);
        }

        public IList<Cooperative> getAllCoopInRegion7()
        {
            return getAllCoopByRegion(Regions._7);
        }

        public IList<Cooperative> getAllCoopInRegion8()
        {
            return getAllCoopByRegion(Regions._8);
        }

        public IList<Cooperative> getAllCoopInRegion9()
        {
            return getAllCoopByRegion(Regions._9);
        }

        public IList<Cooperative> getAllCoopInRegion10()
        {
            return getAllCoopByRegion(Regions._10);
        }

        public IList<Cooperative> getAllCoopInRegion11()
        {
            return getAllCoopByRegion(Regions._11);
        }

        public IList<Cooperative> getAllCoopInRegion12()
        {
            return getAllCoopByRegion(Regions._12);
        }

        public IList<Cooperative> getAllCoopInARMM()
        {
            return getAllCoopByRegion(Regions._ARMM);
        }

        public IList<Cooperative> getAllCoopInCAR()
        {
            return getAllCoopByRegion(Regions._CAR);
        }

        public IList<Cooperative> getAllCoopInCARAGA()
        {
            return getAllCoopByRegion(Regions._CARAGA);
        }

        #endregion   
    }
}
