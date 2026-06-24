using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MedAllergy
{
    public partial class FilterDataDiagnosiscs : Form
    {
        // Pastikan Connection String ini sesuai dengan server SQL-mu
        private readonly string connectionString = @"Data Source=LAPTOP-RAFIAMMA;Initial Catalog=db_alergi_makanan;User ID=sa;Password=Rafi12345;TrustServerCertificate=True;";

        // Variabel global untuk menyimpan data sementara hasil filter agar bisa dilempar ke form cetak
        private DataTable dtLaporan = new DataTable();



        public FilterDataDiagnosiscs()
        {
            InitializeComponent();

            // Panggil fungsi untuk mengisi pilihan ComboBox saat form baru saja dibuka
            LoadComboRisiko();
        }

        private void LoadComboRisiko()
        {
            cmbRekapdata.Items.Clear();
            cmbRekapdata.Items.Add("Semua");
            cmbRekapdata.Items.Add("Rendah");
            cmbRekapdata.Items.Add("Menengah");
            cmbRekapdata.Items.Add("Tinggi");

            // Set otomatis ke "Semua" dan kunci agar tidak bisa diketik asal
            cmbRekapdata.SelectedIndex = 0;
            cmbRekapdata.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // =========================================================================
        // 1. TOMBOL LOAD: Mengambil Data dari SQL Server ke DataGridView
        // =========================================================================
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (cmbRekapdata.SelectedItem == null)
            {
                MessageBox.Show("Pilih tingkat risiko terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Menggunakan Parameterized Query untuk mengambil data gabungan (JOIN)
                    // Data difilter berdasarkan ComboBox (Risiko) dan DateTimePicker (Tanggal)
                    string query = @"SELECT 
                                        u.nama AS NamaPasien, 
                                        d.tanggal_diagnosis AS Tanggal, 
                                        d.catatan_medis AS Catatan, 
                                        d.tingkat_risiko AS Risiko
                                     FROM diagnosis_dokter d
                                     JOIN users u ON d.id_user = u.id_user
                                     WHERE (@Risiko = 'Semua' OR d.tingkat_risiko = @Risiko)
                                       AND CAST(d.tanggal_diagnosis AS DATE) = @Tanggal
                                     ORDER BY d.tanggal_diagnosis DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Risiko", cmbRekapdata.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Tanggal", dtpRekapdata.Value.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    // Bersihkan memori data sebelumnya, lalu isi dengan data baru
                    dtLaporan.Clear();
                    da.Fill(dtLaporan);

                    // Tampilkan data ke layar
                    dataGridView1.DataSource = dtLaporan;

                    // Percantik DataGridView agar rapi
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.RowHeadersVisible = false;

                    // Peringatan jika data di tanggal/risiko tersebut kosong
                    if (dtLaporan.Rows.Count == 0)
                    {
                        MessageBox.Show("Tidak ada data ditemukan untuk filter ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // 2. TOMBOL CETAK: Mengirim Data ke Crystal Report
        // =========================================================================
        // =========================================================================
        // 2. TOMBOL CETAK: Mengirim Data ke Crystal Report (Versi Anti-Bocor Memori)
        // =========================================================================
        // =========================================================================
        // 2. TOMBOL CETAK: Mengirim Data ke Crystal Report (Versi Pembersihan Total)
        // =========================================================================
        private void btnCetak_Click(object sender, EventArgs e)
        {
            if (dtLaporan == null || dtLaporan.Rows.Count == 0)
            {
                MessageBox.Show("Silakan klik 'Load' terlebih dahulu untuk mencari data yang akan dicetak!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (FormReport frmCetak = new FormReport())
                {
                    using (CrystalDecisions.CrystalReports.Engine.ReportDocument rptDocLocal = new CrystalDecisions.CrystalReports.Engine.ReportDocument())
                    {
                        string reportPath = Application.StartupPath + "\\ReportDiagnosis.rpt";

                        // Memuat dan mengisi data
                        rptDocLocal.Load(reportPath);
                        rptDocLocal.SetDataSource(dtLaporan);

                        // Tampilkan ke layar
                        frmCetak.crvDiagnosis.ReportSource = rptDocLocal;
                        frmCetak.crvDiagnosis.Refresh();

                        // Kunci layar agar sistem menunggu
                        frmCetak.ShowDialog();

                        // PEMBERSIHAN LAPIS 1: Lepaskan ikatan file dari layar
                        frmCetak.crvDiagnosis.ReportSource = null;
                        rptDocLocal.Close();
                        rptDocLocal.Dispose();
                    }
                }

                // ---> PEMBERSIHAN LAPIS 2: JURUS PAMUNGKAS <---
                // Memaksa sistem Windows untuk langsung membersihkan sisa sampah 
                // Crystal Reports dari memori/RAM detik ini juga!
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencetak laporan:\n" + ex.Message, "Error System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Biarkan kosong (Fungsi bawaan Visual Studio yang tidak terpakai)
        private void cmbRekapdata_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpRekapdata_ValueChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}