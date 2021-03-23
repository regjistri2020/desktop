using DesktopApp.Luis;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace DesktopApp.Martin
{
    public partial class MesuesMain : Form
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

        string loginID = CookieClass.LoginID;
        String mID;
        public MesuesMain()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MesuesMain_Load(object sender, EventArgs e)
        {

            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Mesues Where LoginID in (SELECT LoginID From Login WHERE User_Name = '" + loginID + "')";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            label2.Text = reader.GetString("Emri") + " " + reader.GetString("Mbiemri");
                            mID = reader.GetString("MesuesID");
                            CookieClass.MesuesID = mID;
                            mesuesDashboardUC1.MesuestextBox.Text= reader.GetString("Emri") + " " + reader.GetString("Mbiemri");
                        }
                    }
                }
                connection.Close();
            }

            //SHAQFJA E NJOFTIMEVE PER MESUESIT
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string query2 = "SELECT Emri, DataEvent, Pershkrim FROM Njoftime WHERE Kategori = 'te dyve' OR Kategori = 'mesues' ";
            MySqlDataAdapter sda = new MySqlDataAdapter(query2, conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            mesuesDashboardUC1.dataGridView1.DataSource = dt;
            conn.Close();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select Emri from Klasa where  MesuesID = '" + mID + "' ";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            mesuesDashboardUC1.KlasatextBox.Text = reader.GetString("Emri") ;
                            justifikoMungesatUC1.textBox4.Text = reader.GetString("Emri");
                            MungesaUC.label4.Text = reader.GetString("Emri");
                            chatUC1.label5.Text = reader.GetString("Emri");
                        }
                    }
                }
                connection.Close();
            }

            // NR I mungesave te klases kujdestare
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select count(*) from Mungesat where KlasaID IN (SELECT KlasaID FROM Klasa WHERE EMRI = '" + mesuesDashboardUC1.KlasatextBox.Text + "') ";
                using (var command = new MySqlCommand(query, connection))
                {
                    object count = command.ExecuteScalar();
                    if (count != null) mesuesDashboardUC1.Mungesa_textBox.Text = count.ToString();
                    else mesuesDashboardUC1.Mungesa_textBox.Text = "0";
                }
                connection.Close();
            }

            // NR I NXENSEVE QE KA NE KLASEN KUJDESTARE TE MESUESES/IT
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select count(*) from Nxenes where Gjinia = 'femer' and KlasaID in (select KlasaID from Klasa where Emri = '" + mesuesDashboardUC1.KlasatextBox.Text + "') ";
                using (var command = new MySqlCommand(query, connection))
                {
                    object count = command.ExecuteScalar();
                    if (count != null) mesuesDashboardUC1.NxenesetextBox.Text = count.ToString();
                    else mesuesDashboardUC1.NxenesetextBox.Text = "  ---  ";
                }
                connection.Close();
            }

            // NR I NXENESVE QE KA NE KLASEN KUJDESTARE TE MESUESES/IT
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select count(*) from Nxenes where Gjinia = 'mashkull' and KlasaID in (select KlasaID from Klasa where Emri = '" + mesuesDashboardUC1.KlasatextBox.Text + "') ";
                using (var command = new MySqlCommand(query, connection))
                {
                    object count = command.ExecuteScalar();
                    if (count != null) mesuesDashboardUC1.NxenestextBox.Text = count.ToString();
                    else mesuesDashboardUC1.NxenestextBox.Text = "  ---  ";
                }
                connection.Close();
            }

            int nr_nxe = Convert.ToInt32(mesuesDashboardUC1.NxenesetextBox.Text + mesuesDashboardUC1.NxenestextBox.Text);
       



            CookieClass.MesuesID = mID;

            hideSubMenu();
            MungesaUC.Hide();
            vleresoNxenesitUC1.Hide();
            fletTremujori1.Hide();
            justifikoMungesatUC1.Hide();
            mesuesDashboardUC1.Show();
            notaTremujoriUC1.Hide();
        }

        private void hideSubMenu()
        {
            if (MesimdhenieSub.Visible == true)
                MesimdhenieSub.Visible = false;
            if (KujdestariaSub.Visible == true)
                KujdestariaSub.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void MesimdhenieButton_Click(object sender, EventArgs e)
        {
            showSubMenu(MesimdhenieSub);
        }

        private void VleresonxenesButton_Click(object sender, EventArgs e)
        {
            VleresonxenesButton.BackColor = Color.FromArgb(135, 190, 235);
            MungesatButton.BackColor = Color.FromArgb(135, 206, 235);

            vleresoNxenesitUC1.BringToFront();
            vleresoNxenesitUC1.Show();
            fletTremujori1.Hide();
        }
           
        private void MungesatButton_Click(object sender, EventArgs e)
        {
            MungesatButton.BackColor = Color.FromArgb(135, 190, 235);
            VleresonxenesButton.BackColor = Color.FromArgb(135, 206, 235);            

            MungesaUC.BringToFront();
            MungesaUC.Show();
            vleresoNxenesitUC1.Hide();
            fletTremujori1.Hide();
        }

        private void Kujdestariabutton_Click_1(object sender, EventArgs e)
        {
            showSubMenu(KujdestariaSub);
        }

        private void fqbutton_Click(object sender, EventArgs e)
        {
            mesuesDashboardUC1.Show();
            mesuesDashboardUC1.BringToFront();
            vleresoNxenesitUC1.Hide();
            MungesaUC.Hide();
        }


        private void DeftesaButton_Click(object sender, EventArgs e)
        {
            DeftesaButton.BackColor = Color.FromArgb(135, 190, 235);
            JustifikomungesatButton.BackColor = Color.FromArgb(135, 206, 235);

            fletTremujori1.Show();
            fletTremujori1.BringToFront();
            mesuesDashboardUC1.Hide();
            MungesaUC.Hide();
            vleresoNxenesitUC1.Hide();
        }

        private void JustifikomungesatButton_Click(object sender, EventArgs e)
        {
            JustifikomungesatButton.BackColor = Color.FromArgb(135, 190, 235);
            DeftesaButton.BackColor = Color.FromArgb(135, 206, 235);

            justifikoMungesatUC1.Show();
            justifikoMungesatUC1.BringToFront();
            mesuesDashboardUC1.Hide();
            MungesaUC.Hide();
            fletTremujori1.Hide();
            vleresoNxenesitUC1.Hide();
        }

        private void Logoutbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MesuesLogin ml = new MesuesLogin();
            ml.Show();
        }

        private void ChatButton_Click(object sender, EventArgs e)
        {
            chatUC1.Show();
            chatUC1.BringToFront();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(135, 190, 235);
            VleresonxenesButton.BackColor = Color.FromArgb(135, 206, 235);
            MungesatButton.BackColor = Color.FromArgb(135, 206, 235);

            notaTremujoriUC1.BringToFront();
            notaTremujoriUC1.Show();
            vleresoNxenesitUC1.Hide();
            fletTremujori1.Hide();
        }

        private void notaTremujoriUC1_Load(object sender, EventArgs e)
        {

        }

        private void chatUC1_Load(object sender, EventArgs e)
        {

        }
    }
}
