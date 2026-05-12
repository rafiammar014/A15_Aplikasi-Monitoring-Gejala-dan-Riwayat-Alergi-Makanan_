using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MedAllergy
{
    public partial class Dashboard : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString = @"Data Source=LAPTOP-RAFIAMMA;Initial Catalog=db_alergi_makanan;User ID=sa;Password=Rafi12345;TrustServerCertificate=True;";

        private int idUserLogin;
        private string idGejalaTerpilih = "0";

        // TUGAS 4 & 5: Membuat Objek BindingSource
        private BindingSource bsRiwayat = new BindingSource();

        public Dashboard(int idUser)
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            this.idUserLogin = idUser;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TampilUserLogin();

            // Seting UI DataGridView
            dgvRiwayatAlergi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRiwayatAlergi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRiwayatAlergi.ReadOnly = true;
            dgvRiwayatAlergi.AllowUserToAddRows = false;
            dgvRiwayatAlergi.RowHeadersVisible = false;

            // Hubungkan BindingSource dengan Event
            bsRiwayat.CurrentChanged += bsRiwayat_CurrentChanged;

            // Cukup gunakan dua fungsi ini (Manual & Aman)
            TampilDataRiwayatLengkap("");
            TampilDiagnosisSaya();
            LoadGrafikAlergi();
        }

        private void TampilUserLogin()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT nama FROM users WHERE id_user = @id", conn);
                cmd.Parameters.AddWithValue("@id", idUserLogin);
                object nama = cmd.ExecuteScalar();
                if (nama != null) lblUserLogin.Text = "Selamat Datang " + nama.ToString();
            }
            catch { }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }
        private void TampilDataRiwayatLengkap(string keyword)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = @"SELECT * FROM vw_DashboardAlergi WHERE id_user = @IdUser ";
                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " AND (nama_makanan LIKE @Key OR deskripsi_gejala LIKE @Key) ";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUser", idUserLogin);
                    if (!string.IsNullOrEmpty(keyword)) cmd.Parameters.AddWithValue("@Key", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // TUGAS 4 & 5: Menyambungkan Data ke BindingSource & Navigator
                    bsRiwayat.DataSource = dt;
                    dgvRiwayatAlergi.DataSource = bsRiwayat;

                    // Pastikan Anda sudah menambahkan BindingNavigator di layar desain dengan nama bindingNavigator1
                    if (bindingNavigator1 != null) bindingNavigator1.BindingSource = bsRiwayat;

                    // ========================================================
                    // STYLING DATAGRIDVIEW RIWAYAT ALERGI
                    // ========================================================

                    // 1. Menyembunyikan kolom ID yang tidak perlu dilihat pasien
                    if (dgvRiwayatAlergi.Columns.Contains("id_makanan")) dgvRiwayatAlergi.Columns["id_makanan"].Visible = false;
                    if (dgvRiwayatAlergi.Columns.Contains("id_gejala")) dgvRiwayatAlergi.Columns["id_gejala"].Visible = false;
                    if (dgvRiwayatAlergi.Columns.Contains("id_user")) dgvRiwayatAlergi.Columns["id_user"].Visible = false;

                    // 2. Mengatur lebar kolom agar memenuhi layar
                    dgvRiwayatAlergi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // 3. Mengubah nama header (Asumsi nama kolom dari vw_DashboardAlergi)
                    if (dgvRiwayatAlergi.Columns.Contains("waktu_konsumsi"))
                        dgvRiwayatAlergi.Columns["waktu_konsumsi"].HeaderText = "Waktu Kejadian";
                    if (dgvRiwayatAlergi.Columns.Contains("nama_makanan"))
                        dgvRiwayatAlergi.Columns["nama_makanan"].HeaderText = "Nama Makanan";
                    if (dgvRiwayatAlergi.Columns.Contains("komposisi"))
                        dgvRiwayatAlergi.Columns["komposisi"].HeaderText = "Komposisi";
                    if (dgvRiwayatAlergi.Columns.Contains("deskripsi_gejala"))
                        dgvRiwayatAlergi.Columns["deskripsi_gejala"].HeaderText = "Gejala yang Muncul";

                    if (dgvRiwayatAlergi.Columns.Contains("tingkat_keparahan"))
                    {
                        dgvRiwayatAlergi.Columns["tingkat_keparahan"].HeaderText = "Keparahan";
                        // Rata tengah khusus untuk kolom keparahan
                        dgvRiwayatAlergi.Columns["tingkat_keparahan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // 4. Membersihkan elemen visual yang tidak perlu
                    dgvRiwayatAlergi.AllowUserToAddRows = false;
                    dgvRiwayatAlergi.RowHeadersVisible = false;

                    // 5. Mempercantik baris dan font header
                    dgvRiwayatAlergi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                    dgvRiwayatAlergi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

                    // ========================================================

                    // Update Label Total Data
                    lblTotalData.Text = "Total Data: " + dt.Rows.Count.ToString();

                    // Catatan: Kode dgvDiagnosisPasien yang nyasar di sini sudah saya hapus 
                    // agar tidak merusak tabel diagnosis di bawahnya.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat alergi: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        // ====================================================================
        // EVENT BINDING: Pengganti CellClick yang merespons Navigator
        // ====================================================================
        private void bsRiwayat_CurrentChanged(object sender, EventArgs e)
        {
            if (bsRiwayat.Current != null)
            {
                DataRowView row = (DataRowView)bsRiwayat.Current;

                // MENCEGAH ERROR & MERESET FORM JIKA TOMBOL (+) DITEKAN
                if (row.IsNew || string.IsNullOrEmpty(row["id_makanan"].ToString()))
                {
                    txtIdOtomatis.Text = "";
                    idGejalaTerpilih = "0";
                    txtNamaMakanan.Text = "";
                    txtKomposisi.Text = "";
                    dtpWaktu.Value = DateTime.Now;
                    txtGejala.Text = "";
                    cmbKeparahan.SelectedIndex = -1;
                    return; // Hentikan proses di sini
                }

                // Jika mengklik data lama, isi form seperti biasa
                txtIdOtomatis.Text = row["id_makanan"].ToString();
                txtNamaMakanan.Text = row["nama_makanan"].ToString();
                txtKomposisi.Text = row["komposisi"].ToString();
                if (DateTime.TryParse(row["waktu_konsumsi"].ToString(), out DateTime wkt)) dtpWaktu.Value = wkt;

                idGejalaTerpilih = row["id_gejala"].ToString();
                string deskripsi = row["deskripsi_gejala"].ToString();

                if (deskripsi != "-") // Jika sudah ada gejala
                {
                    txtGejala.Text = deskripsi;
                    cmbKeparahan.Text = row["tingkat_keparahan"].ToString();
                }
                else // Jika belum ada gejala
                {
                    txtGejala.Text = "";
                    cmbKeparahan.SelectedIndex = -1;
                }
            }
        }

        // ====================================================================
        // LOGIKA TOMBOL (Terhubung Otomatis tanpa cmbPemicu)
        // ====================================================================

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                bool adaYangDisimpan = false;

                // KONDISI 1: SIMPAN DATA BARU (Bisa Makanan Saja, Atau Sekaligus Gejala)
                if (string.IsNullOrEmpty(txtIdOtomatis.Text))
                {
                    if (string.IsNullOrWhiteSpace(txtNamaMakanan.Text))
                    {
                        MessageBox.Show("Nama makanan wajib diisi untuk menyimpan data baru!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 1. Simpan Data Makanannya Terlebih Dahulu
                    SqlCommand cmdMak = new SqlCommand("sp_InsertMakanan", conn);
                    cmdMak.CommandType = CommandType.StoredProcedure;
                    cmdMak.Parameters.AddWithValue("@IdUser", idUserLogin);
                    cmdMak.Parameters.AddWithValue("@NamaMakanan", txtNamaMakanan.Text);
                    cmdMak.Parameters.AddWithValue("@Komposisi", txtKomposisi.Text);
                    cmdMak.Parameters.AddWithValue("@Waktu", dtpWaktu.Value);
                    cmdMak.ExecuteNonQuery();

                    // 2. CEK GEJALA: Jika form gejala juga diisi, langsung simpan sekalian!
                    if (!string.IsNullOrWhiteSpace(txtGejala.Text))
                    {
                        // Trik: Ambil ID Makanan yang BARU SAJA dibuat oleh pasien ini
                        SqlCommand cmdGetId = new SqlCommand("SELECT MAX(id_makanan) FROM catatan_makanan WHERE id_user = @IdUser", conn);
                        cmdGetId.Parameters.AddWithValue("@IdUser", idUserLogin);
                        int newIdMakanan = Convert.ToInt32(cmdGetId.ExecuteScalar());

                        // Masukkan gejala menggunakan ID baru tersebut
                        SqlCommand cmdGej = new SqlCommand("sp_KelolaGejala", conn);
                        cmdGej.CommandType = CommandType.StoredProcedure;
                        cmdGej.Parameters.AddWithValue("@Aksi", "INSERT");
                        cmdGej.Parameters.AddWithValue("@IdMakanan", newIdMakanan);
                        cmdGej.Parameters.AddWithValue("@Deskripsi", txtGejala.Text);
                        cmdGej.Parameters.AddWithValue("@Keparahan", string.IsNullOrWhiteSpace(cmbKeparahan.Text) ? "ringan" : cmbKeparahan.Text);
                        cmdGej.ExecuteNonQuery();
                    }

                    adaYangDisimpan = true;
                    MessageBox.Show("Data rekam medis alergi berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // KONDISI 2: TAMBAH GEJALA KE MAKANAN LAMA (Makanan sudah ada, tapi lupa isi gejala sebelumnya)
                else if (!string.IsNullOrEmpty(txtIdOtomatis.Text) && !string.IsNullOrWhiteSpace(txtGejala.Text) && idGejalaTerpilih == "0")
                {
                    SqlCommand cmdGej = new SqlCommand("sp_KelolaGejala", conn);
                    cmdGej.CommandType = CommandType.StoredProcedure;
                    cmdGej.Parameters.AddWithValue("@Aksi", "INSERT");
                    cmdGej.Parameters.AddWithValue("@IdMakanan", txtIdOtomatis.Text);
                    cmdGej.Parameters.AddWithValue("@Deskripsi", txtGejala.Text);
                    cmdGej.Parameters.AddWithValue("@Keparahan", string.IsNullOrWhiteSpace(cmbKeparahan.Text) ? "ringan" : cmbKeparahan.Text);
                    cmdGej.ExecuteNonQuery();
                    adaYangDisimpan = true;

                    MessageBox.Show("Gejala berhasil ditambahkan pada makanan tersebut!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // KONDISI 3: SALAH PENCET TOMBOL SAVE PADA DATA LAMA YANG SUDAH LENGKAP
                else if (!string.IsNullOrEmpty(txtIdOtomatis.Text) && idGejalaTerpilih != "0")
                {
                    MessageBox.Show("Tombol 'Save' digunakan untuk MENAMBAH data baru.\n\n- Jika ingin MENGUBAH data ini, klik 'Update'.\n- Jika ingin MENAMBAH makanan baru, klik 'Clear' (atau tanda +) di tabel terlebih dahulu.",
                                    "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Jika berhasil, perbarui tabel dan grafik
                if (adaYangDisimpan)
                {
                    TampilDataRiwayatLengkap(""); // Refresh tabel
                    LoadGrafikAlergi();           // Refresh grafik
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // 1. UPDATE MAKANAN (Kiri)
                if (!string.IsNullOrEmpty(txtIdOtomatis.Text))
                {
                    SqlCommand cmdMak = new SqlCommand("sp_UpdateMakanan", conn);
                    cmdMak.CommandType = CommandType.StoredProcedure;
                    cmdMak.Parameters.AddWithValue("@IdMakanan", txtIdOtomatis.Text);
                    cmdMak.Parameters.AddWithValue("@NamaMakanan", txtNamaMakanan.Text);
                    cmdMak.Parameters.AddWithValue("@Komposisi", txtKomposisi.Text);
                    cmdMak.Parameters.AddWithValue("@Waktu", dtpWaktu.Value);
                    cmdMak.ExecuteNonQuery();
                }

                // 2. UPDATE GEJALA (Kanan)
                if (idGejalaTerpilih != "0" && !string.IsNullOrWhiteSpace(txtGejala.Text))
                {
                    SqlCommand cmdGej = new SqlCommand("sp_KelolaGejala", conn);
                    cmdGej.CommandType = CommandType.StoredProcedure;
                    cmdGej.Parameters.AddWithValue("@Aksi", "UPDATE");
                    cmdGej.Parameters.AddWithValue("@IdGejala", idGejalaTerpilih);
                    cmdGej.Parameters.AddWithValue("@IdMakanan", txtIdOtomatis.Text); // Ambil dari ID text box
                    cmdGej.Parameters.AddWithValue("@Deskripsi", txtGejala.Text);
                    cmdGej.Parameters.AddWithValue("@Keparahan", cmbKeparahan.Text);
                    cmdGej.ExecuteNonQuery();
                }

                MessageBox.Show("Data berhasil diperbarui!", "Sukses");
                TampilDataRiwayatLengkap("");
            }
            catch (Exception ex) { MessageBox.Show("Gagal Update: " + ex.Message); }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
            LoadGrafikAlergi();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdOtomatis.Text)) { MessageBox.Show("Pilih data dari tabel dulu!"); return; }

            if (MessageBox.Show("Yakin hapus data ini? Transaksi ini akan menghapus Makanan dan Gejala sekaligus.", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    SqlCommand cmd = new SqlCommand("sp_DeleteMakanan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdMakanan", txtIdOtomatis.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil dihapus!");
                    btnClear_Click(null, null);
                    TampilDataRiwayatLengkap("");
                }
                catch (Exception ex) { MessageBox.Show("Gagal Hapus: " + ex.Message); }
                finally { if (conn.State == ConnectionState.Open) conn.Close(); }
                LoadGrafikAlergi();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Melepas seleksi dari binding navigator agar form benar-benar kosong
            bsRiwayat.Position = -1; 
            
            txtIdOtomatis.Text = "";
            idGejalaTerpilih = "0";

            txtNamaMakanan.Text = "";
            txtKomposisi.Text = "";
            dtpWaktu.Value = DateTime.Now;

            txtGejala.Text = "";
            cmbKeparahan.SelectedIndex = -1;
        }

        private void TampilDiagnosisSaya()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Cari diagnosis yang id_user-nya cocok dengan pasien yang login
                string query = @"SELECT tanggal_diagnosis, catatan_medis, tingkat_risiko 
                         FROM diagnosis_dokter 
                         WHERE id_user = @idPasien
                         ORDER BY tanggal_diagnosis DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPasien", idUserLogin);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // 1. MASUKKAN DATA KE DATAGRIDVIEW TERLEBIH DAHULU
                dgvDiagnosisPasien.DataSource = dt;

                // ========================================================
                // 2. STYLING DATAGRIDVIEW (Dijalankan setelah data masuk)
                // ========================================================

                // Mengatur lebar kolom agar memenuhi ruang kosong
                dgvDiagnosisPasien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Mengubah judul header agar lebih ramah dibaca (sesuai query SQL)
                if (dgvDiagnosisPasien.Columns.Count > 0)
                {
                    dgvDiagnosisPasien.Columns["tanggal_diagnosis"].HeaderText = "Tanggal Diagnosis";
                    dgvDiagnosisPasien.Columns["catatan_medis"].HeaderText = "Catatan Medis";
                    dgvDiagnosisPasien.Columns["tingkat_risiko"].HeaderText = "Tingkat Risiko";

                    // Membuat teks "Tingkat Risiko" rata tengah agar lebih rapi
                    dgvDiagnosisPasien.Columns["tingkat_risiko"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Membersihkan elemen yang tidak perlu (baris baru & kolom panah kiri)
                dgvDiagnosisPasien.AllowUserToAddRows = false;
                dgvDiagnosisPasien.RowHeadersVisible = false;

                // Mempercantik desain tabel (Baris selang-seling & Font Header)
                dgvDiagnosisPasien.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dgvDiagnosisPasien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat diagnosis: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }


        private void LoadGrafikAlergi()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Menghitung jumlah riwayat berdasarkan tingkat keparahannya
                string query = @"SELECT tingkat_keparahan, COUNT(id_gejala) as jumlah 
                         FROM vw_DashboardAlergi 
                         WHERE id_user = @IdUser AND tingkat_keparahan != '-'
                         GROUP BY tingkat_keparahan";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUser", idUserLogin);

                SqlDataReader reader = cmd.ExecuteReader();

                // Reset chart sebelum diisi
                chartKeparahan.Series.Clear();
                chartKeparahan.Series.Add("Keparahan");
                // Mengubah bentuk chart menjadi Pie (Lingkaran)
                chartKeparahan.Series["Keparahan"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

                while (reader.Read())
                {
                    string tingkat = reader["tingkat_keparahan"].ToString();
                    int jumlah = Convert.ToInt32(reader["jumlah"]);

                    // Tambahkan data ke dalam grafik
                    chartKeparahan.Series["Keparahan"].Points.AddXY(tingkat, jumlah);
                }
                reader.Close();
            }
            catch { /* Biarkan kosong jika grafik gagal dimuat */ }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void chartKeparahan_Click(object sender, EventArgs e)
        {

        }

        private void lblUserLogin_Click(object sender, EventArgs e)
        {

        }

        private void dtpWaktu_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}