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
    public partial class PenembalianSiswa : Form
    {
        public PenembalianSiswa()
        {
            InitializeComponent(); LoadPengembalian();
        }
        private void LoadPengembalian()
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM transaksi";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        ddvPengembalian.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Sinin sinin = new Sinin();
            sinin.Show();
            this.Hide();
        }

        private void DasboardBtnSiswa_Click(object sender, EventArgs e)
        {
            DasboardSiswa sinins = new DasboardSiswa();
            sinins.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PeminjamanSiswa sininss = new PeminjamanSiswa();
            sininss.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ddvPengembalian_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
