using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace DesktopApp.Luis
{
	public partial class MesuesitRegjistroUC : UserControl
	{

        
        string gjinia;
        public MesuesitRegjistroUC()
		{
			InitializeComponent();
		}

		private void MesuesitRegjistroUC_Load(object sender, EventArgs e)
		{
            

		}

        
        private void button1_Click(object sender, EventArgs e)
		{
            var a = new Generator();
            
            try
            {   
                string connstr= "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                string query = "SELECT LoginID FROM Login ORDER BY LoginID DESC LIMIT 1";
                MySqlCommand cmnd = new MySqlCommand(query, conn);
                MySqlDataReader MyReader;
                MyReader = cmnd.ExecuteReader();
                int lastid = 0;
                while (MyReader.Read())
                {
                    lastid = Convert.ToInt32(MyReader["LoginID"]) + 1;
                }
                
                conn.Close();

                conn.Open();
                string Query1 = "insert into Login(User_Name, Pasword, RoleID) VALUES('" + nrpersonalTxb.Text + "','" + a.RandomPassword(10) + "','1' )";
                string Query2 = "insert into Mesues(MesuesID, Emri, Mbiemri, Gjinia, LoginID) values('" + nrpersonalTxb.Text + "','" + emriTxb.Text + "','" + mbiemriTxb.Text + "','" + gjinia + "','"+ lastid +"');";
                
                MySqlCommand cmd = new MySqlCommand(Query1, conn);
                MySqlCommand cmd1 = new MySqlCommand(Query2, conn);
                
                MyReader = cmd.ExecuteReader();
                while (MyReader.Read())
                {
                }
                MessageBox.Show("U krijua nje login i ri per mesuesin");
                conn.Close();

                conn.Open();

                MyReader = cmd1.ExecuteReader();
                while (MyReader.Read())
                {
                }
                MessageBox.Show("Rregjistrimi i mësuesit u krye me sukses.");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            emriTxb.Text = "";
            mbiemriTxb.Text = "";
            nrtelefoniTxb.Text = "";
            datelindjaTxb.Text = "";
            nrpersonalTxb.Text = "";
            studimetTxb1.Text = "";
            studimetTxb2.Text = "";
            lendaTxb1.Text = "";
            lendaTxb2.Text = "";

            

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
