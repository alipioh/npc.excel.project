namespace com.npc.excel.reader
{
    partial class Form1
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
            this.dtgData = new System.Windows.Forms.DataGridView();
            this.btnChoosePSA = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnChooseDemand = new System.Windows.Forms.Button();
            this.lblPSAPath = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgData)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgData
            // 
            this.dtgData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgData.Location = new System.Drawing.Point(12, 60);
            this.dtgData.Name = "dtgData";
            this.dtgData.Size = new System.Drawing.Size(525, 190);
            this.dtgData.TabIndex = 0;
            // 
            // btnChoosePSA
            // 
            this.btnChoosePSA.Location = new System.Drawing.Point(12, 10);
            this.btnChoosePSA.Name = "btnChoosePSA";
            this.btnChoosePSA.Size = new System.Drawing.Size(107, 23);
            this.btnChoosePSA.TabIndex = 1;
            this.btnChoosePSA.Text = "Choose PSA";
            this.btnChoosePSA.UseVisualStyleBackColor = true;
            this.btnChoosePSA.Click += new System.EventHandler(this.btnChoosePSA_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnChooseDemand
            // 
            this.btnChooseDemand.Location = new System.Drawing.Point(12, 33);
            this.btnChooseDemand.Name = "btnChooseDemand";
            this.btnChooseDemand.Size = new System.Drawing.Size(107, 23);
            this.btnChooseDemand.TabIndex = 2;
            this.btnChooseDemand.Text = "Choose Demand";
            this.btnChooseDemand.UseVisualStyleBackColor = true;
            // 
            // lblPSAPath
            // 
            this.lblPSAPath.Location = new System.Drawing.Point(125, 15);
            this.lblPSAPath.Name = "lblPSAPath";
            this.lblPSAPath.Size = new System.Drawing.Size(412, 18);
            this.lblPSAPath.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 262);
            this.Controls.Add(this.lblPSAPath);
            this.Controls.Add(this.btnChooseDemand);
            this.Controls.Add(this.btnChoosePSA);
            this.Controls.Add(this.dtgData);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dtgData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgData;
        private System.Windows.Forms.Button btnChoosePSA;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnChooseDemand;
        private System.Windows.Forms.Label lblPSAPath;
    }
}

