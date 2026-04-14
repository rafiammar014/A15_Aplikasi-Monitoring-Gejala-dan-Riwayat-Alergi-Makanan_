namespace MedAllergy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdMakanan = new System.Windows.Forms.TextBox();
            this.txtNamaMakanan = new System.Windows.Forms.TextBox();
            this.txtKomposisi = new System.Windows.Forms.TextBox();
            this.dtpWaktu = new System.Windows.Forms.DateTimePicker();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvMakanan = new System.Windows.Forms.DataGridView();
            this.lblTotalData = new System.Windows.Forms.Label();
            this.btnResetID = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmbMakanan = new System.Windows.Forms.ComboBox();
            this.txtGejala = new System.Windows.Forms.TextBox();
            this.cmbKeparahan = new System.Windows.Forms.ComboBox();
            this.dtpWaktuGejala = new System.Windows.Forms.DateTimePicker();
            this.btnSimpanGejala = new System.Windows.Forms.Button();
            this.dgvGejala = new System.Windows.Forms.DataGridView();
            this.btnHapusGejala = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtNamaPasien = new System.Windows.Forms.TextBox();
            this.dgvDiagnosisPasien = new System.Windows.Forms.DataGridView();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMakanan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGejala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagnosisPasien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 722);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(80, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alergi Tracker";
            // 
            // txtIdMakanan
            // 
            this.txtIdMakanan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdMakanan.Location = new System.Drawing.Point(406, 31);
            this.txtIdMakanan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdMakanan.Name = "txtIdMakanan";
            this.txtIdMakanan.ReadOnly = true;
            this.txtIdMakanan.Size = new System.Drawing.Size(124, 30);
            this.txtIdMakanan.TabIndex = 1;
            this.txtIdMakanan.Text = "ID (Otomatis)";
            this.txtIdMakanan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNamaMakanan
            // 
            this.txtNamaMakanan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNamaMakanan.Location = new System.Drawing.Point(406, 84);
            this.txtNamaMakanan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNamaMakanan.Name = "txtNamaMakanan";
            this.txtNamaMakanan.Size = new System.Drawing.Size(151, 30);
            this.txtNamaMakanan.TabIndex = 2;
            this.txtNamaMakanan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNamaMakanan.TextChanged += new System.EventHandler(this.txtNamaMakanan_TextChanged);
            // 
            // txtKomposisi
            // 
            this.txtKomposisi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKomposisi.Location = new System.Drawing.Point(406, 136);
            this.txtKomposisi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtKomposisi.Multiline = true;
            this.txtKomposisi.Name = "txtKomposisi";
            this.txtKomposisi.Size = new System.Drawing.Size(151, 25);
            this.txtKomposisi.TabIndex = 3;
            this.txtKomposisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpWaktu
            // 
            this.dtpWaktu.Location = new System.Drawing.Point(338, 189);
            this.dtpWaktu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpWaktu.Name = "dtpWaktu";
            this.dtpWaktu.Size = new System.Drawing.Size(308, 30);
            this.dtpWaktu.TabIndex = 4;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(338, 239);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(92, 30);
            this.btnSimpan.TabIndex = 5;
            this.btnSimpan.Text = "Save";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(338, 294);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 33);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(481, 294);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(92, 32);
            this.btnHapus.TabIndex = 7;
            this.btnHapus.Text = "Delete";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(481, 239);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 33);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.Form1_Load);
            // 
            // dgvMakanan
            // 
            this.dgvMakanan.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMakanan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMakanan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMakanan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMakanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMakanan.EnableHeadersVisualStyles = false;
            this.dgvMakanan.Location = new System.Drawing.Point(237, 397);
            this.dgvMakanan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvMakanan.Name = "dgvMakanan";
            this.dgvMakanan.RowHeadersVisible = false;
            this.dgvMakanan.RowHeadersWidth = 51;
            this.dgvMakanan.RowTemplate.Height = 24;
            this.dgvMakanan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMakanan.Size = new System.Drawing.Size(576, 313);
            this.dgvMakanan.TabIndex = 9;
            this.dgvMakanan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMakanan_CellContentClick);
            // 
            // lblTotalData
            // 
            this.lblTotalData.AutoSize = true;
            this.lblTotalData.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTotalData.ForeColor = System.Drawing.Color.White;
            this.lblTotalData.Location = new System.Drawing.Point(636, 674);
            this.lblTotalData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalData.Name = "lblTotalData";
            this.lblTotalData.Size = new System.Drawing.Size(92, 23);
            this.lblTotalData.TabIndex = 10;
            this.lblTotalData.Text = "Total Data";
            this.lblTotalData.Click += new System.EventHandler(this.lblTotalData_Click);
            // 
            // btnResetID
            // 
            this.btnResetID.Location = new System.Drawing.Point(588, 239);
            this.btnResetID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnResetID.Name = "btnResetID";
            this.btnResetID.Size = new System.Drawing.Size(166, 33);
            this.btnResetID.TabIndex = 11;
            this.btnResetID.Text = "Reset ID Makanan";
            this.btnResetID.UseVisualStyleBackColor = true;
            this.btnResetID.Click += new System.EventHandler(this.btnResetID_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // cmbMakanan
            // 
            this.cmbMakanan.FormattingEnabled = true;
            this.cmbMakanan.Location = new System.Drawing.Point(1170, 85);
            this.cmbMakanan.Name = "cmbMakanan";
            this.cmbMakanan.Size = new System.Drawing.Size(162, 31);
            this.cmbMakanan.TabIndex = 12;
            this.cmbMakanan.SelectedIndexChanged += new System.EventHandler(this.cmbMakanan_SelectedIndexChanged);
            // 
            // txtGejala
            // 
            this.txtGejala.Location = new System.Drawing.Point(1170, 36);
            this.txtGejala.Name = "txtGejala";
            this.txtGejala.Size = new System.Drawing.Size(162, 30);
            this.txtGejala.TabIndex = 13;
            // 
            // cmbKeparahan
            // 
            this.cmbKeparahan.FormattingEnabled = true;
            this.cmbKeparahan.Items.AddRange(new object[] {
            "Ringan",
            "Sedang ",
            "Berat"});
            this.cmbKeparahan.Location = new System.Drawing.Point(1170, 137);
            this.cmbKeparahan.Name = "cmbKeparahan";
            this.cmbKeparahan.Size = new System.Drawing.Size(162, 31);
            this.cmbKeparahan.TabIndex = 14;
            this.cmbKeparahan.SelectedIndexChanged += new System.EventHandler(this.cmbKeparahan_SelectedIndexChanged);
            // 
            // dtpWaktuGejala
            // 
            this.dtpWaktuGejala.Location = new System.Drawing.Point(1024, 190);
            this.dtpWaktuGejala.Name = "dtpWaktuGejala";
            this.dtpWaktuGejala.Size = new System.Drawing.Size(308, 30);
            this.dtpWaktuGejala.TabIndex = 15;
            this.dtpWaktuGejala.ValueChanged += new System.EventHandler(this.dtpWaktuGejala_ValueChanged);
            // 
            // btnSimpanGejala
            // 
            this.btnSimpanGejala.Location = new System.Drawing.Point(1170, 239);
            this.btnSimpanGejala.Name = "btnSimpanGejala";
            this.btnSimpanGejala.Size = new System.Drawing.Size(162, 33);
            this.btnSimpanGejala.TabIndex = 16;
            this.btnSimpanGejala.Text = "Simpan Gejala";
            this.btnSimpanGejala.UseVisualStyleBackColor = true;
            this.btnSimpanGejala.Click += new System.EventHandler(this.btnSimpanGejala_Click);
            // 
            // dgvGejala
            // 
            this.dgvGejala.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvGejala.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGejala.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGejala.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGejala.Location = new System.Drawing.Point(831, 397);
            this.dgvGejala.Name = "dgvGejala";
            this.dgvGejala.RowHeadersVisible = false;
            this.dgvGejala.RowHeadersWidth = 51;
            this.dgvGejala.RowTemplate.Height = 24;
            this.dgvGejala.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGejala.Size = new System.Drawing.Size(576, 146);
            this.dgvGejala.TabIndex = 17;
            this.dgvGejala.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGejala_CellContentClick);
            // 
            // btnHapusGejala
            // 
            this.btnHapusGejala.Location = new System.Drawing.Point(1170, 278);
            this.btnHapusGejala.Name = "btnHapusGejala";
            this.btnHapusGejala.Size = new System.Drawing.Size(162, 31);
            this.btnHapusGejala.TabIndex = 18;
            this.btnHapusGejala.Text = "Hapus Gejala";
            this.btnHapusGejala.UseVisualStyleBackColor = true;
            this.btnHapusGejala.Click += new System.EventHandler(this.btnHapusGejala_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(261, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 23);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "Nama Makanan";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(261, 141);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(104, 23);
            this.textBox2.TabIndex = 20;
            this.textBox2.Text = "Komposisi";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(987, 43);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(104, 23);
            this.textBox3.TabIndex = 21;
            this.textBox3.Text = "Gejala";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(986, 92);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(104, 23);
            this.textBox5.TabIndex = 23;
            this.textBox5.Text = "Pemicu";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(985, 142);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(159, 23);
            this.textBox4.TabIndex = 24;
            this.textBox4.Text = "Tingkat Keparahan";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(287, 361);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(139, 24);
            this.textBox6.TabIndex = 25;
            this.textBox6.Text = "Riwayat Alergi ";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(884, 361);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(150, 24);
            this.textBox7.TabIndex = 26;
            this.textBox7.Text = "Riwayat Gejala";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(831, 350);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // txtNamaPasien
            // 
            this.txtNamaPasien.Location = new System.Drawing.Point(590, 29);
            this.txtNamaPasien.Name = "txtNamaPasien";
            this.txtNamaPasien.Size = new System.Drawing.Size(107, 30);
            this.txtNamaPasien.TabIndex = 29;
            // 
            // dgvDiagnosisPasien
            // 
            this.dgvDiagnosisPasien.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDiagnosisPasien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDiagnosisPasien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiagnosisPasien.Location = new System.Drawing.Point(831, 590);
            this.dgvDiagnosisPasien.Name = "dgvDiagnosisPasien";
            this.dgvDiagnosisPasien.ReadOnly = true;
            this.dgvDiagnosisPasien.RowHeadersVisible = false;
            this.dgvDiagnosisPasien.RowHeadersWidth = 51;
            this.dgvDiagnosisPasien.RowTemplate.Height = 24;
            this.dgvDiagnosisPasien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiagnosisPasien.Size = new System.Drawing.Size(576, 120);
            this.dgvDiagnosisPasien.TabIndex = 30;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(884, 559);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(94, 24);
            this.textBox8.TabIndex = 31;
            this.textBox8.Text = "Diagnosis";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(237, 350);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 41);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(831, 547);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 41);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1455, 722);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.dgvDiagnosisPasien);
            this.Controls.Add(this.txtNamaPasien);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnHapusGejala);
            this.Controls.Add(this.dgvGejala);
            this.Controls.Add(this.btnSimpanGejala);
            this.Controls.Add(this.dtpWaktuGejala);
            this.Controls.Add(this.cmbKeparahan);
            this.Controls.Add(this.txtGejala);
            this.Controls.Add(this.cmbMakanan);
            this.Controls.Add(this.btnResetID);
            this.Controls.Add(this.lblTotalData);
            this.Controls.Add(this.dgvMakanan);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.dtpWaktu);
            this.Controls.Add(this.txtKomposisi);
            this.Controls.Add(this.txtNamaMakanan);
            this.Controls.Add(this.txtIdMakanan);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedAllergy";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMakanan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGejala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagnosisPasien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdMakanan;
        private System.Windows.Forms.TextBox txtNamaMakanan;
        private System.Windows.Forms.TextBox txtKomposisi;
        private System.Windows.Forms.DateTimePicker dtpWaktu;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvMakanan;
        private System.Windows.Forms.Label lblTotalData;
        private System.Windows.Forms.Button btnResetID;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox cmbMakanan;
        private System.Windows.Forms.TextBox txtGejala;
        private System.Windows.Forms.ComboBox cmbKeparahan;
        private System.Windows.Forms.DateTimePicker dtpWaktuGejala;
        private System.Windows.Forms.Button btnSimpanGejala;
        private System.Windows.Forms.DataGridView dgvGejala;
        private System.Windows.Forms.Button btnHapusGejala;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtNamaPasien;
        private System.Windows.Forms.DataGridView dgvDiagnosisPasien;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

