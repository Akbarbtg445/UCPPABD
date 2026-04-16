using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UCPPABD
{
    public partial class AdminDashboard : Form
    {
        // String koneksi ke database SQL Server kamu
        string connectionString = @"Data Source=AOZORA\AKBARRZHO;Initial Catalog=UCP_PABD_Jadwal;Integrated Security=True;TrustServerCertificate=True";

        public AdminDashboard()
        {
            InitializeComponent();
            tampilkanData(); // Munculkan data otomatis saat dashboard dibuka
        }

        // --- 1. FUNGSI MENAMPILKAN DATA (READ) ---
        void tampilkanData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Jadwal", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvJadwal.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat tabel: " + ex.Message);
                }
            }
        }

        // --- 2. FUNGSI RESET INPUT ---
        void resetForm()
        {
            cmbHari.SelectedIndex = -1;
            cmbKelas.SelectedIndex = -1;
            cmbMapel.SelectedIndex = -1;
            cmbGuru.SelectedIndex = -1;
            dtpMulai.Value = DateTime.Now;
            dtpSelesai.Value = DateTime.Now;
        }

        // --- 3. TOMBOL TAMBAH (CREATE) ---
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbHari.Text == "" || cmbKelas.Text == "" || cmbMapel.Text == "" || cmbGuru.Text == "")
            {
                MessageBox.Show("Mohon isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Jadwal (hari, jam_mulai, jam_selesai, idKelas, idMapel, idGuru) " +
                                   "VALUES (@hari, @mulai, @selesai, @kelas, @mapel, @guru)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@hari", cmbHari.Text);
                    cmd.Parameters.AddWithValue("@mulai", dtpMulai.Value.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@selesai", dtpSelesai.Value.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@kelas", cmbKelas.Text);
                    cmd.Parameters.AddWithValue("@mapel", cmbMapel.Text);
                    cmd.Parameters.AddWithValue("@guru", cmbGuru.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Jadwal Berhasil Ditambahkan!");
                    tampilkanData();
                    resetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Simpan: " + ex.Message);
                }
            }
        }

        // --- 4. TOMBOL UBAH (UPDATE) ---
        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvJadwal.CurrentRow == null) { MessageBox.Show("Pilih data yang ingin diubah!"); return; }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Ambil ID dari kolom pertama (idJadwal)
                    string id = dgvJadwal.CurrentRow.Cells[0].Value.ToString();
                    string query = "UPDATE Jadwal SET hari=@hari, jam_mulai=@mulai, jam_selesai=@selesai, idKelas=@kelas, idMapel=@mapel, idGuru=@guru WHERE idJadwal=@id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@hari", cmbHari.Text);
                    cmd.Parameters.AddWithValue("@mulai", dtpMulai.Value.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@selesai", dtpSelesai.Value.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@kelas", cmbKelas.Text);
                    cmd.Parameters.AddWithValue("@mapel", cmbMapel.Text);
                    cmd.Parameters.AddWithValue("@guru", cmbGuru.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Diperbarui!");
                    tampilkanData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Update: " + ex.Message);
                }
            }
        }

        // --- 5. TOMBOL HAPUS (DELETE) ---
        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvJadwal.CurrentRow == null) { MessageBox.Show("Pilih data yang ingin dihapus!"); return; }

            string id = dgvJadwal.CurrentRow.Cells[0].Value.ToString();
            DialogResult dr = MessageBox.Show("Hapus jadwal ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Jadwal WHERE idJadwal = @id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data Terhapus!");
                        tampilkanData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Hapus: " + ex.Message);
                    }
                }
            }
        }

        // --- 6. LOGIKA KLIK TABEL (Agar data muncul di inputan) ---
        private void dgvJadwal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvJadwal.CurrentRow != null)
            {
                cmbHari.Text = dgvJadwal.CurrentRow.Cells["hari"].Value.ToString();
                cmbKelas.Text = dgvJadwal.CurrentRow.Cells["idKelas"].Value.ToString();
                cmbMapel.Text = dgvJadwal.CurrentRow.Cells["idMapel"].Value.ToString();
                // Jika kolom idGuru ada di tabel:
                // cmbGuru.Text = dgvJadwal.CurrentRow.Cells["idGuru"].Value.ToString();
            }
        }

        // --- 7. TOMBOL LOGOUT ---
        private void btnLogoutA_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin ingin keluar?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form1 login = new Form1();
                login.Show();
                this.Hide();
            }
        }

        // --- EVENT KOSONG (Hanya agar tidak error designer) ---
        private void button4_Click(object sender, EventArgs e) { /* Fitur Cetak */ }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
    }
}