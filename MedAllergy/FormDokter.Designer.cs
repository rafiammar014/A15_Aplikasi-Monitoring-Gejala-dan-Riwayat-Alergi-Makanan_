namespace MedAllergy
{
    partial class FormDokter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDokter));
            this.cmbPasien = new System.Windows.Forms.ComboBox();
            this.dgvRiwayatPasien = new System.Windows.Forms.DataGridView();
            this.txtHasilDiagnosis = new System.Windows.Forms.TextBox();
            this.btnSimpanDiagnosis = new System.Windows.Forms.Button();
            this.cmbRisiko = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayatPasien)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPasien
            // 
            this.cmbPasien.FormattingEnabled = true;
            this.cmbPasien.Location = new System.Drawing.Point(442, 88);
            this.cmbPasien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPasien.Name = "cmbPasien";
            this.cmbPasien.Size = new System.Drawing.Size(143, 33);
            this.cmbPasien.TabIndex = 0;
            this.cmbPasien.SelectedIndexChanged += new System.EventHandler(this.cmbPasien_SelectedIndexChanged);
            // 
            // dgvRiwayatPasien
            // 
            this.dgvRiwayatPasien.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvRiwayatPasien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRiwayatPasien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRiwayatPasien.Location = new System.Drawing.Point(299, 382);
            this.dgvRiwayatPasien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvRiwayatPasien.Name = "dgvRiwayatPasien";
            this.dgvRiwayatPasien.ReadOnly = true;
            this.dgvRiwayatPasien.RowHeadersVisible = false;
            this.dgvRiwayatPasien.RowHeadersWidth = 51;
            this.dgvRiwayatPasien.RowTemplate.Height = 24;
            this.dgvRiwayatPasien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRiwayatPasien.Size = new System.Drawing.Size(540, 301);
            this.dgvRiwayatPasien.TabIndex = 1;
            // 
            // txtHasilDiagnosis
            // 
            this.txtHasilDiagnosis.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtHasilDiagnosis.Location = new System.Drawing.Point(847, 382);
            this.txtHasilDiagnosis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHasilDiagnosis.Multiline = true;
            this.txtHasilDiagnosis.Name = "txtHasilDiagnosis";
            this.txtHasilDiagnosis.Size = new System.Drawing.Size(387, 231);
            this.txtHasilDiagnosis.TabIndex = 2;
            this.txtHasilDiagnosis.TextChanged += new System.EventHandler(this.txtHasilDiagnosis_TextChanged_1);
            // 
            // btnSimpanDiagnosis
            // 
            this.btnSimpanDiagnosis.Location = new System.Drawing.Point(1052, 638);
            this.btnSimpanDiagnosis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSimpanDiagnosis.Name = "btnSimpanDiagnosis";
            this.btnSimpanDiagnosis.Size = new System.Drawing.Size(182, 44);
            this.btnSimpanDiagnosis.TabIndex = 3;
            this.btnSimpanDiagnosis.Text = "Simpan Diagnosis";
            this.btnSimpanDiagnosis.UseVisualStyleBackColor = true;
            this.btnSimpanDiagnosis.Click += new System.EventHandler(this.btnSimpanDiagnosis_Click);
            // 
            // cmbRisiko
            // 
            this.cmbRisiko.FormattingEnabled = true;
            this.cmbRisiko.Location = new System.Drawing.Point(442, 166);
            this.cmbRisiko.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbRisiko.Name = "cmbRisiko";
            this.cmbRisiko.Size = new System.Drawing.Size(143, 33);
            this.cmbRisiko.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 696);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 120);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(119, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alergi Tracker";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(345, 166);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(66, 24);
            this.textBox2.TabIndex = 21;
            this.textBox2.Text = "RIsiko";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(345, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 24);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "Pasien";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(362, 347);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(168, 27);
            this.textBox7.TabIndex = 27;
            this.textBox7.Text = "Riwayat Pasien";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(298, 326);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(912, 347);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(168, 27);
            this.textBox3.TabIndex = 29;
            this.textBox3.Text = "Diagnosis";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(849, 326);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            // 
            // FormDokter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1247, 696);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbRisiko);
            this.Controls.Add(this.btnSimpanDiagnosis);
            this.Controls.Add(this.txtHasilDiagnosis);
            this.Controls.Add(this.dgvRiwayatPasien);
            this.Controls.Add(this.cmbPasien);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormDokter";
            this.Text = "FormDokter";
            this.Load += new System.EventHandler(this.FormDokter_Load);
            this.Click += new System.EventHandler(this.btnSimpanDiagnosis_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayatPasien)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPasien;
        private System.Windows.Forms.DataGridView dgvRiwayatPasien;
        private System.Windows.Forms.TextBox txtHasilDiagnosis;
        private System.Windows.Forms.Button btnSimpanDiagnosis;
        private System.Windows.Forms.ComboBox cmbRisiko;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}