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

        private void button1_Click(object sender, EventArgs e)
        {
            using (var data = new Dbase()) {
                Area area1 = new Area();
                area1.name = "LUZON";
                data.areas.Add(area1);
            }
        }
    }
}
