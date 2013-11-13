using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace com.npc.desktop.pro
{
    class PSA
    {
        private String file = "Summary of PSC";
        private String workSheet = "PSC_ECs";
        private List<Kwh> kwhData;
        private List<Mwh> mwhData;
        public PSA() {
            kwhData = new List<Kwh>();
            mwhData = new List<Mwh>();

            kwhData.Add(new Kwh() { Name="2008", Column="J"});
            kwhData.Add(new Kwh() { Name = "2009", Column = "K" });
            kwhData.Add(new Kwh() { Name = "2010", Column="L"});
            kwhData.Add(new Kwh() { Name = "2011", Column = "M" });
            kwhData.Add(new Kwh() { Name = "2012", Column = "N" });
            kwhData.Add(new Kwh() { Name = "2013", Column = "O" });
            kwhData.Add(new Kwh() { Name = "2014", Column = "P" });
            kwhData.Add(new Kwh() { Name = "2015", Column = "Q" });
            kwhData.Add(new Kwh() { Name = "2016", Column = "R" });
            kwhData.Add(new Kwh() { Name = "2017", Column = "S" });
            kwhData.Add(new Kwh() { Name = "2018", Column = "T" });
            kwhData.Add(new Kwh() { Name = "2019", Column = "U" });
            kwhData.Add(new Kwh() { Name = "2020", Column = "V" });
            kwhData.Add(new Kwh() { Name = "2021", Column = "W" });
            kwhData.Add(new Kwh() { Name = "2022", Column = "X" });

            mwhData.Add(new Mwh() { Name="2008", Column="J"});
            mwhData.Add(new Mwh() { Name = "2009", Column = "K" });
            mwhData.Add(new Mwh() { Name = "2010", Column="L"});
            mwhData.Add(new Mwh() { Name = "2011", Column = "M" });
            mwhData.Add(new Mwh() { Name = "2012", Column = "N" });
            mwhData.Add(new Mwh() { Name = "2013", Column = "O" });
            mwhData.Add(new Mwh() { Name = "2014", Column = "P" });
            mwhData.Add(new Mwh() { Name = "2015", Column = "Q" });
            mwhData.Add(new Mwh() { Name = "2016", Column = "R" });
            mwhData.Add(new Mwh() { Name = "2017", Column = "S" });
            mwhData.Add(new Mwh() { Name = "2018", Column = "T" });
            mwhData.Add(new Mwh() { Name = "2019", Column = "U" });
            mwhData.Add(new Mwh() { Name = "2020", Column = "V" });
            mwhData.Add(new Mwh() { Name = "2021", Column = "W" });
            mwhData.Add(new Mwh() { Name = "2022", Column = "X" });
        }


        [CategoryAttribute("Document Settings"),
        ReadOnly(true),
          DefaultValueAttribute("Summary of PSC")]
        public String File {
            get { return file; }
            set { file = value;  }
        }

        [CategoryAttribute("Document Settings"),
       DefaultValueAttribute("PSC_ECs")]
        public String WorkSheet {
            get { return workSheet; }
            set { workSheet = value; }
        }

       
        public List<Kwh> Kwh_Data {
            get { return kwhData; }
            set { kwhData = value; }
        }

        public List<Mwh> Mwh_Data{
            get {return mwhData;}
            set {mwhData = value;}
        }
    }
}
