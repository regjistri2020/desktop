using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DesktopApp.Luis
{
    public partial class MesuesitEditoUC : UserControl
    {
        SqlDataAdapter adap;
        SqlConnection con;
        DataSet ds;
        SqlCommandBuilder cmd;

        public MesuesitEditoUC()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MesuesitEditoUC_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DesktopApp.Properties.Settings.e_nxenesitConnectionString"].ConnectionString;
            con.Open();
            //adap = new SqlDataAdapter("select * from Mesues ", con);
            //ds = new System.Data.DataSet();
            //adap.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cmd = new SqlCommandBuilder(adap);
            //adap.Update(ds);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text == null)
            //{
            //    adap = new SqlDataAdapter("select * from Mesues ", con);
            //    ds = new System.Data.DataSet();
            //    adap.Fill(ds);
            //    dataGridView1.DataSource = ds.Tables[0];
            //}
            //else
            //{
            //    adap = new SqlDataAdapter("select * from Mesues WHERE emri like '%" + textBox1.Text + "%' ", con);
            //    ds = new System.Data.DataSet();
            //    adap.Fill(ds);
            //    dataGridView1.DataSource = ds.Tables[0];
            //}
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //adap = new SqlDataAdapter("select * from Mesues ", con);
            //ds = new System.Data.DataSet();
            //adap.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Lista e mësuesve u gjenerua me sukses.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
