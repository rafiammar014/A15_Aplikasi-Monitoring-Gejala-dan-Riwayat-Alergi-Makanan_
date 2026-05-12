# 🛡️ Skenario & Mitigasi SQL Injection pada Form Login

Repositori ini mendemonstrasikan kerentanan keamanan **SQL Injection (SQLi)** pada *Form Login* aplikasi desktop berbasis C# WinForms, serta bagaimana cara memitigasinya menggunakan *Parameterized Queries*.

1. Skenario Kode yang Rentan (Vulnerable Code)
Serangan SQL Injection dapat terjadi apabila aplikasi menggabungkan (*concatenate*) input pengguna langsung ke dalam string *query* database.

Jika aplikasi ini ditulis menggunakan cara yang rentan, kodenya akan terlihat seperti ini:

// CONTOH KODE RENTAN 
string emailInput = txtEmail.Text;
string passwordInput = txtPassword.Text;

string query = "SELECT id_user, nama, role FROM users WHERE email = '" + emailInput + "' AND password = '" + passwordInput + "'";

SqlCommand cmd = new SqlCommand(query, conn);
SqlDataReader reader = cmd.ExecuteReader();


