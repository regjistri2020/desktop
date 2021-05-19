using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DesktopApp.Luis
{
    
    public partial class AdminKonfigurime : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        MySqlConnection conn;
        MySqlDataAdapter da;
        MySqlCommandBuilder cmb;
        DataSet ds;
        string connstr = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
        DataTable table = new DataTable();
        public AdminKonfigurime()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void AdminKonfigurime_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            string MesLog_query = "SELECT Count(*) FROM Periudha WHERE Emri = 'Tremujori 1'";
            MySqlCommand cmd = new MySqlCommand(MesLog_query, conn);
            cmd.ExecuteReader();

            conn.Close();

            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (Convert.ToInt32(dt.Rows[0][0]) == 0)
            {
                label17.Text = "Pa Filluar";
                label17.ForeColor = System.Drawing.Color.Gray;
                label18.Text = "Pa Filluar";
                label18.ForeColor = System.Drawing.Color.Gray;
                button5.Hide();
                button6.Hide();
                label20.Text = "Pa Filluar";
                label20.ForeColor = System.Drawing.Color.Gray;
                button4.Text = "Fillo Tremujorin";
            }
            else
            {
                var connectionString = "server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT * FROM Periudha WHERE Emri = 'Tremujori 1'";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            
                            while (reader.Read())
                            {
                                if(reader.GetString("Statusi")=="Mbyllur")
                                {
                                    label17.Text = "Mbyllur";
                                    label17.ForeColor = System.Drawing.Color.Red;
                                    button4.Hide();
                                    using (var connection1 = new MySqlConnection(connectionString))
                                    {
                                        connection1.Open();
                                        var query1 = "SELECT * FROM Periudha WHERE Emri = 'Tremujori 2'";
                                        using (var command1 = new MySqlCommand(query1, connection1))
                                        {
                                            using (var reader1 = command1.ExecuteReader())
                                            {
                                                //Iterate through the rows and add it to the combobox's items
                                                while (reader1.Read())
                                                {
                                                    if (reader1.GetString("Statusi") == "Mbyllur")
                                                    {
                                                        label18.Text = "Mbyllur";
                                                        label18.ForeColor = System.Drawing.Color.Red;
                                                        button5.Hide();
                                                    }

                                                    else if (reader1.GetString("Statusi") == "Aktiv")
                                                    {
                                                        label18.Text = "Aktiv";
                                                        label20.Text = "Pa Filluar";
                                                        label20.ForeColor = System.Drawing.Color.Gray;
                                                        button5.Show();
                                                        button6.Hide();
                                                        button5.Text = "Mbyll Tremujorin";
                                                    }
                                                }
                                            }
                                        }
                                        connection1.Close();
                                    }
                                }

                                else if(reader.GetString("Statusi") == "Aktiv")
                                {
                                    label17.Text = "Aktiv";
                                    label17.ForeColor = System.Drawing.Color.Green;
                                    label18.Text = "Pa filluar";
                                    label18.ForeColor = System.Drawing.Color.Gray;
                                    label20.Text = "Pa filluar";
                                    label20.ForeColor = System.Drawing.Color.Gray;
                                    button4.Text = "Mbyll Tremujorin";
                                    button5.Hide();
                                    button6.Hide(); 
                                }
                            }
                            connection.Close();
                        }
                    }
                }
                
            }


            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                string query = "select * from Login where RoleID=2";
                da = new MySqlDataAdapter(query, conn);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                string Query1 = "insert into Login(User_Name, Pasword, RoleID) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','2' )";
                MySqlCommand cmd = new MySqlCommand(Query1, conn);
                cmd.ExecuteReader();
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                string query = "select * from Login where RoleID=2";
                da = new MySqlDataAdapter(query, conn);
                ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox2.Image = new Bitmap(open.FileName);
                // image file path  
                //textBox1.Text = open.FileName;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);
            cmb = new MySqlCommandBuilder(da);
            da.Update(ds);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void T(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmb = new MySqlCommandBuilder(da);
            da.Update(ds);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Fillo Tremujorin")
            {
                try
                {
MySqlConnection conn = new MySqlConnection(connstr);
                string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
                string query = "INSERT INTO Periudha(Emri, Data1, Statusi) VALUES('Tremujori 1','"+date+"','Aktiv')";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteReader();
                MessageBox.Show("Tani e tutje notat e vendosura do ti përkasin \n tremujorit të parë, deri në mbyllje të tij.");
                conn.Close();
                button4.Text = "Mbyll Tremujorin";
                label17.Text = "Aktiv";
                label17.ForeColor = System.Drawing.Color.Green;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                
                try
                {
                    MySqlConnection conn = new MySqlConnection(connstr);
                    string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
                    string query = "UPDATE Periudha SET Data2 = '" + date + "', Statusi='Mbyllur' WHERE Emri='Tremujori 1'";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteReader();
                    MessageBox.Show("Tremujori i parë u mbyll me sukses!");
                    conn.Close();
                    button4.Hide();
                    label17.Text = "Mbyllur";
                    label17.ForeColor = System.Drawing.Color.Red;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    MySqlConnection conn = new MySqlConnection(connstr);
                    string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
                    string query = "INSERT INTO Periudha(Emri, Data1, Statusi) VALUES('Tremujori 2','" + date + "','Aktiv')";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteReader();
                    MessageBox.Show("Tani e tutje notat e vendosura do ti përkasin \n tremujorit të dytë, deri në mbyllje të tij.");
                    conn.Close();
                    button4.Hide();
                    label18.Text = "Aktiv";
                    button5.Show();
                    label18.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
