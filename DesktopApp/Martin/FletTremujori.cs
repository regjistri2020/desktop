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

namespace DesktopApp.Martin
{
    public partial class FletTremujori : UserControl
    {

        DataTable table = new DataTable();
        public FletTremujori()
        {
            InitializeComponent();
        }


        private void KerkoButton_Click(object sender, EventArgs e)
        {
            if (NxenestextBox.Text == "Martin")
            {
                table.Rows.Clear();
                table.Rows.Add(" 1", "Gjuhë Shqipe", 10, 10, 10);
                table.Rows.Add(" 2", "Letërsi", 10, 10, 10);
                table.Rows.Add(" 3", "Gjuhë e huaj - Anglisht", 10, 10, 10);
                table.Rows.Add(" 4", "Gjuhë e huaj - Gjermanisht ", 10, 10, 10);
                table.Rows.Add(" 5", "Gjeografi", 10, 10, 10);
                table.Rows.Add(" 6", "Matematikë", 10, 10, 10);
                table.Rows.Add(" 7", "Biologji", 10, 10, 10);
                table.Rows.Add(" 8", "Fiskulturë ", 10, 10, 10);
                table.Rows.Add(" 9", "Programim dhe inxhinieri Softwaresh", 10, 10, 10);
                table.Rows.Add("10", "Baza të dhënash dhe sistemet e informacionit", 10, 10, 10);
                table.Rows.Add("11", "Sisteme rrjetash dhe sisteme të shpërndara", 10, 10, 10);
                table.Rows.Add("12", "Ekonomi ndërmarrjeje dhe menaxhim ", 10, 10, 10);
                table.Rows.Add("13", "Planifikim sistemi dhe zhvillim projektesh", 10, 10, 10);
            }
            else
            {
                table.Rows.Clear();
                table.Rows.Add(" 1", "Gjuhë Shqipe", 9, 9, 10);
                table.Rows.Add(" 2", "Letërsi", 8, 9, 10);
                table.Rows.Add(" 3", "Gjuhë e huaj - Anglisht", 9, 10, 10);
                table.Rows.Add(" 4", "Gjuhë e huaj - Gjermanisht ", 8, 8, 9);
                table.Rows.Add(" 5", "Gjeografi", 10, 10, 10);
                table.Rows.Add(" 6", "Matematikë", 9, 9, 9);
                table.Rows.Add(" 7", "Biologji", 10, 10, 10);
                table.Rows.Add(" 8", "Fiskulturë ", 10, 10, 10);
                table.Rows.Add(" 9", "Programim dhe inxhinieri Softwaresh", 10, 9, 10);
                table.Rows.Add("10", "Baza të dhënash dhe sistemet e informacionit", 10, 10, 9);
                table.Rows.Add("11", "Sisteme rrjetash dhe sisteme të shpërndara", 9, 10, 10);
                table.Rows.Add("12", "Ekonomi ndërmarrjeje dhe menaxhim ", 10, 10, 10);
                table.Rows.Add("13", "Planifikim sistemi dhe zhvillim projektesh", 10, 10, 10);
            }

            dataGridView1.DataSource = table;
        }

        private void FletTremujori_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            table.Columns.Add("Nr.", typeof(string));
            table.Columns.Add("Emërtimet", typeof(string));
            table.Columns.Add("Notë me gojë", typeof(string));
            table.Columns.Add("Notë Portofoli", typeof(string));
            table.Columns.Add("Notë Testi", typeof(string));
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // used to hide specific columns
            //this.dataGridView1.Columns["CustomerID"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
