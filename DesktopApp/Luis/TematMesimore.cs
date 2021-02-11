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

        }
    }
}
