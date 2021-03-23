using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using MySql.Data.MySqlClient;
using DesktopApp.Luis;

namespace DesktopApp.Martin
{
    public partial class MungesaUC : UserControl
    {

        string nxenesID;

        DataTable table = new DataTable();

        public MungesaUC()
        {
            InitializeComponent();
        }

        private void Kerkobutton_Click(object sender, EventArgs e)
        {
             
        }


        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                try
                {
                    if (Row.Cells["Mungesa"].Value.ToString() == "True")
                    {
                        int tradeID = Convert.ToInt32(dataGridView1.Rows[Row.Index].Cells["NxenesID"].Value.ToString());
                        // Write Update Query for the ID received here 
                        var src = DateTime.Now;
                        var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);

                        var query = " Insert Into Mungesat ( NxenesID, LendaID, MesuesID, TemaID, DATAT, KlasaID) VALUES ('" + tradeID + "', '" + CookieClass.LendaID + "', '" + CookieClass.MesuesID.ToString() + "', '" + CookieClass.TemaID.ToString() + "', '" + hm.ToString() + "', '" + CookieClass.KlasaID.ToString() + "')";

                        MySqlConnection conn = new MySqlConnection("server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME");
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Mungesat u vendosen me sukses!");
                    }
                }

                catch(Exception ex)
                {

                }
            }


            var accountSid = "AC3648693fb0ccb73d81ffbf42186b6248";
            var authToken = "dd6ae58115bf55404da4e875ec0f66c8";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+355686888201"));
            messageOptions.MessagingServiceSid = "MGc2b6f0ceb144dbb8149397ffe352017c";
            messageOptions.Body = "Ky eshte nje mesazh i automatizuar nga platforma e nxenesit.al";

            //var message = MessageResource.Create(messageOptions);
            //Console.WriteLine(message.Body);
        }

        private void KerkonxComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fullName = KerkonxComboBox.Text;
            var names = fullName.Split(' ');
            var firstName = names[0];
            var lastName = names[1];

            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select * from Nxenes where KlasaID in (Select KlasaID from Klasa where Emri = '" + label4.Text + "') ";
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
                var query = "Select NxenesID, Emri, Mbiemri from Nxenes where KlasaID in (Select KlasaID from Klasa where Emri = '" + label4.Text + "') and Emri = '"+ firstName + "' and Mbiemri = '" + lastName + "'  ";
                using (var da = new MySqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dt.Columns.Add(new DataColumn("Mungesa", typeof(bool)));
                }
                connection.Close();
            }
        }

        private void KerkonxComboBox_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //MBUSHJA E COMBOBOX ME EMRAT DHE MBIEMRAT E NXENESVE
            label4.Text = CookieClass.Klasa;

            KerkonxComboBox.Items.Clear();
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select * from Nxenes where KlasaID in (Select KlasaID from Klasa where Emri = '" + label4.Text + "' )";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            KerkonxComboBox.Items.Add(reader.GetString("Emri") + " " + reader.GetString("Mbiemri"));
                        }
                    }
                }
            }

            //MBUSHJA E DATAGRIDVIEW
            
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select NxenesID, Emri, Mbiemri from Nxenes where KlasaID in (Select KlasaID from Klasa where Emri = '" + label4.Text + "') ";
                using (var da = new MySqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dt.Columns.Add(new DataColumn("Mungesa", typeof(bool)));
                }
                connection.Close();
            }
        }
    }
}
