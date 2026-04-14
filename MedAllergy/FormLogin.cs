using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedAllergy
{
    public partial class FormLogin : Form
    {
        // Koneksi ke Database
        private readonly string connectionString = @"Data Source=LAPTOP-RAFIAMMA;Initial Catalog=db_alergi_makanan;User ID=sa;Password=Rafi12345;TrustServerCertificate=True;";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Validasi jika kosong
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Email dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                // 2. Cek apakah email dan password cocok di database
                string query = "SELECT id_user, nama, role FROM users WHERE email = @Email AND password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                // 3. Jika data ditemukan (Login Sukses)
                if (reader.Read())
                {
                    string namaUser = reader["nama"].ToString();
                    string roleUser = reader["role"].ToString().ToLower();

                    MessageBox.Show("Login Berhasil! Selamat datang, " + namaUser, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Sembunyikan layar login
                    this.Hide();

                    // 4. Arahkan ke Form yang tepat berdasarkan Role
                    if (roleUser == "pasien")
                    {
                        int idLogin = Convert.ToInt32(reader["id_user"]); // Ambil ID dari database
                        Form1 formPasien = new Form1(idLogin); // Kirim ID ke Form1
                        formPasien.Show();
                        this.Hide();
                    }
                    else if (roleUser == "dokter")
                    {
                        FormDokter formDokter = new FormDokter();
                        formDokter.FormClosed += (s, args) => this.Close();
                        formDokter.Show();
                    }
                }
                else
                {
                    // Jika data tidak ditemukan (Login Gagal)
                    MessageBox.Show("Email atau Password salah!", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan sistem: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        // Event kosong dari desainer
        private void FormLogin_Load(object sender, EventArgs e) { }
    }
}