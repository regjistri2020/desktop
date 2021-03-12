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
        long lastID;
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
                string theDate = datelindjaTxb.Value.ToShortDateString();
                string Query1 = "insert into Login(User_Name, Pasword, RoleID) VALUES('" + nrpersonalTxb.Text + "','" + a.RandomPassword(10) + "','1' )";
                MySqlCommand cmd = new MySqlCommand(Query1, conn);
                cmd.ExecuteReader();
                lastID = cmd.LastInsertedId;
                MessageBox.Show("U krijua nje login i ri per mesuesin");
                conn.Close();

                conn.Open();
                string Query2 = "insert into Mesues(MesuesID, Emri, Mbiemri, Gjinia, LoginID, nr_tel, datelindja, studimet1, studimet2) values('" + nrpersonalTxb.Text + "','" + emriTxb.Text + "','" + mbiemriTxb.Text + "','" + gjinia + "','" + lastID + "','" + nrtelefoniTxb.Text + "','" + theDate + "' ,'" + studimetTxb1.Text + "','" + studimetTxb2.Text + "' );";
                MySqlCommand cmd1 = new MySqlCommand(Query2, conn);
                cmd1.ExecuteReader();
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

            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gjinia = "mashkull";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gjinia = "femer";
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
