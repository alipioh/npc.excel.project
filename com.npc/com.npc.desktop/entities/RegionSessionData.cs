using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    class RegionSessionData : BaseSession
    {
        #region REGIONS METHOD
        /// <summary>
        /// All methods support for Region.cs
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>

        public Regions getRegionByArea(Int32 areaId) {
            return Dbase.getCurrentInstance().regions
                    .Where(r => r.area.areaId == areaId)
                    .FirstOrDefault<Regions>();
        }

        public Regions getRegionByName(String regionName)
        {
            return Dbase.getCurrentInstance().regions
                    .Where(r => r.name == regionName)
                    .FirstOrDefault<Regions>();
        }

        public Regions getRegion1()
        {
            return getRegionByName(Regions._1);
        }

        public Regions getRegion2()
        {
            return getRegionByName(Regions._2);
        }

        public Regions getRegion3()
        {
            return getRegionByName(Regions._3);
        }

        public Regions getRegion4A()
        {
            return getRegionByName(Regions._4_A);
        }

        public Regions getRegion4B()
        {
            return getRegionByName(Regions._4_B);
        }

        public Regions getRegion5()
        {
            return getRegionByName(Regions._5);
        }

        public Regions getRegion6() {
            return getRegionByName(Regions._6);
        }

        public Regions getRegion7()
        {
            return getRegionByName(Regions._7);
        }

        public Regions getRegion8()
        {
            return getRegionByName(Regions._8);
        }

        public Regions getRegion9()
        {
            return getRegionByName(Regions._9);
        }

        public Regions getRegion10()
        {
            return getRegionByName(Regions._10);
        }

        public Regions getRegion11()
        {
            return getRegionByName(Regions._11);
        }

        public Regions getRegion12()
        {
            return getRegionByName(Regions._12);
        }

        public Regions getRegionCAR()
        {
            return getRegionByName(Regions._CAR);
        }

        public Regions getRegionARMM()
        {
            return getRegionByName(Regions._ARMM);
        }

        public Regions getRegionCARAGA()
        {
            return getRegionByName(Regions._CARAGA);
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
