using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    [Serializable]
    [Table("npcCooperativeDataValues")]
    class CooperativeDataValues
    {
        public static String ENTITY_NAME = "npcCooperativeDataValues";

        public CooperativeDataValues() {
            contents = new List<CooperativeDataContent>();
        }

        public CooperativeDataValues(Cooperative cooperative, DataType dataType) : base() {
            this.cooperativeId = cooperative.cooperativeId;
            this.dataTypeId = dataType.dataTypeId;
        }

        public CooperativeDataValues(Int32 cooperativeId, Int32 dataTypeId) : base()
        {
            this.cooperativeId = cooperativeId;
            this.dataTypeId = dataTypeId;
        }

        #region FIELDS
        [Key]
        public Int32 cooperativeDataValuesId { get; set; }
        #endregion

        #region FOREIGN KEY

        #region FOREIGN KEY FOR DATATYPE
        public Int32 dataTypeId { get; set; }

        [ForeignKey("dataTypeId")]
        public virtual DataType dataType { get; set; }
        #endregion

        #region FOREIGN KEY FOR COOPERATIVE
        public Int32 cooperativeId { get; set; }

        [ForeignKey("cooperativeId")]
        public virtual Cooperative cooperative { get; set; }
        #endregion
        
        #endregion

        #region COLLECTIONS
        public ICollection<CooperativeDataContent> contents { get; set; }
        #endregion
    }
}
