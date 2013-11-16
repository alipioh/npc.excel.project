using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace com.npc.desktop.utils
{
    class ExcelUtil 
    {
        private Excel.Application application;
        private Excel.Workbook workBook;
        private Excel.Worksheet workSheet;
        private Object misValue = System.Reflection.Missing.Value;

        public String SheetName { get; set; }
        public String Path { get; set; }

        public ExcelUtil() {
            application = new Excel.Application();
           
        }

        #region CELL
        public void WriteCell(Int32 row, Int32 column, String value)
        {
            workSheet.Cells[row, column] = value;
        }

        public Object ReadCell(Int32 row, String column){
            return ReadCell(column + row.ToString());
        }

        public String ReadCell(String range) {
            return workSheet.Range[range].Text;
        }

        public Object[,] ReadCellByRange(String range) {
            Object[,] values = application.Range[range].Value;
            return values;
        }
        #endregion

        #region OTHER ATTRIBUTES
        public static Excel.Application getCurrentInstance() {
            return new Excel.Application();
        }

        public void AddWorkbook() {
            workBook = application.Workbooks.Add(misValue);
        }

        public void AddWorksheet(String sheetName) {
            this.workSheet = workBook.Sheets[SheetName];
        }

        public void Open(String path) {
            workBook =  application.Workbooks.Open(path);    
        }

        public void Worksheet(String workSheet)
        {
            this.workSheet = workBook.Worksheets[workSheet];
        }

        public void Save() {
            Save(null);
        }

        public void Save(String fileName) {
            try
            {
                if (fileName != null)
                    Path = fileName;

                workSheet.SaveAs(Path);
                Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
            }
            
        }

        public void Close() {
            workBook.Close();
            application.Quit();

            ReleaseObject(application); 
            ReleaseObject(workBook);
            ReleaseObject(workSheet);
        }

        private void ReleaseObject(Object obj) {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex) {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion
    }
}
