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

namespace DesktopApp.Luis
{
    public partial class EventetAdminUC : UserControl
    {
        string drejtuar;
        string checkedTitle;
        public EventetAdminUC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Njoftime(Emri, DataEvent, Kategori, Pershkrim) VALUES('" + textBox1.Text + "',now(),'" + drejtuar + "','" + richTextBox1.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Njoftimi u krijua me sukses!");
                conn.Close();


                DisplayElements();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ka nje gabim teknik:" + ex.Message + "\t" + ex.GetType());
            }

        }
        void DisplayElements()
        {
            //comboBox3.Items.Clear();
            var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Njoftime ";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            checkedListBox1.Items.Add(reader.GetString("Emri"));
                        }
                    }
                }
            }
        }

        private void EventetAdminUC_Load(object sender, EventArgs e)
        {
            //checkedListBox1.Items.Add("Festat 28-29 Nentori");
            //checkedListBox1.Items.Add("Faza 1 Prezantimi i diplomave");
            //checkedListBox1.Items.Add("Festat e fundvitit");
            DisplayElements();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = checkedListBox1.Items.Count;


            for (int index = count; index > 0; index--)

            {
                if (checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[index - 1]))
                {
                    try
                    {
                    checkedTitle = checkedListBox1.GetItemText(checkedListBox1.Items[index - 1]);
                        try
                        {
                            MySqlConnection conn = new MySqlConnection("server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME");
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand("Delete FROM Njoftime WHERE Emri = '"+checkedTitle+"'", conn);
                            cmd.ExecuteNonQuery();
                            
                            conn.Close();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ka nje gabim teknik:" + ex.Message + "\t" + ex.GetType());
                        }
                        checkedListBox1.Items.RemoveAt(index - 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    
                }
            }
        }

    

           
         

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                drejtuar = "te dyve";
            }
            else
                drejtuar = "mesuesve";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                drejtuar = "te dyve";
            }
            else
                drejtuar = "prinderve";
        }
    }
}
