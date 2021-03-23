using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using DesktopApp.Luis;

namespace DesktopApp.Martin
{
    public partial class FletTremujori : UserControl
    {

        string firstName, lastName;
        string loginID = CookieClass.LoginID;

        public FletTremujori()
        {
            InitializeComponent();
        }


        private void FletTremujori_Load(object sender, EventArgs e)
        {
            
        }

        public void exportgridtopdf(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            pdftable.DefaultCell.PaddingLeft = 5;
            pdftable.DefaultCell.PaddingRight = 5;
            pdftable.WidthPercentage = 90;
            pdftable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdftable.DefaultCell.BorderWidth = 1;


            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

            //add header
            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240); //potential error
                pdftable.AddCell(cell);
            }

            // add datarow
            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }


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
                    Paragraph paragraph = new Paragraph("                                                FLETË INFORMUESE TREMUJORI PËR PRINDIN");
                    Paragraph paragraph2 = new Paragraph(" ");

                    Paragraph paragraph3 = new Paragraph("                Shkolla për TIK “Hermann Gmeiner”                                      Viti shkollor: 2020-2021  ");
                    Paragraph paragraph4 = new Paragraph("                Nr i amzës: 213 ");
                    Paragraph paragraph5 = new Paragraph("                Data: 10.12.2020");
                    Paragraph paragraph6 = new Paragraph(" ");

                    Paragraph paragraph7 = new Paragraph("                                                                           Progresi i nxënësit ");
                    Paragraph paragraph8 = new Paragraph("                                                                                 Martin Koçi ");
                    Paragraph paragraph9 = new Paragraph(" ");


                    pdfdoc.Add(paragraph);
                    pdfdoc.Add(paragraph2);
                    pdfdoc.Add(paragraph3);
                    pdfdoc.Add(paragraph4);
                    pdfdoc.Add(paragraph5);
                    pdfdoc.Add(paragraph6);
                    pdfdoc.Add(paragraph7);
                    pdfdoc.Add(paragraph8);
                    pdfdoc.Add(paragraph9);
                    pdfdoc.Add(pdftable);

                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exportgridtopdf(dataGridView2, "Notat e tremujorit ");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            //SHFAQJA E TE DHENAVE NE DATAGRIDVIEW1 
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();  
                 var query = "SELECT Nxenes.Emri, Nxenes.Mbiemri, NotaTremujor.NotaGoje, NotaTremujor.NotaShkrim, NotaTremujor.NotaPortofol FROM Nxenes JOIN NotaTremujor ON Nxenes.NxenesID = NotaTremujor.NxenesID WHERE NotaTremujor.KlasaID IN(SELECT KlasaID From Klasa WHERE Emri = '"+ label6.Text + "') AND NotaTremujor.LendaID IN (SELECT LendaID FROM Lendet WHERE EmerLende = '"+ comboBox2.Text +"' ) ; ";
                using (var da = new MySqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                connection.Close();
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

            //SHFAQJA E TE DHENAVE NE DATAGRIDVIEW1 KUR KLIKOHET BUTONI RIFRESKONI
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Nxenes.Emri, Nxenes.Mbiemri, NotaTremujor.NotaGoje, NotaTremujor.NotaShkrim, NotaTremujor.NotaPortofol FROM Nxenes JOIN NotaTremujor ON Nxenes.NxenesID = NotaTremujor.NxenesID WHERE NotaTremujor.KlasaID IN(SELECT KlasaID From Klasa WHERE Emri = '" + label6.Text + "'); ";
                using (var da = new MySqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                connection.Close();
            }

            //SHFAQJA E TE DHENAVE NE DATAGRIDVIEW2 KUR KLIKOHET BUTONI RIFRESKONI
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Lendet.EmerLende, NotaTremujor.NotaGoje, NotaTremujor.NotaShkrim, NotaTremujor.NotaPortofol FROM NotaTremujor JOIN Lendet ON NotaTremujor.LendaID = Lendet.LendaID WHERE NotaTremujor.KlasaID IN(SELECT KlasaID From Klasa WHERE Emri = '" + label6.Text + "'); ";
                using (var da = new MySqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
                connection.Close();
            }

            //MBUSHJA E COMBOBOX ME EMRAT E LENDEVE QE ZHVILLON KLASA
            comboBox2.Items.Clear();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT EmerLende FROM Lendet WHERE LendaID IN (SELECT LendaID FROM Jep_Mesim WHERE KlasaID IN (SELECT KlasaID FROM Klasa WHERE Emri = '"+ label6.Text +"'))";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader.GetString("EmerLende"));
                        }
                    }
                }
            }

            //MBUSHJA E COMBOBOX ME EMRAT E NXENESVE TE KLASES PERKATESE
            NxenescomboBox.Items.Clear();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Select * from Nxenes where KlasaID in (Select KlasaID from Klasa where Emri = '" + label6.Text + "' )";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            NxenescomboBox.Items.Add(reader.GetString("Emri") + " " + reader.GetString("Mbiemri"));
                        }
                    }
                }
            }
        }

        
        
        private void NxenescomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MBUSHJA E DATAGRIDVIEW ME NOTAT E NXENESIT TE PERCAKTUAR
            string fullName = NxenescomboBox.Text;
            var names = fullName.Split(' ');
            firstName = names[0];
            lastName = names[1];

            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Lendet.EmerLende, NotaTremujor.NotaGoje, NotaTremujor.NotaShkrim, NotaTremujor.NotaPortofol FROM NotaTremujor JOIN Lendet ON NotaTremujor.LendaID = Lendet.LendaID WHERE NotaTremujor.KlasaID IN(SELECT KlasaID From Klasa WHERE Emri = '"+ label6.Text + "') AND NotaTremujor.NxenesID IN(SELECT NxenesID FROM Nxenes WHERE Emri = '"+ firstName + "' AND Mbiemri = '" + lastName + "'); ";
                using (var da = new MySqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
                connection.Close();
            }
        }
    }
}
