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
            string query = "select * from Nxenes";
            da = new MySqlDataAdapter(query, conn);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 160, 174);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 64);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            exportgridtopdf(dataGridView1, "PDF test");
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
                    Paragraph paragraph = new Paragraph("KREDINCIALET E IDENTIFIKIMIT TË PRINDËRVE NË SISTEM");
                    Paragraph paragraph2 = new Paragraph(" ");

                    Paragraph paragraph3 = new Paragraph(" Emri i Shkollës: Shkolla për TIK “Hermann Gmeiner”                            Viti shkollor: 2020-2021  ");
                    Paragraph paragraph31 = new Paragraph(" ");
                    Paragraph paragraph4 = new Paragraph(" Kredincialet identifikuese në sistem për prindin e nxënësit Luis Kateshi janë si vijojnë: ");
                    Paragraph paragraph5 = new Paragraph(" Username: 89dad83         Fjalëkalimi: 435jjjfsdfsi4");
                    Paragraph paragraph6 = new Paragraph(" ");

                    Paragraph paragraph7 = new Paragraph(" Cdo paqartësi apo problem teknik mund ta drejtoni në adresën tonë të emailit suportIT@hg.edu.al ");
                    Paragraph paragraph8 = new Paragraph(" ");
                    Paragraph paragraph9 = new Paragraph(" ");


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
                    pdfdoc.Add(pdftable);

                    pdfdoc.Close();
                    stream.Close();
                }
            }

        }
    }
}
