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
        // String koneksi ke database SQL Server
        string connectionString = @"Data Source=AOZORA\AKBARRZHO;Initial Catalog=UCP_PABD_Jadwal;Integrated Security=True;TrustServerCertificate=True";

        public AdminDashboard()
        {
            InitializeComponent();
            tampilkanData();      // Load tabel jadwal
            isiPilihanComboBox(); // Load pilihan Kelas, Guru, Mapel
        }

        // --- 1. FUNGSI MENAMPILKAN DATA KE TABEL ---
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

        // --- 2. FUNGSI ISI PILIHAN COMBOBOX (SESUAI NAMA KOLOM DB) ---
        void isiPilihanComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Ambil Data Kelas
                    SqlCommand cmdKelas = new SqlCommand("SELECT idKelas FROM Kelas", conn);
                    SqlDataReader drKelas = cmdKelas.ExecuteReader();
                    cmbKelas.Items.Clear();
                    while (drKelas.Read()) { cmbKelas.Items.Add(drKelas["idKelas"].ToString()); }
                    drKelas.Close();

                    // 2. Ambil Data Guru (Kolom 'nama')
                    SqlCommand cmdGuru = new SqlCommand("SELECT nama FROM Guru", conn);
                    SqlDataReader drGuru = cmdGuru.ExecuteReader();
                    cmbGuru.Items.Clear();
                    while (drGuru.Read()) { cmbGuru.Items.Add(drGuru["nama"].ToString()); }
                    drGuru.Close();

                    // 3. Ambil Data Mata Pelajaran (Kolom 'namaMapel')
                    SqlCommand cmdMapel = new SqlCommand("SELECT namaMapel FROM MataPelajaran", conn);
                    SqlDataReader drMapel = cmdMapel.ExecuteReader();
                    cmbMapel.Items.Clear();
                    while (drMapel.Read()) { cmbMapel.Items.Add(drMapel["namaMapel"].ToString()); }
                    drMapel.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat pilihan dropdown: " + ex.Message);
                }
            }
        }

        // --- 3. FUNGSI RESET FORM ---
        void resetForm()
        {
            cmbHari.SelectedIndex = -1;
            cmbKelas.SelectedIndex = -1;
            cmbMapel.SelectedIndex = -1;
            cmbGuru.SelectedIndex = -1;
            dtpMulai.Value = DateTime.Now;
            dtpSelesai.Value = DateTime.Now;
        }

        // --- 4. TOMBOL TAMBAH (SESUAI jamMulai, jamSelesai, idKeahlian) ---
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
                    // Query disesuaikan dengan screenshot SSMS: jamMulai, jamSelesai, idKeahlian
                    string query = "INSERT INTO Jadwal (hari, jamMulai, jamSelesai, idKelas, idKeahlian, idGuru) " +
                                   "VALUES (@hari, @mulai, @selesai, @kelas, @mapel, @guru)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@hari", cmbHari.Text);
                    cmd.Parameters.AddWithValue("@mulai", dtpMulai.Value.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@selesai", dtpSelesai.Value.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@kelas", cmbKelas.Text);
                    cmd.Parameters.AddWithValue("@mapel", cmbMapel.Text); // Dimasukkan ke idKeahlian
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

        // --- 5. TOMBOL UBAH (UPDATE) ---
        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvJadwal.CurrentRow == null) { MessageBox.Show("Pilih data yang ingin diubah!"); return; }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string id = dgvJadwal.CurrentRow.Cells["idJadwal"].Value.ToString();

                    // Query UPDATE disesuaikan
                    string query = "UPDATE Jadwal SET hari=@hari, jamMulai=@mulai, jamSelesai=@selesai, " +
                                   "idKelas=@kelas, idKeahlian=@mapel, idGuru=@guru WHERE idJadwal=@id";

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

        // --- 6. TOMBOL HAPUS (DELETE) ---
        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvJadwal.CurrentRow == null) { MessageBox.Show("Pilih data yang ingin dihapus!"); return; }

            string id = dgvJadwal.CurrentRow.Cells["idJadwal"].Value.ToString();
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
                        resetForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Hapus: " + ex.Message);
                    }
                }
            }
        }

        // --- 7. KLIK TABEL (Isi Form Otomatis - Sinkron idKeahlian) ---
        private void dgvJadwal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvJadwal.CurrentRow != null)
            {
                cmbHari.Text = dgvJadwal.CurrentRow.Cells["hari"].Value.ToString();
                cmbKelas.Text = dgvJadwal.CurrentRow.Cells["idKelas"].Value.ToString();

                // Menggunakan idKeahlian sesuai kolom di DB
                cmbMapel.Text = dgvJadwal.CurrentRow.Cells["idKeahlian"].Value.ToString();
                cmbGuru.Text = dgvJadwal.CurrentRow.Cells["idGuru"].Value.ToString();
            }
        }

        // --- 8. LOGOUT ---
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

        // Event kosong untuk menjaga keutuhan file designer
        private void button4_Click(object sender, EventArgs e) { }
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