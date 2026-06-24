using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedAllergy
{
    public partial class FormRegister : Form
    {
        private readonly string connectionString = @"Data Source=LAPTOP-RAFIAMMA;Initial Catalog=db_alergi_makanan;User ID=sa;Password=Rafi12345;TrustServerCertificate=True;";
        public FormRegister()
        {
            InitializeComponent();
        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input Dasar (Cek kekosongan kolom)
            if (string.IsNullOrWhiteSpace(txtNamaBaru.Text) ||
                string.IsNullOrWhiteSpace(txtEmailBaru.Text) ||
                string.IsNullOrWhiteSpace(txtPassBaru.Text))
            {
                MessageBox.Show("Semua kolom wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = txtEmailBaru.Text.Trim();
            string password = txtPassBaru.Text.Trim();
            string roleUser = "";

            // 2. Validasi Format Email sekaligus Menentukan Role Secara Otomatis
            if (email.EndsWith("@pasien.com", StringComparison.OrdinalIgnoreCase))
            {
                roleUser = "pasien";
            }
            else if (email.EndsWith("@rs", StringComparison.OrdinalIgnoreCase) || email.EndsWith("@rs.com", StringComparison.OrdinalIgnoreCase))
            {
                roleUser = "dokter"; // Saya tambahkan opsi @rs.com untuk fleksibilitas, keduanya akan terbaca sebagai dokter
            }
            else
            {
                MessageBox.Show("Format email tidak valid!\n\n- Gunakan akhiran '@pasien.com' untuk mendaftar sebagai Pasien.\n- Gunakan akhiran '@rs' untuk mendaftar sebagai Dokter.",
                                "Peringatan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Validasi Password (Minimal 8 karakter, minimal 1 huruf, minimal 1 angka)
            if (password.Length < 8 || !password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                MessageBox.Show("Password tidak memenuhi standar keamanan!\n\nSyarat Password:\n- Minimal 8 karakter\n- Mengandung setidaknya 1 huruf\n- Mengandung setidaknya 1 angka",
                                "Peringatan Keamanan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Proses Simpan menggunakan Stored Procedure
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("sp_RegisterUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nama", txtNamaBaru.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    // MENGGUNAKAN ROLE YANG DIDETEKSI DARI EMAIL, BUKAN HARDCODE LAGI
                    cmd.Parameters.AddWithValue("@Role", roleUser);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Registrasi Berhasil sebagai {roleUser.ToUpper()}! Anda sekarang bisa login.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Kembali ke Form Login
                    FormLogin login = new FormLogin();
                    login.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Registrasi: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnKembali_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }

        private void brnSimpan_Click(object sender, EventArgs e)
        {

        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
