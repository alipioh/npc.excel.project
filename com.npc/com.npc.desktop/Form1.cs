using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.npc.desktop.entities;
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

            
            foreach(DataRow dr in ds.Tables["tbl"].Rows){
                DataValues dataValue = new DataValues();

                String plantName = dr[4].ToString();
                String coopName = dr[3].ToString();
                String regionName = dr[1].ToString();
                String areaName= dr[0].ToString();

                Plant plant = plantDataSession.getPlantByName(plantName);
                if (plant == null)
                {
                    Cooperative coop = cooperativeDataSession.getCooperativeByName(coopName);
                    if (coop == null)
                    {
                        Regions region = regionDataSession.getRegionByName(regionName);
                        if (region == null)
                        {
                            Area area = areaSessionData.getAreaByName(areaName);

                            region = new Regions();
                            region.name = regionName;
                            region.areaId = area.areaId;

                            coop = new Cooperative();
                            coop.name = coopName;
                            coop.region = region;

                            plant = new Plant();
                            plant.name = plantName;
                            plant.cooperative = coop;

                            dataValue.plant = plant;

                            Console.WriteLine("Region NULL");
                        }
                        else
                        {
                            coop = new Cooperative();
                            coop.name = coopName;
                            coop.region = region;

                            plant = new Plant();
                            plant.name = plantName;
                            plant.cooperative = coop;

                            dataValue.plant = plant;
                        }
                    }
                    else {
                        plant = new Plant();
                        plant.name = plantName;
                        plant.cooperative = coop;

                        dataValue.plant = plant;
                    }
                }
                else
                {
                    dataValue.plantId = plant.plantId;
                }

                dataValue.dataTypeId = dataTypeSessionData.getDataTypeByName(dr[8].ToString()).dataTypeId;
                dataValue.dataCategoryId = dataCategorySessionData.getDataCategoryByName("psa").dataCategoryId;
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

                using (var db = new Dbase())
                {
                    db.dataValues.Add(dataValue);
                    db.SaveChanges();

                }
                //dataValuesSessionData.add(dataValue);
            }        
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
    }
}
