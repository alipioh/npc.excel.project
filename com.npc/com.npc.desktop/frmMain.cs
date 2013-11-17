using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.npc.desktop.entities;
using com.npc.desktop.pro;
using com.npc.desktop.utils;

namespace com.npc.desktop
{
    public partial class frmMain : Form
    {
        private DataContentSessionData dataContentSessionData;
        private AreaSessionData areaSessionData;
        private PlantDataSession plantSessionData;
        private RegionSessionData regionSessionData;
        private CooperativeSessionData cooperativeSessionData;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = new Excel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Excel excel = (Excel)propertyGrid.SelectedObject;
            propertyGrid.SelectedObject = new PSA();

            pnlPSA.Show();
            pnlDemand.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = new Demand();
            pnlDemand.Show();
            pnlPSA.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtPSA.Text = openFileDialog1.FileName;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Demand demand = (Demand)propertyGrid.SelectedObject;
            NumberToLetterUtil converter = new NumberToLetterUtil();

            ExcelUtil excel = new ExcelUtil();
            excel.AddWorkbook();
            excel.Worksheet("Sheet1");

            
            int start1 = demand.StartRow1Index;
            int end1 = demand.EndRow1Index;

            int start2 = Int32.Parse(converter.getNumberByLetter(demand.StartColumn1Index));
            int end2 = Int32.Parse(converter.getNumberByLetter(demand.EndColumn1Index));

            DataContent dataContent = new DataContent();
            DataValues dataValue = new DataValues();
            DataCategory dataCategory = new DataCategory();
            

            for (int cntr = start1; cntr <= end1; cntr++) {
                //for(int cntr2= start2; cntr2 <=end2; cntr2++){

                //    String cell = converter.getLetterByNumber(cntr2) + cntr;
                //    String path = @"='" + demand.Path + "\\[" + demand.FileName + "]" + demand.WorkSheet + "'!" + cell;
                //    excel.WriteCell(1, 1, path);
                //    Console.WriteLine(excel.ReadCell(1, "A"));
                
                //}

                foreach (TotalElectricityPurchased electricity in demand.ElectricityPurchase)
                {
                    String cell = electricity.Column + cntr;
                    String path = @"='" + demand.Path + "\\[" + demand.FileName + "]" + demand.WorkSheet + "'!" + cell;
                    excel.WriteCell(1, 1, path);
                    Console.WriteLine(electricity.Name + " - " + excel.ReadCell(1, "A"));
                }
            }
            
            
            //excel.Save("test2.xlsx");
            excel.Close();
            Console.WriteLine("Success!");
            Console.WriteLine(demand.Region);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDemand.Text = openFileDialog1.FileName;
                String path = Path.GetDirectoryName(txtDemand.Text);
                Demand demand = new Demand();
                demand.FileName = openFileDialog1.SafeFileName;
                demand.Path = path;
                propertyGrid.SelectedObject = demand;
            }
            
        }
    }
}

