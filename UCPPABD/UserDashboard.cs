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
            tampilkanData();    // Load semua jadwal saat mulai
            isiPilihanKelas();  // Isi dropdown Kelas
        }

        // --- 1. FUNGSI LOAD PILIHAN KELAS (DENGAN PENGECEKAN) ---
        void isiPilihanKelas()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Mengambil semua data dari tabel Kelas
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Kelas", conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    cmbKelas.Items.Clear();

                    if (!dr.HasRows)
                    {
                        MessageBox.Show("Peringatan: Tabel 'Kelas' di database kosong!");
                    }

                    while (dr.Read())
                    {
                        // dr[0] biasanya adalah idKelas
                        cmbKelas.Items.Add(dr[0].ToString());
                    }
                    dr.Close();

                    // Jika masih kosong setelah looping, tambahkan item manual untuk tes UI
                    if (cmbKelas.Items.Count == 0)
                    {
                        cmbKelas.Items.Add("KLS01"); // Data pancingan
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal koneksi ke tabel Kelas: " + ex.Message);
                }
            }
        }

        // --- 2. FUNGSI TAMPILKAN SEMUA DATA JADWAL ---
        void tampilkanData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Sesuaikan kolom dengan database: jamMulai, jamSelesai, idKeahlian
                    SqlDataAdapter da = new SqlDataAdapter("SELECT idJadwal, hari, jamMulai, jamSelesai, idKelas, idKeahlian, idGuru FROM Jadwal", conn);
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

        // --- 3. TOMBOL CARI (Cari Jadwal per Kelas) ---
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbKelas.Text))
            {
                MessageBox.Show("Pilih kelas terlebih dahulu!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT idJadwal, hari, jamMulai, jamSelesai, idKelas, idKeahlian, idGuru FROM Jadwal WHERE idKelas = @kelas";
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

        // --- 4. LOGIKA KLIK TABEL & CEK KAPASITAS ---
        private void dgvJadwal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvJadwal.CurrentRow != null)
            {
                try
                {
                    string idJadwal = dgvJadwal.CurrentRow.Cells["idJadwal"].Value.ToString();
                    string idKelas = dgvJadwal.CurrentRow.Cells["idKelas"].Value.ToString();

                    // Isi form: idKeahlian adalah kolom Mapel di DB kamu
                    txtMapel.Text = dgvJadwal.CurrentRow.Cells["idKeahlian"].Value.ToString();
                    cmbKelas.Text = idKelas;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // 1. Ambil Kapasitas Maksimal
                        SqlCommand cmdMax = new SqlCommand("SELECT kapasitas FROM Kelas WHERE idKelas = @kelas", conn);
                        cmdMax.Parameters.AddWithValue("@kelas", idKelas);
                        object res = cmdMax.ExecuteScalar();
                        int max = (res != null) ? Convert.ToInt32(res) : 0;

                        // 2. Hitung Siswa yang sudah masuk
                        SqlCommand cmdTerisi = new SqlCommand("SELECT COUNT(*) FROM Jadwal_Pribadi WHERE idJadwal = @id", conn);
                        cmdTerisi.Parameters.AddWithValue("@id", idJadwal);
                        int terisi = Convert.ToInt32(cmdTerisi.ExecuteScalar());

                        int sisa = max - terisi;

                        lblMax.Text = max.ToString();
                        lblTerisi.Text = terisi.ToString();
                        lblSisa.Text = sisa.ToString();

                        if (sisa > 0)
                        {
                            lblStatus.Text = "TERSEDIA";
                            lblStatus.ForeColor = Color.Green;
                            btnSimpan.Enabled = true; // button3 adalah tombol Simpan
                        }
                        else
                        {
                            lblStatus.Text = "PENUH";
                            lblStatus.ForeColor = Color.Red;
                            btnSimpan.Enabled = false;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error Detail: " + ex.Message); }
            }
        }

        // --- 5. TOMBOL SIMPAN JADWAL PRIBADI ---
        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvJadwal.CurrentRow == null) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string idJadwal = dgvJadwal.CurrentRow.Cells["idJadwal"].Value.ToString();
                    string nisSiswa = lblNIS.Text;

                    // Cek duplikat
                    SqlCommand cek = new SqlCommand("SELECT COUNT(*) FROM Jadwal_Pribadi WHERE idJadwal=@id AND NIS=@nis", conn);
                    cek.Parameters.AddWithValue("@id", idJadwal);
                    cek.Parameters.AddWithValue("@nis", nisSiswa);
                    if ((int)cek.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Jadwal ini sudah ada di daftar pribadimu!");
                        return;
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO Jadwal_Pribadi (idJadwal, NIS) VALUES (@id, @nis)", conn);
                    cmd.Parameters.AddWithValue("@id", idJadwal);
                    cmd.Parameters.AddWithValue("@nis", nisSiswa);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil disimpan!", "Sukses");
                    dgvJadwal_CellClick(null, null); // Refresh status kuota
                }
                catch (Exception ex) { MessageBox.Show("Gagal: " + ex.Message); }
            }
        }

        // --- 6. TOMBOL CETAK JADWAL PRIBADI ---
        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvJadwal.Rows.Count > 0)
            {
                MessageBox.Show("Mencetak Jadwal Pribadi untuk NIS: " + lblNIS.Text, "Cetak");
                // Logika cetak sama seperti Admin Dashboard bisa ditambahkan di sini
            }
        }

        // --- 7. LOGOUT ---
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        // Event handler kosong untuk Designer
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