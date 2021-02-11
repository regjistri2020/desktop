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

namespace DesktopApp.Luis
{
    public partial class NxenesitRregjistro : UserControl
    {
        string gjinia;
        public NxenesitRregjistro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = new Generator();

            try
            {
                string connstr = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                string query = "SELECT LoginID FROM Login ORDER BY LoginID DESC LIMIT 1";
                string query2 = "SELECT KlasaID FROM Klasa WHERE Emri = '"+klasaCombo.Text+"'";
                MySqlCommand cmnd = new MySqlCommand(query, conn);
                MySqlDataReader MyReader;
                MyReader = cmnd.ExecuteReader();
                int lastid = 0;
                while (MyReader.Read())
                {
                    lastid = Convert.ToInt32(MyReader["LoginID"]) + 1;
                }conn.Close();
                conn.Open();
                cmnd.CommandText = query2;
                MySqlDataReader MyReader1;
                MyReader1 = cmnd.ExecuteReader();
                int klasaid=0;
                while (MyReader1.Read())
                {
                    klasaid = Convert.ToInt32(MyReader1["KlasaID"]);
                }
                MessageBox.Show(klasaid.ToString());

                conn.Close();

                conn.Open();
                string theDate = datelindjaTxb.Value.ToShortDateString();
                MessageBox.Show(theDate);
                string Query1 = "insert into Login(User_Name, Pasword, RoleID) VALUES('" + nrpersonalTxb.Text + "','" + a.RandomPassword(10) + "','3' )";
                string Query2 = "insert into Nxenes(NxenesID, Emri, Mbiemri, Gjinia, LoginID, KlasaID, NrTelPrind, Ditelindja, EmriBabait, EmriMamase) values('" + nrpersonalTxb.Text + "','" + emriTxb.Text + "','" + mbiemriTxb.Text + "','" + gjinia + "','" + lastid + "','" + nrtel.Text + "','" + theDate + "' ,'" + emerBabai.Text + "','" + emriNenes.Text + "' );";

                MySqlCommand cmd = new MySqlCommand(Query1, conn);
                MySqlCommand cmd1 = new MySqlCommand(Query2, conn);


                MyReader = cmd.ExecuteReader();
                while (MyReader.Read())
                {
                }
                MessageBox.Show("U krijua nje login i ri per Nxenesin");
                conn.Close();

                conn.Open();

                MyReader = cmd1.ExecuteReader();
                while (MyReader.Read())
                {
                }
                MessageBox.Show("Rregjistrimi i nxenesit u krye me sukses.");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            emriTxb.Text = "";
            mbiemriTxb.Text = "";
            datelindjaTxb.Text = "";
            nrpersonalTxb.Text = "";
            klasaCombo.Text = "";
            nrtel.Text = "";
            emerBabai.Text = "";
            emriNenes.Text = ""; 
        }

        private void NxenesitRregjistro_Load(object sender, EventArgs e)
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
                            klasaCombo.Items.Add(reader.GetString("Emri"));
                        }
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gjinia = "mashkull";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gjinia = "femer";
        }
    }
}
