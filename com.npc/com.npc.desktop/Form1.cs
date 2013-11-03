using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.npc.desktop.com.npc.desktop.entities;

namespace com.npc.desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e){
            try {
                //using (var db = new Dbase())
                //{
                //    Area area = new Area();
                //    area.name = Area.LUZON;

                //    Regions region = new Regions();
                //    region.name = "region 1";
                //    region.area = area;

                //    db.regions.Add(region);
                //    db.SaveChanges();
                //    MessageBox.Show("Saved!");
                //}
                Regions region = new Regions();
                region.name = "region 1 ";
             
                AreaSessionData areaSessionData = new AreaSessionData();
                areaSessionData.getLuzonArea().regions.Add(region);
                //dataGridView1.DataSource = areaSessionData.getAllRegionsByArea("luzons");
                dataGridView1.DataSource = new RegionSessionData().getAllPlantsInRegion1();

                //dataGridView1.DataSource = new RegionSessionData().getAllRegionsInLuzon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
