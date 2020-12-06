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

namespace DesktopApp.Luis
{
	public partial class MesuesitRegjistroUC : UserControl
	{
        SqlDataAdapter adap;
        SqlConnection con;
        DataSet ds;
        SqlCommandBuilder cmd;
        string gjinia;
        public MesuesitRegjistroUC()
		{
			InitializeComponent();
		}

		private void MesuesitRegjistroUC_Load(object sender, EventArgs e)
		{

		}


        // Instantiate random number generator.  
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        // Generates a random string with a given size.    
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public string RandomPassword(int size = 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(RandomString(4, true));
                builder.Append(RandomNumber(1000, 9999));
                builder.Append(RandomString(2, false));
                return builder.ToString();
            }
        

        private void button1_Click(object sender, EventArgs e)
		{
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\developer\source\repos\desktop\DesktopApp\e-nxenesit.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();

            SqlCommand scmd = con.CreateCommand();
            scmd.CommandType = CommandType.Text;
            scmd.CommandText = " Insert into Mesues(MesuesID, Emri, Mbiemri, Lenda1, Lenda2, MesuesPass, Gjinia) values ('" + nrpersonalTxb.Text + "','" + emriTxb.Text + "','" + mbiemriTxb.Text + "','" + lendaTxb1.Text + "','" + lendaTxb2.Text + "','"+ RandomPassword() + "','" + gjinia + "')";
            scmd.ExecuteNonQuery();

            emriTxb.Text = "";
            mbiemriTxb.Text = "";
            nrtelefoniTxb.Text = "";
            datelindjaTxb.Text = "";
            nrpersonalTxb.Text = "";
            studimetTxb1.Text = "";
            studimetTxb2.Text = "";
            lendaTxb1.Text = "";
           lendaTxb2.Text = "";

            MessageBox.Show("Rregjistrimi i mësuesit u krye me sukses.");

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
