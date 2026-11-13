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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent(); LoadUsers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sinin sinin = new Sinin();
            sinin.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PenembalianAdmin jsk = new PenembalianAdmin();
            jsk.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PeminjamanAdmin jsk2 = new PeminjamanAdmin();
            jsk2.Show();
            this.Hide();
        }

        private void DasboardBtnSiswa_Click(object sender, EventArgs e)
        {
            Form2 jsk3 = new Form2();
            jsk3.Show();
            this.Hide();
        }
        private void LoadUsers()
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM anggota";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvUsers.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Users Error: " + ex.Message);
            }
        }
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
