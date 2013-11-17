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
        public enum Regions { Region_1, Region_2, Region_3, Region_4A, Region_4B, Region_5, Region_6, Region_7, Region_8,
                              Region_9, Region_10, Region_11, Region_12, CAR, CARAGA, ARMM};
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

        private List<TotalElectricityPurchased> electricityPurchases;
        private List<TotalPeakDemand> peakDemands;
        private List<Kwh> psaDemand;
        private List<Mwh> energySales;
        private List<DDPSupplyContracted> supplyContracted;

        public Demand() {
            electricityPurchases = new List<TotalElectricityPurchased>();
            peakDemands = new List<TotalPeakDemand>();
            psaDemand = new List<Kwh>();
            energySales = new List<Mwh>();
            supplyContracted = new List<DDPSupplyContracted>();

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

            psaDemand.Add(new Kwh { Name = "2008", Column = "F", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2009", Column = "G", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2010", Column = "H", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2011", Column = "I", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2012", Column = "J", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2013", Column = "K", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2014", Column = "L", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2015", Column = "M", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2016", Column = "N", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2017", Column = "O", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2018", Column = "P", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2019", Column = "Q", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2020", Column = "R", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2021", Column = "S", Keyword="Kwh" });
            psaDemand.Add(new Kwh { Name = "2022", Column = "T", Keyword="Kwh" });

            energySales.Add(new Mwh { Name = "2008", Column = "F", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2009", Column = "G", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2010", Column = "H", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2011", Column = "I", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2012", Column = "J", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2013", Column = "K", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2014", Column = "L", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2015", Column = "M", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2016", Column = "N", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2017", Column = "O", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2018", Column = "P", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2019", Column = "Q", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2020", Column = "R", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2021", Column = "S", Keyword="Mwh" });
            energySales.Add(new Mwh { Name = "2022", Column = "T", Keyword="Mwh" });
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
        public List<Kwh> PSADemand
        {
            get { return psaDemand; }
            set { psaDemand = value; }
        }

        [CategoryAttribute("Worksheet PSC_ECs")]
        public List<Mwh> EnergySales
        {
            get { return energySales; }
            set { energySales = value; }
        }
        #endregion

        #region DDP-DEMAND
        [CategoryAttribute("Worksheet DDP-Demand")]
        public AreaType Area { get; set; }

        [CategoryAttribute("Worksheet DDP-Demand")]
        public Regions Region { get; set; }

        [CategoryAttribute("Worksheet DDP-Demand")]
        public String Plant { set; get; }

        [CategoryAttribute("Worksheet DDP-Demand")]
        public String Cooperative { set; get; }

        [CategoryAttribute("Worksheet DDP-Demand")]
        public String CooperativeAccronym { set; get; }

        [CategoryAttribute("Worksheet DDP-Demand")]
        public List<TotalPeakDemand> PeakDemand
        {
            get { return peakDemands; }
            set { peakDemands = value; }
        }

        [CategoryAttribute("Worksheet DDP-Demand")]
        public List<TotalElectricityPurchased> ElectricityPurchase
        {
            get { return electricityPurchases; }
            set { electricityPurchases = value; }
        }
        #endregion

        #region DDP-Supply Contracted
        [CategoryAttribute("Worksheet Supply-Contracted")]
        public List<DDPSupplyContracted> SupplyContracted
        {
            get { return supplyContracted; }
            set { supplyContracted = value; }
        }
        #endregion
    }
}
