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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtIdDiagnosis = new System.Windows.Forms.TextBox();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnImportdatabase = new System.Windows.Forms.Button();
            this.dgvDiagnosis = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayatPasien)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagnosis)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPasien
            // 
            this.cmbPasien.FormattingEnabled = true;
            this.cmbPasien.Location = new System.Drawing.Point(403, 40);
            this.cmbPasien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPasien.Name = "cmbPasien";
            this.cmbPasien.Size = new System.Drawing.Size(159, 33);
            this.cmbPasien.TabIndex = 0;
            this.cmbPasien.SelectedIndexChanged += new System.EventHandler(this.cmbPasien_SelectedIndexChanged);
            // 
            // dgvRiwayatPasien
            // 
            this.dgvRiwayatPasien.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvRiwayatPasien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRiwayatPasien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRiwayatPasien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRiwayatPasien.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRiwayatPasien.GridColor = System.Drawing.Color.Black;
            this.dgvRiwayatPasien.Location = new System.Drawing.Point(252, 412);
            this.dgvRiwayatPasien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvRiwayatPasien.Name = "dgvRiwayatPasien";
            this.dgvRiwayatPasien.ReadOnly = true;
            this.dgvRiwayatPasien.RowHeadersVisible = false;
            this.dgvRiwayatPasien.RowHeadersWidth = 51;
            this.dgvRiwayatPasien.RowTemplate.Height = 24;
            this.dgvRiwayatPasien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRiwayatPasien.Size = new System.Drawing.Size(982, 271);
            this.dgvRiwayatPasien.TabIndex = 1;
            this.dgvRiwayatPasien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRiwayatPasien_CellContentClick);
            // 
            // txtHasilDiagnosis
            // 
            this.txtHasilDiagnosis.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtHasilDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHasilDiagnosis.ForeColor = System.Drawing.Color.Black;
            this.txtHasilDiagnosis.Location = new System.Drawing.Point(260, 214);
            this.txtHasilDiagnosis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHasilDiagnosis.Multiline = true;
            this.txtHasilDiagnosis.Name = "txtHasilDiagnosis";
            this.txtHasilDiagnosis.Size = new System.Drawing.Size(230, 135);
            this.txtHasilDiagnosis.TabIndex = 2;
            // 
            // btnSimpanDiagnosis
            // 
            this.btnSimpanDiagnosis.BackColor = System.Drawing.Color.DarkGray;
            this.btnSimpanDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpanDiagnosis.ForeColor = System.Drawing.Color.White;
            this.btnSimpanDiagnosis.Location = new System.Drawing.Point(585, 38);
            this.btnSimpanDiagnosis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSimpanDiagnosis.Name = "btnSimpanDiagnosis";
            this.btnSimpanDiagnosis.Size = new System.Drawing.Size(181, 32);
            this.btnSimpanDiagnosis.TabIndex = 3;
            this.btnSimpanDiagnosis.Text = "Simpan Diagnosis";
            this.btnSimpanDiagnosis.UseVisualStyleBackColor = false;
            this.btnSimpanDiagnosis.Click += new System.EventHandler(this.btnSimpanDiagnosis_Click);
            // 
            // cmbRisiko
            // 
            this.cmbRisiko.FormattingEnabled = true;
            this.cmbRisiko.Location = new System.Drawing.Point(403, 102);
            this.cmbRisiko.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbRisiko.Name = "cmbRisiko";
            this.cmbRisiko.Size = new System.Drawing.Size(159, 33);
            this.cmbRisiko.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 696);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(75, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alergi Tracker";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(257, 107);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 24);
            this.textBox2.TabIndex = 21;
            this.textBox2.Text = "Tingkat Risiko";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(260, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 24);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "Nama Pasien";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(319, 384);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(168, 27);
            this.textBox7.TabIndex = 27;
            this.textBox7.Text = "Riwayat Pasien";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(255, 363);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(260, 186);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(183, 27);
            this.textBox3.TabIndex = 29;
            this.textBox3.Text = "Diagnosis";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(505, 166);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.DarkGray;
            this.btnHapus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.ForeColor = System.Drawing.Color.White;
            this.btnHapus.Location = new System.Drawing.Point(585, 81);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(181, 36);
            this.btnHapus.TabIndex = 31;
            this.btnHapus.Text = "Hapus Diagnosis";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(585, 123);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(181, 31);
            this.btnUpdate.TabIndex = 32;
            this.btnUpdate.Text = "Perbarui Diagnosis";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtIdDiagnosis
            // 
            this.txtIdDiagnosis.Location = new System.Drawing.Point(1176, 0);
            this.txtIdDiagnosis.Name = "txtIdDiagnosis";
            this.txtIdDiagnosis.Size = new System.Drawing.Size(70, 31);
            this.txtIdDiagnosis.TabIndex = 33;
            this.txtIdDiagnosis.Visible = false;
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.BackColor = System.Drawing.Color.DarkGray;
            this.btnImportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportExcel.ForeColor = System.Drawing.Color.White;
            this.btnImportExcel.Location = new System.Drawing.Point(1034, 216);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(162, 29);
            this.btnImportExcel.TabIndex = 34;
            this.btnImportExcel.Text = "Import Excel";
            this.btnImportExcel.UseVisualStyleBackColor = false;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnImportdatabase
            // 
            this.btnImportdatabase.BackColor = System.Drawing.Color.DarkGray;
            this.btnImportdatabase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportdatabase.ForeColor = System.Drawing.Color.White;
            this.btnImportdatabase.Location = new System.Drawing.Point(1034, 261);
            this.btnImportdatabase.Name = "btnImportdatabase";
            this.btnImportdatabase.Size = new System.Drawing.Size(162, 32);
            this.btnImportdatabase.TabIndex = 35;
            this.btnImportdatabase.Text = "Import ke Database";
            this.btnImportdatabase.UseVisualStyleBackColor = false;
            this.btnImportdatabase.Click += new System.EventHandler(this.btnImportdatabase_Click);
            // 
            // dgvDiagnosis
            // 
            this.dgvDiagnosis.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiagnosis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiagnosis.Location = new System.Drawing.Point(507, 216);
            this.dgvDiagnosis.Name = "dgvDiagnosis";
            this.dgvDiagnosis.RowHeadersWidth = 51;
            this.dgvDiagnosis.RowTemplate.Height = 24;
            this.dgvDiagnosis.Size = new System.Drawing.Size(502, 133);
            this.dgvDiagnosis.TabIndex = 36;
            this.dgvDiagnosis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiagnosis_CellClick);
            // 
            // FormDokter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1247, 696);
            this.Controls.Add(this.dgvDiagnosis);
            this.Controls.Add(this.btnImportdatabase);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.txtIdDiagnosis);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnHapus);
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
            this.ForeColor = System.Drawing.Color.White;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagnosis)).EndInit();
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
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtIdDiagnosis;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btnImportdatabase;
        private System.Windows.Forms.DataGridView dgvDiagnosis;
    }
}