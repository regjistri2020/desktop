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

		public VleresoNxenesitUC()
		{
			InitializeComponent();
		}


		private void pictureBox2_Click(object sender, EventArgs e)
		{
            
        }

		private void button2_Click(object sender, EventArgs e)
		{

		}

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VleresoNxenesitUC_Load(object sender, EventArgs e)
        {
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Emri FROM Klasa";
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
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CookieClass.Lenda = comboBox2.Text;
        }
    }
}
