using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Prasarana
{
    public partial class PeminjamanSiswa : Form
    {
        public PeminjamanSiswa()
        {
            InitializeComponent();
            LoadBooks(); DataGridViewButtonColumn btnPinjam =
    new DataGridViewButtonColumn();

            btnPinjam.Name = "Pinjam";
            btnPinjam.HeaderText = "Aksi";
            btnPinjam.Text = "Pinjam";
            btnPinjam.UseColumnTextForButtonValue = true;

            guna2DataGridView1.Columns.Add(btnPinjam);
        }

        private void LoadBooks()
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM buku";

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    guna2DataGridView1.AutoGenerateColumns = true;
                    guna2DataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }


        private void Searc_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT * FROM buku
                             WHERE judul_buku LIKE @search
                             OR pengarang LIKE @search
                             OR penerbit LIKE @search";

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(query, conn);

                    adapter.SelectCommand.Parameters.AddWithValue(
                        "@search", "%" + textBox1.Text + "%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    guna2DataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sinin sinin = new Sinin();
            sinin.Show();
            this.Hide();
        }

        private void DasboardBtnSiswa_Click(object sender, EventArgs e)
        {
            DasboardSiswa ds = new DasboardSiswa();
            ds.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PenembalianSiswa jsk4 = new PenembalianSiswa();
            jsk4.Show();
            this.Hide();
        }

        private void DasboardBtnSiswa_Click_1(object sender, EventArgs e)
        {
            DasboardSiswa ds = new DasboardSiswa();
            ds.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                try
                {
                    using (MySqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();

                        string query = @"SELECT * FROM buku
                    WHERE judul_buku LIKE @search
                    OR pengarang LIKE @search
                    OR penerbit LIKE @search";

                        MySqlDataAdapter adapter =
                            new MySqlDataAdapter(query, conn);

                        adapter.SelectCommand.Parameters.AddWithValue(
                            "@search", "%" + textBox1.Text + "%");

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        guna2DataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
