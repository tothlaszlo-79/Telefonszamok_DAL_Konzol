using System.Linq;
using Telefonszamok_DAL_Konzol;

namespace Telefonszamok_WPF
{
    public static class Bovito
    {
        //kiegészítő metódus a telefonszámok kezeléséhez. Egy enSzemely entitást kap a konstruktorban ezen fog foreach ciklusban végigmenni.
        public static string Telefonszamok(this enSzemely enSzemely)
        {
            var s = "";
            foreach (var x in enSzemely.enTelefonszamok)
            {
                s = s + x.Szam;
                //ha nem az ustolsó elem akkor az s változóhoz hozzáad még egy y karaktert. A Last a collection tipusú adatokon értelmezett művelet mint pl. First, Next stb
                if (x != enSzemely.enTelefonszamok.Last()) 
                    s = s + ", ";
            }
            return s;
        }
    }
}
