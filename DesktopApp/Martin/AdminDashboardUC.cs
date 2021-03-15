using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DesktopApp.Martin
{
    public partial class AdminDashboardUC : UserControl
    {
        public AdminDashboardUC()
        {
            InitializeComponent();
        }

        private void AdminDashboardUC_Load(object sender, EventArgs e)
        {
            string date = DateTime.UtcNow.ToString("dd-MM-yyyy");
            DatatextBox.Clear();
            DatatextBox.Text = Convert.ToString(date);


            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT count(*) FROM Nxenes ";
                using (var command = new MySqlCommand(query, connection))
                {
                    object count = command.ExecuteScalar();
                    if (count != null) NxenestextBox.Text = count.ToString();
                }
            }


            var connectionString2 = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString2))
            {
                connection.Open();
                var query = "SELECT count(*) FROM Mesues ";
                using (var command = new MySqlCommand(query, connection))
                {
                    object count = command.ExecuteScalar();
                    if (count != null) MesuestextBox.Text = count.ToString();
                    else MesuestextBox.Text = "  ---  ";

                }
            }
        }

    }
}
