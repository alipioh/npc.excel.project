using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    [Serializable]
    [Table("npcCooperativeDataContent")]
    class CooperativeDataContent
    {
        public static String ENTITY_NAME = "npcCooperativeDataContent";
        [Key]
        public Int32 cooperativeDataContentId { get; set; }
        public String header { get; set; }
        public String value { get; set; }

        #region FOREIGN KEY
        public Int32 cooperativeDataValuesId { get; set; }

        [ForeignKey("cooperativeDataValuesId")]
        public virtual CooperativeDataValues cooperativeDataValues { get; set; }
        #endregion
    }
}
