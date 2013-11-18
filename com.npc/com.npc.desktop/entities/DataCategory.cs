using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    [Serializable]
    [Table("npcDataCategory")]
    class DataCategory
    {
        public DataCategory()
        {
            
        }

        #region ENCAPSULATION METHODS or ACCESSOR & MUTATOR METHODS
        [Key]
        public Int32 dataCategoryId { get; set; }
        public String name { get; set; }
        #endregion

        #region COLLECTIONS
        #endregion
    }
}
