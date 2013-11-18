/**
 *  Author: HERNAN JOHN B. ALIPIO 
 *  Description : Data repositories for data values
 *  Date Created: November 1, 2013 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    [Serializable]
    [Table("npcDataValues")]
    class DataValues 
    {
        public DataValues() {
            contents = new List<DataContent>();
        }

        public DataValues(Plant plant, DataType dataType)
            : base()
        {
            this.plantId = plant.plantId;
            this.dataTypeId = dataTypeId;
        }

        #region ENCAPSULATION METHOD / ACCESSOR & MUTATOR METHODS
        [Key]
        public Int32 dataValuesId { get; set; }
       
        #endregion

        #region FOREIGN KEY FOR DATATYPE
        public Int32 dataTypeId { get; set; }

        [ForeignKey("dataTypeId")]
        public virtual DataType dataType { get; set; }
        #endregion

        #region FOREIGN KEY FOR PLANT
        public Int32 plantId { get; set; }

        [ForeignKey("plantId")]
        public virtual Plant plant { get; set; }
        #endregion


        #region COLLECTIONS
        public ICollection<DataContent> contents {get;set;}
        #endregion
    }
}
