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
        string connectionString = @"Data Source=AOZORA\AKBARRZHO;Initial Catalog=UCP_PABD_Jadwal;Integrated Security=True;TrustServerCertificate=True";

        public UserDashboard()
        {
            InitializeComponent();
            tampilkanData();
            isiPilihanKelas();
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

                    // Kita bersihkan dua-duanya biar adil
                    cmbKelas.Items.Clear();        // Dropdown Cari (Atas)
                    cmbPilihkelas.Items.Clear();   // Dropdown Edit (Bawah/Kanan)

                    while (dr.Read())
                    {
                        string dataKelas = dr["idKelas"].ToString();
                        cmbKelas.Items.Add(dataKelas);
                        cmbPilihkelas.Items.Add(dataKelas);
                    }
                    dr.Close();

                    // Pancingan jika database kosong
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

        // --- 2. FUNGSI TAMPILKAN DATA JADWAL ---
        void tampilkanData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT idJadwal, hari, jamMulai, jamSelesai, idKelas, idKeahlian, idGuru FROM Jadwal", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvJadwal.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Gagal memuat jadwal: " + ex.Message); }
            }
        }

        // --- 3. TOMBOL CARI ---
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbKelas.Text)) return;

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

        // --- 4. KLIK TABEL (SYNC KE FORM EDIT) ---
        private void dgvJadwal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvJadwal.CurrentRow != null)
            {
                try
                {
                    string idJadwal = dgvJadwal.CurrentRow.Cells["idJadwal"].Value.ToString();
                    string idKelas = dgvJadwal.CurrentRow.Cells["idKelas"].Value.ToString();

                    // Tampilkan di box Edit Jadwal Pribadi
                    txtMapel.Text = dgvJadwal.CurrentRow.Cells["idKeahlian"].Value.ToString();
                    cmbPilihkelas.Text = idKelas; // Pastikan nama objeknya cmbPilihkelas

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // Ambil Kapasitas
                        SqlCommand cmdMax = new SqlCommand("SELECT kapasitas FROM Kelas WHERE idKelas = @kelas", conn);
                        cmdMax.Parameters.AddWithValue("@kelas", idKelas);
                        object res = cmdMax.ExecuteScalar();
                        int max = (res != null) ? Convert.ToInt32(res) : 0;

                        // Hitung Terisi
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
                            btnSimpan.Enabled = true;
                        }
                        else
                        {
                            lblStatus.Text = "PENUH";
                            lblStatus.ForeColor = Color.Red;
                            btnSimpan.Enabled = false;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Gagal pilih data: " + ex.Message); }
            }
        }

        // --- 5. SIMPAN KE JADWAL PRIBADI ---
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

                    SqlCommand cmd = new SqlCommand("INSERT INTO Jadwal_Pribadi (idJadwal, NIS) VALUES (@id, @nis)", conn);
                    cmd.Parameters.AddWithValue("@id", idJadwal);
                    cmd.Parameters.AddWithValue("@nis", nisSiswa);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Jadwal Pribadi Berhasil Disimpan!", "Sukses");
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

        // Event handler kosong agar tidak error
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