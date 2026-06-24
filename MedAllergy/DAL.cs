using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace MedAllergy
{
    public class DAL
    {
        // 1. Fungsi untuk mendapatkan IP Address otomatis (Penting untuk Deploy)
        public static string GetLocalIPAddress()
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1"; // Default jika tidak menemukan IP
        }

        // 2. Fungsi untuk mengambil Connection String secara dinamis
        public string GetConnectionString()
        {
            // Menggunakan IP lokal agar bisa diakses dalam jaringan
            return $"Data Source={GetLocalIPAddress()};Initial Catalog=db_alergi_makanan;User ID=sa;Password=Rafi12345;TrustServerCertificate=True;";
        }

        // 3. Contoh cara pakai koneksi di fungsi lain (Misal: untuk eksekusi Query)
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}