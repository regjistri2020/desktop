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
using DesktopApp.Luis;

namespace DesktopApp.Martin
{
    public partial class MesuesDashboardUC : UserControl
    {
        
        public MesuesDashboardUC()
        {
            InitializeComponent();
        }

        private void DatatextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void MesuesDashboardUC_Load(object sender, EventArgs e)
        {
            string date = DateTime.UtcNow.ToString("dd-MM-yyyy");
            DatatextBox.Clear();
            DatatextBox.Text = Convert.ToString(date);



        }

        private void KlasatextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
