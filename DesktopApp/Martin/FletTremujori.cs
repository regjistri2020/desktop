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

namespace DesktopApp.Martin
{
    public partial class FletTremujori : UserControl
    {
        
        MySqlDataAdapter sda;
        DataTable dt;
        DataSet ds;
        MySqlConnection conn;
        string connstring = @"server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";

        DataTable table = new DataTable();
        public FletTremujori()
        {
            InitializeComponent();
        }


        private void KerkoButton_Click(object sender, EventArgs e)
        {
            
        }

        private void FletTremujori_Load(object sender, EventArgs e)
        {
            //dataGridView1.Columns.Clear();
            //dataGridView1.DataSource = null;

            conn = new MySqlConnection(connstring);
            conn.Open();
            string query1 = "select NotaTremujorID, Periudha, MesuesID, LendaID, KlasaID, NxenesID, NotaGoje, NotaShkrim, NotaPortofol from NotaTremujor";
            sda = new MySqlDataAdapter(query1, conn);

            dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // used to hide specific columns
            //this.dataGridView1.Columns["CustomerID"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
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
            exportgridtopdf(dataGridView1, "Notat PDF test");
        }
    }
}
