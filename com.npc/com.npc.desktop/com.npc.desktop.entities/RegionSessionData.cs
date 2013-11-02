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
        public IList getAllPlantsByRegion(String region) {
            return null;
        }
        public IList getAllPlantsInRegion1() {
            return getAllPlantsByRegion(Region._1);
        }
        public IList getAllPlantsInRegion2()
        {
            return getAllPlantsByRegion(Region._2);
        }
        public IList getAllPlantsInRegion3()
        {
            return getAllPlantsByRegion(Region._3);
        }
        public IList getAllPlantsInRegion4A()
        {
            return getAllPlantsByRegion(Region._4_A);
        }
        public IList getAllPlantsInRegion4B()
        {
            return getAllPlantsByRegion(Region._4_B);
        }
        public IList getAllPlantsInRegion5()
        {
            return getAllPlantsByRegion(Region._5);
        }
        public IList getAllPlantsInRegion6()
        {
            return getAllPlantsByRegion(Region._6);
        }
        public IList getAllPlantsInRegion7()
        {
            return getAllPlantsByRegion(Region._7);
        }
        public IList getAllPlantsInRegion8()
        {
            return getAllPlantsByRegion(Region._8);
        }
        public IList getAllPlantsInRegion9()
        {
            return getAllPlantsByRegion(Region._9);
        }
        public IList getAllPlantsInRegion10()
        {
            return getAllPlantsByRegion(Region._10);
        }
        public IList getAllPlantsInRegion11()
        {
            return getAllPlantsByRegion(Region._11);
        }
        public IList getAllPlantsInRegion12()
        {
            return getAllPlantsByRegion(Region._12);
        }
        #endregion   
    }
}
