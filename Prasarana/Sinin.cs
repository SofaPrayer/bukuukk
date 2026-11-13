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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace Prasarana
{
    public partial class Sinin : Form
    {
        public Sinin()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }


        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            // Get values from textboxes
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    // Check Admin
                    string adminQuery = @"SELECT id_admin
                FROM admin
                WHERE username = @username
                AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(adminQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            UserSession.Role = "Admin";

                            Form2 admin = new Form2();
                            admin.Show();
                            this.Hide();
                            return;
                        }
                    }

                    // Check Student
                    string studentQuery = @"SELECT id_anggota, nama_anggota
                FROM anggota
                WHERE username = @username
                AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(studentQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserSession.IdAnggota =
                                    Convert.ToInt32(reader["id_anggota"]);

                                UserSession.NamaAnggota =
                                    reader["nama_anggota"].ToString();

                                UserSession.Role = "Siswa";

                                DasboardSiswa siswa = new DasboardSiswa();
                                siswa.Show();
                                this.Hide();
                                return;
                            }
                        }
                    }

                    MessageBox.Show("Username atau Password salah!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }



        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}
