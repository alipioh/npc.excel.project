using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace com.npc.desktop.entities
{
    [Serializable]
    [Table("npcCooperative")]
    class Cooperative
    {
        #region Constructor
        public Cooperative() {
            plants = new List<Plant>();
        }

        private Cooperative(String coopName, String accronym) : this()
        {
            name = coopName;
            this.accronym = accronym;
        }

        public Cooperative(String coopName, String accronym, Int32 regionId) : this(coopName, accronym) {
            this.regionId = regionId;
        }

        public Cooperative(String coopName, String accronym, Regions region) : this(coopName, accronym) {
            this.region = region;
        }
        #endregion

        #region ENCAPSULATION METHODS OR ACCESSOR & MUTATOR METHODS
        [Key]
        public Int32 cooperativeId { get; set; }
        public String name { get; set; }
        public String accronym { get; set; }
        #endregion
        
        #region FOREIGN KEY FOR REGION
        public Int32 regionId { get; set; }
        
        [ForeignKey("regionId")]
        public virtual Regions region { get; set; }
        #endregion
        
        #region COLLECTION
        public ICollection<Plant> plants { get; set; }
        #endregion
    }
}
