using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using com.npc.desktop.entities;
using com.npc.desktop.enums;
using com.npc.desktop.exceptions;
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
            
            DataContent dataContent = new DataContent();
            DataValues dataValue = new DataValues();
            DataCategory dataCategory = new DataCategory();
            
            NumberToLetterUtil numUtil = new NumberToLetterUtil();

            if (demand.RowSequenceType == RowSequenceType.Range) {
                try
                {
                    excel.Open(demand.Path + "/" + demand.FileName);
                    excel.Worksheet(demand.WorkSheet);

                    Object[,] obj = excel.ReadCellByRange(demand.RowRangeFrom + ":" + demand.RowRangeTo);
                    for (int outer = 1; outer <= obj.GetUpperBound(0); outer++)
                    {
                        for (int inner = 1; inner <= obj.GetUpperBound(1); inner++)
                        {
                            Console.WriteLine(numUtil.getLetterByNumber(inner) + outer + " = " + obj[outer, inner]);
                        }
                    }
                }
                catch (WorksheetNotFoundException wnfe)
                {
                    MessageBox.Show(null, wnfe.Message, "Error Window", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (RangeInvalidException rie) {
                    MessageBox.Show(null, rie.Message, "Error Window", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else if (demand.RowSequenceType == RowSequenceType.Collection) {
                try {
                    excel.AddWorkbook();
                    excel.Worksheet("Sheet1");

                    foreach (String cntr in demand.RowCollection)
                    {
                        foreach (TotalElectricityPurchased electricity in demand.ElectricityPurchase)
                        {
                            String cell = electricity.Column + cntr;
                            String path = @"='" + demand.Path + "\\[" + demand.FileName + "]" + demand.WorkSheet + "'!" + cell;
                            excel.WriteCell(1, 1, path);
                            Console.WriteLine(electricity.Name + " - " + excel.ReadCell(1, "A"));
                        }
                    }
                }
                catch (NullReferenceException nre)
                {
                    MessageBox.Show(null,"Collection of row sequence is null", "Error Window", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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
                Demand demand = (Demand)propertyGrid.SelectedObject;

                demand.FileName = openFileDialog1.SafeFileName;
                demand.Path = path;
                propertyGrid.SelectedObject = demand;
            }
            
        }
    }
}

