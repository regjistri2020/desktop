using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace DesktopApp.Luis
{
	public partial class VleresoNxenesitUC : UserControl
	{
        string nxenesID;
        long lastTemaId;
        
        
		public VleresoNxenesitUC()
		{
			InitializeComponent();
		}


		private void pictureBox2_Click(object sender, EventArgs e)
		{
            
        }

		private void button2_Click(object sender, EventArgs e)
		{
            try
            {
                MySqlConnection conn = new MySqlConnection("server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Notat (NxenesID, TemaMesimoreID, Nota, Shenime, Kategoria) VALUES ('"+int.Parse(nxenesID)+"', '"+Convert.ToInt32(lastTemaId)+"', '"+int.Parse(textBox3.Text)+"', '"+textBox4.Text+"', '"+comboBox4.Text+"')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Nota e nxenesit u vendos!");
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ka nje gabim teknik:" + ex.Message + "\t" + ex.GetType());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string theDate = dateTimePicker1.Value.ToShortDateString();
                MySqlConnection conn = new MySqlConnection("server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO TematMesimore (DataTemes, MesuesID, LendaID, KlasaID, TemaMesimore) VALUES ('"+theDate+ "', '" + CookieClass.MesuesID+ "', '" + CookieClass.LendaID + "', '" + CookieClass.KlasaID + "', '" + textBox1.Text + "');", conn);
                cmd.ExecuteNonQuery();
                lastTemaId = cmd.LastInsertedId;
                MessageBox.Show("Tema u shtua me sukses!" + lastTemaId);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ka nje gabim teknik:" + ex.Message + "\t" + ex.GetType());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VleresoNxenesitUC_Load(object sender, EventArgs e)
        {
            
         
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            var a = new TematMesimore();
            a.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CookieClass.Klasa = comboBox1.Text;

            comboBox3.Items.Clear();
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Nxenes WHERE KlasaID IN (SELECT KlasaID FROM Klasa WHERE Emri = '"+comboBox1.Text+"')";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            comboBox3.Items.Add(reader.GetString("Emri")+" "+ reader.GetString("Mbiemri"));
                        }
                    }
                }
            }


            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT KlasaID FROM Klasa where Emri = '"+comboBox1.Text+"'";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            CookieClass.KlasaID = reader.GetString("KlasaID");
                        }
                    }
                }
            }

            comboBox2.Items.Clear();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT EmerLende FROM Lendet WHERE LendaID in (SELECT LendaID FROM Jep_Mesim WHERE MesuesID = '"+CookieClass.MesuesID+"' AND KlasaID in (SELECT KlasaID from Klasa where Emri = '"+comboBox1.Text+"'))";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader.GetString("EmerLende"));
                        }
                    }
                }
            }



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CookieClass.Lenda = comboBox2.Text;

            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT LendaID FROM Lendet where EmerLende = '" + comboBox2.Text + "'";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            CookieClass.LendaID = reader.GetString("LendaID");
                        }
                    }
                }
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Emri FROM Klasa WHERE KlasaID in (SELECT KlasaID FROM Jep_Mesim WHERE MesuesID = '" + CookieClass.MesuesID + "')";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader.GetString("Emri"));
                        }
                    }
                }
            }



        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fullName = comboBox3.Text;
            var names = fullName.Split(' ');
            string firstName = names[0];
            string lastName = names[1];


            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT NxenesID from Nxenes WHERE KlasaID = '" + CookieClass.KlasaID + "' AND Emri = '" + firstName + "' AND Mbiemri = '" +lastName +"'";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            nxenesID = reader.GetString("NxenesID");
                        }
                    }
                }
            }


            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Notat.Nota, TematMesimore.TemaMesimore, Notat.Shenime, Notat.Kategoria FROM Notat JOIN Nxenes ON Nxenes.NxenesID=Notat.NxenesID JOIN TematMesimore ON TematMesimore.TemaMesimoreID=Notat.TemaMesimoreID WHERE Nxenes.NxenesID in (SELECT NxenesID FROM Nxenes WHERE Emri = '"+firstName+"' AND Mbiemri = '"+lastName+"') AND TematMesimore.LendaID = '"+CookieClass.LendaID+"'";
                using (var da = new MySqlDataAdapter(query, connection))
                {
                    var ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                connection.Close();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
