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
        static private string klasa, klasaID, lenda, lendaID, loginID, mesuesID, data;
        static private long temaID;

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

        static public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        static public long TemaID
        {
            get
            {
                return temaID;
            }

            set
            {
                temaID = value;
            }
        }

        static public string LendaID
        {
            get
            {
                return lendaID;
            }

            set
            {
                lendaID = value;
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

        static public string KlasaID
        {
            get
            {
                return klasaID;
            }

            set
            {
                klasaID = value;
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
