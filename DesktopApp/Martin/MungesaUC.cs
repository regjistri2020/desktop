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

namespace DesktopApp.Martin
{
    public partial class MungesaUC : UserControl
    {
        DataTable table = new DataTable();

        public MungesaUC()
        {
            InitializeComponent();
        }

        private void Kerkobutton_Click(object sender, EventArgs e)
        {
            
            if (KerkonxTextBox.Text == "Martin")
            {
                table.Rows.Clear();
                table.Rows.Add("Martin", "Koçi", false);
            }
            else
            {
                table.Rows.Clear();
                table.Rows.Add("Aldi", "Duka", false);
                table.Rows.Add("Almirado", "Lekgegaj", true);
                table.Rows.Add("Andja", "Bardha", false);
                table.Rows.Add("Armando", "Harizi", true);
                table.Rows.Add("Brajan", "Kuca", true);
                table.Rows.Add("Dorian", "Danushi", true);
                table.Rows.Add("Ejona", "Çaushi", true);
                table.Rows.Add("Elger", "Topi", false);
                table.Rows.Add("Elis", "Sadikaj", true);
                table.Rows.Add("Emanuel", "Shanku", true);
                table.Rows.Add("Enes", "Vojka", true);
                table.Rows.Add("Enis", "Lika", true);
                table.Rows.Add("Florian", "Hiso", true);
                table.Rows.Add("Geldi", "Koni", true);
                table.Rows.Add("Gerind", "Tershana", true);
                table.Rows.Add("Gerti", "Dokaj", false);
                table.Rows.Add("Kevin", "Ali", false);
                table.Rows.Add("Kevin", "Merko", true);
                table.Rows.Add("Klaus", "Tanku", true);
                table.Rows.Add("Klea", "Manushi", false);
                table.Rows.Add("Lea", "Allkoja", false);
                table.Rows.Add("Luis", "Kateshi", false);
                table.Rows.Add("Martin", "Koçi", false);
                table.Rows.Add("Orges", "Bardhi", false);
                table.Rows.Add("Rejon", "Hakrama", false);
                table.Rows.Add("Renis", "Hoxha", true);
                table.Rows.Add("Rineda", "Dallashi", false);
                table.Rows.Add("Rogers", "Bardhi", true);
                table.Rows.Add("Thoma", "Nika", true);
                table.Rows.Add("Valeriano", "Bardhi", false);
                table.Rows.Add("Zyber", "Korbi", true);
            }
            dataGridView1.DataSource = table;
        }

        private void MungesaUC_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            table.Columns.Add("Emri", typeof(string));
            table.Columns.Add("Mbiemri", typeof(string));
            table.Columns.Add("Mungesë", typeof(bool));

            table.Rows.Add("Aldi", "Duka", false);
            table.Rows.Add("Almirado", "Lekgegaj", true);
            table.Rows.Add("Andja", "Bardha", false);
            table.Rows.Add("Armando", "Harizi", true);
            table.Rows.Add("Brajan", "Kuca", true);
            table.Rows.Add("Dorian", "Danushi", true);
            table.Rows.Add("Ejona", "Çaushi", true);
            table.Rows.Add("Elger", "Topi", false);
            table.Rows.Add("Elis", "Sadikaj", true);
            table.Rows.Add("Emanuel", "Shanku", true);
            table.Rows.Add("Enes", "Vojka", true);
            table.Rows.Add("Enis", "Lika", true);
            table.Rows.Add("Florian", "Hiso", true);
            table.Rows.Add("Geldi", "Koni", true);
            table.Rows.Add("Gerind", "Tershana", true);
            table.Rows.Add("Gerti", "Dokaj", false);
            table.Rows.Add("Kevin", "Ali", false);
            table.Rows.Add("Kevin", "Merko", true);
            table.Rows.Add("Klaus", "Tanku", true);
            table.Rows.Add("Klea", "Manushi", false);
            table.Rows.Add("Lea", "Allkoja", false);
            table.Rows.Add("Luis", "Kateshi", false);
            table.Rows.Add("Martin", "Koçi", false);
            table.Rows.Add("Orges", "Bardhi", false);
            table.Rows.Add("Rejon", "Hakrama", false);
            table.Rows.Add("Renis", "Hoxha", true);
            table.Rows.Add("Rineda", "Dallashi", false);
            table.Rows.Add("Rogers", "Bardhi", true);
            table.Rows.Add("Thoma", "Nika", true);
            table.Rows.Add("Valeriano", "Bardhi", false);
            table.Rows.Add("Zyber", "Korbi", true);
            dataGridView1.DataSource = table;
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
