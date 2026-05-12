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
            // 1. Validasi Input Dasar
            if (string.IsNullOrWhiteSpace(txtNamaBaru.Text) ||
                string.IsNullOrWhiteSpace(txtEmailBaru.Text) ||
                string.IsNullOrWhiteSpace(txtPassBaru.Text))
            {
                MessageBox.Show("Semua kolom wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Proses Simpan menggunakan Stored Procedure (Pencegahan SQL Injection)
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Menggunakan Parameterized Query melalui Stored Procedure
                    SqlCommand cmd = new SqlCommand("sp_RegisterUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Mengirimkan parameter input
                    cmd.Parameters.AddWithValue("@Nama", txtNamaBaru.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmailBaru.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassBaru.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", "pasien");

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registrasi Berhasil! Anda sekarang bisa login.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Kembali ke Form Login
                    FormLogin login = new FormLogin();
                    login.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Menangkap pesan error dari Stored Procedure (misal: Email sudah ada)
                    MessageBox.Show("Gagal Registrasi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnKembali_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }
    }
}
