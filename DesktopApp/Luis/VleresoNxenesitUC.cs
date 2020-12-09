using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DesktopApp.Luis
{
	public partial class VleresoNxenesitUC : UserControl
	{
		SqlDataAdapter adap;
		SqlConnection con;
		DataSet ds;
		SqlCommandBuilder cmd;

		public VleresoNxenesitUC()
		{
			InitializeComponent();
		}


		private void pictureBox2_Click(object sender, EventArgs e)
		{
			
		}


	}
}
