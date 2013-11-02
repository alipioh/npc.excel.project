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
        public static readonly String LUZON = "luzon";
        public static readonly String VISAYAS = "visayas";
        public static readonly String MINDANAO = "mindanao";

        [Key]
        public Int32 areaId { get; set; }
        public String name { get; set; }

        public IList<Region> regions { get; set; }
    }
}
