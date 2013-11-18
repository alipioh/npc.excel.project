using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.npc.desktop.enums;

namespace com.npc.desktop.pro
{
    class Demand
    {
         public enum RowSequence { Range, Collection }

        private String[] rowCollection;
        
        private String rowRangeFrom;
        private String rowRangeTo;
        private String fileName;
        private String workSheet = "DDP-Demand";
        private String path;
        private String areaColumn = "A";
        private String regionColumn = "B";
        private String cooperativeColumn = "C";
        private String cooperativeAccronymColumn = "D";
        private String plantColumn = "E";
        private String plantColumnIndex;

        private List<DdpDemandData> ddpDemandData;
        private List<PscEcsData> pscEcsData;
       
        private List<DDPSupplyContractedData> contractedData;

        public Demand() {
            
            initPeakDemand();
           
            initPSADemand();
            

            initDDPSupplyContractedData();
        }


        #region MISC
        public String[] RowCollection
        {
            get { return rowCollection; }
            set { rowCollection = value; }
        }

        public String RowRangeFrom
        {
            get { return rowRangeFrom; }
            set { rowRangeFrom = value; }
        }

        public String RowRangeTo
        {
            get { return rowRangeTo; }
            set { rowRangeTo = value; }
        }

        public RowSequenceType RowSequenceType { get; set; }
        #endregion

        #region Document Settings
        [CategoryAttribute("Document Settings")]
        public String FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        [CategoryAttribute("Document Settings")]
        public String WorkSheet
        {
            get { return workSheet; }
            set { workSheet = value; }
        }

        [CategoryAttribute("Document Settings")]
        public String Path
        {
            get { return path; }
            set { path = value; }
        }
        #endregion

        #region Summary of PSC
        private void initPSADemand()
        {
            pscEcsData = new List<PscEcsData>();
            pscEcsData.Add(new PscEcsData { Name = "2008", Column = "F" });
            pscEcsData.Add(new PscEcsData { Name = "2009", Column = "G" });
            pscEcsData.Add(new PscEcsData { Name = "2010", Column = "H" });
            pscEcsData.Add(new PscEcsData { Name = "2011", Column = "I" });
            pscEcsData.Add(new PscEcsData { Name = "2012", Column = "J" });
            pscEcsData.Add(new PscEcsData { Name = "2013", Column = "K" });
            pscEcsData.Add(new PscEcsData { Name = "2014", Column = "L" });
            pscEcsData.Add(new PscEcsData { Name = "2015", Column = "M" });
            pscEcsData.Add(new PscEcsData { Name = "2016", Column = "N" });
            pscEcsData.Add(new PscEcsData { Name = "2017", Column = "O" });
            pscEcsData.Add(new PscEcsData { Name = "2018", Column = "P" });
            pscEcsData.Add(new PscEcsData { Name = "2019", Column = "Q" });
            pscEcsData.Add(new PscEcsData { Name = "2020", Column = "R" });
            pscEcsData.Add(new PscEcsData { Name = "2021", Column = "S" });
            pscEcsData.Add(new PscEcsData { Name = "2022", Column = "T" });

        }

        [CategoryAttribute("Worksheet PSC_ECs")]
        public String[] PscEcsKeyword { get; set; }

       [CategoryAttribute("Worksheet PSC_ECs")]
        public String PscEcsKeywordColumn { get; set; }




        [CategoryAttribute("Worksheet PSC_ECs")]
        public String AreaColumn
        {
            get { return areaColumn; }
            set { areaColumn = value; }
        }

        [CategoryAttribute("Worksheet PSC_ECs")]
        public String RegionColumn
        {
            get { return regionColumn; }
            set { regionColumn = value; }
        }

        [CategoryAttribute("Worksheet PSC_ECs")]
        public String CooperativeColumn
        {
            get { return cooperativeColumn; }
            set { cooperativeColumn = value; }
        }

        [CategoryAttribute("Worksheet PSC_ECs")]
        public String CooperativeAccronymColumn {
            get { return cooperativeAccronymColumn; }
            set { cooperativeAccronymColumn = value; }
        }

        [CategoryAttribute("Worksheet PSC_ECs")]
        public String PlantColumn
        {
            get { return plantColumn; }
            set { plantColumn = value; }
        }

         [CategoryAttribute("Worksheet PSC_ECs")]
        public List<PscEcsData> PscEcsData
        {
            get { return pscEcsData; }
            set { pscEcsData = value; }
        }

