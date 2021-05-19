using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DesktopApp.Luis;

namespace DesktopApp.Martin
{
    public partial class MesuesDashboardUC : UserControl
    {
        string loginID = CookieClass.LoginID;
        String mID;
        public MesuesDashboardUC()
        {
            InitializeComponent();
        }

        private void DatatextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void MesuesDashboardUC_Load(object sender, EventArgs e)
        {
            string date = DateTime.UtcNow.ToString("dd-MM-yyyy");
            DatatextBox.Clear();
            DatatextBox.Text = Convert.ToString(date);



        }

        private void KlasatextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Datapanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Mesues Where LoginID in (SELECT LoginID From Login WHERE User_Name = '" + loginID + "')";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            MesuestextBox.Text = reader.GetString("Emri") + " " + reader.GetString("Mbiemri");
                            mID = reader.GetString("MesuesID");
                        }
                    }
                }
                connection.Close();
            }

            // SHAFQJA E NJOFTIMEVE

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string query2 = "SELECT Emri, DataEvent, Pershkrim FROM Njoftime WHERE Kategori = 'te dyve' OR Kategori = 'mesues' ";
            MySqlDataAdapter sda = new MySqlDataAdapter(query2, conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

            // NR I mungesave te klases
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select count(*) from Mungesat where KlasaID IN (SELECT KlasaID FROM Klasa WHERE EMRI = '" + KlasatextBox.Text + "') ";
                using (var command = new MySqlCommand(query, connection))
                {
                    object count = command.ExecuteScalar();
                    if (count != null) Mungesa_textBox.Text = count.ToString();
                    else Mungesa_textBox.Text = "0";
                }
                connection.Close();
            }

            // NR I NXENSEVE QE KA NE KLASEN KUJDESTARE TE MESUESES/IT
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select count(*) from Nxenes where Gjinia = 'femer' and KlasaID in (select KlasaID from Klasa where Emri = '" + KlasatextBox.Text + "') ";
                using (var command = new MySqlCommand(query, connection))
                {
                    object count = command.ExecuteScalar();
                    if (count != null) NxenesetextBox.Text = count.ToString();
                    else NxenesetextBox.Text = "  ---  ";
                }
                connection.Close();
            }

            // NR I NXENESVE QE KA NE KLASEN KUJDESTARE TE MESUESES/IT
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select count(*) from Nxenes where Gjinia = 'mashkull' and KlasaID in (select KlasaID from Klasa where Emri = '" + KlasatextBox.Text + "') ";
                using (var command = new MySqlCommand(query, connection))
                {
                    object count = command.ExecuteScalar();
                    if (count != null) NxenestextBox.Text = count.ToString();
                    else NxenestextBox.Text = "  ---  ";
                }
                connection.Close();
            }

            
        }
    }
}
