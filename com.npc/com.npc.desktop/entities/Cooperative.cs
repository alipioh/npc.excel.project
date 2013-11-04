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
        public Cooperative() {
            plants = new List<Plant>();
        }
        
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
