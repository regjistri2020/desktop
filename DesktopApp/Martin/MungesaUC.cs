using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using MySql.Data.MySqlClient;

namespace DesktopApp.Martin
{
    public partial class MungesaUC : UserControl
    {

        long lastTemaId;

        DataTable table = new DataTable();

        public MungesaUC()
        {
            InitializeComponent();
        }

        private void Kerkobutton_Click(object sender, EventArgs e)
        {
            
            
        }

        private void MungesaUC_Load(object sender, EventArgs e)
        {
            //MySqlConnection conn = new MySqlConnection("server=remotemysql.com;userid=gBh6InugME;password=NSGsLG2ITM;database=gBh6InugME");
            //conn.Open();
            //MySqlCommand cmd = new MySqlCommand("INSERT INTO TematMesimore (DataTemes, MesuesID, LendaID, KlasaID, TemaMesimore) VALUES ('" + theDate + "', '" + CookieClass.MesuesID + "', '" + CookieClass.LendaID + "', '" + CookieClass.KlasaID + "', '" + textBox1.Text + "');", conn);
            //cmd.ExecuteNonQuery();
            //lastTemaId = cmd.LastInsertedId;
            //MessageBox.Show("Tema u shtua me sukses!" + lastTemaId);
            //conn.Close();


            

        }

        private void button1_Click(object sender, EventArgs e)
        {





            var accountSid = "AC3648693fb0ccb73d81ffbf42186b6248";
            var authToken = "dd6ae58115bf55404da4e875ec0f66c8";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+355686888201"));
            messageOptions.MessagingServiceSid = "MGc2b6f0ceb144dbb8149397ffe352017c";
            messageOptions.Body = "Ky eshte nje mesazh i automatizuar nga platforma e nxenesit.al";

            //var message = MessageResource.Create(messageOptions);
            //Console.WriteLine(message.Body);
        }
    }
}
