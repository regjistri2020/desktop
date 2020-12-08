using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Luis
{
    public partial class EventetAdminUC : UserControl
    {
        public EventetAdminUC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textBox1.Text);
        }
    }
}
