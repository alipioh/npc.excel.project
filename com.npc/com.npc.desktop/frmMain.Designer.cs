namespace com.npc.desktop
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlPSA = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtPSA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDemand = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtDemand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlPSA.SuspendLayout();
            this.pnlDemand.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(252, 273);
            this.propertyGrid.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "PSA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox3);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid);
            this.splitContainer1.Size = new System.Drawing.Size(911, 273);
            this.splitContainer1.SplitterDistance = 655;
            this.splitContainer1.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(0, 73);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(655, 200);
            this.textBox3.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 73);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlPSA);
            this.panel2.Controls.Add(this.pnlDemand);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(655, 44);
            this.panel2.TabIndex = 4;
            // 
            // pnlPSA
            // 
            this.pnlPSA.Controls.Add(this.button6);
            this.pnlPSA.Controls.Add(this.button3);
            this.pnlPSA.Controls.Add(this.txtPSA);
            this.pnlPSA.Controls.Add(this.label2);
            this.pnlPSA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPSA.Location = new System.Drawing.Point(0, -4);
            this.pnlPSA.Name = "pnlPSA";
            this.pnlPSA.Size = new System.Drawing.Size(655, 24);
            this.pnlPSA.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(403, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Save";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(301, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Browse PSA";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtPSA
            // 
            this.txtPSA.Location = new System.Drawing.Point(49, 4);
            this.txtPSA.Name = "txtPSA";
            this.txtPSA.Size = new System.Drawing.Size(249, 20);
            this.txtPSA.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "PATH: ";
            // 
            // pnlDemand
            // 
            this.pnlDemand.Controls.Add(this.button7);
            this.pnlDemand.Controls.Add(this.button5);
            this.pnlDemand.Controls.Add(this.button4);
            this.pnlDemand.Controls.Add(this.txtDemand);
            this.pnlDemand.Controls.Add(this.label1);
            this.pnlDemand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDemand.Location = new System.Drawing.Point(0, 20);
            this.pnlDemand.Name = "pnlDemand";
            this.pnlDemand.Size = new System.Drawing.Size(655, 24);
            this.pnlDemand.TabIndex = 0;
            this.pnlDemand.Visible = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(505, 1);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Save";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(403, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(96, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(301, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Browse Demand";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtDemand
            // 
            this.txtDemand.Location = new System.Drawing.Point(49, 3);
            this.txtDemand.Name = "txtDemand";
            this.txtDemand.Size = new System.Drawing.Size(249, 20);
            this.txtDemand.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PATH: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Demand";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(301, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 5;
            this.button8.Text = "Query";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 273);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlPSA.ResumeLayout(false);
            this.pnlPSA.PerformLayout();
            this.pnlDemand.ResumeLayout(false);
            this.pnlDemand.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlPSA;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtPSA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlDemand;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtDemand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}