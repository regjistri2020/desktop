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

namespace DesktopApp
{
    public partial class Administrator : Form
    {
        DataSet ds;
        string connstr = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

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

        public Administrator()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void closepictureBox_Click(object sender, EventArgs e)
        {
            var a = new Form1();
            a.Show();
            this.Close();
        }

        private void BackpictureBox_Click(object sender, EventArgs e)
        {
            var a = new Form1();
            a.Show();
            this.Hide();
        }

        


        private void minimizepictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Vendosja e kredencialeve u krye me sukses!", "         ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminMain m = new AdminMain();
                m.Show();
                this.Hide();
            }
            else
                label1.Show();
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            label1.Hide();
        }
    }
}
