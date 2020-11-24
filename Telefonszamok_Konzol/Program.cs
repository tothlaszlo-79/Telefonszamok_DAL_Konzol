using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telefonszamok_DAL_Konzol;

namespace Telefonszamok_Konzol
{
    class Program
    {
        static cnTelefonszamok cnTelefonszamok;
        static void Main(string[] args)
        {
            cnTelefonszamok = new cnTelefonszamok();
            // Adatfelvitel();
            Lekerdez();
        }

        private static void Adatfelvitel()
        {
            var helyseg = new enHelyseg { Irsz = 2000, Nev = "Teszthelyseg" };
            var szemely = new enSzemely
            {
                Vezeteknev = "",
                Utonev = "",
                Lakcim = "",
                enHelyseg = helyseg
            };

            helyseg.enSzemelyek.Add(szemely);
            var t1 = new enTelefonszam { Szam = "+36-555-555", enSzemely = szemely };
            var t2 = new enTelefonszam { Szam = "+36-666-666", enSzemely = szemely };
            szemely.enTelefonszamok.Add(t1);
            szemely.enTelefonszamok.Add(t2);
            cnTelefonszamok.enHelysegek.Add(helyseg);
            cnTelefonszamok.enSzemelyek.Add(szemely);
            cnTelefonszamok.enTelefonszamok.Add(t1);
            cnTelefonszamok.enTelefonszamok.Add(t2);
            cnTelefonszamok.SaveChanges();
        }

        private static void Lekerdez()
        {
            Console.WriteLine("Összes adat\r\n-------");
            foreach (var x in cnTelefonszamok.enSzemelyek)
            {
                var s = x.Vezeteknev + " " + x.Utonev + " " +
                    x.enHelyseg.Irsz + " " + x.enHelyseg.Nev + " " +
                    x.Lakcim + ", ";
                foreach (var y in x.enTelefonszamok)
                {
                    s += y.Szam;
                    if (y != x.enTelefonszamok.Last()) s += ", ";
                }
            Console.WriteLine(s);
            Console.ReadLine();
            }
        }

    }
}
