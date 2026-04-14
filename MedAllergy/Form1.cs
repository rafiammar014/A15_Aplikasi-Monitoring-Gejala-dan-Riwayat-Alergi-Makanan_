using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedAllergy
{
    public partial class Form1 : Form
    {
       
        private readonly SqlConnection conn;

        private readonly string connectionString =
            @"Data Source=LAPTOP-RAFIAMMA;Initial Catalog=db_alergi_makanan;User ID=sa;Password=Rafi12345;TrustServerCertificate=True;";

        private int idUserLogin;
        public Form1(int idUser)
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            this.idUserLogin = idUser; 
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            dgvMakanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMakanan.MultiSelect = false;
            dgvMakanan.ReadOnly = true;
            dgvMakanan.AllowUserToAddRows = false;
            dgvMakanan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMakanan.RowHeadersVisible = false; 
            dgvMakanan.CellClick += dgvMakanan_CellClick;

            
            if (dgvGejala != null)
            {
                dgvGejala.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvGejala.MultiSelect = false;
                dgvGejala.ReadOnly = true;
                dgvGejala.AllowUserToAddRows = false;
                dgvGejala.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvGejala.RowHeadersVisible = false;
            }

            //
           
            TampilData();         
            LoadComboMakanan();  
            TampilDataGejala();   
            TampilDiagnosisSaya();
        }

        
        private void TampilData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                dgvMakanan.Rows.Clear();
                dgvMakanan.Columns.Clear();

                dgvMakanan.Columns.Add("id_makanan", "ID");
                dgvMakanan.Columns.Add("nama_pasien", "Nama Pasien"); 
                dgvMakanan.Columns.Add("nama_makanan", "Nama Makanan");
                dgvMakanan.Columns.Add("komposisi", "Komposisi");
                dgvMakanan.Columns.Add("waktu_konsumsi", "Waktu Konsumsi");

                dgvMakanan.Columns["id_makanan"].Visible = false;

                
                string query = @"SELECT c.id_makanan, u.nama AS nama_pasien, c.nama_makanan, c.komposisi, c.waktu_konsumsi 
                         FROM catatan_makanan c
                         JOIN users u ON c.id_user = u.id_user";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvMakanan.Rows.Add(
                        reader["id_makanan"].ToString(),
                        reader["nama_pasien"].ToString(), 
                        reader["nama_makanan"].ToString(),
                        reader["komposisi"].ToString(),
                        Convert.ToDateTime(reader["waktu_konsumsi"]).ToString("dd/MM/yyyy HH:mm")
                    );
                }
                reader.Close();

                string queryCount = "SELECT COUNT(*) FROM catatan_makanan";
                SqlCommand cmdCount = new SqlCommand(queryCount, conn);
                int total = (int)cmdCount.ExecuteScalar();
                lblTotalData.Text = "Total Data Tercatat: " + total.ToString();
            }
    // ... (sisa try catch biarkan sama)

            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

               
                if (string.IsNullOrWhiteSpace(txtNamaPasien.Text))
                {
                    MessageBox.Show("Nama Pasien harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNamaPasien.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNamaMakanan.Text))
                {
                    MessageBox.Show("Nama makanan harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNamaMakanan.Focus();
                    return;
                }

                
                string namaDiketik = txtNamaPasien.Text.Trim();
                int idUser = 0;

                string queryCariUser = "SELECT id_user FROM users WHERE nama = @NamaPasien AND role = 'pasien'";
                SqlCommand cmdCari = new SqlCommand(queryCariUser, conn);
                cmdCari.Parameters.AddWithValue("@NamaPasien", namaDiketik);

                object resultId = cmdCari.ExecuteScalar();

                if (resultId != null)
                {
                    
                    idUser = Convert.ToInt32(resultId);
                }
                else
                {
                    
                    
                    string emailDummy = namaDiketik.Replace(" ", "").ToLower() + new Random().Next(1000, 9999) + "@pasien.com";

                    string queryBuatBaru = @"INSERT INTO users (nama, email, password, role) 
                                             VALUES (@NamaBaru, @EmailDummy, '12345', 'pasien');
                                             SELECT SCOPE_IDENTITY();"; 

                    SqlCommand cmdBuat = new SqlCommand(queryBuatBaru, conn);
                    cmdBuat.Parameters.AddWithValue("@NamaBaru", namaDiketik);
                    cmdBuat.Parameters.AddWithValue("@EmailDummy", emailDummy);

                    
                    idUser = Convert.ToInt32(cmdBuat.ExecuteScalar());

                    
                    MessageBox.Show($"Pasien baru bernama '{namaDiketik}' telah otomatis didaftarkan ke sistem!", "Info Pasien Baru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // ==============================================================

                
                string query = @"INSERT INTO catatan_makanan (id_user, nama_makanan, komposisi, waktu_konsumsi) 
                                 VALUES (@IdUser, @NamaMakanan, @Komposisi, @Waktu)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUser", idUser);
                cmd.Parameters.AddWithValue("@NamaMakanan", txtNamaMakanan.Text);
                cmd.Parameters.AddWithValue("@Komposisi", txtKomposisi.Text);
                cmd.Parameters.AddWithValue("@Waktu", dtpWaktu.Value);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data makanan berhasil ditambahkan!", "Sukses");
                    ClearForm();
                    txtNamaPasien.Text = "";
                    TampilData();
                    LoadComboMakanan();
                }
                else
                {
                    MessageBox.Show("Data gagal ditambahkan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }
       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdMakanan.Text == "")
                {
                    MessageBox.Show("Pilih data yang akan diupdate dari tabel terlebih dahulu!", "Peringatan");
                    return;
                }

                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = @"UPDATE catatan_makanan 
                                 SET nama_makanan = @Nama, 
                                     komposisi = @Komposisi, 
                                     waktu_konsumsi = @Waktu 
                                 WHERE id_makanan = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", txtIdMakanan.Text);
                cmd.Parameters.AddWithValue("@Nama", txtNamaMakanan.Text);
                cmd.Parameters.AddWithValue("@Komposisi", txtKomposisi.Text);
                cmd.Parameters.AddWithValue("@Waktu", dtpWaktu.Value);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data berhasil diupdate", "Sukses");
                    ClearForm();
                    TampilData();
                    LoadComboMakanan(); 
                    TampilDataGejala(); 
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        
        private void ClearForm()
        {
            txtIdMakanan.Text = "";
            txtNamaMakanan.Text = "";
            txtKomposisi.Text = "";
            dtpWaktu.Value = DateTime.Now;
        }

       
        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdMakanan.Text == "" || txtIdMakanan.Text == "ID (Otomatis)")
                {
                    MessageBox.Show("Pilih data yang akan dihapus dari tabel terlebih dahulu!", "Peringatan");
                    return;
                }

                DialogResult resultConfirm = MessageBox.Show(
                    "Yakin ingin menghapus data makanan ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultConfirm == DialogResult.Yes)
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string query = "DELETE FROM catatan_makanan WHERE id_makanan = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", txtIdMakanan.Text);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus", "Sukses");
                        ClearForm();
                        TampilData();
                        LoadComboMakanan(); 
                        TampilDataGejala(); 
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void dgvMakanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0) return;

            
            DataGridViewRow row = dgvMakanan.Rows[e.RowIndex];

            
            if (row.Cells["id_makanan"].Value != null)
            {
                txtIdMakanan.Text = row.Cells["id_makanan"].Value.ToString();
                txtNamaMakanan.Text = row.Cells["nama_makanan"].Value.ToString();
                txtKomposisi.Text = row.Cells["komposisi"].Value.ToString();

                
                if (DateTime.TryParse(row.Cells["waktu_konsumsi"].Value.ToString(), out DateTime waktu))
                {
                    dtpWaktu.Value = waktu;
                }
                else
                {
                    dtpWaktu.Value = DateTime.Now;
                }
            }
        }

        private void btnResetID_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "PERINGATAN: Tindakan ini akan MENGHAPUS SELURUH DATA MAKANAN (dan gejala terkait) Anda dan mereset ID kembali ke angka 1. Apakah Anda yakin ingin melanjutkan?",
                "Konfirmasi Reset Keseluruhan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string queryHapusGejala = "DELETE FROM gejala_alergi";
                    SqlCommand cmdHapusGejala = new SqlCommand(queryHapusGejala, conn);
                    cmdHapusGejala.ExecuteNonQuery();

                    string queryHapusMakanan = "DELETE FROM catatan_makanan";
                    SqlCommand cmdHapusMakanan = new SqlCommand(queryHapusMakanan, conn);
                    cmdHapusMakanan.ExecuteNonQuery();

                    string queryResetID = "DBCC CHECKIDENT ('catatan_makanan', RESEED, 0)";
                    SqlCommand cmdResetID = new SqlCommand(queryResetID, conn);
                    cmdResetID.ExecuteNonQuery();

                    MessageBox.Show("Semua data berhasil dihapus dan urutan ID telah direset ke 1.", "Reset Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    TampilData();
                    LoadComboMakanan();
                    TampilDataGejala();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mereset: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
        }

        
        // FUNGSI GEJALA ALERGI (MASTER-DETAIL)
        // ==========================================================

        private void LoadComboMakanan()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT id_makanan, nama_makanan FROM catatan_makanan";
                SqlCommand cmdCombo = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmdCombo);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMakanan.DataSource = dt;
                cmbMakanan.DisplayMember = "nama_makanan"; 
                cmbMakanan.ValueMember = "id_makanan";     
                cmbMakanan.SelectedIndex = -1;             
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error load combo: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void TampilDataGejala()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                dgvGejala.Rows.Clear();
                dgvGejala.Columns.Clear();

                dgvGejala.Columns.Add("id_gejala", "ID Gejala");
                dgvGejala.Columns.Add("nama_pasien", "Nama Pasien");
                dgvGejala.Columns.Add("nama_makanan", "Pemicu (Makanan)");
                dgvGejala.Columns.Add("deskripsi_gejala", "Gejala");
                dgvGejala.Columns.Add("tingkat_keparahan", "Keparahan");
                dgvGejala.Columns.Add("waktu_muncul", "Waktu Gejala");

                dgvGejala.Columns["id_gejala"].Visible = false;

                string query = @"SELECT g.id_gejala, u.nama AS nama_pasien, c.nama_makanan, g.deskripsi_gejala, g.tingkat_keparahan, g.waktu_muncul
                                 FROM gejala_alergi g
                                 JOIN catatan_makanan c ON g.id_makanan = c.id_makanan
                                 JOIN users u ON c.id_user = u.id_user";

                SqlCommand cmdG = new SqlCommand(query, conn);
                SqlDataReader drG = cmdG.ExecuteReader();

                while (drG.Read())
                {
                    dgvGejala.Rows.Add(
                        drG["id_gejala"].ToString(),
                        drG["nama_pasien"].ToString(),
                        drG["nama_makanan"].ToString(),
                        drG["deskripsi_gejala"].ToString(),
                        drG["tingkat_keparahan"].ToString(),
                        Convert.ToDateTime(drG["waktu_muncul"]).ToString("dd/MM/yyyy HH:mm")
                    );
                }
                drG.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gagal menampilkan tabel gejala: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void btnSimpanGejala_Click(object sender, EventArgs e)
        {
            
            if (cmbMakanan.SelectedValue == null)
            {
                MessageBox.Show("Pilih makanan pemicu terlebih dahulu dari dropdown!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGejala.Text))
            {
                MessageBox.Show("Deskripsi gejala harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = @"INSERT INTO gejala_alergi (id_makanan, deskripsi_gejala, tingkat_keparahan, waktu_muncul) 
                                 VALUES (@IdMakanan, @Gejala, @Keparahan, @Waktu)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdMakanan", cmbMakanan.SelectedValue);
                cmd.Parameters.AddWithValue("@Gejala", txtGejala.Text);

                
                string keparahan = string.IsNullOrWhiteSpace(cmbKeparahan.Text) ? "ringan" : cmbKeparahan.Text.ToLower();
                cmd.Parameters.AddWithValue("@Keparahan", keparahan);

                cmd.Parameters.AddWithValue("@Waktu", dtpWaktuGejala.Value);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Gejala berhasil dicatat!", "Sukses");
                    txtGejala.Clear();
                    cmbKeparahan.SelectedIndex = -1;
                    dtpWaktuGejala.Value = DateTime.Now;
                    TampilDataGejala(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan gejala: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        
        private void dgvMakanan_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTotalData_Click(object sender, EventArgs e) { }
        private void txtNamaMakanan_TextChanged(object sender, EventArgs e) { }
        private void cmbMakanan_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpWaktuGejala_ValueChanged(object sender, EventArgs e) { }
        private void cmbKeparahan_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvGejala_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnHapusGejala_Click(object sender, EventArgs e)
        {
            
            if (dgvGejala.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan klik baris data gejala yang ingin dihapus pada tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string idGejalaTerpilih = dgvGejala.SelectedRows[0].Cells["id_gejala"].Value.ToString();

            
            DialogResult dialog = MessageBox.Show(
                "Apakah Anda yakin ingin menghapus data gejala ini?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string query = "DELETE FROM gejala_alergi WHERE id_gejala = @IdGejala";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdGejala", idGejalaTerpilih);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Data gejala berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TampilDataGejala(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus gejala: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
        }
        private void TampilDiagnosisSaya()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

             
                string query = @"SELECT tanggal_diagnosis, catatan_medis, tingkat_risiko 
                         FROM diagnosis_dokter 
                         WHERE id_user = @idPasien
                         ORDER BY tanggal_diagnosis DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPasien", idUserLogin);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

               
                dgvDiagnosisPasien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat diagnosis: " + ex.Message);
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        }
    }
