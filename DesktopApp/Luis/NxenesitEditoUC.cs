using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DesktopApp.Luis
{
    public partial class NxenesitEditoUC : UserControl
    {
        MySqlCommandBuilder cmb;
        MySqlDataAdapter da;
        DataSet ds;
        MySqlConnection conn;
        string connstring = @"server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
        int index;

        DataTable table = new DataTable();
        public NxenesitEditoUC()
        {
            InitializeComponent();
        }

        private void NxenesitEditoUC_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connstring);
            conn.Open();
            string query = "select * from Nxenes ORDER BY emri";
            da = new MySqlDataAdapter(query, conn);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("select * from Nxenes ", conn);
            ds = new System.Data.DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("select * from Nxenes WHERE Emri like '%" + bunifuTextbox1.Text + "%' ", conn);
            ds = new System.Data.DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmb = new MySqlCommandBuilder(da);
            da.Update(ds);
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("select * from Nxenes WHERE Emri like '%" + textBox1.Text + "%' ", conn);
            ds = new System.Data.DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
