using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopApp.Luis;
using MySql.Data.MySqlClient;

namespace DesktopApp.Klea
{
    public partial class JustifikoMungesatUC : UserControl
    {
        string nxenesID;
        public JustifikoMungesatUC()
        {
            InitializeComponent();
        }

        private void JustifikoMungesatUC_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fullName = comboBox3.Text;
            comboBox3.Text = fullName;
            var names = fullName.Split(' ');
            var firstName = names[0];
            var lastName = names[1];

            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT NxenesID from Nxenes WHERE KlasaID in (SELECT KlasaID FROM Klasa WHERE Emri = '" + textBox4.Text + "') AND Emri = '" + firstName + "' AND Mbiemri = '" + lastName + "'";
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
            DataGridRefresher();
        }
        void DataGridRefresher()
        {
            
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select b.EmerLende, a.DATAT, a.Justifikuar from Mungesat a, Lendet b where a.LendaID = b.LendaID and a.NxenesID = '" + nxenesID + "'; ";
                   using (var da = new MySqlDataAdapter(query, connection))
                {
                    var ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                connection.Close();
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT * FROM Nxenes WHERE KlasaID IN (SELECT KlasaID FROM Klasa WHERE Emri = '" + textBox4.Text + "')";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                comboBox3.Items.Add(reader.GetString("Emri") + " " + reader.GetString("Mbiemri"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
