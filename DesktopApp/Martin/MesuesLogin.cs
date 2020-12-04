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
    public partial class MesuesLogin : Form
    {
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

        private void UsernametextBox_TextChanged(object sender, EventArgs e)
        {
            UsernametextBox.Clear();
            UsernamePanel.BackColor = Color.FromArgb(100, 149, 237);

            PassPanel.BackColor = Color.Black;
        }

        private void PasstextBox_TextChanged(object sender, EventArgs e)
        {
            PasstextBox.Clear();
            PassPanel.BackColor = Color.FromArgb(100, 149, 237);

            UsernamePanel.BackColor = Color.Black;
        }

        private void closepictureBox_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
