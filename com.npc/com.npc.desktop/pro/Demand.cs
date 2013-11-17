using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.npc.desktop.pro
{
    class Demand
    {
        public enum Regions { Region_1, Region_2, Region_3, Region_4A, Region_4B, Region_5, Region_6, Region_7, Region_8,
                              Region_9, Region_10, Region_11, Region_12, CAR, CARAGA, ARMM};
        public enum RowSequence { Range, Collection }

        private String[] rowCollection;
        private Int32 rowRangeFrom;
        private Int32 rowRangeTo;

        private String fileName;
        private String workSheet = "DDP-Demand";
        private String path;

        private List<TotalElectricityPurchased> electricityPurchases;
        private List<TotalPeakDemand> peakDemands;

        private Int32 startRow1Index;
        private Int32 endRow1Index;
        private Int32 startRow2Index;
        private Int32 endRow2Index;

        private String startColumn1Index;
        private String endColumn1Index;
        private String startColumn2Index;
        private String endColumn2Index;

        private RowSequenceRange rowSequenceRange;
        

        public Demand() {
            electricityPurchases = new List<TotalElectricityPurchased>();
            peakDemands = new List<TotalPeakDemand>();

            StartRow1Index = 63;
            EndRow1Index = 63;
            
            StartColumn1Index = "F";
            EndColumn1Index = "T";

            StartRow2Index = 130;
            EndRow2Index = 130;

            StartColumn2Index = "F";
            EndColumn2Index = "T";

            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2008", Column = "F" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2009", Column = "G" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2010", Column = "H" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2011", Column = "I" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2012", Column = "J" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2013", Column = "K" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2014", Column = "L" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2015", Column = "M" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2016", Column = "N" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2017", Column = "O" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2018", Column = "P" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2019", Column = "Q" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2020", Column = "R" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2021", Column = "S" });
            electricityPurchases.Add(new TotalElectricityPurchased { Name = "2022", Column = "T" });

            peakDemands.Add(new TotalPeakDemand { Name = "2008", Column = "F" });
            peakDemands.Add(new TotalPeakDemand { Name = "2009", Column = "G" });
            peakDemands.Add(new TotalPeakDemand { Name = "2010", Column = "H" });
            peakDemands.Add(new TotalPeakDemand { Name = "2011", Column = "I" });
            peakDemands.Add(new TotalPeakDemand { Name = "2012", Column = "J" });
            peakDemands.Add(new TotalPeakDemand { Name = "2013", Column = "K" });
            peakDemands.Add(new TotalPeakDemand { Name = "2014", Column = "L" });
            peakDemands.Add(new TotalPeakDemand { Name = "2015", Column = "M" });
            peakDemands.Add(new TotalPeakDemand { Name = "2016", Column = "N" });
            peakDemands.Add(new TotalPeakDemand { Name = "2017", Column = "O" });
            peakDemands.Add(new TotalPeakDemand { Name = "2018", Column = "P" });
            peakDemands.Add(new TotalPeakDemand { Name = "2019", Column = "Q" });
            peakDemands.Add(new TotalPeakDemand { Name = "2020", Column = "R" });
            peakDemands.Add(new TotalPeakDemand { Name = "2021", Column = "S" });
            peakDemands.Add(new TotalPeakDemand { Name = "2022", Column = "T" });
        }

        public Regions Region{ get; set; }

        
        public String[] RowSequenceCollection
        {
            get { return rowCollection; }
            set { rowCollection = value; }
        }

        public Int32 RowRangeFrom
        {
            get { return rowRangeFrom; }
            set { rowRangeFrom = value; }
        }

        public Int32 RowRangeTo
        {
            get { return rowRangeTo; }
            set { rowRangeTo = value; }
        }

        public RowSequence RowSequenceType { get; set; }

        public String Plant { set; get; }

        public String Cooperative { set; get; }
        public String CooperativeAccronym { set; get; }

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

        #region Reading Settings
        [CategoryAttribute("Electricity Purchase Reading Settings")]
        public Int32 StartRow1Index
        {
            set { startRow1Index = value; }
            get { return startRow1Index; }
        }

        [CategoryAttribute("Electricity Purchase Reading Settings")]
        public Int32 EndRow1Index
        {
            set { endRow1Index = value; }
            get {return endRow1Index;}
        }

        [CategoryAttribute("Electricity Purchase Reading Settings")]
        public String StartColumn1Index
        {
            set { startColumn1Index = value; }
            get { return startColumn1Index; }
        }

        [CategoryAttribute("Electricity Purchase Reading Settings")]
        public String EndColumn1Index
        {
            set { endColumn1Index = value;  }
            get { return endColumn1Index; }
        }
        #endregion
        
        #region Peak Demand Settings
        [CategoryAttribute("Peak Demand Reading Settings")]
        public Int32 StartRow2Index
        {
            set { startRow2Index = value; }
            get { return startRow2Index; }
        }

        [CategoryAttribute("Peak Demand Reading Settings")]
        public Int32 EndRow2Index
        {
            set { endRow2Index = value; }
            get { return endRow2Index; }
        }

        [CategoryAttribute("Peak Demand Reading Settings")]
        public String StartColumn2Index
        {
            set { startColumn2Index = value; }
            get { return startColumn2Index; }
        }

        [CategoryAttribute("Peak Demand Reading Settings")]
        public String EndColumn2Index
        {
            set { endColumn2Index = value; }
            get { return endColumn2Index; }
        }
        #endregion
        
        #region Electricity Purchase Data
         [CategoryAttribute("Electricity Purchase Data")]
        public List<TotalElectricityPurchased> ElectricityPurchase
        {
            get { return electricityPurchases; }
            set { electricityPurchases = value; }
        }
        #endregion

        #region Peak Demand Data
        [CategoryAttribute("Peak Demand Data")]
        public List<TotalPeakDemand> PeakDemand {
            get { return peakDemands; }
            set { peakDemands = value; }
        }
        #endregion

        #region Row-User Define
        #endregion
    }
}
