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





Form Login

<img width="850" height="886" alt="image" src="https://github.com/user-attachments/assets/9983c868-f374-4129-a02d-76d9ec2057a4" />


Form Registrasi

<img width="913" height="859" alt="image" src="https://github.com/user-attachments/assets/059390ac-f8d6-4116-a8f3-b7df4275814e" />


Form Dashboard

<img width="1474" height="937" alt="image" src="https://github.com/user-attachments/assets/795da3c7-d3e7-4f8b-8459-eabfd2f0ea12" />


Form Dokter 

<img width="1333" height="905" alt="image" src="https://github.com/user-attachments/assets/e54f4b03-4986-4543-a0e1-b3e362613b56" />






Stored Procedure 

<img width="1034" height="773" alt="image" src="https://github.com/user-attachments/assets/923821e3-1b5f-4c55-a430-3fab8b19f1ec" />


<img width="1200" height="810" alt="image" src="https://github.com/user-attachments/assets/0348fc67-e881-4673-9fda-fceaad53caa5" />


<img width="830" height="835" alt="image" src="https://github.com/user-attachments/assets/4a0809a0-9a2b-4e6f-af5f-39564438742f" />


<img width="750" height="805" alt="image" src="https://github.com/user-attachments/assets/4fe17731-b7df-4386-a710-45639ff8ec73" />






