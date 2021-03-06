﻿using MySql.Data.MySqlClient;
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
    public partial class TematMesimore : Form
    {
        public TematMesimore()
        {
            InitializeComponent();
        }

        private void TematMesimore_Load(object sender, EventArgs e)
        {
            label2.Text = CookieClass.Klasa;
            label3.Text = CookieClass.Lenda;
            

            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT TemaMesimore AS 'Tema e mesimit', DataTemes AS 'Data' FROM TematMesimore where MesuesID = '"+CookieClass.MesuesID+"' and KlasaID IN (SELECT KlasaID FROM Klasa WHERE Emri = '"+CookieClass.Klasa+"') and LendaID in (SELECT LendaID FROM Lendet WHERE EmerLende = '"+CookieClass.Lenda+"') ORDER BY DataTemes DESC";
                    using (var da = new MySqlDataAdapter(query, connection))
                    {
                    var ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                connection.Close();
            }
        }
    }
}
