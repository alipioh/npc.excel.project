﻿/**
 *  Author: HERNAN JOHN B. ALIPIO 
 *  Description : Data repositories for plant
 *  Date Created: November 1, 2013 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    [Serializable]
    [Table("npcPlant")]
    class Plant
    {
        public Plant() {
            dataValues = new List<DataValues>();
        }

        #region ENCAPSULATION METHODS OR ACCESSOR & MUTATOR METHODS
        [Key]
        public Int32 plantId { get; set; }
        
        public String name { get; set; }
        #endregion

        #region FOREIGN KEY FOR REGION
        public Int32 cooperativeId { get; set; }
        
        [ForeignKey("cooperativeId")]
        public virtual Cooperative cooperative { get; set; }
        #endregion

        #region COLLECTIONS
        public ICollection<DataValues> dataValues { get; set; }
        #endregion
    }
}