using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.npc.desktop.entities;
using com.npc.desktop.pro;
using com.npc.desktop.utils;
using db = System.Data.OleDb;


namespace com.npc.desktop
{
    public partial class Form1 : Form
    {
        private DataSet ds;
        private PlantDataSession plantDataSession = new PlantDataSession();
        private CooperativeSessionData cooperativeDataSession = new CooperativeSessionData();
        private RegionSessionData regionDataSession = new RegionSessionData();
        private AreaSessionData areaSessionData = new AreaSessionData();
        private DataValuesDataSession dataValuesSessionData = new DataValuesDataSession();
        private DataTypeSessionData dataTypeSessionData = new DataTypeSessionData();
        private DataCategorySessionData dataCategorySessionData = new DataCategorySessionData();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e){
            openFileDialog1.ShowDialog();
            String fileName = openFileDialog1.FileName;

            search(fileName);

            Int32 row = 0;
                    
            foreach(DataRow dr in ds.Tables["tbl"].Rows){
                ++row;
                DataValues dataValue = new DataValues();

                String plantName = dr[4].ToString();
                String coopName = dr[3].ToString();
                String coopAccrnym = dr[2].ToString();
                String regionName = dr[1].ToString();
                String areaName= dr[0].ToString();
                
                Regions region = regionDataSession.getRegionByName(regionName);
                Plant plant = plantDataSession.getPlantByName(plantName);
                if (plant == null)
                {
                    Cooperative coop = cooperativeDataSession.getCooperativeByName(coopName);
                    if (coop == null)
                    {
                        if (region == null)
                        {
                            Area area = areaSessionData.getAreaByName(areaName);
                            region = new Regions(regionName, area.areaId);
                            coop = new Cooperative(coopName, coopAccrnym, region);
                        }
                        else
                        {
                            coop = new Cooperative(coopName, coopAccrnym, region.regionId);
                        }
                        
                        plant = new Plant(plantName, coop);
                        dataValue.plant = plant;
                    }
                    else {
                        plant = new Plant(plantName, coop.cooperativeId);
                        dataValue.plant = plant;
                    }
                }
                else
                {
                    Plant plantTemp = plantDataSession.getPlantByPlantNCoop(plantName, coopName);
                    if (plantTemp == null)
                    {
                        var db = Dbase.getCurrentInstance();
                        Cooperative coop = cooperativeDataSession.getCooperativeByName(coopName);
                        
                        if (coop == null)
                        {
                            Regions regionTemp = regionDataSession.getRegionByName(regionName);
                            if (regionTemp == null) { 
                                Area area = areaSessionData.getAreaByName(areaName);
                                regionTemp = new Regions(regionName, area.areaId);
                                db.regions.Add(regionTemp);
                                db.SaveChanges();
                            }
                            coop = new Cooperative(coopName, coopAccrnym, regionTemp.regionId);
                            db.cooperatives.Add(coop);
                            db.SaveChanges();
                        }

                        Plant plantNew = new Plant(plantName, coop.cooperativeId);

                        db.plants.Add(plantNew);
                        db.SaveChanges();

                        dataValue.plantId = plantNew.plantId;
                    }
                    else {
                        dataValue.plantId = plantTemp.plantId;
                    }
                }

                dataValue.dataTypeId = dataTypeSessionData.getDataTypeByName(dr[8].ToString()).dataTypeId;
                
                using (var db = new Dbase())
                {
                    db.dataValues.Add(dataValue);
                    db.SaveChanges();

                    PSA psa = new PSA();
                    ExcelUtil exc = new ExcelUtil();
                    exc.Open(fileName);
                    exc.Worksheet("PSC_ECs");

                    foreach (PscEcsData kwh in psa.Kwh_Data)
                    {
                        DataContent content = new DataContent();
                        content.header = kwh.Name;
                        //content.value = dr[Int32.Parse(kwh.Name) - 1999].ToString();
                        content.value = exc.ReadCell(kwh.Column + row);
                        Console.WriteLine(row + " = " + content.value);
                        content.dataValuesId = dataValue.dataValuesId;
                        db.dataContents.Add(content);
                        db.SaveChanges();
                    }
                }
                
                    /*
                        dataValue.d2008 = Double.Parse("0" + dr[9].ToString());
                        dataValue.d2009 = Double.Parse("0" + dr[10].ToString());
                        dataValue.d2010 = Double.Parse("0" + dr[11].ToString());
                        dataValue.d2011 = Double.Parse("0" + dr[12].ToString());
                        dataValue.d2012 = Double.Parse("0" + dr[13].ToString());
                        dataValue.d2013 = Double.Parse("0" + dr[14].ToString());
                        dataValue.d2014 = Double.Parse("0" + dr[15].ToString());
                        dataValue.d2015 = Double.Parse("0" + dr[16].ToString());
                        dataValue.d2016 = Double.Parse("0" + dr[17].ToString());
                        dataValue.d2017 = Double.Parse("0" + dr[18].ToString());
                        dataValue.d2018 = Double.Parse("0" + dr[19].ToString());
                        dataValue.d2019 = Double.Parse("0" + dr[20].ToString());
                        dataValue.d2020 = Double.Parse("0" + dr[21].ToString());
                        dataValue.d2021 = Double.Parse("0" + dr[22].ToString());
                        dataValue.d2022 = Double.Parse("0" + dr[23].ToString());
                    */

                    using (var db = new Dbase())
                    {
                        db.dataValues.Add(dataValue);
                        db.SaveChanges();
                    }
            }

            Console.WriteLine("DONE!");
        }

