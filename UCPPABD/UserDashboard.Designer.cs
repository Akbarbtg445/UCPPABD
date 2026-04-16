namespace UCPPABD
{
    partial class UserDashboard
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNIS = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKelas = new System.Windows.Forms.ComboBox();
            this.dgvJadwal = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPilihkelas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMapel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCetak = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSisa = new System.Windows.Forms.Label();
            this.lblTerisi = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(796, 73);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(105, 34);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblNIS);
            this.panel1.Controls.Add(this.lblNama);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 55);
            this.panel1.TabIndex = 1;
            // 
            // lblNIS
            // 
            this.lblNIS.AutoSize = true;
            this.lblNIS.Location = new System.Drawing.Point(566, 19);
            this.lblNIS.Name = "lblNIS";
            this.lblNIS.Size = new System.Drawing.Size(36, 20);
            this.lblNIS.TabIndex = 1;
            this.lblNIS.Text = "NIS";
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(310, 19);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(51, 20);
            this.lblNama.TabIndex = 0;
            this.lblNama.Text = "Nama";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCari);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbKelas);
            this.groupBox1.Location = new System.Drawing.Point(29, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 114);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lihat Jadwal Kelas";
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(134, 74);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(75, 34);
            this.btnCari.TabIndex = 2;
            this.btnCari.Text = "CARI";
            this.btnCari.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kelas";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbKelas
            // 
            this.cmbKelas.FormattingEnabled = true;
            this.cmbKelas.Location = new System.Drawing.Point(134, 35);
            this.cmbKelas.Name = "cmbKelas";
            this.cmbKelas.Size = new System.Drawing.Size(121, 28);
            this.cmbKelas.TabIndex = 0;
            // 
            // dgvJadwal
            // 
            this.dgvJadwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJadwal.Location = new System.Drawing.Point(218, 233);
            this.dgvJadwal.Name = "dgvJadwal";
            this.dgvJadwal.ReadOnly = true;
            this.dgvJadwal.RowHeadersWidth = 62;
            this.dgvJadwal.RowTemplate.Height = 28;
            this.dgvJadwal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJadwal.Size = new System.Drawing.Size(450, 183);
            this.dgvJadwal.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSimpan);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbPilihkelas);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMapel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnCetak);
            this.groupBox2.Location = new System.Drawing.Point(556, 465);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 230);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit Jadwal Pribadi";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(14, 194);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 36);
            this.btnSimpan.TabIndex = 7;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Simpan Perubahan";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // cmbPilihkelas
            // 
            this.cmbPilihkelas.FormattingEnabled = true;
            this.cmbPilihkelas.Location = new System.Drawing.Point(160, 82);
            this.cmbPilihkelas.Name = "cmbPilihkelas";
            this.cmbPilihkelas.Size = new System.Drawing.Size(129, 28);
            this.cmbPilihkelas.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pilih Kelas";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtMapel
            // 
            this.txtMapel.Location = new System.Drawing.Point(160, 40);
            this.txtMapel.Name = "txtMapel";
            this.txtMapel.Size = new System.Drawing.Size(129, 26);
            this.txtMapel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mata Pelajaran";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cetak Jadwal Pribadi";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnCetak
            // 
            this.btnCetak.Location = new System.Drawing.Point(214, 194);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(75, 30);
            this.btnCetak.TabIndex = 0;
            this.btnCetak.Text = "Cetak";
            this.btnCetak.UseVisualStyleBackColor = true;
            this.btnCetak.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblStatus);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.lblSisa);
            this.groupBox3.Controls.Add(this.lblTerisi);
            this.groupBox3.Controls.Add(this.lblMax);
            this.groupBox3.Location = new System.Drawing.Point(67, 465);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 224);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cek Kapasitas";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(256, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Penuh";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(147, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "Tersedia";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // lblSisa
            // 
            this.lblSisa.AutoSize = true;
            this.lblSisa.Location = new System.Drawing.Point(11, 149);
            this.lblSisa.Name = "lblSisa";
            this.lblSisa.Size = new System.Drawing.Size(86, 20);
            this.lblSisa.TabIndex = 2;
            this.lblSisa.Text = "Sisa Kuota";
            // 
            // lblTerisi
            // 
            this.lblTerisi.AutoSize = true;
            this.lblTerisi.Location = new System.Drawing.Point(11, 90);
            this.lblTerisi.Name = "lblTerisi";
            this.lblTerisi.Size = new System.Drawing.Size(147, 20);
            this.lblTerisi.TabIndex = 1;
            this.lblTerisi.Text = "Jumlah Siswa Terisi";
            this.lblTerisi.Click += new System.EventHandler(this.label9_Click);
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(11, 46);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(149, 20);
            this.lblMax.TabIndex = 0;
            this.lblMax.Text = "Kapasitas Maksimal";
            this.lblMax.Click += new System.EventHandler(this.label8_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(205, 112);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 20);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status";
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 720);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvJadwal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLogout);
            this.Name = "UserDashboard";
            this.Text = "UserDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvJadwal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKelas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMapel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPilihkelas;
        private System.Windows.Forms.Label lblNIS;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblSisa;
        private System.Windows.Forms.Label lblTerisi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblStatus;
    }
}