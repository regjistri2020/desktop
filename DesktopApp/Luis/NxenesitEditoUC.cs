using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DesktopApp.Luis
{
    public partial class NxenesitEditoUC : UserControl
    {
        MySqlCommandBuilder cmb;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        MySqlConnection conn;
        string connstring = @"server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME", emri, username, pass;
        int klasaid;

        DataTable table = new DataTable();
        public NxenesitEditoUC()
        {
            InitializeComponent();
        }

        private void NxenesitEditoUC_Load(object sender, EventArgs e)
        {
            dataGridRefresher();

        }
        void dataGridRefresher()
        {
            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();
                string query = "select NxenesID as 'Nr. Amze', Emri, Mbiemri, EmriBabait as 'Atesia', EmriMamase as 'Emri i nenes', NrTelPrind as 'Nr. Tel Prindi', Ditelindja from Nxenes";
                da = new MySqlDataAdapter(query, conn);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            klasaCombo.Text = null;
            textBox1.Text = null;
            dataGridRefresher();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmb = new MySqlCommandBuilder(da);
                da.Update(ds);
                MessageBox.Show("Tabela e nxënësve u përditsua me sukses.");
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
            da = new MySqlDataAdapter("select NxenesID as 'Nr. Amze', Emri, Mbiemri, EmriBabait as 'Atesia', EmriMamase as 'Emri i nenes', NrTelPrind as 'Nr. Tel Prindi', Ditelindja from Nxenes WHERE Emri like '%" + textBox1.Text + "%' ", conn);
            ds = new System.Data.DataSet();
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
            if (klasaCombo.SelectedItem != null)
            {
                
                var names = klasaCombo.Text.Split(' ');
                exportgridtopdf("Kredincialet e prindërve për klasën " + names[1]);
            }
            else if (klasaCombo.SelectedItem == null)
            {
                MessageBox.Show("Zgjidhni një klasë");
            }

        }

        public void exportgridtopdf(string filename)
        {
            try
            {
                conn.Open();
            da = new MySqlDataAdapter("SELECT Login.User_Name, Login.Pasword, Nxenes.Emri, Nxenes.Mbiemri FROM Nxenes JOIN Login ON Login.LoginID = Nxenes.LoginID WHERE Nxenes.KlasaID = '"+klasaid+"'", conn);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";

            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    Paragraph paragraph0 = new Paragraph(" ");
                    int i=0;
                    foreach (DataRow row in dt.Rows)
                    {
                        i++;
                        if(i%5==0)
                        {
                            pdfdoc.NewPage();
                        }
                        emri = row["Emri"].ToString() +" "+ row["Mbiemri"].ToString();
                        username = row["User_Name"].ToString();
                        pass = row["Pasword"].ToString();
                        iTextSharp.text.Font myFont = FontFactory.GetFont("Arial", 10, new iTextSharp.text.BaseColor(0, 0, 255));
                        Paragraph paragraph = new Paragraph("KREDINCIALET E IDENTIFIKIMIT TË PRINDËRVE NË SISTEM");
                        Paragraph paragraph2 = new Paragraph(" ");
                        Paragraph paragraph3 = new Paragraph(" Emri i Shkollës: Shkolla për TIK “Hermann Gmeiner”                            Viti shkollor: 2020-2021  ");
                        Paragraph paragraph31 = new Paragraph(" ");
                        Paragraph paragraph4 = new Paragraph(" Kredincialet identifikuese në sistem për prindin e nxënësit " + emri + " janë si vijojnë: ");
                        Paragraph paragraph5 = new Paragraph(" Username: " + username + "         Fjalëkalimi: " + pass, myFont);
                        Paragraph paragraph6 = new Paragraph(" ");
                        Paragraph paragraph7 = new Paragraph(" Cdo paqartësi apo problem teknik mund ta drejtoni në adresën tonë të emailit suportIT@hg.edu.al ");
                        Paragraph paragraph8 = new Paragraph(" ");
                        Paragraph paragraph9 = new Paragraph(" ------------------------------------------------------------------------------------------------------------------------------------------");

                        pdfdoc.Add(paragraph0);
                        pdfdoc.Add(paragraph);
                        pdfdoc.Add(paragraph2);
                        pdfdoc.Add(paragraph3);
                        pdfdoc.Add(paragraph31);
                        pdfdoc.Add(paragraph4);
                        pdfdoc.Add(paragraph5);
                        pdfdoc.Add(paragraph6);
                        pdfdoc.Add(paragraph7);
                        pdfdoc.Add(paragraph8);
                        pdfdoc.Add(paragraph9);
                    }

                    pdfdoc.Add(paragraph0);
                    pdfdoc.Close();
                    stream.Close();
                }
            }

        }

        private void klasaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string connstr = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                string query2 = "SELECT KlasaID FROM Klasa WHERE Emri = '" + klasaCombo.Text + "'";
                MySqlCommand cmnd = new MySqlCommand(query2, conn);
                MySqlDataReader MyReader;
                MyReader = cmnd.ExecuteReader();
                while (MyReader.Read())
                {
                    klasaid = Convert.ToInt32(MyReader["KlasaID"]);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                
            }
            conn.Open();
            da = new MySqlDataAdapter("select NxenesID as 'Nr. Amze', Emri, Mbiemri, EmriBabait as 'Atesia', EmriMamase as 'Emri i nenes', NrTelPrind as 'Nr. Tel Prindi', Ditelindja from Nxenes Where KlasaID = '" + klasaid+"' ", conn);
            ds = new System.Data.DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void klasaCombo_Click(object sender, EventArgs e)
        {
            klasaCombo.Items.Clear();
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
                            klasaCombo.Items.Add(reader.GetString("Emri"));
                        }
                    }
                }
            }
        }
    }
}
