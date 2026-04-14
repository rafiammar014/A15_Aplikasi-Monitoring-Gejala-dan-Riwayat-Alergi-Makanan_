using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedAllergy
{
    public partial class FormDokter : Form
    {
        // 1. Inisialisasi Koneksi
        private readonly SqlConnection conn;

        private readonly string connectionString =
            @"Data Source=LAPTOP-RAFIAMMA;Initial Catalog=db_alergi_makanan;User ID=sa;Password=Rafi12345;TrustServerCertificate=True;";

        public FormDokter()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        // 2. Saat Form Dokter Dibuka
        private void FormDokter_Load(object sender, EventArgs e)
        {
            // Pengaturan Desain Tabel Riwayat (Hanya Baca)
            dgvRiwayatPasien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRiwayatPasien.MultiSelect = false;
            dgvRiwayatPasien.ReadOnly = true; // Dokter tidak bisa mengubah data pasien
            dgvRiwayatPasien.AllowUserToAddRows = false;
            dgvRiwayatPasien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRiwayatPasien.RowHeadersVisible = false;

            // Membuat Kolom Tabel
            dgvRiwayatPasien.Columns.Add("waktu", "Waktu Kejadian");
            dgvRiwayatPasien.Columns.Add("makanan", "Pemicu (Makanan)");
            dgvRiwayatPasien.Columns.Add("gejala", "Gejala yang Muncul");
            dgvRiwayatPasien.Columns.Add("keparahan", "Keparahan");

            // Memuat Pilihan Pasien dan Risiko
            LoadComboPasien();
            LoadComboRisiko();
        }

        // 3. Fungsi Memuat Daftar Pasien
        private void LoadComboPasien()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT id_user, nama FROM users WHERE role = 'pasien'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbPasien.DataSource = dt;
                cmbPasien.DisplayMember = "nama";
                cmbPasien.ValueMember = "id_user";
                cmbPasien.SelectedIndex = -1; // Kosongkan saat awal dibuka
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat pasien: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        // 4. Fungsi Mengisi Pilihan Risiko Diagnosis
        private void LoadComboRisiko()
        {
            cmbRisiko.Items.Clear();
            cmbRisiko.Items.Add("Rendah");
            cmbRisiko.Items.Add("Menengah");
            cmbRisiko.Items.Add("Tinggi");
            cmbRisiko.DropDownStyle = ComboBoxStyle.DropDownList; // Kunci agar tidak bisa diketik sembarangan
        }

        // 5. EVENT: Saat Nama Pasien Dipilih, Tampilkan Riwayatnya!
        private void cmbPasien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Abaikan jika belum ada yang dipilih
            if (cmbPasien.SelectedValue == null || cmbPasien.SelectedIndex == -1) return;

            // Pastikan nilai yang diambil adalah Angka ID
            if (int.TryParse(cmbPasien.SelectedValue.ToString(), out int idPasien))
            {
                TampilRiwayatPasien(idPasien);
            }
        }

        // 6. Fungsi Utama Menarik Data Riwayat Gabungan (JOIN)
        private void TampilRiwayatPasien(int idPasien)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                dgvRiwayatPasien.Rows.Clear();

                // Menggabungkan tabel Gejala dan Makanan untuk pasien yang dipilih
                string query = @"SELECT g.waktu_muncul, c.nama_makanan, g.deskripsi_gejala, g.tingkat_keparahan
                                 FROM gejala_alergi g
                                 JOIN catatan_makanan c ON g.id_makanan = c.id_makanan
                                 WHERE c.id_user = @IdUser
                                 ORDER BY g.waktu_muncul DESC"; // Urutkan dari yang terbaru

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUser", idPasien);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvRiwayatPasien.Rows.Add(
                        Convert.ToDateTime(reader["waktu_muncul"]).ToString("dd/MM/yyyy HH:mm"),
                        reader["nama_makanan"].ToString(),
                        reader["deskripsi_gejala"].ToString(),
                        reader["tingkat_keparahan"].ToString()
                    );
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        // 7. Simpan Diagnosis Dokter
        private void btnSimpanDiagnosis_Click(object sender, EventArgs e)
        {
            // Validasi kelengkapan data
            if (cmbPasien.SelectedValue == null)
            {
                MessageBox.Show("Pilih pasien terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtHasilDiagnosis.Text))
            {
                MessageBox.Show("Catatan medis diagnosis tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbRisiko.SelectedItem == null)
            {
                MessageBox.Show("Pilih tingkat risiko alergi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = @"INSERT INTO diagnosis_dokter (id_user, catatan_medis, tingkat_risiko)
                                 VALUES (@IdUser, @Catatan, @Risiko)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUser", cmbPasien.SelectedValue);
                cmd.Parameters.AddWithValue("@Catatan", txtHasilDiagnosis.Text);
                cmd.Parameters.AddWithValue("@Risiko", cmbRisiko.SelectedItem.ToString());

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Data diagnosis berhasil disimpan ke dalam rekam medis!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHasilDiagnosis.Clear();
                    cmbRisiko.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan diagnosis: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        // Event Kosong (Biarkan jika terlanjur dibuat oleh desainer)
        private void dgvRiwayatPasien_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtHasilDiagnosis_TextChanged(object sender, EventArgs e) { }

        private void txtHasilDiagnosis_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}