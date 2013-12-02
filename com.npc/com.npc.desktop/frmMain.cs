using System;
using System.Collections;
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
        private NumberToLetterUtil numUtil = new NumberToLetterUtil();

        private List<Int32> psaLuzonMark = new List<Int32>();
        private List<Int32> psaVisayasMark = new List<Int32>();
        private List<Int32> psaMindanaoMark = new List<Int32>();

        private List<Int32> demandLuzonMark = new List<Int32>();
        private List<Int32> demandVisayasMark = new List<Int32>();
        private List<Int32> demandMindanaoMark = new List<Int32>();
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
            demand.PscEcsData.Clear();
            demand.PscEcsData.Add(new PscEcsData() { Name="2008", Column="J"});
            demand.PscEcsData.Add(new PscEcsData() { Name = "2009", Column = "K" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2010", Column = "L" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2011", Column = "M" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2012", Column = "N" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2013", Column = "O" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2014", Column = "P" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2015", Column = "Q" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2016", Column = "R" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2017", Column = "S" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2018", Column = "T" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2019", Column = "U" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2020", Column = "V" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2021", Column = "W" });
            demand.PscEcsData.Add(new PscEcsData() { Name = "2022", Column = "X" });
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

                       
                        if(obj[row, Int32.Parse(numUtil.getNumberByLetter(demand.PlantColumn)) - numberGap + 1] == null) continue; 
                        Plant plant = new Plant(obj[row, Int32.Parse(numUtil.getNumberByLetter(demand.PlantColumn)) - numberGap + 1].ToString(), cooperative.cooperativeId);
                        plant = (Plant)plantSessionData.createIfNotExist(plant);
                        //plant = (Plant)plantSessionData.add(plant);

                        //if (plant == null) continue;

                        Console.WriteLine("Plant: " + plant.plantId);

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

        private Int32 row;
        private void button8_Click(object sender, EventArgs e)
        {
            excel = new ExcelUtil();
            excel.AddWorkbook();
            excel.Worksheet("Sheet1");

            List<String> lstData = new List<String>();
            StreamWriter writer = new StreamWriter("testCSV.csv",false);

            List<String> luzonPSASummary = new List<String>();
            List<String> luzonDemandSummary = new List<String>();

            //testing for changes
            row = 0;
            int areaCntr = 0;
            IList<Area> areas = areaSessionData.getAllAreas();
            foreach (Area area in areas) {
                areaCntr++;
                foreach (Regions region in regionSessionData.getAllRegionsByArea(area))
                {
                    List<Cooperative> coops = cooperativeSessionData.getCooperativeByRegion(region.regionId);
                    int coopCntr = 0;
                    foreach (Cooperative coop in coops)
                    {
                        coopCntr++;

                        row++;
                        writer.WriteLine();
                        
                        row++;
                        writer.WriteLine();

                        row++;
                        writer.WriteLine(area.name + "," + region.name + "," + coop.name);

                        IList<Plant> plants = plantSessionData.getAllPlantByCoop(coop.cooperativeId);
                        
                        //row++;
                        //writer.WriteLine(area.name + "," + region.name + ",PSA,=SUM(D" + (row + 1) + ":D" + (row + plants.Count) + ")");
                       
                        int PSARow = row;

                        //row++;
                        int col;
                        //Console.WriteLine(plants.Count.ToString());
                        Console.WriteLine("Coop: " + coop.name + " " + ((double)coopCntr / coops.Count));
                        txtOutput.AppendText(areaCntr + " out of" + areas.Count + ": " + (((double)coopCntr/coops.Count) * 100) + "%\n");
                        loadingBar.Value = (int)(((double)coopCntr / coops.Count) * 100);

                        int colCntr;
                        int psaRowMarker=0;
                        List<String> data1;
                        List<String> data2;

                        bool psaRegistered = false;
                        
                                        
                        foreach (Plant plant in plants)
                        {
                            if (plant != null)
                            {
                                col = 3;
                                colCntr = 1; //
                                data1 = new List<String>();
                                data2 = new List<String>();

                                String psaOutput = "";
                                
                                foreach (DataValues dataValue in plant.dataValues)
                                {
                                    col++;
                                    List<string> tempData = null;

                                    if (colCntr == 1)
                                    {
                                        data1 = dataContentSessionData.findDataContentValueByDataValuesId(dataValue);
                                        tempData = data1;
                                    }
                                    else if (colCntr == 2)
                                    {
                                        data2 = dataContentSessionData.findDataContentValueByDataValuesId(dataValue);
                                        tempData = data2;
                                    }

                                    if (!psaRegistered) {
                                        int column = 4;
                                        
                                        foreach (String str in tempData)
                                        {
                                            psaOutput += "=SUM(" + numUtil.getLetterByNumber(column) + ("row") + ":" + numUtil.getLetterByNumber(column) + ("rows") + "),";
                                            column++;
                                        }
                                    }
                                    
                                    colCntr++;

                                    col = 4;
                                }

                                if(!psaRegistered){
                                    row++;
                                    psaRowMarker = row;
                                    luzonPSASummary.Add(row.ToString());
                                    psaOutput.Remove(psaOutput.LastIndexOf(','));
                                    writer.WriteLine(area.name + "," + region.name + ",PSA," + psaOutput.Replace("rows", (row + plants.Count).ToString()).Replace("row", (row + 1).ToString()));
                                }

                                psaRegistered = true;
                                    
                                List<String> output = merge(data1, data2);
                                output.Insert(0, area.name.Replace(",",""));
                                output.Insert(1, region.name);
                                output.Insert(2, plant.name.Replace(",",""));

                                Console.WriteLine(String.Join(",", output));
                                row++;
                                writer.WriteLine(String.Join(",", output));

                            }
                        }
                       
                        Console.WriteLine("-----------");


                        col = 3;
                        
                        colCntr = 1;
                        data1 = new List<String>();
                        data2 = new List<String>();

                       
                        foreach (CooperativeDataValues dataValue in coop.cooperativeDataValues)
                        {
                            List<string> tempData = null;
                            col++;
                            if (colCntr == 1) {
                                data1 = cooperativeDataContentSessionData.findDataContentValueByDataValuesId(dataValue);
                                tempData = data1;
                            }
                            else if (colCntr == 2) {
                                data2 = cooperativeDataContentSessionData.findDataContentValueByDataValuesId(dataValue);
                                tempData = data2;
                            }
                           
                            colCntr++;
                        }

                        List<String> output2 = merge(data1, data2);
                        
                        int resColumn = 4;
                        row++;
                        String reserveDef = "";

                        foreach(String str in output2){
                            reserveDef += "=" + (psaRowMarker == 0 ? "0" : numUtil.getLetterByNumber(resColumn) + (psaRowMarker)) + "-" + numUtil.getLetterByNumber(resColumn) + (row) + ",";
                            resColumn++;
                        }

                        output2.Insert(0, area.name.Replace(",", ""));
                        output2.Insert(1, region.name);
                        output2.Insert(2, "DEMAND");

                        luzonDemandSummary.Add(row.ToString());
                        row++;
                        writer.WriteLine(String.Join(",", output2));


                        if (!reserveDef.Equals("")) 
                            reserveDef.Remove(reserveDef.LastIndexOf(','));
                        
                        writer.WriteLine(area.name + "," + region.name + ",RESERVE/DEFICIT," + reserveDef);
                    }
                }
            }

            writer.Close();
            
            //ExcelUtil excel = new ExcelUtil();
            row++;
            row++;
            excel.Open(Application.StartupPath.ToString() + "\\testCSV.csv");
            excel.Worksheet("testCSV");
            
            excel.WriteCell(row, 2, "Luzon");
            excel.WriteCell(row, 3, "PSA");
            excel.WriteCell(row, 4, Summary(luzonPSASummary).Replace(",",",D"));
            excel.setBackgroundColor("D" + row, Color.Gainsboro);
            excel.copy("D" + row,"E" + row + ":AG" +row);

            row++;

            excel.WriteCell(row, 2, "Luzon");
            excel.WriteCell(row, 3, "DEMAND");
            excel.WriteCell(row, 4, Summary(luzonDemandSummary).Replace(",", ",D"));
            excel.setBackgroundColor("D" + row, Color.LightCyan);
            excel.copy("D" + row, "E" + row + ":AG" + row);

            row++;

            excel.WriteCell(row, 2, "Luzon");
            excel.WriteCell(row, 3, "RESERVE/DEFICIT");
            excel.WriteCell(row, 4, "=D" + (row-2) + "-D" + (row-1));
            excel.setBackgroundColor("D" + row, Color.LightCyan);
            excel.copy("D" + row, "E" + row + ":AG" + row);

            excel.Save("newExcel.xls");

            GC.Collect();
            Console.WriteLine("Save!");
        }

        private String Summary(List<String> source)
        {
            String summary ="=SUBTOTAL(9," + String.Join(",",source)  + ")";
            return summary;
        }


        private void summary(String summaryArea,List<Int32> psaRowMarks, List<Int32> demandRowMarks, Int32 startingRow) {
            excel.WriteCell(startingRow, 2, summaryArea);
            excel.WriteCell(startingRow, 3, "PSA");
            excel.WriteCell(startingRow, 4, ("=SUBTOTAL(9, " + String.Join(",", psaRowMarks.ToArray()) + ")").Replace(",",",D").Replace(" ", ""));
            excel.copy(numUtil.getLetterByNumber(4) + startingRow, "E" + startingRow + ":" + "AG" + startingRow);
            excel.setBackgroundColor("D"+ startingRow + ":AG" + startingRow, Color.Wheat);
            
            excel.WriteCell(startingRow + 1, 3, "DEMAND");
            excel.WriteCell(startingRow + 1, 4, ("=SUBTOTAL(9, " + String.Join(",", demandRowMarks.ToArray()) + ")").Replace(",", ",D").Replace(" ", ""));
            excel.copy(numUtil.getLetterByNumber(4) + (startingRow + 1), "E" + (startingRow + 1) + ":" + "AG" + (startingRow+1));
            excel.setBackgroundColor("D" + (startingRow+1) + ":AG" + (startingRow+1), Color.Gainsboro);
            
            excel.WriteCell(startingRow + 2, 3, "RESERVE / DEFICIT");
            excel.WriteCell(startingRow + 2, 4, "=D" + startingRow + "-" + "D" + (startingRow+1));
            excel.copy(numUtil.getLetterByNumber(4) + (startingRow+2), "E" + (startingRow + 2) + ":" + "AG" + (startingRow + 2));
            excel.setBackgroundColor("D" + (startingRow + 2) + ":AG" + (startingRow + 2), Color.LightCoral);
        }

        private List<String> merge(List<String> list1, List<String> list2) {
            List<String> data = new List<String>();
            for (int i = 0; i < list1.Count; i++)
            {
                try
                {
                    data.Add(list1[i]);
                    data.Add(list2[i]);
                }
                catch (IndexOutOfRangeException iore) {
                    data.Add("0");
                }catch(ArgumentOutOfRangeException aore){
                    data.Add("0");
                }
               
            }

            return data;
        }
    }
}


