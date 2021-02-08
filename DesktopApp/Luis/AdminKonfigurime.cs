using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DesktopApp.Luis
{
   
    public partial class AdminKonfigurime : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter da;
        MySqlCommandBuilder cmb;
        DataSet ds;
        string connstr = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
        DataTable table = new DataTable();
        public AdminKonfigurime()
        {
            InitializeComponent();
        }

        private void AdminKonfigurime_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                string query = "select * from Login where RoleID=2";
                da = new MySqlDataAdapter(query, conn);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                string Query1 = "insert into Login(User_Name, Pasword, RoleID) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','2' )";
                MySqlCommand cmd = new MySqlCommand(Query1, conn);
                cmd.ExecuteReader();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                string query = "select * from Login where RoleID=2";
                da = new MySqlDataAdapter(query, conn);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);
            cmb = new MySqlCommandBuilder(da);
            da.Update(ds);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void T(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmb = new MySqlCommandBuilder(da);
            da.Update(ds);
        }
    }
}
