using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DesktopApp.Klea
{
    public partial class KlasatAdminUC : UserControl
    {
        SqlDataAdapter adap;
        SqlConnection con;
        DataSet ds;
        SqlCommandBuilder cmd;
        public KlasatAdminUC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\desktop\DesktopApp\e-nxenesit.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();

            SqlCommand scmd = con.CreateCommand();
            scmd.CommandType = CommandType.Text;
            scmd.CommandText = " Insert into Klasa(KlasaID, Emri, MesuesID, Niveli) values ('" + klasaTxb.Text + "','" + comboBox1.Text + "')";
            scmd.ExecuteNonQuery();

            klasaTxb.Text = "";
            comboBox1.Text = "";

            MessageBox.Show("Rregjistrimi i klasës u krye me sukses.");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                adap = new SqlDataAdapter("select * from Mesues ", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
    }

