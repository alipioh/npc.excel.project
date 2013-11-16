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

        #region ENCAPSULATION METHOD / ACCESSOR & MUTATOR METHODS
        [Key]
        public Int32 dataValuesId { get; set; }
       
        /*
        public Double d2008 { get; set; }
        public Double d2009 { get; set; }
        public Double d2010 { get; set; }
        public Double d2011 { get; set; }
        public Double d2012 { get; set; }
        public Double d2013 { get; set; }
        public Double d2014 { get; set; }
        public Double d2015 { get; set; }
        public Double d2016 { get; set; }
        public Double d2017 { get; set; }
        public Double d2018 { get; set; }
        public Double d2019 { get; set; }
        public Double d2020 { get; set; }
        public Double d2021 { get; set; }
        public Double d2022 { get; set; }
       */
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

        #region FOREIGN KEY FOR DATA CATEGORY
        public Int32 dataCategoryId { get; set; }
        
        [ForeignKey("dataCategoryId")]
        public virtual DataCategory dataCategory { get; set; }
        #endregion

        #region COLLECTIONS
        public ICollection<DataContent> contents {get;set;}
        #endregion
    }
}
