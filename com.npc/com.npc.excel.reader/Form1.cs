using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dbase = System.Data.OleDb;

namespace com.npc.excel.reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChoosePSA_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            String fileName = openFileDialog1.FileName;
            
            lblPSAPath.Text = fileName;
            search(fileName);
        }

        private void search(String file) {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= '" + file +"';Extended Properties='Excel 8.0;HDR=Yes;'";
            string query = "select * from [PSC_ECs$A4:X2000] WHERE F1 <> ''";

            dbase.OleDbConnection cn = new dbase.OleDbConnection();
            cn.ConnectionString = strConn;
            cn.Open();

            dbase.OleDbDataAdapter da = new dbase.OleDbDataAdapter(query, cn);
            DataSet ds = new DataSet();

            da.Fill(ds, "tbl");
            dtgData.DataSource = ds.Tables["tbl"];

            cn.Close();
        }
    }
}
