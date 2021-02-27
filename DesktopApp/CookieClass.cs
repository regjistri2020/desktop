using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DesktopApp.Luis
{
    public class CookieClass
    {
        static private string klasa, lenda, loginID, mesuesID;

        static public string MesuesID
        {
            get
            {
                return mesuesID;
            }

            set
            {
                mesuesID = value;
            }
        }

        static public string Klasa
        { 
            get
            {
                return klasa;
            }

            set
            {
                klasa = value;
            }
        }
   
        static public string Lenda
        {
            get
            {
                return lenda;
            }

            set
            {
                lenda = value;
            }
        }


        static public string LoginID
        {
            get
            {
                return loginID;
            }

            set
            {
                loginID = value;
            }
        }

    }
}
