using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Martin
{
    public partial class MesuesLogin : Form
    {
        //SqlDataAdapter sda;
        //DataTable dt;
        //SqlCommandBuilder scb;

        //String connectionsString = "@";

        public MesuesLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UsernamePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void closepictureBox_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void UsernameTextbox_Click(object sender, EventArgs e)
        {
            UsernametextBox.Clear();
            UsernamePanel.BackColor = Color.FromArgb(100, 149, 237);

            PassPanel.BackColor = Color.Black;
        }

        private void PasstextBox_Click(object sender, EventArgs e)
        {
            PasstextBox.Clear();
            PassPanel.BackColor = Color.FromArgb(100, 149, 237);

            UsernamePanel.BackColor = Color.Black;
        }

        private void Hyni_button_Click(object sender, EventArgs e)
        {
            //string query = "Select * from MESUES where Username = '"+ UsernametextBox.Text + "' and Password = '"+ PasstextBox + "' ";
            //SqlConnection con = new SqlConnection(connectionsString);
            //con.Open();
            //sda = new SqlDataAdapter(query, con);
            //sda.SelectCommand.ExecuteNonQuery();

            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //if (dt.Rows[0][0].ToString == "1")
            //{
            //    MessageBox.Show("Logini u krye me sukses! ");
            //    this.Hide();
            //    MesueseMain m = new MesueseMain();
            //    m.Show();
            //}

            //else
            //{
            //    MessageBox.Show("Ju nuk u futet me sukses ne platforme! ");
            //}

            MesuesMain mm = new MesuesMain();
            mm.Show();
            this.Hide();

            //con.Close();
        }
    }
}
