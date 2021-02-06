using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace DesktopApp.Luis
{
    public partial class MesuesitEditoUC : UserControl
    {
        MySqlCommandBuilder cmb;
        MySqlDataAdapter da;
        DataSet ds;
        MySqlConnection conn;
        string connstring = @"server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
        int index;

        DataTable table = new DataTable();
        public MesuesitEditoUC()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MesuesitEditoUC_Load(object sender, EventArgs e)
        {


            conn = new MySqlConnection(connstring);
            conn.Open();
            string query = "select * from Mesues ORDER BY emri";
            da = new MySqlDataAdapter(query, conn);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            cmb = new MySqlCommandBuilder(da);
            da.Update(ds);
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == null)
            {
                da = new MySqlDataAdapter("select * from Mesues ", conn);
                ds = new System.Data.DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                da = new MySqlDataAdapter("select * from Mesues WHERE Emri like '%" + textBox1.Text + "%' ", conn);
                ds = new System.Data.DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            da = new MySqlDataAdapter("select * from Mesues ", conn);
            ds = new System.Data.DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lista e mësuesve u gjenerua me sukses.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
