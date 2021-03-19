using MySql.Data.MySqlClient;
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
    public partial class NotaTremujoriUC : UserControl
    {
        DataTable dt;
        string lendaID;
        public NotaTremujoriUC()
        {
            InitializeComponent();
        }

        private void NotaTremujoriUC_Load(object sender, EventArgs e)
        {
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            comboBox2.Items.Clear();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Emri, Statusi FROM Periudha";
                using (var da = new MySqlDataAdapter(query, connection))
                {
                    dt = new DataTable();
                    da.Fill(dt);
                }
                connection.Close();
            }

            dataGridRefresher();
        }
        void dataGridRefresher()
        {
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "select b.NxenesID, b.Emri, b.Mbiemri, sum(b.Note_Me_Goje) as Note_Me_Goje,  sum(b.Note_Portofoli) as Note_Portofoli,  sum(b.Note_Provimi) as Note_Provimi from ( select a.NxenesID, a.Emri, a.Mbiemri,  Case when a.kategoria='Note me Goje (NG)' then a.Mesatarja else 0 end as Note_Me_Goje, Case when a.kategoria='Note Portofoli (NP)' then a.Mesatarja  else 0 end as Note_Portofoli, Case when a.kategoria='Note Test (NT)' then a.Mesatarja else 0 end as Note_Provimi from ( select a.NxenesID, b.Emri, b.Mbiemri, round(AVG(Nota),2) as Mesatarja, a.kategoria from Notat a, Nxenes b where a.NxenesID=b.NxenesID group by a.NxenesID, b.Emri, b.Mbiemri, a.kategoria) a) b group by  b.NxenesID, b.Emri, b.Mbiemri;";
                using (var da = new MySqlDataAdapter(query, connection))
                {
                    var ds = new DataSet();
                    da.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
                connection.Close();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT EmerLende FROM Lendet WHERE LendaID in (SELECT LendaID FROM Jep_Mesim WHERE MesuesID = '" + CookieClass.MesuesID + "' AND KlasaID in (SELECT KlasaID from Klasa where Emri = '" + comboBox1.Text + "'))";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            comboBox3.Items.Add(reader.GetString("EmerLende"));
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
                var query = "SELECT Emri FROM Klasa WHERE KlasaID in (SELECT KlasaID FROM Jep_Mesim WHERE MesuesID = '" + CookieClass.MesuesID + "')";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader.GetString("Emri"));
                        }
                    }
                }
            }
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            comboBox2.Items.Clear();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Emri, Statusi FROM Periudha";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader.GetString("Emri"));
                        }
                    }
                }
                connection.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["Emri"].ToString() == comboBox2.Text)
                {
                    if (row["Statusi"].ToString() == "Mbyllur")
                    {
                        label7.Text = "Mbyllur";
                        pictureBox2.Hide();
                    }
                    else if(row["Statusi"].ToString() == "Aktiv")
                    {
                        label7.Text = "Mbyll";
                        pictureBox2.Show();
                    }
                    MessageBox.Show(comboBox2.Text + " është" + row["Statusi"].ToString());
                }

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString()+" "+ dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();

            var nxenesID = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();

            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Notat.Nota, TematMesimore.TemaMesimore, Notat.Shenime, Notat.Kategoria FROM Notat JOIN Nxenes ON Nxenes.NxenesID=Notat.NxenesID JOIN TematMesimore ON TematMesimore.TemaMesimoreID=Notat.TemaMesimoreID WHERE Nxenes.NxenesID = '"+nxenesID+"' AND TematMesimore.LendaID = '" + lendaID + "'";
                using (var da = new MySqlDataAdapter(query, connection))
                {
                    var ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                connection.Close();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT LendaID FROM Lendet where EmerLende = '" + comboBox3.Text + "'";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            lendaID = reader.GetString("LendaID");
                        }
                    }
                }
            }
        }
    }
}
