using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedAllergy
{
    public partial class FormDokter : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString = @"Data Source=LAPTOP-RAFIAMMA;Initial Catalog=db_alergi_makanan;User ID=sa;Password=Rafi12345;TrustServerCertificate=True;";

        public FormDokter()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        private void FormDokter_Load(object sender, EventArgs e)
        {
            // Seting UI DataGridView
            dgvRiwayatPasien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRiwayatPasien.MultiSelect = false;
            dgvRiwayatPasien.ReadOnly = true;
            dgvRiwayatPasien.AllowUserToAddRows = false;
            dgvRiwayatPasien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRiwayatPasien.RowHeadersVisible = false;

            LoadComboPasien();
            LoadComboRisiko();
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

                cmbPasien.DataSource = dt;
                cmbPasien.DisplayMember = "nama";
                cmbPasien.ValueMember = "id_user";
                cmbPasien.SelectedIndex = -1;
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
            }
        }

        private void TampilRiwayatPasien(int idPasien)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Mengambil data dari View vw_RiwayatPasienLengkap
                string query = @"SELECT waktu_konsumsi, nama_makanan, komposisi, deskripsi_gejala, tingkat_keparahan 
                                 FROM vw_RiwayatPasienLengkap 
                                 WHERE id_user = @IdUser 
                                 ORDER BY waktu_konsumsi DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUser", idPasien);

                // Menggunakan DataAdapter untuk mengisi DataGridView langsung
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Hubungkan DataTable ke DataGridView
                dgvRiwayatPasien.DataSource = dt;

                // Ubah nama kolom agar lebih mudah dibaca
                if (dgvRiwayatPasien.Columns.Count > 0)
                {
                    dgvRiwayatPasien.Columns["waktu_konsumsi"].HeaderText = "Waktu Kejadian";
                    dgvRiwayatPasien.Columns["nama_makanan"].HeaderText = "Makanan";
                    dgvRiwayatPasien.Columns["komposisi"].HeaderText = "Komposisi";
                    dgvRiwayatPasien.Columns["deskripsi_gejala"].HeaderText = "Gejala";
                    dgvRiwayatPasien.Columns["tingkat_keparahan"].HeaderText = "Keparahan";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void btnSimpanDiagnosis_Click(object sender, EventArgs e)
        {
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

                // Menggunakan Stored Procedure untuk menyimpan diagnosis
                SqlCommand cmd = new SqlCommand("sp_InsertDiagnosis", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUser", cmbPasien.SelectedValue);
                cmd.Parameters.AddWithValue("@Catatan", txtHasilDiagnosis.Text.Trim());
                cmd.Parameters.AddWithValue("@Risiko", cmbRisiko.SelectedItem.ToString());

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data diagnosis berhasil disimpan ke dalam rekam medis!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHasilDiagnosis.Clear();
                cmbRisiko.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan diagnosis: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        // Fungsi bawaan yang kosong
        private void dgvRiwayatPasien_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtHasilDiagnosis_TextChanged(object sender, EventArgs e) { }
        private void txtHasilDiagnosis_TextChanged_1(object sender, EventArgs e) { }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 1. Validasi: Pastikan ID Diagnosis sudah terisi (biasanya terisi saat mengklik data di tabel)
            if (string.IsNullOrWhiteSpace(txtIdDiagnosis.Text))
            {
                MessageBox.Show("Pilih data diagnosis yang ingin diubah terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validasi input form
            if (string.IsNullOrWhiteSpace(txtHasilDiagnosis.Text) || cmbRisiko.SelectedItem == null)
            {
                MessageBox.Show("Catatan medis dan risiko tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // 3. Memanggil Stored Procedure Update
                SqlCommand cmd = new SqlCommand("sp_UpdateDiagnosis", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdDiagnosis", txtIdDiagnosis.Text);
                cmd.Parameters.AddWithValue("@Catatan", txtHasilDiagnosis.Text.Trim());
                cmd.Parameters.AddWithValue("@Risiko", cmbRisiko.SelectedItem.ToString());

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data diagnosis berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Bersihkan form setelah sukses
                txtIdDiagnosis.Clear();
                txtHasilDiagnosis.Clear();
                cmbRisiko.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Gagal Update: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            // 1. Validasi: Pastikan ID Diagnosis sudah terisi
            if (string.IsNullOrWhiteSpace(txtIdDiagnosis.Text))
            {
                MessageBox.Show("Pilih data diagnosis yang ingin dihapus terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Konfirmasi keamanan sebelum menghapus
            if (MessageBox.Show("Yakin ingin menghapus rekam medis diagnosis ini? Data yang dihapus tidak dapat dikembalikan.",
                                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // 3. Memanggil Stored Procedure Delete
                    SqlCommand cmd = new SqlCommand("sp_DeleteDiagnosis", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdDiagnosis", txtIdDiagnosis.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data diagnosis berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Bersihkan form
                    txtIdDiagnosis.Clear();
                    txtHasilDiagnosis.Clear();
                    cmbRisiko.SelectedIndex = -1;
                }
                catch (Exception ex) { MessageBox.Show("Gagal Hapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally { if (conn.State == ConnectionState.Open) conn.Close(); }
            }
        }
    }
}