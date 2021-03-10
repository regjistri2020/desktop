using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopApp.Luis;

namespace DesktopApp.Martin
{
    public partial class MesuesLogin : Form
    {
        
        string connstr = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

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
            UsernametextBox.ForeColor = Color.Gray;
            UsernametextBox.Clear();
            UsernamePanel.BackColor = Color.FromArgb(100, 149, 237);
            UsernametextBox.ForeColor = Color.FromArgb(100, 149, 237);

            PassPanel.BackColor = Color.Black;
            PasstextBox.ForeColor = Color.Gray;
        }

        private void PasstextBox_Click(object sender, EventArgs e)
        {
            PasstextBox.ForeColor = Color.Gray;
            PasstextBox.Clear();
            PassPanel.BackColor = Color.FromArgb(100, 149, 237);
            PasstextBox.ForeColor = Color.FromArgb(100, 149, 237);

            UsernametextBox.ForeColor = Color.Black;
            UsernamePanel.BackColor = Color.Black;
        }

        private void Hyni_button_Click(object sender, EventArgs e)
        {
            PassPanel.BackColor = Color.FromArgb(100, 149, 237);
            PasstextBox.ForeColor = Color.Black;
            UsernamePanel.BackColor = Color.FromArgb(100, 149, 237);
            UsernamePanel.ForeColor = Color.Black;

            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            //RoleID = '1' 
            string MesLog_query = "Select count(*) from Login where User_Name = '" + UsernametextBox.Text + "' and Pasword = '" + PasstextBox.Text + "' AND RoleID = 1 ";
            MySqlCommand cmd = new MySqlCommand(MesLog_query, conn);
            cmd.ExecuteReader();
            
            conn.Close();

            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (Convert.ToInt32(dt.Rows[0][0]) == 1)
            {
                CookieClass.LoginID = UsernametextBox.Text;
                MessageBox.Show("Vendosja e kredencialeve u krye me sukses!", "         ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MesuesMain m = new MesuesMain();
                m.Show();
                this.Hide();

                
            }
            else
                MessageBox.Show("Vendosni sakte kredencialet!", " Mësuesi nuk ekziston ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void minimizepictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BackpictureBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void UsernametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
