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

namespace UCPPABD
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Ambil data dari inputan
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Silakan pilih Role terlebih dahulu!");
                return;
            }

            // 2. Tentukan tabel target (Gunakan [User] dengan kurung siku karena User adalah keyword SQL)
            string tabel = (role == "Admin") ? "Admin" : "[User]";

            // 3. String Koneksi (Sesuaikan Nama Server kamu)
            string connectionString = @"Data Source=AOZORA\AKBARRZHO;Initial Catalog=UCP_PABD_Jadwal;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // 4. Query untuk mengecek username dan password
                    string query = $"SELECT COUNT(*) FROM {tabel} WHERE username=@user AND password=@pass";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    int hasil = (int)cmd.ExecuteScalar();

                    if (hasil > 0)
                    {
                        MessageBox.Show($"Login sebagai {role} Berhasil!");

                        // 5. Perpindahan Halaman sesuai Role
                        if (role == "Admin")
                        {
                            AdminDashboard adminForm = new AdminDashboard();
                            adminForm.Show();
                        }
                        else
                        {
                            UserDashboard userForm = new UserDashboard();
                            userForm.Show();
                        }

                        this.Hide(); // Sembunyikan form login
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }

        }
    }
}
