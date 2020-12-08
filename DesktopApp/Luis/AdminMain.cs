using DesktopApp.Martin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Luis
{
	public partial class AdminMain : Form
	{
		public AdminMain()
		{
			InitializeComponent();
		}

		private void AdminMain_Load(object sender, EventArgs e)
		{
			hideSubMenu();
			mesuesitEditoUC1.Hide();
			mesuesitRegjistroUC1.Hide();
		}
		private void hideSubMenu()
		{
			if (MesuesitSub.Visible == true)
				MesuesitSub.Visible = false;
			if (NxenesitSub.Visible == true)
				NxenesitSub.Visible = false;
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

		private void button2_Click(object sender, EventArgs e)
		{
			showSubMenu(MesuesitSub);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			showSubMenu(NxenesitSub);
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void Close_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			button3.BackColor = Color.FromArgb(255, 200, 0);
			button4.BackColor = Color.FromArgb(255, 220, 0);
			mesuesitRegjistroUC1.BringToFront();
			mesuesitRegjistroUC1.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			button4.BackColor = Color.FromArgb(255, 200, 0);
			button3.BackColor = Color.FromArgb(255, 220, 0);
			mesuesitEditoUC1.Show();
			mesuesitEditoUC1.BringToFront();

		}

		private void button6_Click(object sender, EventArgs e)
		{
			button6.BackColor = Color.FromArgb(255, 200, 0);
			button7.BackColor = Color.FromArgb(255, 220, 0);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			button7.BackColor = Color.FromArgb(255, 200, 0);
			button6.BackColor = Color.FromArgb(255, 220, 0);
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			var a = new AdminKonfigurime();
			a.Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			AdminDashboardUC ad = new AdminDashboardUC();
			ad.Dock = DockStyle.Fill;
			this.Controls.Add(ad);
			adminDashboardUC1.Show();
			adminDashboardUC1.BringToFront();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			klasatAdminUC1.Show();
			klasatAdminUC1.BringToFront();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			
		}
	}
}
