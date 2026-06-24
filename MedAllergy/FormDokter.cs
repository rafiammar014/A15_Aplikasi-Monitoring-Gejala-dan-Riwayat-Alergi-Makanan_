using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using ExcelDataReader;

namespace MedAllergy
{
    public partial class FormDokter : Form
    {
        private DataTable dtDataExcelSementara;
        private readonly SqlConnection conn;
        private readonly string connectionString = @"Data Source=LAPTOP-RAFIAMMA;Initial Catalog=db_alergi_makanan;User ID=sa;Password=Rafi12345;TrustServerCertificate=True;";

        public FormDokter()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        private void FormDokter_Load(object sender, EventArgs e)
        {
            // Seting UI DataGridView Riwayat
            dgvRiwayatPasien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRiwayatPasien.MultiSelect = false;
            dgvRiwayatPasien.ReadOnly = true;
            dgvRiwayatPasien.AllowUserToAddRows = false;
            dgvRiwayatPasien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRiwayatPasien.RowHeadersVisible = false;

            // Seting UI DataGridView Diagnosis (Tabel Baru)
            dgvDiagnosis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiagnosis.MultiSelect = false;
            dgvDiagnosis.ReadOnly = true;
            dgvDiagnosis.AllowUserToAddRows = false;
            dgvDiagnosis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiagnosis.RowHeadersVisible = false;
            dgvDiagnosis.CellClick += dgvDiagnosis_CellClick;

            LoadComboRisiko();
            LoadComboPasien(); // Ini akan otomatis memicu kemunculan data di kedua tabel
        }

        private void LoadComboPasien()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT id_user, nama FROM users WHERE role = 'pasien'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Matikan event sementara agar tidak error saat pengisian data
                cmbPasien.SelectedIndexChanged -= cmbPasien_SelectedIndexChanged;

                cmbPasien.DataSource = dt;
                cmbPasien.DisplayMember = "nama";
                cmbPasien.ValueMember = "id_user";

                // Nyalakan event kembali
                cmbPasien.SelectedIndexChanged += cmbPasien_SelectedIndexChanged;

                // PERBAIKAN: Paksa pilih pasien urutan pertama (0) agar tabel langsung terlihat isinya
                if (dt.Rows.Count > 0)
                {
                    cmbPasien.SelectedIndex = 0;
                }
                else
                {
                    cmbPasien.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat pasien: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void LoadComboRisiko()
        {
            cmbRisiko.Items.Clear();
            cmbRisiko.Items.Add("Rendah");
            cmbRisiko.Items.Add("Menengah");
            cmbRisiko.Items.Add("Tinggi");
            cmbRisiko.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmbPasien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPasien.SelectedValue == null || cmbPasien.SelectedIndex == -1) return;

            if (int.TryParse(cmbPasien.SelectedValue.ToString(), out int idPasien))
            {
                TampilRiwayatPasien(idPasien);
                TampilDiagnosis(idPasien); // Otomatis load tabel diagnosis juga
            }
        }

        // =========================================================================
        // FUNGSI TAMPIL TABEL
        // =========================================================================

        private void TampilRiwayatPasien(int idPasien)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = @"SELECT waktu_konsumsi, nama_makanan, komposisi, deskripsi_gejala, tingkat_keparahan 
                                 FROM vw_RiwayatPasienLengkap 
                                 WHERE id_user = @IdUser 
                                 ORDER BY waktu_konsumsi DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUser", idPasien);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRiwayatPasien.DataSource = dt;

