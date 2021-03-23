using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopApp.Luis;
using MySql.Data.MySqlClient;

namespace DesktopApp.Klea
{
    public partial class KlasatAdminUC : UserControl
    {
        string mesuesID, mesuesIDLenda;
        MySqlCommandBuilder cmb;
        MySqlDataAdapter da;
        DataSet ds;
        MySqlConnection conn;
        string connstring = @"server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
        int index,klasaid;
        long lastidLenda;
        public KlasatAdminUC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dataGridRefresher1();
        }
        void dataGridRefresher1()
        {
            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();
                string query = "select Klasa.KlasaID, Klasa.Emri, Mesues.Emri from Klasa, Mesues Where Klasa.MesuesID = Mesues.MesuesID ";
                da = new MySqlDataAdapter(query, conn);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        void dataGridRefresher2()
        {
            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();
                string query = "SELECT Jep_Mesim.LendaID, Mesues.Emri, Mesues.Mbiemri, Lendet.EmerLende FROM Jep_Mesim JOIN Mesues ON Jep_Mesim.MesuesID = Mesues.MesuesID  JOIN Lendet ON Jep_Mesim.LendaID = Lendet.LendaID WHERE Jep_Mesim.KlasaID = '"+klasaid+"'";
                da = new MySqlDataAdapter(query, conn);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KlasatAdminUC_Load(object sender, EventArgs e)
        {
            dataGridRefresher1();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string connstr = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
                MySqlConnection conn = new MySqlConnection(connstr);

                conn.Open();
                string Query1 = "insert into Klasa (Emri, MesuesID) Values('" + klasaTxb.Text + "', '" + mesuesID + "'); ";

                MySqlCommand cmd = new MySqlCommand(Query1, conn);
                cmd.ExecuteReader();

                MessageBox.Show("Klasa u krijua me sukses!");
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            klasaTxb.Text = null;
            comboBox1.Text = null;
            dataGridRefresher1();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                try
                {
                    string fullName = comboBox1.Text;
                    var names = fullName.Split(' ');
                    string firstName = names[0];
                    string lastName = names[1];

                    var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        var query = "SELECT MesuesID FROM Mesues where Emri = '" + firstName + "' and Mbiemri = '" + lastName + "' ";
                        using (var command = new MySqlCommand(query, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                //Iterate through the rows and add it to the combobox's items
                                while (reader.Read())
                                {
                                    mesuesID = reader.GetString("MesuesID");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmb = new MySqlCommandBuilder(da);
            da.Update(ds);
            conn.Close();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = comboBox3.Text;
            label8.ForeColor = System.Drawing.Color.Green;
            try
            {
                string connstr = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                string query2 = "SELECT KlasaID FROM Klasa WHERE Emri = '" + comboBox3.Text + "'";
                MySqlCommand cmnd = new MySqlCommand(query2, conn);
                MySqlDataReader MyReader;
                MyReader = cmnd.ExecuteReader();
                while (MyReader.Read())
                {
                    klasaid = Convert.ToInt32(MyReader["KlasaID"]);
                }
                conn.Close();
            }
            catch (Exception ex) { 
            }

            dataGridRefresher2();
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Emri, Mbiemri FROM Mesues";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader.GetString("Emri") + " " + reader.GetString("Mbiemri"));
                        }
                    }
                }
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Emri FROM Klasa";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            comboBox3.Items.Add(reader.GetString("Emri"));
                        }
                    }
                }
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Emri, Mbiemri FROM Mesues";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader.GetString("Emri") + " " + reader.GetString("Mbiemri"));
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string connstr = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
                MySqlConnection conn = new MySqlConnection(connstr);

                conn.Open();
                string Query1 = "INSERT INTO Lendet(EmerLende) Values('"+textBox1.Text+"')";

                MySqlCommand cmd = new MySqlCommand(Query1, conn);
                cmd.ExecuteReader();
                lastidLenda = cmd.LastInsertedId;
                conn.Close();

                conn.Open();
                string Query2 = "INSERT INTO Jep_Mesim(MesuesID, LendaID, KlasaID) Values('"+ Convert.ToInt32(mesuesIDLenda) +"', '" + Convert.ToInt32(lastidLenda) + "', '"+ Convert.ToInt32(klasaid) +"')";

                MySqlCommand cmd2 = new MySqlCommand(Query2, conn);
                cmd2.ExecuteReader();

                MessageBox.Show("Lenda u shtua me sukses!");
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Text = null;
            comboBox2.Text = null;
            dataGridRefresher2();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string fullName = comboBox2.Text;
                var names = fullName.Split(' ');
                string firstName = names[0];
                string lastName = names[1];

                var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT MesuesID FROM Mesues where Emri = '" + firstName + "' and Mbiemri = '" + lastName + "' ";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                mesuesIDLenda = reader.GetString("MesuesID");
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }
    }


       
   
    }

