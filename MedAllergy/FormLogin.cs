using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedAllergy
{
    public partial class FormLogin : Form
    {
        private readonly string connectionString = @"Data Source=LAPTOP-RAFIAMMA;Initial Catalog=db_alergi_makanan;User ID=sa;Password=Rafi12345;TrustServerCertificate=True;";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validasi input tidak boleh kosong
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Email dan Password wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Menggunakan blok 'using' untuk manajemen koneksi yang aman
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                   // PENCEGAHAN SQL INJECTION: Menggunakan Parameterized Query 
                    string query = "SELECT id_user, nama, role FROM users WHERE email = @Email AND password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Input user dipetakan ke parameter, bukan digabung langsung ke string query 
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string namaUser = reader["nama"].ToString();
                                string roleUser = reader["role"].ToString().ToLower();

                                MessageBox.Show("Login Berhasil! Selamat datang, " + namaUser, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();

                                if (roleUser == "pasien")
                                {
                                    int idLogin = Convert.ToInt32(reader["id_user"]);
                                    Form1 formPasien = new Form1(idLogin);
                                    formPasien.Show();
                                }
                                else if (roleUser == "dokter")
                                {
                                    FormDokter formDokter = new FormDokter();
                                    formDokter.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Email atau Password salah!", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kesalahan Keamanan/Sistem: " + ex.Message);
                }
            }
        }

        // Fungsi khusus untuk tombol Registrasi
        private void lnkRegistrasi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister formDaftar = new FormRegister();
            formDaftar.Show();
            this.Hide();
        }

        // --- Fungsi bawaan yang kosong biarkan saja ---
        private void FormLogin_Load(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}