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

namespace DesktopApp
{
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            var a = new AdminMain();
            a.Show();
            this.Hide();
        }
    }
}
