using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Luis
{
    public class CookieClass
    {

        static private string klasa, lenda;
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

    }
}
