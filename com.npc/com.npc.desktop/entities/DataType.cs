/**
 *  Author: HERNAN JOHN B. ALIPIO 
 *  Description : Data repositories for data type
 *              : DataTypes are, Demand & Energy Supplies
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
    [Table("npcDataType")]
    class DataType 
    {
        public static readonly String _KH = "kh";
        public static readonly String _MWH = "mwh";

        public DataType() {
            dataValues = new List<DataValues>();
        }

        #region ENCAPSULATION METHOD OR ACCESSOR & MUTATOR METHODS
        [Key]
        public Int32 dataTypeId { get; set; }

        public String name { get; set; }
        #endregion

        #region COLLECTIONS
        public ICollection<DataValues> dataValues { get; set; }
        #endregion
    }
}