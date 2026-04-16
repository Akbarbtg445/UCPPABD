using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Wajib ditambahkan untuk akses database

namespace UCPPABD
{
    public partial class UserDashboard : Form
    {
        // Alamat database kamu
        string connectionString = @"Data Source=AOZORA\AKBARRZHO;Initial Catalog=UCP_PABD_Jadwal;Integrated Security=True;TrustServerCertificate=True";

        public UserDashboard()
        {
            InitializeComponent();
            tampilkanData(); // Panggil data saat form pertama kali muncul
        }

        // --- 1. FUNGSI TAMPILKAN SEMUA DATA JADWAL ---
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
                    MessageBox.Show("Gagal memuat jadwal: " + ex.Message);
                }
            }
        }

        // --- 2. TOMBOL CARI (Cari Jadwal per Kelas) ---
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbKelas.Text)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Jadwal WHERE idKelas = @kelas";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kelas", cmbKelas.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvJadwal.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        // --- 3. LOGIKA KLIK TABEL & CEK KAPASITAS ---
        // Pastikan event ini dihubungkan ke 'CellClick' di Properties DataGridView
        private void dgvJadwal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvJadwal.CurrentRow != null)
            {
                // Ambil data dari baris yang diklik
                string idJadwal = dgvJadwal.CurrentRow.Cells[0].Value.ToString();
                string idKelas = dgvJadwal.CurrentRow.Cells["idKelas"].Value.ToString();

                // Isi form Edit Jadwal Pribadi secara otomatis
                txtMapel.Text = dgvJadwal.CurrentRow.Cells["idMapel"].Value.ToString();
                cmbKelas.Text = idKelas;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Cek Kapasitas Maksimal Kelas
                        SqlCommand cmdMax = new SqlCommand("SELECT kapasitas FROM Kelas WHERE idKelas = @kelas", conn);
                        cmdMax.Parameters.AddWithValue("@kelas", idKelas);
                        int max = Convert.ToInt32(cmdMax.ExecuteScalar());

                        // Hitung jumlah siswa yang sudah mengambil jadwal ini
                        SqlCommand cmdTerisi = new SqlCommand("SELECT COUNT(*) FROM Jadwal_Pribadi WHERE idJadwal = @id", conn);
                        cmdTerisi.Parameters.AddWithValue("@id", idJadwal);
                        int terisi = Convert.ToInt32(cmdTerisi.ExecuteScalar());

                        int sisa = max - terisi;

                        // Tampilkan hasil ke label
                        lblMax.Text = max.ToString();
                        lblTerisi.Text = terisi.ToString();
                        lblSisa.Text = sisa.ToString();

                        // Update Status
                        if (sisa > 0)
                        {
                            lblStatus.Text = "TERSEDIA";
                            lblStatus.ForeColor = Color.Green;
                            btnSimpan.Enabled = true; // Tombol Simpan aktif
                        }
                        else
                        {
                            lblStatus.Text = "PENUH";
                            lblStatus.ForeColor = Color.Red;
                            btnSimpan.Enabled = false; // Tombol Simpan mati
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Gagal Cek Kapasitas: " + ex.Message); }
                }
            }
        }

        // --- 4. TOMBOL SIMPAN JADWAL PRIBADI ---
        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvJadwal.CurrentRow == null) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string idJadwal = dgvJadwal.CurrentRow.Cells[0].Value.ToString();
                    string nisSiswa = lblNIS.Text; // Diambil dari identitas login di atas

                    string query = "INSERT INTO Jadwal_Pribadi (idJadwal, NIS) VALUES (@id, @nis)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idJadwal);
                    cmd.Parameters.AddWithValue("@nis", nisSiswa);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Jadwal berhasil disimpan ke daftar pribadi!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan: " + ex.Message);
                }
            }
        }

        // --- 5. LOGOUT ---
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Panggil kembali form login
                Form1 login = new Form1();
                login.Show();

                // Sembunyikan dashboard user
                this.Hide();
            }
        }

        // Event handler kosong agar tidak error saat designer dibuka
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }

        private void cmbPilihkelas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
