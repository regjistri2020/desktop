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
        string lendaID, klasaID, periudhaID;
        int index;
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
                var query = "SELECT * FROM Periudha";
                using (var da = new MySqlDataAdapter(query, connection))
                {
                    dt = new DataTable();
                    da.Fill(dt);
                }
                connection.Close();
            }

        }
        void dataGridRefresher()
        {
            var connectionString = "server = remotemysql.com; userid = gBh6InugME; password = NSGsLG2ITM; database = gBh6InugME";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select b.NxenesID, b.Emri, b.Mbiemri, sum(b.Note_Me_Goje) as Note_Me_Goje,  sum(b.Note_Portofoli) as Note_Portofoli,  sum(b.Note_Provimi) as Note_Provimifrom ( select a.NxenesID, a.Emri, a.Mbiemri, Case when a.kategoria='Note me Goje (NG)' then a.Mesatarja else 0 end as Note_Me_Goje, Case when a.kategoria='Note Portofoli (NP)' then a.Mesatarja  else 0 end as Note_Portofoli, Case when a.kategoria='Note Test (NT)' then a.Mesatarja else 0 end as Note_Provimi from ( select a.NxenesID, b.Emri, b.Mbiemri, round(AVG(Nota),2) as Mesatarja, a.kategoria from Notat a, Nxenes b  , Jep_Mesim c where a.NxenesID=b.NxenesID and a.Jep_MesimID=c.Jep_MesimID and a.PeriudhaID = '"+periudhaID+"' and c.KlasaID = '"+klasaID+"' and c.LendaID = '"+lendaID+"' group by a.NxenesID, b.Emri, b.Mbiemri, a.kategoria) a) b group by  b.NxenesID, b.Emri, b.Mbiemri;";
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
                connection.Close();
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT KlasaID FROM Klasa where Emri = '" + comboBox1.Text + "'";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            klasaID = reader.GetString("KlasaID");
                        }
                    }
                }
                connection.Close();
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
                var query = "SELECT * FROM Periudha";
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
                    periudhaID = row["PeriudhaID"].ToString();
                    if (row["Statusi"].ToString() == "Mbyllur")
                    {
                        label7.Text = "Mbyllur";
                        pictureBox2.Hide();
                        dataGridView2.Enabled = false;

                        //notat e tremujorit do te merren nga tabela NotaTremujori
                        //datagridView nuk do mund te editohet

                        var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
                        using (var connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            var query = "SELECT NotaTremujor.NxenesID, Nxenes.Emri, Nxenes.Mbiemri, NotaTremujor.NotaGoje, NotaTremujor.NotaShkrim, NotaTremujor.NotaPortofol FROM NotaTremujor JOIN  Nxenes ON NotaTremujor.NxenesID = Nxenes.NxenesID WHERE NotaTremujor.KlasaID ='"+klasaID+"' and NotaTremujor.LendaID = '"+lendaID+ "' AND NotaTremujor.Periudha = '" + row["PeriudhaID"].ToString() + "'";
                            using (var da = new MySqlDataAdapter(query, connection))
                            {
                                var ds = new DataSet();
                                da.Fill(ds);
                                dataGridView2.DataSource = ds.Tables[0];
                            }
                            connection.Close();
                        }

                    }
                    else if(row["Statusi"].ToString() == "Aktiv")
                    {
                        

                        //do kontrollojm nese periudhaid ndodhet ne tabelen e NotaTrm
                        //notat do meren nga query i perbere i MYSQL
                        //kur te behet insert do 
                        

                        var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
                        MySqlConnection conn = new MySqlConnection(connectionString);
                        conn.Open();
                        string AdmLog_query = "SELECT Count(*) FROM NotaTremujor WHERE Periudha = '"+row["PeriudhaID"]+"' and LendaID='"+lendaID+"'";
                        MySqlCommand cmd = new MySqlCommand(AdmLog_query, conn);
                        cmd.ExecuteReader();
                        conn.Close();
                        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (Convert.ToInt32(dt.Rows[0][0]) >= 1)
                        {
                            label7.Text = "Mbyllur";
                            pictureBox2.Hide();
                            dataGridView2.Enabled = false;

                            //notat e tremujorit do te merren nga tabela NotaTremujori
                            //datagridView nuk do mund te editohet

                            using (var connection = new MySqlConnection(connectionString))
                            {
                                connection.Open();
                                var query = "SELECT NotaTremujor.NxenesID, Nxenes.Emri, Nxenes.Mbiemri, NotaTremujor.NotaGoje, NotaTremujor.NotaShkrim, NotaTremujor.NotaPortofol FROM NotaTremujor JOIN  Nxenes ON NotaTremujor.NxenesID = Nxenes.NxenesID WHERE NotaTremujor.KlasaID ='" + klasaID + "' and NotaTremujor.LendaID = '" + lendaID + "' AND NotaTremujor.Periudha = '" + row["PeriudhaID"].ToString() + "'";
                                using (var da = new MySqlDataAdapter(query, connection))
                                {
                                    var ds = new DataSet();
                                    da.Fill(ds);
                                    dataGridView2.DataSource = ds.Tables[0];
                                }
                                connection.Close();
                            }
                            MessageBox.Show("Ky tremujor tashme eshte mbyllur njehere per kete lende");
                        }
                        else
                        {
                            label7.Text = "Mbyll";
                            pictureBox2.Show();
                            dataGridView2.Enabled = true;


                            using (var connection = new MySqlConnection(connectionString))
                            {
                                connection.Open();
                                var query = "Select b.NxenesID, b.Emri, b.Mbiemri, sum(b.Note_Me_Goje) as Note_Me_Goje,  sum(b.Note_Portofoli) as Note_Portofoli,  sum(b.Note_Provimi) as Note_Provimi from ( select a.NxenesID, a.Emri, a.Mbiemri, Case when a.kategoria='Note me Goje (NG)' then a.Mesatarja else 0 end as Note_Me_Goje, Case when a.kategoria='Note Portofoli (NP)' then a.Mesatarja  else 0 end as Note_Portofoli, Case when a.kategoria='Note Test (NT)' then a.Mesatarja else 0 end as Note_Provimi from ( select a.NxenesID, b.Emri, b.Mbiemri, round(AVG(Nota),2) as Mesatarja, a.kategoria from Notat a, Nxenes b  , Jep_Mesim c where a.NxenesID=b.NxenesID and a.Jep_MesimID=c.Jep_MesimID and a.PeriudhaID = '" + row["PeriudhaID"].ToString() + "' and c.KlasaID = '" + klasaID + "' and c.LendaID = '" + lendaID + "' group by a.NxenesID, b.Emri, b.Mbiemri, a.kategoria) a) b group by  b.NxenesID, b.Emri, b.Mbiemri;";
                                using (var da = new MySqlDataAdapter(query, connection))
                                {
                                    var ds = new DataSet();
                                    da.Fill(ds);
                                    dataGridView2.DataSource = ds.Tables[0];
                                }
                                connection.Close();
                            }
                        }    
                           
                    }
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
            index = e.RowIndex;
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows[index].Cells[3].Value = textBox3.Text;
            dataGridView2.Rows[index].Cells[4].Value = textBox4.Text;
            dataGridView2.Rows[index].Cells[5].Value = textBox5.Text;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                try
                {
                    string StrQuery = "INSERT INTO NotaTremujor(Periudha, MesuesID, LendaID, KlasaID, NxenesID, NotaGoje, NotaShkrim, NotaPortofol) VALUES ('" + periudhaID + "','" + CookieClass.MesuesID + "','" + lendaID + "','" + klasaID + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','" + row.Cells[5].Value.ToString() + "')";

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand comm = new MySqlCommand(StrQuery, conn))
                        {
                            conn.Open();
                            comm.ExecuteNonQuery();
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Tremujori per kete lende u mbyll me sukses. Ju nuk mund ti mbishkruani me notat e vendosura!");
            label7.Text = "Mbyllur";
            pictureBox2.Hide();
            dataGridView2.Enabled = false;
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