                if (dgvRiwayatPasien.Columns.Count > 0)
                {
                    dgvRiwayatPasien.Columns["waktu_konsumsi"].HeaderText = "Waktu Kejadian";
                    dgvRiwayatPasien.Columns["nama_makanan"].HeaderText = "Makanan";
                    dgvRiwayatPasien.Columns["komposisi"].HeaderText = "Komposisi";
                    dgvRiwayatPasien.Columns["deskripsi_gejala"].HeaderText = "Gejala";
                    dgvRiwayatPasien.Columns["tingkat_keparahan"].HeaderText = "Keparahan";
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal memuat riwayat: " + ex.Message); }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        // FUNGSI BARU: Untuk mengisi tabel dgvDiagnosis
        private void TampilDiagnosis(int idPasien)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = @"SELECT id_diagnosis, tanggal_diagnosis, catatan_medis, tingkat_risiko 
                                 FROM diagnosis_dokter 
                                 WHERE id_user = @IdUser 
                                 ORDER BY tanggal_diagnosis DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUser", idPasien);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDiagnosis.DataSource = dt;

                // Sembunyikan ID dari layar agar rapi
                if (dgvDiagnosis.Columns.Contains("id_diagnosis"))
                    dgvDiagnosis.Columns["id_diagnosis"].Visible = false;

                if (dgvDiagnosis.Columns.Count > 0)
                {
                    dgvDiagnosis.Columns["tanggal_diagnosis"].HeaderText = "Tanggal";
                    dgvDiagnosis.Columns["catatan_medis"].HeaderText = "Catatan Diagnosis";
                    dgvDiagnosis.Columns["tingkat_risiko"].HeaderText = "Risiko";
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal memuat diagnosis: " + ex.Message); }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        // =========================================================================
        // EVENT CLICK TABEL (Agar bisa Edit & Hapus)
        // =========================================================================

        private void dgvDiagnosis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Jika baris tabel diagnosis diklik, otomatis isi Textbox untuk persiapan Update/Hapus
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDiagnosis.Rows[e.RowIndex];
                txtIdDiagnosis.Text = row.Cells["id_diagnosis"].Value.ToString();
                txtHasilDiagnosis.Text = row.Cells["catatan_medis"].Value.ToString();
                cmbRisiko.SelectedItem = row.Cells["tingkat_risiko"].Value.ToString();
            }
        }

        // =========================================================================
        // LOGIKA CRUD (Simpan, Update, Hapus)
        // =========================================================================

        private void btnSimpanDiagnosis_Click(object sender, EventArgs e)
        {
            if (cmbPasien.SelectedValue == null) { MessageBox.Show("Pilih pasien!"); return; }
            if (string.IsNullOrWhiteSpace(txtHasilDiagnosis.Text)) { MessageBox.Show("Catatan tidak boleh kosong!"); return; }
            if (cmbRisiko.SelectedItem == null) { MessageBox.Show("Pilih tingkat risiko!"); return; }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("sp_InsertDiagnosis", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUser", cmbPasien.SelectedValue);
                cmd.Parameters.AddWithValue("@Catatan", txtHasilDiagnosis.Text.Trim());
                cmd.Parameters.AddWithValue("@Risiko", cmbRisiko.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data diagnosis berhasil disimpan!");

                txtHasilDiagnosis.Clear();
                cmbRisiko.SelectedIndex = -1;

                // Refresh tabel diagnosis setelah sukses simpan
                TampilDiagnosis(Convert.ToInt32(cmbPasien.SelectedValue));
            }
            catch (Exception ex) { MessageBox.Show("Gagal menyimpan diagnosis: " + ex.Message); }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdDiagnosis.Text)) { MessageBox.Show("Pilih data diagnosis dari tabel terlebih dahulu!"); return; }
            if (string.IsNullOrWhiteSpace(txtHasilDiagnosis.Text) || cmbRisiko.SelectedItem == null) { MessageBox.Show("Data tidak boleh kosong!"); return; }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("sp_UpdateDiagnosis", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDiagnosis", txtIdDiagnosis.Text);
                cmd.Parameters.AddWithValue("@Catatan", txtHasilDiagnosis.Text.Trim());
                cmd.Parameters.AddWithValue("@Risiko", cmbRisiko.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data diagnosis berhasil diperbarui!");

                txtIdDiagnosis.Clear();
                txtHasilDiagnosis.Clear();
                cmbRisiko.SelectedIndex = -1;

                // Refresh tabel
                TampilDiagnosis(Convert.ToInt32(cmbPasien.SelectedValue));
            }
            catch (Exception ex) { MessageBox.Show("Gagal Update: " + ex.Message); }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdDiagnosis.Text)) { MessageBox.Show("Pilih data diagnosis dari tabel terlebih dahulu!"); return; }

