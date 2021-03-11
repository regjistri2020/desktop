using DesktopApp.Luis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DesktopApp
{
    public partial class Administrator : Form
    {
        DataSet ds;
        string connstr = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

        public Administrator()
        {
            InitializeComponent();
        }

        private void closepictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BackpictureBox_Click(object sender, EventArgs e)
        {
            var a = new Form1();
            a.Show();
            this.Hide();
        }

        private void Hyni_button_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 149, 237);
            PasstextBox.ForeColor = Color.Black;
            panel3.BackColor = Color.FromArgb(100, 149, 237);
            panel3.ForeColor = Color.Black;

            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            //RoleID = '1' 
            string AdmLog_query = "Select count(*) from Login where User_Name = '" + UsertextBox.Text + "' and Pasword = '" + PasstextBox.Text + "' AND RoleID = 2 ";
            MySqlCommand cmd = new MySqlCommand(AdmLog_query, conn);
            cmd.ExecuteReader();
            conn.Close();

            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (Convert.ToInt32(dt.Rows[0][0]) == 1)
            {
                MessageBox.Show("Vendosja e kredencialeve u krye me sukses!","         " , MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminMain m = new AdminMain();
                m.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Vendosni sakte kredencialet!", " Administratori nuk ekziston ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void minimizepictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txt(object sender, EventArgs e)
        {
            UsertextBox.Clear();
            panel3.BackColor = Color.FromArgb(100, 149, 237);
            UsertextBox.ForeColor = Color.FromArgb(100, 149, 237);

            panel2.BackColor = Color.Black;
            PasstextBox.ForeColor = Color.Gray;
        }

        private void pass(object sender, EventArgs e)
        {
            PasstextBox.Clear();
            panel2.BackColor = Color.FromArgb(100, 149, 237);
            PasstextBox.ForeColor = Color.FromArgb(100, 149, 237);

            UsertextBox.ForeColor = Color.Black;
            panel3.BackColor = Color.Black;
        }
    }
}