        //[CategoryAttribute("Worksheet PSC_ECs")]
        //public List<Mwh> EnergySales
        //{
        //    get { return energySales; }
        //    set { energySales = value; }
        //}
        #endregion

        #region DDP-DEMAND
        private void initPeakDemand(){
            ddpDemandData = new List<DdpDemandData>();

            ddpDemandData.Add(new DdpDemandData { Name = "2008", Column = "F" });
            ddpDemandData.Add(new DdpDemandData { Name = "2009", Column = "G" });
            ddpDemandData.Add(new DdpDemandData { Name = "2010", Column = "H" });
            ddpDemandData.Add(new DdpDemandData { Name = "2011", Column = "I" });
            ddpDemandData.Add(new DdpDemandData { Name = "2012", Column = "J" });
            ddpDemandData.Add(new DdpDemandData { Name = "2013", Column = "K" });
            ddpDemandData.Add(new DdpDemandData { Name = "2014", Column = "L" });
            ddpDemandData.Add(new DdpDemandData { Name = "2015", Column = "M" });
            ddpDemandData.Add(new DdpDemandData { Name = "2016", Column = "N" });
            ddpDemandData.Add(new DdpDemandData { Name = "2017", Column = "O" });
            ddpDemandData.Add(new DdpDemandData { Name = "2018", Column = "P" });
            ddpDemandData.Add(new DdpDemandData { Name = "2019", Column = "Q" });
            ddpDemandData.Add(new DdpDemandData { Name = "2020", Column = "R" });
            ddpDemandData.Add(new DdpDemandData { Name = "2021", Column = "S" });
            ddpDemandData.Add(new DdpDemandData { Name = "2022", Column = "T" });
        }

         [CategoryAttribute("Worksheet DDP-Demand")]
        public String[] DdpDemandKeyword { get; set; }

         [CategoryAttribute("Worksheet DDP-Demand")]
        public String DdpDemandkeywordColumn { get; set; }


        [CategoryAttribute("Worksheet DDP-Demand")]
        public AreaType Area { get; set; }

        [CategoryAttribute("Worksheet DDP-Demand")]
        public RegionType Region { get; set; }

        
        [CategoryAttribute("Worksheet DDP-Demand")]
        public String Cooperative { set; get; }

        [CategoryAttribute("Worksheet DDP-Demand")]
        public String CooperativeAccronym { set; get; }

        [CategoryAttribute("Worksheet DDP-Demand")]
        public List<DdpDemandData> DdpDemandData
        {
            get { return ddpDemandData; }
            set { ddpDemandData = value; }
        }
        #endregion

        #region DDP-Supply Contracted
        private void initDDPSupplyContractedData()
        {
            contractedData = new List<DDPSupplyContractedData>();

            contractedData.Add(new DDPSupplyContractedData() { Name = "2008", Column = "E" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2009", Column = "F" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2010", Column = "G" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2011", Column = "H" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2012", Column = "I" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2013", Column = "K" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2014", Column = "L" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2015", Column = "M" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2016", Column = "N" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2017", Column = "O" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2018", Column = "P" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2019", Column = "Q" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2020", Column = "R" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2021", Column = "S" });
            contractedData.Add(new DDPSupplyContractedData() { Name = "2022", Column = "T" });
        }
        
        [CategoryAttribute("Worksheet Supply-Contracted")]
        public String[] SupplyContractedKeyword { get; set; }

        [CategoryAttribute("Worksheet Supply-Contracted")]
        public String SupplyContractedKeywordColumn { get; set; }

         [CategoryAttribute("Worksheet Supply-Contracted")]
        public AreaType SupplyContractedArea { get; set; }

        [CategoryAttribute("Worksheet Supply-Contracted")]
        public RegionType SupplyContractedRegion{ get;set;  }

       
        [CategoryAttribute("Worksheet Supply-Contracted")]
        public String SupplyContractedCooperative { get; set; }


        [CategoryAttribute("Worksheet Supply-Contracted")]
        public String SupplyContractedCooperativeAccronym { get; set; }
       
        [CategoryAttribute("Worksheet Supply-Contracted")]
        public List<DDPSupplyContractedData> SupplyContractedData
        {
            get { return contractedData; }
            set { contractedData = value; }
        }

        [CategoryAttribute("Worksheet Supply-Contracted")]
        public String PlantColumnIndex
        {
            get { return plantColumnIndex; }
            set { plantColumnIndex = value; }
        }

        #endregion
    }
}
