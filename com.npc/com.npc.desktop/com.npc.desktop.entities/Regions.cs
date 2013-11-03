/**
 *  Author: HERNAN JOHN B. ALIPIO 
 *  Description : Data repositories for regions
 *  Date Created: November 1, 2013 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace com.npc.desktop.com.npc.desktop.entities
{
    [Serializable]
    [Table("npcRegions")]
    class Regions
    {
        #region ATTRIBUTES
        public static readonly String _1 = "Region 1";
        public static readonly String _2 = "Region 2";
        public static readonly String _3 = "Region 3";
        public static readonly String _4_A = "Region 4A";
        public static readonly String _4_B = "Region 4B";
        public static readonly String _5 = "Region 5";
        public static readonly String _6 = "Region 6";
        public static readonly String _7 = "Region 7";
        public static readonly String _8 = "Region 8";
        public static readonly String _9 = "Region 9";
        public static readonly String _10 = "Region 10";
        public static readonly String _11 = "Region 11";
        public static readonly String _12 = "Region 12";
        #endregion

        public Regions()
        {
            plants = new List<Plant>();
        }

        #region ENCAPSULATION METHODS / ACCESSOR & MUTATOR METHODS
        [Key]
        public Int32 regionId { get; set; }
        public String name { get; set; }
        #endregion

        #region FOREIGN KEY FOR AREA
        public Int32 areaId { get; set; }
        
        [ForeignKey("areaId")]
        public virtual Area area { get; set; }
        #endregion

        #region COLLECTIONS
        public ICollection<Plant> plants { get; set; }
        #endregion
    }
}
