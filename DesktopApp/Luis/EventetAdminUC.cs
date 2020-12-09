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
            textBox1.Text = "";
            richTextBox1.Text = "";
            numericUpDown1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;

        }

        private void EventetAdminUC_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("Festat 28-29 Nentori");
            checkedListBox1.Items.Add("Faza 1 Prezantimi i diplomave");
            checkedListBox1.Items.Add("Festat e fundvitit");
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = checkedListBox1.Items.Count;

            for (int index = count; index > 0; index--)

            {
                if (checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[index - 1]))
                {
                    checkedListBox1.Items.RemoveAt(index - 1);
                }

            }
        }
    }
}
