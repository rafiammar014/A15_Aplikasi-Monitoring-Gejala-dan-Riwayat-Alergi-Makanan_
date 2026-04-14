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
            
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Email dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                
                string query = "SELECT id_user, nama, role FROM users WHERE email = @Email AND password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                SqlDataReader reader = cmd.ExecuteReader();

               
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

        
        private void FormLogin_Load(object sender, EventArgs e) { }
    }
}