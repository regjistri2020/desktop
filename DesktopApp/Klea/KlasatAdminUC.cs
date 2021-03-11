using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopApp.Luis;
using MySql.Data.MySqlClient;

namespace DesktopApp.Klea
{
    public partial class KlasatAdminUC : UserControl
    {
        string mesuesID;
        MySqlCommandBuilder cmb;
        MySqlDataAdapter da;
        DataSet ds;
        MySqlConnection conn;
        string connstring = @"server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
        int index;
        public KlasatAdminUC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dataGridRefresher();
        }
        void dataGridRefresher()
        {
            conn = new MySqlConnection(connstring);
            conn.Open();
            string query = "select Klasa.KlasaID, Klasa.Emri, Mesues.Emri from Klasa, Mesues Where Klasa.MesuesID = Mesues.MesuesID ";
            da = new MySqlDataAdapter(query, conn);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KlasatAdminUC_Load(object sender, EventArgs e)
        {
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Emri, Mbiemri FROM Mesues";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader.GetString("Emri") + " " + reader.GetString("Mbiemri"));
                        }
                    }
                }
            }

            dataGridRefresher();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string connstr = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
                MySqlConnection conn = new MySqlConnection(connstr);

                conn.Open();
                string Query1 = "insert into Klasa (Emri, MesuesID) Values('" + klasaTxb.Text + "', '" + mesuesID + "'); ";

                MySqlCommand cmd = new MySqlCommand(Query1, conn);
                cmd.ExecuteReader();

                MessageBox.Show("Klasa u krijua me sukses!");
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fullName = comboBox1.Text;
            var names = fullName.Split(' ');
            string firstName = names[0];
            string lastName = names[1];

            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT MesuesID FROM Mesues where Emri = '"+firstName+"' and Mbiemri = '"+lastName+"' ";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            mesuesID = reader.GetString("MesuesID");
                        }
                    }
                }
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmb = new MySqlCommandBuilder(da);
            da.Update(ds);
            conn.Close();

        }
    }


       
   
    }