        private void search(String file)
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= '" + file + "';Extended Properties='Excel 8.0;HDR=Yes;'";
            string query = "select * from [PSC_ECs$A4:X2000] WHERE F1 <> ''";

            db.OleDbConnection cn = new db.OleDbConnection();
            cn.ConnectionString = strConn;
            cn.Open();

            db.OleDbDataAdapter da = new db.OleDbDataAdapter(query, cn);
            ds = new DataSet();

            da.Fill(ds, "tbl");
            dtgData.DataSource = ds.Tables["tbl"];

            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExcelUtil excel = new ExcelUtil();
               
            //foreach(Area areas in areaSessionData.getAllRegionsByArea(Area.LUZON)){
            //    foreach (Regions region in areas.regions) {
            //       // Console.WriteLine(region.name);
            //    }
            //    //excel.WriteCell(1, rows++, region.name);
            //    //foreach (Regions region in areas.regions) {
            //    //    Console.WriteLine(region.name);
            //    //    excel.WriteCell(1,rows++, region.name);
                    
            //    //}
            //}


            //int rows = 1;
            //int currentRow = 1;

            //foreach (Area area in areaSessionData.getAllAreas()) {
            //    Console.WriteLine(area.name);
            //    foreach (Regions region in area.regions) {
            //        Console.WriteLine(" +" + region.name);
            //        foreach (Cooperative coop in cooperativeDataSession.getCooperativeByRegion(region.regionId)) {
            //            Console.WriteLine("  +" + coop.name);
            //            foreach (Plant plant in plantDataSession.getAllPlantByCoop(coop.cooperativeId)) {
            //                Console.WriteLine("   +" + plant.name);
            //            }
            //        }
            //    }
            //}

           
            //foreach(Plant data in plantDataSession.getAllPlantData()){
            //    Console.WriteLine(data.name);

            //    excel.WriteCell(currentRow, 1, data.cooperative.region.area.name);
            //    excel.WriteCell(currentRow, 2, data.cooperative.region.name);
            //    excel.WriteCell(currentRow, 3, data.cooperative.name);
            //    ++currentRow;
                
            //    //currentRow++;
            //    excel.WriteCell(currentRow, 1, data.cooperative.region.area.name);
            //    excel.WriteCell(currentRow, 2, data.cooperative.region.name);
            //    excel.WriteCell(currentRow, 3, data.name);
                
            //    foreach (DataValues d in data.dataValues) {
            //        excel.WriteCell(currentRow, 4, d.d2008.ToString());
            //        excel.WriteCell(currentRow, 6, d.d2009.ToString());
            //        excel.WriteCell(currentRow, 8, d.d2010.ToString());
            //        excel.WriteCell(currentRow, 10, d.d2011.ToString());
            //        excel.WriteCell(currentRow, 12, d.d2012.ToString());
            //        excel.WriteCell(currentRow, 14, d.d2013.ToString());
            //        excel.WriteCell(currentRow, 16, d.d2014.ToString());
            //        excel.WriteCell(currentRow, 18, d.d2015.ToString());
            //        excel.WriteCell(currentRow, 20, d.d2016.ToString());
            //        excel.WriteCell(currentRow, 22, d.d2017.ToString());
            //        excel.WriteCell(currentRow, 24, d.d2018.ToString());
            //        excel.WriteCell(currentRow, 26, d.d2019.ToString());
            //        excel.WriteCell(currentRow, 28, d.d2020.ToString());
            //        excel.WriteCell(currentRow, 30, d.d2021.ToString());
            //        excel.WriteCell(currentRow, 32, d.d2022.ToString());
            //    }
            //    //currentRow = rows++;
            //    currentRow += 2;
            //}

            //excel.AddWorkbook();
           
            //excel.Worksheet("Sheet1");
            //excel.AddWorksheet("Sheet1");
            
            excel.AddWorkbook();
            excel.Worksheet("Sheet1");
            
            excel.WriteCell(1, 1, @"='E:\ECs (108)\1.  LUZON (50)\2013 DDP REGION 5 (11)\2013 ALECO DDP\[2013_aleco_ddp.xlsm]DDP-Demand'!$F$130");

            Console.WriteLine(excel.ReadCell(1, "A"));
            //excel.Save("test2.xlsx");
            excel.Close();
            Console.WriteLine("Success!");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain();
            mainForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            String fileName = openFileDialog1.FileName;
            ExcelUtil exc = new ExcelUtil();
            exc.Open(fileName);
            //exc.AddWorkbook();
            exc.Worksheet("Sheet1");


            Object[,] obj = exc.ReadCellByRange("A1:Y806");
            Console.WriteLine(obj.GetUpperBound(0));
            Console.WriteLine(obj.GetUpperBound(1));

            NumberToLetterUtil numUtil = new NumberToLetterUtil();

            for (int x = 1; x < obj.GetUpperBound(0); x++)
            {
                for (int y = 1; y < obj.GetUpperBound(1); y++)
                {
                    Console.WriteLine(numUtil.getLetterByNumber(y) + x + " = " + obj[x, y]);
                }
            }

            //for (int cntr = 5; cntr < 500; cntr++) {
            //    Console.WriteLine(exc.ReadCell("A" + cntr.ToString()));
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Application.StartupPath.ToString());
            ExcelUtil excel = new ExcelUtil();
            
            excel.Open(Application.StartupPath.ToString() + "\\testCSV.csv");
            excel.Worksheet("testCSV");
            excel.setBackgroundColor("A1:A5", Color.Red);
            excel.WriteCell(1, 1, "Tet");

            excel.Save("newExcel.xls");
            Console.WriteLine("Save");
        }
    }
}
