using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace com.npc.desktop.utils
{
    class ExcelUtil 
    {
        private Excel.Application application;
        private Excel.Workbook workBook;
        private Excel.Worksheet workSheet;
        private Object misValue = System.Reflection.Missing.Value;

        //public static String DEFAULT_SHEET_1 = "Sheet1";
        //public static String DEFAULT_SHEET_2 = "Sheet2";
        //public static String DEFAULT_SHEET_3 = "Sheet3";

        public String SheetName { get; set; }
        public String Path { get; set; }

        public ExcelUtil(String workSheet) {
            application = new Excel.Application();
            workBook = application.Workbooks.Add(misValue);

            SheetName = workSheet;

            this.workSheet = workBook.Sheets[SheetName];

        }


        public void WriteCell(Int32 row, Int32 column, String value)
        {
            workSheet.Cells[row, column] = value;
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
    }
}
