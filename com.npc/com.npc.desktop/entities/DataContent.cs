using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    [Serializable]
    [Table("npcDataContent")]
    class DataContent
    {
        public static String ENTITY_NAME = "npcDataContent";
        #region FIELDS
        [Key]
        public Int32 dataContentId { get; set; }
        public String value { get; set; }
        public String header { get; set; }
        #endregion

        #region FOREIGN KEY FOR DATA VALUE
        public Int32 dataValuesId { get; set; }

        [ForeignKey("dataValuesId")]
        public virtual DataValues dataValues { get; set; }
        #endregion
    }
}
