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
    public partial class UserDashboard : Form
    {
        // Alamat database kamu
        string connectionString = @"Data Source=AOZORA\AKBARRZHO;Initial Catalog=UCP_PABD_Jadwal;Integrated Security=True;TrustServerCertificate=True";

        public UserDashboard()
        {
            InitializeComponent();
            tampilkanData();    // Memuat data saat aplikasi dibuka [cite: 86]
            isiPilihanKelas();  // Mengisi daftar kelas di dropdown
        }

        // --- 1. FUNGSI ISI SEMUA DROPDOWN KELAS ---
        void isiPilihanKelas()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT idKelas FROM Kelas", conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    cmbKelas.Items.Clear();        // Dropdown Cari (Atas)
                    cmbPilihkelas.Items.Clear();   // Dropdown Edit (Bawah/Kanan)

                    while (dr.Read())
                    {
                        string dataKelas = dr["idKelas"].ToString();
                        cmbKelas.Items.Add(dataKelas);
                        cmbPilihkelas.Items.Add(dataKelas);
                    }
                    dr.Close();

                    // Fail-safe jika database kosong
                    if (cmbKelas.Items.Count == 0)
                    {
                        cmbKelas.Items.Add("KLS01");
                        cmbPilihkelas.Items.Add("KLS01");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat daftar kelas: " + ex.Message);
                }
            }
        }

        // --- 2. FUNGSI TAMPILKAN DATA JADWAL (DENGAN JOIN AGAR MUNCUL NAMA MAPEL) ---
        void tampilkanData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Menggunakan JOIN agar mendapatkan namaMapel dan namaGuru, bukan ID-nya saja
                    string query = @"SELECT j.idJadwal, j.hari, j.jamMulai, j.jamSelesai, j.idKelas, 
                                     m.namaMapel, g.nama as namaGuru 
                                     FROM Jadwal j 
                                     JOIN MataPelajaran m ON j.idKeahlian = m.idMapel 
                                     JOIN Guru g ON j.idGuru = g.idGuru";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvJadwal.DataSource = dt; // Menampilkan seluruh data ke DataGridView [cite: 86]
                }
                catch (Exception ex) { MessageBox.Show("Gagal memuat jadwal: " + ex.Message); }
            }
        }

        // --- 3. TOMBOL CARI (BERDASARKAN KELAS) ---
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbKelas.Text)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    [cite_start]// Query pencarian berdasarkan field idKelas [cite: 87]
                    string query = @"SELECT j.idJadwal, j.hari, j.jamMulai, j.jamSelesai, j.idKelas, 
                                     m.namaMapel, g.nama as namaGuru 
                                     FROM Jadwal j 
                                     JOIN MataPelajaran m ON j.idKeahlian = m.idMapel 
                                     JOIN Guru g ON j.idGuru = g.idGuru 
                                     WHERE j.idKelas = @kelas";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kelas", cmbKelas.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvJadwal.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Error Cari: " + ex.Message); }
            }
        }

        // --- 4. KLIK TABEL (PILIH DATA KE TEXTBOX & CEK KAPASITAS) ---
        private void dgvJadwal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvJadwal.CurrentRow != null)
            {
                try
                {
                    [cite_start]// Fitur pilih data dari DataGridView ke TextBox/Control [cite: 88]
                    string idJadwal = dgvJadwal.CurrentRow.Cells["idJadwal"].Value.ToString();
                    string idKelas = dgvJadwal.CurrentRow.Cells["idKelas"].Value.ToString();
                    string namaMapel = dgvJadwal.CurrentRow.Cells["namaMapel"].Value.ToString();

                    txtMapel.Text = namaMapel;      // Menampilkan nama mata pelajaran hasil JOIN
                    cmbPilihkelas.Text = idKelas;   // Menyesuaikan pilihan kelas di box Edit

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        [cite_start]// 1. Ambil Kapasitas Maksimal menggunakan ExecuteScalar 
                        SqlCommand cmdMax = new SqlCommand("SELECT kapasitas FROM Kelas WHERE idKelas = @kelas", conn);
                        cmdMax.Parameters.AddWithValue("@kelas", idKelas);
                        object res = cmdMax.ExecuteScalar();
                        int max = (res != null) ? Convert.ToInt32(res) : 0;

                        [cite_start]// 2. Menghitung jumlah data siswa yang sudah terdaftar menggunakan ExecuteScalar [cite: 82, 83]
                        SqlCommand cmdTerisi = new SqlCommand("SELECT COUNT(*) FROM Jadwal_Pribadi WHERE idJadwal = @id", conn);
                        cmdTerisi.Parameters.AddWithValue("@id", idJadwal);
                        int terisi = Convert.ToInt32(cmdTerisi.ExecuteScalar());

                        int sisa = max - terisi;

                        [cite_start]// Menampilkan total record pada label [cite: 84]
                        lblMax.Text = max.ToString();
                        lblTerisi.Text = terisi.ToString();
                        lblSisa.Text = sisa.ToString();

                        // Update Status Visual
                        if (sisa > 0)
                        {
                            lblStatus.Text = "TERSEDIA";
                            lblStatus.ForeColor = Color.Green;
                            button3.Enabled = true;
                        }
                        else
                        {
                            lblStatus.Text = "PENUH";
                            lblStatus.ForeColor = Color.Red;
                            button3.Enabled = false;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Gagal pilih data: " + ex.Message); }
            }
        }

        // --- 5. SIMPAN KE JADWAL PRIBADI (INSERT) ---
        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvJadwal.CurrentRow == null) return;

            [cite_start]// Tambahkan konfirmasi sebelum data disimpan 
            DialogResult dr = MessageBox.Show("Simpan jadwal ini ke daftar pribadi?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string idJadwal = dgvJadwal.CurrentRow.Cells["idJadwal"].Value.ToString();
                    string nisSiswa = lblNIS.Text; // Pastikan lblNIS sudah terisi dari form Login

                    [cite_start]// Implementasi query INSERT menggunakan SqlCommand dan ExecuteNonQuery [cite: 79]
                    string query = "INSERT INTO Jadwal_Pribadi (idJadwal, NIS) VALUES (@id, @nis)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idJadwal);
                    cmd.Parameters.AddWithValue("@nis", nisSiswa);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Jadwal Pribadi Berhasil Disimpan!", "Sukses");

                    // Refresh tampilan kapasitas
                    dgvJadwal_CellClick(null, null);
                }
                catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); }
            }
        }

        // --- 6. LOGOUT ---
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
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
        private void cmbPilihkelas_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}