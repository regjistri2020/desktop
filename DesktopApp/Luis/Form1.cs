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

namespace DesktopApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var a = new Administrator();
			a.Show();
			this.Hide();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MesuesLogin m = new MesuesLogin();
			m.Show();
			this.Hide();
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;

		}

		private void PrivacylinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Hide();
			PrivacyPolicy privacy = new PrivacyPolicy();
			privacy.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://enxenesit.000webhostapp.com/home/");
		}
	}
}