            if (MessageBox.Show("Yakin ingin menghapus rekam medis diagnosis ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    SqlCommand cmd = new SqlCommand("sp_DeleteDiagnosis", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdDiagnosis", txtIdDiagnosis.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data diagnosis berhasil dihapus!");

                    txtIdDiagnosis.Clear();
                    txtHasilDiagnosis.Clear();
                    cmbRisiko.SelectedIndex = -1;

                    // Refresh tabel
                    TampilDiagnosis(Convert.ToInt32(cmbPasien.SelectedValue));
                }
                catch (Exception ex) { MessageBox.Show("Gagal Hapus: " + ex.Message); }
                finally { if (conn.State == ConnectionState.Open) conn.Close(); }
            }
        }

        // =========================================================================
        // FITUR IMPORT EXCEL
        // =========================================================================

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
            openFileDialog.Title = "Pilih File Excel Riwayat Pasien";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                { UseHeaderRow = true }
                            });

                            dtDataExcelSementara = result.Tables[0];

                            dgvRiwayatPasien.DataSource = dtDataExcelSementara;
                            MessageBox.Show("File Excel berhasil dibaca!\n\nSilakan cek datanya di tabel layar, lalu klik tombol 'Import ke Database' untuk menyimpannya permanen.", "Preview Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Gagal membaca Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnImportdatabase_Click(object sender, EventArgs e)
        {
            if (dtDataExcelSementara == null || dtDataExcelSementara.Rows.Count == 0)
            {
                MessageBox.Show("Belum ada data Excel yang dibaca! Silakan klik 'Import Excel' terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (DataRow row in dtDataExcelSementara.Rows)
                        {
                            if (string.IsNullOrWhiteSpace(row["id_user"].ToString())) continue;

                            SqlCommand cmdMak = new SqlCommand("sp_InsertMakanan", conn, trans);
                            cmdMak.CommandType = CommandType.StoredProcedure;
                            cmdMak.Parameters.AddWithValue("@IdUser", Convert.ToInt32(row["id_user"]));
                            cmdMak.Parameters.AddWithValue("@NamaMakanan", row["nama_makanan"].ToString());
                            cmdMak.Parameters.AddWithValue("@Komposisi", row["komposisi"].ToString());

                            DateTime waktuKonsumsi = DateTime.Now;
                            if (row["waktu_konsumsi"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["waktu_konsumsi"].ToString()))
                            {
                                DateTime.TryParse(row["waktu_konsumsi"].ToString(), out waktuKonsumsi);
                            }
                            cmdMak.Parameters.AddWithValue("@Waktu", waktuKonsumsi);
                            cmdMak.ExecuteNonQuery();

                            string gejala = row["deskripsi_gejala"].ToString();
                            if (!string.IsNullOrWhiteSpace(gejala))
                            {
                                SqlCommand cmdGetId = new SqlCommand("SELECT MAX(id_makanan) FROM catatan_makanan WHERE id_user = @IdUser", conn, trans);
                                cmdGetId.Parameters.AddWithValue("@IdUser", Convert.ToInt32(row["id_user"]));
                                int newIdMakanan = Convert.ToInt32(cmdGetId.ExecuteScalar());

                                SqlCommand cmdGej = new SqlCommand("sp_KelolaGejala", conn, trans);
                                cmdGej.CommandType = CommandType.StoredProcedure;
                                cmdGej.Parameters.AddWithValue("@Aksi", "INSERT");
                                cmdGej.Parameters.AddWithValue("@IdMakanan", newIdMakanan);
                                cmdGej.Parameters.AddWithValue("@Deskripsi", gejala);

                                string keparahan = string.IsNullOrWhiteSpace(row["tingkat_keparahan"].ToString()) ? "Ringan" : row["tingkat_keparahan"].ToString();
                                cmdGej.Parameters.AddWithValue("@Keparahan", keparahan);

                                cmdGej.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        MessageBox.Show("Data riwayat alergi pasien berhasil diimport dan disimpan ke Database SQL Server!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dtDataExcelSementara = null;

                        if (cmbPasien.SelectedValue != null && int.TryParse(cmbPasien.SelectedValue.ToString(), out int idPasien))
                        {
                            TampilRiwayatPasien(idPasien);
                        }
                    }
                    catch (Exception exTrans)
                    {
                        trans.Rollback();
                        throw new Exception("Transaksi dibatalkan. Pastikan tidak ada data duplikat atau format salah: " + exTrans.Message);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal menyimpan ke database:\n\n" + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        // Add this method to MedAllergy\FormDokter.cs (inside the FormDokter class)
        private void dgvRiwayatPasien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Keep behavior minimal and safe: select the clicked row if valid.
            if (e.RowIndex >= 0 && e.RowIndex < dgvRiwayatPasien.Rows.Count)
            {
                dgvRiwayatPasien.ClearSelection();
                dgvRiwayatPasien.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}