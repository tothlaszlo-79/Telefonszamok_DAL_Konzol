using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telefonszamok_WPF
{
    //azért kell ez az osztály hogy ide töltsük be a táblázatból az adatokat (saját felépítésben nem ahogy a táblákban szerepelnek)
    class SzemelyesAdatok
    {
        public string Vezeteknev { get; set; }
        public string Utonev { get; set; }
        public Int16 Irsz { get; set; }
        public string Helysegnev { get; set; }
        public string Lakcim { get; set; }
        public string Telefonszamok { get; set; }
    }
}
