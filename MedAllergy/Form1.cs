using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace MedAllergy
{
    public partial class Form1 : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString = @"Data Source=LAPTOP-RAFIAMMA;Initial Catalog=db_alergi_makanan;User ID=sa;Password=Rafi12345;TrustServerCertificate=True;";

        private int idUserLogin;
        private string idGejalaTerpilih = "0"; // Menyimpan ID Gejala jika baris diklik

        public Form1(int idUser)
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            this.idUserLogin = idUser;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // FITUR 4: Menampilkan Siapa yang Login di label2
            TampilUserLogin();

            // Seting UI DataGridView
            dgvRiwayatAlergi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRiwayatAlergi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRiwayatAlergi.ReadOnly = true;
            dgvRiwayatAlergi.AllowUserToAddRows = false;
            dgvRiwayatAlergi.RowHeadersVisible = false;

            // Load Data Awal
            TampilDataRiwayatLengkap(""); // Parameter kosong = tampil semua
            TampilDiagnosisSaya();
        }

        private void TampilUserLogin()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT nama FROM users WHERE id_user = @id", conn);
                cmd.Parameters.AddWithValue("@id", idUserLogin);
                object nama = cmd.ExecuteScalar();
                if (nama != null) lblUserLogin.Text = "Login sebagai: " + nama.ToString();
            }
            catch { }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        // FITUR 2: MENGGUNAKAN VIEW GABUNGAN (SELECT)
        private void TampilDataRiwayatLengkap(string keyword)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Jika keyword kosong tampil semua, jika ada isinya jalankan logika SEARCH
                string query = @"SELECT * FROM vw_DashboardAlergi WHERE id_user = @IdUser ";
                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " AND (nama_makanan LIKE @Key OR deskripsi_gejala LIKE @Key) ";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUser", idUserLogin);
                if (!string.IsNullOrEmpty(keyword)) cmd.Parameters.AddWithValue("@Key", "%" + keyword + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRiwayatAlergi.DataSource = dt;
                dgvRiwayatAlergi.Columns["id_makanan"].Visible = false;
                dgvRiwayatAlergi.Columns["id_gejala"].Visible = false;
                dgvRiwayatAlergi.Columns["id_user"].Visible = false;

                // Update Total Data
                lblTotalData.Text = "Total Data: " + dt.Rows.Count.ToString();
            }
            catch (Exception ex) { MessageBox.Show("Error Load DGV: " + ex.Message); }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        // ====================================================================
        // FITUR 3: BUTTONS TERHUBUNG KE MAKANAN (KIRI) DAN GEJALA (KANAN)
        // ====================================================================

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                bool adaYangDisimpan = false;

                // 1. CEK KIRI: Jika Nama Makanan Diisi, Simpan Makanan via SP_InsertMakanan
                if (!string.IsNullOrWhiteSpace(txtNamaMakanan.Text))
                {
                    SqlCommand cmdMak = new SqlCommand("sp_InsertMakanan", conn);
                    cmdMak.CommandType = CommandType.StoredProcedure;
                    cmdMak.Parameters.AddWithValue("@IdUser", idUserLogin);
                    cmdMak.Parameters.AddWithValue("@NamaMakanan", txtNamaMakanan.Text);
                    cmdMak.Parameters.AddWithValue("@Komposisi", txtKomposisi.Text);
                    cmdMak.Parameters.AddWithValue("@Waktu", dtpWaktu.Value);
                    cmdMak.ExecuteNonQuery();
                    adaYangDisimpan = true;
                }

                // 2. CEK KANAN: Jika Gejala dan Pemicu Diisi, Simpan Gejala via SP_KelolaGejala
                if (!string.IsNullOrWhiteSpace(txtGejala.Text) && cmbPemicu.SelectedValue != null)
                {
                    SqlCommand cmdGej = new SqlCommand("sp_KelolaGejala", conn);
                    cmdGej.CommandType = CommandType.StoredProcedure;
                    cmdGej.Parameters.AddWithValue("@Aksi", "INSERT");
                    cmdGej.Parameters.AddWithValue("@Deskripsi", txtGejala.Text);
                    cmdGej.Parameters.AddWithValue("@Keparahan", cmbKeparahan.Text);
                    cmdGej.ExecuteNonQuery();
                    adaYangDisimpan = true;
                }

                if (adaYangDisimpan)
                {
                    MessageBox.Show("Data berhasil disimpan!", "Sukses");
                    btnClear_Click(null, null);
                    TampilDataRiwayatLengkap("");
                }
                else
                {
                    MessageBox.Show("Harap isi Nama Makanan (Kiri) atau Gejala beserta Pemicunya (Kanan)!", "Peringatan");
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); }
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
                    cmdGej.Parameters.AddWithValue("@Deskripsi", txtGejala.Text);
                    cmdGej.Parameters.AddWithValue("@Keparahan", cmbKeparahan.Text);
                    cmdGej.ExecuteNonQuery();
                }

                MessageBox.Show("Data berhasil diperbarui!", "Sukses");
                btnClear_Click(null, null);
                TampilDataRiwayatLengkap("");
            }
            catch (Exception ex) { MessageBox.Show("Gagal Update: " + ex.Message); }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdOtomatis.Text)) { MessageBox.Show("Pilih data dari tabel dulu!"); return; }

            if (MessageBox.Show("Yakin hapus data ini? Transaksi ini akan menghapus Makanan dan Gejala sekaligus.", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // Menggunakan SP Transaksi Hapus Induk & Anak buatan Anda!
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
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIdOtomatis.Text = "";
            idGejalaTerpilih = "0";

            txtNamaMakanan.Text = "";
            txtKomposisi.Text = "";
            dtpWaktu.Value = DateTime.Now;

            txtGejala.Text = "";
            cmbKeparahan.SelectedIndex = -1;
        }


        // ====================================================================
        // EVENT DATAGRIDVIEW CLICK (Mengisi Sisi Kiri dan Kanan Sekaligus)
        // ====================================================================
        private void dgvRiwayatAlergi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvRiwayatAlergi.Rows[e.RowIndex];

            // Isi Form Kiri (Makanan)
            txtIdOtomatis.Text = row.Cells["id_makanan"].Value.ToString();
            txtNamaMakanan.Text = row.Cells["nama_makanan"].Value.ToString();
            txtKomposisi.Text = row.Cells["komposisi"].Value.ToString();
            if (DateTime.TryParse(row.Cells["waktu_konsumsi"].Value.ToString(), out DateTime wkt)) dtpWaktu.Value = wkt;

            // Isi Form Kanan (Gejala)
            idGejalaTerpilih = row.Cells["id_gejala"].Value.ToString();
            string deskripsi = row.Cells["deskripsi_gejala"].Value.ToString();

            if (deskripsi != "-") // Jika ada gejala
            {
                txtGejala.Text = deskripsi;
                cmbKeparahan.Text = row.Cells["tingkat_keparahan"].Value.ToString();
            }
            else // Jika makanan belum punya gejala
            {
                txtGejala.Text = "";
                cmbKeparahan.SelectedIndex = -1;
            }
        }

        // Tampil Diagnosis Bawah
        private void TampilDiagnosisSaya()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string q = "SELECT tanggal_diagnosis, catatan_medis, tingkat_risiko FROM diagnosis_dokter WHERE id_user = @id";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", idUserLogin);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(); da.Fill(dt);
                dgvDiagnosisPasien.DataSource = dt;
            }
            catch { }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }
    }
}