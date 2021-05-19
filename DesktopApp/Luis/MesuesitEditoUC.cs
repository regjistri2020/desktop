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
            conn.Open();
            da = new MySqlDataAdapter("select MesuesID AS ID, Emri, Mbiemri, Gjinia, nr_tel as 'Nr. Tel', datelindja as Datelindja, studimet1 as 'Studime 1', studimet2 as 'Studime 2' from Mesues WHERE Emri like '%" + textBox1.Text + "%' ", conn);
            ds = new System.Data.DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void MesuesitEditoUC_Load(object sender, EventArgs e)
        {
            dataGridView2.Hide();

            try
            {
    conn = new MySqlConnection(connstring);
                conn.Open();
                string query = "SELECT MesuesID AS ID, Emri, Mbiemri, Gjinia, nr_tel as 'Nr. Tel', datelindja as Datelindja, studimet1 as 'Studime 1', studimet2 as 'Studime 2' from Mesues ORDER BY emri";
                da = new MySqlDataAdapter(query, conn);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch
            {

            }
            conn = new MySqlConnection(connstring);
            conn.Open();
            string query1 = "SELECT Mesues.Emri, Mesues.Mbiemri, Login.User_Name as 'Kodi identifikues', Login.Pasword AS Fjalekalimi FROM Mesues JOIN Login ON Mesues.LoginID = Login.LoginID";
            da = new MySqlDataAdapter(query1, conn);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmb = new MySqlCommandBuilder(da);
            da.Update(ds);
            conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == null)
            {
                conn.Open();
                da = new MySqlDataAdapter("select MesuesID AS ID, Emri, Mbiemri, Gjinia, nr_tel as 'Nr. Tel', datelindja as Datelindja, studimet1 as 'Studime 1', studimet2 as 'Studime 2' from Mesues order by Emri ", conn);
                ds = new System.Data.DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
            else
            {
                conn.Open();
                da = new MySqlDataAdapter("select MesuesID AS ID, Emri, Mbiemri, Gjinia, nr_tel as 'Nr. Tel', datelindja as Datelindja, studimet1 as 'Studime 1', studimet2 as 'Studime 2' from Mesues WHERE Emri like '%" + textBox1.Text + "%' ", conn);
                ds = new System.Data.DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("select MesuesID AS ID, Emri, Mbiemri, Gjinia, nr_tel as 'Nr. Tel', datelindja as Datelindja, studimet1 as 'Studime 1', studimet2 as 'Studime 2' from Mesues ", conn);
            ds = new System.Data.DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lista e mësuesve u gjenerua me sukses.");
            exportgridtopdf2(dataGridView1, "Lista e mësuesve të shkollës");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("select MesuesID AS ID, Emri, Mbiemri, Gjinia, nr_tel as 'Nr. Tel', datelindja as Datelindja, studimet1 as 'Studime 1', studimet2 as 'Studime 2' from Mesues WHERE Emri like '%" + textBox1.Text + "%' ", conn);
            ds = new System.Data.DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void bunifuTextbox1_OnTextChange_1(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            exportgridtopdf(dataGridView2, "Kredincialet login për mësuesit");
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
                    pdftable.AddCell(new Phrase(cell.Value?.ToString(), text));
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
                    Paragraph paragraph = new Paragraph("                                 KREDINCIALET E IDENTIFIKIMIT TË MËSUESVE NË SISTEM");
                    Paragraph paragraph2 = new Paragraph(" ");

                    Paragraph paragraph3 = new Paragraph("               Shkolla për TIK “Hermann Gmeiner”                            Viti shkollor: 2020-2021  ");
                    Paragraph paragraph31 = new Paragraph(" ");
                    Paragraph paragraph32 = new Paragraph(" ");
                    Paragraph paragraph33 = new Paragraph(" ");

                    Paragraph paragraph7 = new Paragraph("    Cdo paqartësi apo problem teknik mund ta drejtoni në adresën tonë të emailit suportIT@hg.edu.al ");
                    Paragraph paragraph8 = new Paragraph(" ");
                    Paragraph paragraph9 = new Paragraph(" ");


                    pdfdoc.Add(paragraph);
                    pdfdoc.Add(paragraph2);
                    pdfdoc.Add(paragraph3);
                    pdfdoc.Add(paragraph31);
                    pdfdoc.Add(paragraph32);
                    pdfdoc.Add(paragraph33);
                    pdfdoc.Add(paragraph7);
                    pdfdoc.Add(paragraph8);
                    pdfdoc.Add(paragraph9);
                    pdfdoc.Add(pdftable);

                    pdfdoc.Close();
                    stream.Close();
                }
            }

        }
        public void exportgridtopdf2(DataGridView dgw, string filename)
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
                    pdftable.AddCell(new Phrase(cell.Value?.ToString(), text));
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
                    Paragraph paragraph = new Paragraph("                                            LISTA E MESUESVE TE SHKOLLES");
                    Paragraph paragraph2 = new Paragraph(" ");

                    Paragraph paragraph3 = new Paragraph("               Shkolla për TIK “Hermann Gmeiner”                            Viti shkollor: 2020-2021  ");
                    Paragraph paragraph31 = new Paragraph(" ");
                    Paragraph paragraph32 = new Paragraph(" ");
                    Paragraph paragraph33 = new Paragraph(" ");

                    Paragraph paragraph7 = new Paragraph("    Cdo paqartësi apo problem teknik mund ta drejtoni në adresën tonë të emailit suportIT@hg.edu.al ");
                    Paragraph paragraph8 = new Paragraph(" ");
                    Paragraph paragraph9 = new Paragraph(" ");


                    pdfdoc.Add(paragraph);
                    pdfdoc.Add(paragraph2);
                    pdfdoc.Add(paragraph3);
                    pdfdoc.Add(paragraph31);
                    pdfdoc.Add(paragraph32);
                    pdfdoc.Add(paragraph33);
                    pdfdoc.Add(paragraph7);
                    pdfdoc.Add(paragraph8);
                    pdfdoc.Add(paragraph9);
                    pdfdoc.Add(pdftable);

                    pdfdoc.Close();
                    stream.Close();
                }
            }

        }
    }
}
