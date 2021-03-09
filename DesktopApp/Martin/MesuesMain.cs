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

namespace DesktopApp.Martin
{
    public partial class MesuesMain : Form
    {
       
        string loginID = CookieClass.LoginID;
        String mID;
        public MesuesMain()
        {
            InitializeComponent();
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

                            mesuesDashboardUC1.MesuestextBox.Text= reader.GetString("Emri") + " " + reader.GetString("Mbiemri");
                            mID = reader.GetString("MesuesID");

                        }
                    }
                }
                connection.Close();
            }
           CookieClass.MesuesID = mID;
            MessageBox.Show(mID);

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
            System.Diagnostics.Process.Start("http://www.webpage.com");
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
    }
}
