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
        private DataContentSessionData dataContentSessionData = new DataContentSessionData();
        private AreaSessionData areaSessionData= new AreaSessionData();
        private PlantDataSession plantSessionData = new PlantDataSession();
        private RegionSessionData regionSessionData = new RegionSessionData();
        private CooperativeSessionData cooperativeSessionData = new CooperativeSessionData();
        private DataTypeSessionData dataTypeSessionData = new DataTypeSessionData();
        private DataValuesDataSession dataValuesSessionData = new DataValuesDataSession();
        private CooperativeDataValuesSessionData cooperativeDataValueSessionData = new CooperativeDataValuesSessionData();
        private CooperativeDataContentSessionData cooperativeDataContentSessionData = new CooperativeDataContentSessionData();
        
        private DataContent dataContent = new DataContent();
        private DataValues dataValue = new DataValues();
        private DataCategory dataCategory = new DataCategory();
        private DataType dataType = new DataType();
        private CooperativeDataValues cooperativeDataValue = new CooperativeDataValues();
        private CooperativeDataContent cooperativeDataContent = new CooperativeDataContent();

        private ExcelUtil excel;
            
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

            NumberToLetterUtil numUtil = new NumberToLetterUtil();

            if (demand.RowSequenceType == RowSequenceType.Range) {
                try
                {
                    ExcelUtil excel = new ExcelUtil();
                    excel.Open(demand.Path + "/" + demand.FileName);
                    excel.Worksheet(demand.WorkSheet);

                    Object[,] obj = excel.ReadCellByRange(demand.RowRangeFrom + ":" + demand.RowRangeTo);
                    for (int row = 1; row <= obj.GetUpperBound(0); row++)
                    {
                        for (int column = 1; column <= obj.GetUpperBound(1); column++)
                        {
                            Console.WriteLine(numUtil.getLetterByNumber(column) + "[" + numUtil.getNumberByLetter(numUtil.getLetterByNumber(column)) + "]" + row + " = " + obj[row, column]);
                        }
                    }
                    excel.Close();
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
                try
                {
                    readDDPDemandByCollection(demand);
                }
                catch (NullReferenceException nre)
                {
                    MessageBox.Show(null, nre.Message.ToString(), "Error Window", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

           
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


        #region DDP-DEMAND BY COLLECTION
        private void readDDPDemandByCollection(Demand demand)
        {
            excel = new ExcelUtil();

            excel.AddWorkbook();
            excel.Worksheet("Sheet1");

            String cell = null;
            String path = null;
            foreach (String cntr in demand.RowCollection)
            {
                cell = demand.DdpDemandkeywordColumn + cntr;
                path = @"='" + demand.Path + "\\[" + demand.FileName + "]" + demand.WorkSheet + "'!" + cell;
                excel.WriteCell(1, 1, path);
                String data = excel.ReadCell("A1").ToString();

                dataType = new DataType(data);
                dataType = (DataType)dataTypeSessionData.createIfNotExist(dataType);

                Area area = new Area("Luzon");
                area = (Area)areaSessionData.createIfNotExist(area);

                Regions region = new Regions(demand.Region.ToString().Replace("_", " "), area.areaId);
                region = (Regions)regionSessionData.createIfNotExist(region);

                Cooperative cooperative = new Cooperative(demand.Cooperative, demand.CooperativeAccronym, region.regionId);
                cooperative = (Cooperative)cooperativeSessionData.createIfNotExist(cooperative);

                CooperativeDataValues coopSearch = cooperativeDataValueSessionData.findDataValuesByCoopertiveId(cooperative, dataType);
                if (coopSearch != null)
                {
                    cooperativeDataContentSessionData.deleteByDataValueId(coopSearch.cooperativeDataValuesId);
                    cooperativeDataValue = coopSearch;
                }
                else
                {
                    cooperativeDataValue = new CooperativeDataValues(cooperative, dataType);
                    cooperativeDataValue = (CooperativeDataValues)cooperativeDataValueSessionData.add(cooperativeDataValue);
                }

                writeDDPDemandCoopCollection(demand, cntr);
            }

            excel.Close();
        }

        private void writeDDPDemandCoopCollection(Demand demand, String dataType) {
            foreach (DdpDemandData electricity in demand.DdpDemandData)
            {
                String cell = electricity.Column + dataType;
                String path = @"='" + demand.Path + "\\[" + demand.FileName + "]" + demand.WorkSheet + "'!" + cell;
                excel.WriteCell(1, 1, path);
                Console.WriteLine(electricity.Name + " - " + excel.ReadCell(1, "A"));

                cooperativeDataContent = new CooperativeDataContent();
                cooperativeDataContent.header = electricity.Name;
                cooperativeDataContent.value = excel.ReadCell("A1");
                cooperativeDataContent.cooperativeDataValuesId = cooperativeDataValue.cooperativeDataValuesId;
                cooperativeDataContentSessionData.add(cooperativeDataContent);
            }
        }
        #endregion

        private void button7_Click(object sender, EventArgs e)
        {
            Demand demand = (Demand)propertyGrid.SelectedObject;
            NumberToLetterUtil converter = new NumberToLetterUtil();

            NumberToLetterUtil numUtil = new NumberToLetterUtil();

            if (demand.RowSequenceType == RowSequenceType.Range)
            {
                try
                {
                    String firstLetter = demand.RowRangeFrom.ElementAt(0).ToString();

                    ExcelUtil excel = new ExcelUtil();

                    excel.Open(demand.Path + "/" + demand.FileName);
                    excel.Worksheet(demand.WorkSheet);

                    Object[,] obj = excel.ReadCellByRange(demand.RowRangeFrom + ":" + demand.RowRangeTo);
                    for (int row = 1; row <= obj.GetUpperBound(0); row++)
                    {
                        //for (int col = 1; col <= obj.GetUpperBound(1); col++) {
                        //    if (obj[row, col] == null) {
                        //        Console.WriteLine("NUl");
                        //        continue;
                        //    }

                        //    Console.WriteLine(obj[row, col].ToString());
                        //}
                        int numberGap = Int32.Parse(numUtil.getNumberByLetter(firstLetter));

                        //Area area = new Area(obj[row, Int32.Parse(numUtil.getNumberByLetter(demand.AreaColumn)) - numberGap + 1].ToString());
                        Area area = new Area("Luzon");
                        area = (Area)areaSessionData.createIfNotExist(area);

                        Regions region = new Regions(obj[row, Int32.Parse(numUtil.getNumberByLetter(demand.RegionColumn)) - numberGap + 1].ToString(), area.areaId);
                        region = (Regions)regionSessionData.createIfNotExist(region);

                        Cooperative cooperative = new Cooperative(obj[row, Int32.Parse(numUtil.getNumberByLetter(demand.CooperativeColumn)) - numberGap + 1].ToString(), "", region.regionId);
                        cooperative = (Cooperative)cooperativeSessionData.createIfNotExist(cooperative);

                        if (obj[row, Int32.Parse(numUtil.getNumberByLetter(demand.PlantColumn)) - numberGap + 1] == null)
                        {
                            continue;
                        }

                        Plant plant = new Plant(obj[row, Int32.Parse(numUtil.getNumberByLetter(demand.PlantColumn)) - numberGap + 1].ToString(), cooperative.cooperativeId);
                        plant = (Plant)plantSessionData.createIfNotExist(plant);

                        if (plant == null) continue;

                        Console.WriteLine(Int32.Parse(numUtil.getNumberByLetter(demand.PscEcsKeywordColumn)).ToString());

                        DataType dataType = new DataType(obj[row, Int32.Parse(numUtil.getNumberByLetter(demand.PscEcsKeywordColumn)) - numberGap + 1].ToString());
                        dataType = (DataType)dataTypeSessionData.createIfNotExist(dataType);

                        DataValues dataValue = new DataValues(plant.plantId, dataType.dataTypeId);
                        dataValue = (DataValues)dataValuesSessionData.createIfNotExist(dataValue);

                        foreach (PscEcsData ecsData in demand.PscEcsData)
                        {
                            object dataObect = obj[row, Int32.Parse(numUtil.getNumberByLetter(ecsData.Column)) - numberGap + 1];
                            String data = "0";

                            if (dataObect != null) {
                                data = dataObect.ToString();
                            }

                            DataContent dataContent = new DataContent(ecsData.Name,data, dataValue.dataValuesId);
                            dataContentSessionData.add(dataContent);
                        }
                        
                    }
                    excel.Close();
                }
                catch (WorksheetNotFoundException wnfe)
                {
                    MessageBox.Show(null, wnfe.Message, "Error Window", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (RangeInvalidException rie)
                {
                    MessageBox.Show(null, rie.Message, "Error Window", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IndexOutOfRangeException iore) {
                    MessageBox.Show(null, "Index not in a range.", "Error Window", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (demand.RowSequenceType == RowSequenceType.Collection)
            {
                try
                {
                    excel = new ExcelUtil();

                    excel.AddWorkbook();
                    excel.Worksheet("Sheet1");

                    String cell = null;
                    String path = null;

                    foreach (String row in demand.RowCollection) {
                        cell = demand.PlantColumnIndex + row;
                        path = @"='" + demand.Path + "\\[" + demand.FileName + "]" + demand.WorkSheet + "'!" + cell;
                        excel.WriteCell(1, 1, path);
                        String plantName = excel.ReadCell("A1").ToString();
                        Console.WriteLine(plantName);

                        
                        int rowIndex = Int32.Parse(row)+2;
                        for (int cntr = rowIndex; cntr < (rowIndex + 2); cntr++)
                        {
                            cell = demand.SupplyContractedKeywordColumn + cntr;
                            path = @"='" + demand.Path + "\\[" + demand.FileName + "]" + demand.WorkSheet + "'!" + cell;
                            excel.WriteCell(1, 1, path);
                            String data = excel.ReadCell("A1").ToString();

                            dataType = new DataType(data);
                            dataType = (DataType)dataTypeSessionData.createIfNotExist(dataType);
                            Console.WriteLine("data: " + dataType.dataTypeId);
                            
                            Area area = new Area("Luzon");
                            area = (Area)areaSessionData.createIfNotExist(area);

                            Regions region = new Regions(demand.SupplyContractedRegion.ToString().Replace("_", " "), area.areaId);
                            region = (Regions)regionSessionData.createIfNotExist(region);

                            Cooperative cooperative = new Cooperative(demand.SupplyContractedCooperative, demand.SupplyContractedCooperativeAccronym, region.regionId);
                            cooperative = (Cooperative)cooperativeSessionData.createIfNotExist(cooperative);

                            Plant plant = new Plant(plantName, cooperative.cooperativeId );
                            plant = (Plant)plantSessionData.createIfNotExist(plant);
                            Console.WriteLine("Plant: " + plant.plantId);

                            //DataValues coopSearch = data
                            DataValues coopSearch = dataValuesSessionData.findDataValuesByPlantId(plant, dataType);
                            if (coopSearch != null)
                            {
                                dataContentSessionData.deleteByDataValueId(coopSearch.dataValuesId);
                                dataValue = coopSearch;
                            }
                            else
                            {
                                dataValue = new DataValues();
                                dataValue.plantId = plant.plantId;
                                dataValue.dataTypeId = dataType.dataTypeId;
                                dataValue = (DataValues)dataValuesSessionData.add(dataValue);
                            }

                            foreach (DDPSupplyContractedData contractedData in demand.SupplyContractedData)
                            {
                                cell = contractedData.Column + cntr;
                                path = @"='" + demand.Path + "\\[" + demand.FileName + "]" + demand.WorkSheet + "'!" + cell;
                                excel.WriteCell(1, 1, path);
                                Console.WriteLine(contractedData.Name + " - " + excel.ReadCell(1, "A"));

                                dataContent = new DataContent();
                                dataContent.header = contractedData.Name;
                                dataContent.value = excel.ReadCell("A1");
                                dataContent.dataValuesId = dataValue.dataValuesId;
                                dataContentSessionData.add(dataContent);
                            }
                        }
                    }

                    excel.Close();
                }
                catch (NullReferenceException nre)
                {
                    MessageBox.Show(null, nre.Message.ToString(), "Error Window", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            Console.WriteLine("Success!");
            Console.WriteLine(demand.Region);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //testing for changes
            foreach (Regions region in regionSessionData.getAllRegions()) {
                foreach (Cooperative coop in cooperativeSessionData.getCooperativeByRegion(region.regionId))
                {
                    foreach (Plant plant in plantSessionData.getAllPlantByCoop(coop.cooperativeId)) {
                        if (plant == null) continue;

                        Console.WriteLine("Cooperative: " + plant.name);

                        foreach (DataValues dataValue in dataValuesSessionData.findDataValuesByPlant(plant))
                        {
                            Console.WriteLine("Id: " + dataValue.dataValuesId);
                            foreach (DataContent dataContent in dataContentSessionData.findDataContentByDataValuesId(dataValue))
                            {
                                Console.WriteLine("Plant Content: " + dataContent.header);
                            }
                        }
                    }
                   
                    foreach (CooperativeDataValues cooperativeDataValue in cooperativeDataValueSessionData.findDataValuesByCooperativeId(coop)) {
                        foreach (CooperativeDataContent coopDataContent in cooperativeDataContentSessionData.findAllDataContentByDataValue(cooperativeDataValue)) {
                            Console.WriteLine("Coop Content: " + coopDataContent.value);
                        }
                    }
                }
            } 
        }
    }
}

