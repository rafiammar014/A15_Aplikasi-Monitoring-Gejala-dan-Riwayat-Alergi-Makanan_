namespace MedAllergy
{
    partial class FilterDataDiagnosiscs
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbRekapdata = new System.Windows.Forms.ComboBox();
            this.dtpRekapdata = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(773, 437);
            this.dataGridView1.TabIndex = 0;
            // 
            // cmbRekapdata
            // 
            this.cmbRekapdata.FormattingEnabled = true;
            this.cmbRekapdata.Location = new System.Drawing.Point(12, 90);
            this.cmbRekapdata.Name = "cmbRekapdata";
            this.cmbRekapdata.Size = new System.Drawing.Size(194, 24);
            this.cmbRekapdata.TabIndex = 1;
            // 
            // dtpRekapdata
            // 
            this.dtpRekapdata.CalendarFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRekapdata.Location = new System.Drawing.Point(232, 92);
            this.dtpRekapdata.Name = "dtpRekapdata";
            this.dtpRekapdata.Size = new System.Drawing.Size(249, 22);
            this.dtpRekapdata.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DarkGray;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(662, 88);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(123, 35);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnCetak
            // 
            this.btnCetak.BackColor = System.Drawing.Color.DarkGray;
            this.btnCetak.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCetak.ForeColor = System.Drawing.Color.White;
            this.btnCetak.Location = new System.Drawing.Point(662, 584);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(123, 37);
            this.btnCetak.TabIndex = 4;
            this.btnCetak.Text = "Cetak";
            this.btnCetak.UseVisualStyleBackColor = false;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "REKAP DATA DIAGNOSIS";
            // 
            // FilterDataDiagnosiscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(797, 633);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCetak);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dtpRekapdata);
            this.Controls.Add(this.cmbRekapdata);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FilterDataDiagnosiscs";
            this.Text = "Rekap Data";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbRekapdata;
        private System.Windows.Forms.DateTimePicker dtpRekapdata;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Label label1;
    }
}