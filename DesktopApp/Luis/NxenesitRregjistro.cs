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
        long lastid;
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
                string query2 = "SELECT KlasaID FROM Klasa WHERE Emri = '"+klasaCombo.Text+"'";
                MySqlCommand cmnd = new MySqlCommand(query2, conn);
                MySqlDataReader MyReader;
                MyReader = cmnd.ExecuteReader();
                int klasaid=0;
                while (MyReader.Read())
                {
                    klasaid = Convert.ToInt32(MyReader["KlasaID"]);
                }
                MessageBox.Show(klasaid.ToString());
                conn.Close();

                conn.Open();
                string theDate = datelindjaTxb.Value.ToShortDateString();
                string Query1 = "insert into Login(User_Name, Pasword, RoleID) VALUES('" + nrpersonalTxb.Text + "','" + a.RandomPassword(10) + "','3' )";
                MySqlCommand cmd = new MySqlCommand(Query1, conn);
                cmd.ExecuteReader();
                lastid = cmd.LastInsertedId;
                MessageBox.Show("U krijua nje login i ri per Nxenesin");
                conn.Close();

                conn.Open();
                string Query2 = "insert into Nxenes(NxenesID, Emri, Mbiemri, Gjinia, LoginID, KlasaID, NrTelPrind, Ditelindja, EmriBabait, EmriMamase) values('" + nrpersonalTxb.Text + "','" + emriTxb.Text + "','" + mbiemriTxb.Text + "','" + gjinia + "','" + lastid + "', '" + klasaid + "','" + nrtel.Text + "','" + theDate + "' ,'" + emerBabai.Text + "','" + emriNenes.Text + "' );";
                MySqlCommand cmd1 = new MySqlCommand(Query2, conn);
                cmd1.ExecuteNonQuery();
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

        private void klasaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
