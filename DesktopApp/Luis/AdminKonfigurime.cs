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
    public partial class AdminKonfigurime : Form
    {
        DataTable table = new DataTable();
        public AdminKonfigurime()
        {
            InitializeComponent();
        }

        private void AdminKonfigurime_Load(object sender, EventArgs e)
        {
            table.Columns.Add("User", typeof(string));// data type str
            table.Columns.Add("Fjalekalimi", typeof(string));// datatype string
            table.Columns.Add("Roli", typeof(string));// datatype string

            dataGridView1.DataSource = table;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table.Rows.Add(textBox1.Text, textBox2.Text, comboBox1.Text);
            dataGridView1.DataSource = table;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox2.Image = new Bitmap(open.FileName);
                // image file path  
                //textBox1.Text = open.FileName;
            }
        }
    }
}
