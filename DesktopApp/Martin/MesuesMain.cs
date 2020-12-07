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
        public MesuesMain()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MesuesMain_Load(object sender, EventArgs e)
        {
            hideSubMenu();
            MungesaUC.Hide();
            vleresoNxenesitUC1.Hide();
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

        private void KujdestariaButton_Click(object sender, EventArgs e)
        {
            showSubMenu(KujdestariaSub);
        }

        private void Vleresonx_button_Click(object sender, EventArgs e)
        {
            vleresoNxenesitUC1.BringToFront();
            vleresoNxenesitUC1.Show();
        }

        private void Mungesa_button_Click(object sender, EventArgs e)
        {
            MungesaUC.BringToFront();
            MungesaUC.Show();
        }
    }
}
