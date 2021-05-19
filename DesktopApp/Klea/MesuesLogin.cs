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
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace DesktopApp.Martin
{
    public partial class MesuesLogin : Form
    {
      
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
       );
        string connstr = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

        public MesuesLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void closepictureBox_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
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

        private void Hyni_button_Click_1(object sender, EventArgs e)
        {    
            try
            {
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
                    label1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UsernametextBox_Click_1(object sender, EventArgs e)
        {
            UsernametextBox.Text = "";
        }

        private void PasstextBox_Click_1(object sender, EventArgs e)
        {
            PasstextBox.Text = "";
        }

        private void MesuesLogin_Load(object sender, EventArgs e)
        {
            label1.Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
            var a = new Administrator();
            a.Show();
            this.Hide();
        }
    }
}
