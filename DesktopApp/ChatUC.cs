using DesktopApp.Luis;
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

namespace DesktopApp
{
    public partial class ChatUC : UserControl
    {
        string nxenesID, klasaID;
        public ChatUC()
        {
            InitializeComponent();
        }

        private void ChatUC_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (3 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer1_Tick_1);
            timer.Start();
        }
        void datarefresher()
        {
            listBox1.Items.Clear();
            try
            {
                var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT * FROM Mesazhe WHERE (Sender = '" + CookieClass.LoginID + "' AND Reciever = '" + nxenesID + "') OR (Sender = '" + nxenesID + "' AND Reciever = '" + CookieClass.LoginID + "') ";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {

                                if (reader.GetString("Sender") == CookieClass.LoginID)
                                {
                                    listBox1.Items.Add("Une: " + reader.GetString("Mesazhi"));
                                }
                                else
                                {
                                    listBox1.Items.Add("Prindi i nxenesit: " + reader.GetString("Mesazhi"));
                                }
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                string theDate = DateTime.Now.ToString();
                CookieClass.Data = theDate;
                MySqlConnection conn = new MySqlConnection("server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Mesazhe(Mesazhi, DateOra, Sender, Reciever) VALUES('"+textBox1.Text+"','"+theDate+"','"+CookieClass.LoginID+"','"+nxenesID+"')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                datarefresher();
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ka nje gabim teknik:" + ex.Message + "\t" + ex.GetType());
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            try
            {
                            using (var connection = new MySqlConnection(connectionString))
                            {
                                connection.Open();
                                var query = "SELECT KlasaID FROM Klasa where Emri = '"+label5.Text+"'";
                                using (var command = new MySqlCommand(query, connection))
                                {
                                    using (var reader = command.ExecuteReader())
                                    {
                                        //Iterate through the rows and add it to the combobox's items
                                        while (reader.Read())
                                        {
                                            klasaID = reader.GetString("KlasaID");
                                        }
                                    }
                                }
                                connection.Close();
                            }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Nxenes WHERE KlasaID = '" + klasaID + "'";
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
                connection.Close();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            datarefresher();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            datarefresher();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fullName = comboBox1.Text;
            label4.Text = "Mesazhet me prindin e nxenesit " + fullName;
            var names = fullName.Split(' ');
            var firstName = names[0];
            var lastName = names[1];

            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT NxenesID from Nxenes WHERE KlasaID = '" + klasaID + "' AND Emri = '" + firstName + "' AND Mbiemri = '" + lastName + "'";
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
                connection.Close();
            }
            datarefresher();
        }
    }
}
