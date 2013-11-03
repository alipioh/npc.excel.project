/**
 *  Author: HERNAN JOHN B. ALIPIO 
 *  Description : Data repositories for area
 *              : Area values are, LUZON, VISAYAZ & MINDANAO
 *  Date Created: November 1, 2013  
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace com.npc.desktop.com.npc.desktop.entities
{
    [Serializable]
    [Table("npcAreas")]
    class Area
    {
        #region ATTRIBUTES
        public static readonly String LUZON = "luzon";
        public static readonly String VISAYAS = "visayas";
        public static readonly String MINDANAO = "mindanao";
        #endregion

        public Area()
        {
            regions = new List<Regions>();
        }

        #region ENCAPSULATION METHODS OR ACCESSOR & MUTATOR METHODS
        [Key]
        public Int32 areaId { get; set; }
        public String name { get; set; }
        #endregion

        #region COLLECTIONS
        public ICollection<Regions> regions { get; set; }
        #endregion
    }
}
