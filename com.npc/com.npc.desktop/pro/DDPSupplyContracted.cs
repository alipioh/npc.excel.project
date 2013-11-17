using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.npc.desktop.enums;

namespace com.npc.desktop.pro
{
    class DDPSupplyContracted
    {
        private String plantColumnIndex;
        private String plantRowIndex;

        private List<DDPSupplyContractedData> contractedData;

        public DDPSupplyContracted(){
            contractedData = new List<DDPSupplyContractedData>();

            contractedData.Add(new DDPSupplyContractedData(){Name = "2008", Column = "E"});
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

        public String PlantColumnIndex
        {
            get { return plantColumnIndex; }
            set { plantColumnIndex = value; }
        }

        public String PlantRowIndex
        {
            get { return plantRowIndex; }
            set { plantRowIndex = value; }
        }

        public List<DDPSupplyContractedData> ContracteData
        {
            get { return contractedData; }
            set { contractedData = value; }
        }

        public RegionType Region {set; get;}
    }
}
