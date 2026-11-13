using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prasarana
{
    public partial class DasboardSiswa : Form
    {
        public DasboardSiswa()
        {
            InitializeComponent(); LoadDashboard();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                Sinin sinin = new Sinin();
                sinin.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PeminjamanSiswa ps = new PeminjamanSiswa();
            ps.Show();
            this.Hide();
        }

        private void DasboardBtnSiswa_Click(object sender, EventArgs e)
        {

        }
        private void LoadDashboard()
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    // Total Books
                    string queryBuku = "SELECT COUNT(*) FROM buku";

                    using (MySqlCommand cmd = new MySqlCommand(queryBuku, conn))
                    {
                        lblTotalBuku.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Total Registered Students
                    string queryAnggota = "SELECT COUNT(*) FROM anggota";

                    using (MySqlCommand cmd = new MySqlCommand(queryAnggota, conn))
                    {
                        lblTotalAnggota.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Currently Borrowed Books
                    string queryPinjam = @"SELECT COUNT(DISTINCT id_buku)
                FROM transaksi
                WHERE status_transaksi = 'Dipinjam'";

                    using (MySqlCommand cmd = new MySqlCommand(queryPinjam, conn))
                    {
                        lblBukuDipinjam.Text = cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard Error: " + ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            PenembalianSiswa ps2
                = new PenembalianSiswa();
            ps2.Show();
            this.Hide();
        }
    }
}
