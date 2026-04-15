namespace UCPPABD
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvJadwal = new System.Windows.Forms.DataGridView();
            this.panelinput = new System.Windows.Forms.GroupBox();
            this.cmbHari = new System.Windows.Forms.ComboBox();
            this.dtpMulai = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKelas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpSelesai = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMapel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbGuru = new System.Windows.Forms.ComboBox();
            this.btnLogoutA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).BeginInit();
            this.panelinput.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvJadwal
            // 
            this.dgvJadwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJadwal.Location = new System.Drawing.Point(156, 450);
            this.dgvJadwal.Name = "dgvJadwal";
            this.dgvJadwal.RowHeadersWidth = 62;
            this.dgvJadwal.RowTemplate.Height = 28;
            this.dgvJadwal.Size = new System.Drawing.Size(611, 150);
            this.dgvJadwal.TabIndex = 0;
            this.dgvJadwal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJadwal_CellContentClick);
            // 
            // panelinput
            // 
            this.panelinput.Controls.Add(this.cmbGuru);
            this.panelinput.Controls.Add(this.label11);
            this.panelinput.Controls.Add(this.label10);
            this.panelinput.Controls.Add(this.label9);
            this.panelinput.Controls.Add(this.label8);
            this.panelinput.Controls.Add(this.label7);
            this.panelinput.Controls.Add(this.btnCetak);
            this.panelinput.Controls.Add(this.btnHapus);
            this.panelinput.Controls.Add(this.btnUbah);
            this.panelinput.Controls.Add(this.btnTambah);
            this.panelinput.Controls.Add(this.label6);
            this.panelinput.Controls.Add(this.cmbMapel);
            this.panelinput.Controls.Add(this.dtpSelesai);
            this.panelinput.Controls.Add(this.label4);
            this.panelinput.Controls.Add(this.cmbKelas);
            this.panelinput.Controls.Add(this.label3);
            this.panelinput.Controls.Add(this.label2);
            this.panelinput.Controls.Add(this.label1);
            this.panelinput.Controls.Add(this.dtpMulai);
            this.panelinput.Controls.Add(this.cmbHari);
            this.panelinput.Location = new System.Drawing.Point(156, 84);
            this.panelinput.Name = "panelinput";
            this.panelinput.Size = new System.Drawing.Size(611, 296);
            this.panelinput.TabIndex = 1;
            this.panelinput.TabStop = false;
            this.panelinput.Text = "Form Input Jadwal";
            // 
            // cmbHari
            // 
            this.cmbHari.FormattingEnabled = true;
            this.cmbHari.Items.AddRange(new object[] {
            "Senin",
            "Selasa",
            "Rabu",
            "Kamis",
            "Jumat",
            "Sabtu"});
            this.cmbHari.Location = new System.Drawing.Point(120, 33);
            this.cmbHari.Name = "cmbHari";
            this.cmbHari.Size = new System.Drawing.Size(121, 28);
            this.cmbHari.TabIndex = 0;
            this.cmbHari.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dtpMulai
            // 
            this.dtpMulai.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpMulai.Location = new System.Drawing.Point(373, 35);
            this.dtpMulai.Name = "dtpMulai";
            this.dtpMulai.ShowUpDown = true;
            this.dtpMulai.Size = new System.Drawing.Size(121, 26);
            this.dtpMulai.TabIndex = 1;
            this.dtpMulai.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pilih hari";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jam Mulai";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pilih Kelas";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbKelas
            // 
            this.cmbKelas.FormattingEnabled = true;
            this.cmbKelas.Location = new System.Drawing.Point(120, 124);
            this.cmbKelas.Name = "cmbKelas";
            this.cmbKelas.Size = new System.Drawing.Size(121, 28);
            this.cmbKelas.TabIndex = 5;
            this.cmbKelas.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Jam Selesai";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dtpSelesai
            // 
            this.dtpSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSelesai.Location = new System.Drawing.Point(373, 76);
            this.dtpSelesai.Name = "dtpSelesai";
            this.dtpSelesai.ShowUpDown = true;
            this.dtpSelesai.Size = new System.Drawing.Size(121, 26);
            this.dtpSelesai.TabIndex = 7;
            this.dtpSelesai.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tabel Jadwal saat ini";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cmbMapel
            // 
            this.cmbMapel.FormattingEnabled = true;
            this.cmbMapel.Location = new System.Drawing.Point(373, 153);
            this.cmbMapel.Name = "cmbMapel";
            this.cmbMapel.Size = new System.Drawing.Size(121, 28);
            this.cmbMapel.TabIndex = 8;
            this.cmbMapel.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Mata Pelajaran";
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(47, 244);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(121, 28);
            this.btnTambah.TabIndex = 10;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(188, 244);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(121, 28);
            this.btnUbah.TabIndex = 11;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(320, 244);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(121, 28);
            this.btnHapus.TabIndex = 12;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCetak
            // 
            this.btnCetak.Location = new System.Drawing.Point(462, 244);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(121, 28);
            this.btnCetak.TabIndex = 13;
            this.btnCetak.Text = "Cetak";
            this.btnCetak.UseVisualStyleBackColor = true;
            this.btnCetak.Click += new System.EventHandler(this.button4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tambah Jadwal";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(184, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ubah Jadwal";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(316, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Hapus Jadwal";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(458, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Cetak Jadwal";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(316, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Guru";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // cmbGuru
            // 
            this.cmbGuru.FormattingEnabled = true;
            this.cmbGuru.Location = new System.Drawing.Point(373, 119);
            this.cmbGuru.Name = "cmbGuru";
            this.cmbGuru.Size = new System.Drawing.Size(121, 28);
            this.cmbGuru.TabIndex = 19;
            // 
            // btnLogoutA
            // 
            this.btnLogoutA.Location = new System.Drawing.Point(783, 27);
            this.btnLogoutA.Name = "btnLogoutA";
            this.btnLogoutA.Size = new System.Drawing.Size(103, 30);
            this.btnLogoutA.TabIndex = 3;
            this.btnLogoutA.Text = "LOG OUT";
            this.btnLogoutA.UseVisualStyleBackColor = true;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 612);
            this.Controls.Add(this.btnLogoutA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelinput);
            this.Controls.Add(this.dgvJadwal);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).EndInit();
            this.panelinput.ResumeLayout(false);
            this.panelinput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJadwal;
        private System.Windows.Forms.GroupBox panelinput;
        private System.Windows.Forms.DateTimePicker dtpMulai;
        private System.Windows.Forms.ComboBox cmbHari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbKelas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpSelesai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMapel;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbGuru;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnLogoutA;
    }
}