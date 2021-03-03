using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Martin
{
    public partial class AdminDashboardUC : UserControl
    {
        public AdminDashboardUC()
        {
            InitializeComponent();
        }

        private void MesuestextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DatatextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ShkollatextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminDashboardUC_Load(object sender, EventArgs e)
        {
            DatatextBox.Clear();
            DatatextBox.Text = Convert.ToString(DateTime.UtcNow.ToString("MM-dd-yyyy"));
        }
    }
}
