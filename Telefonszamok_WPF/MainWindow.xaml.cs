using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Telefonszamok_DAL_Konzol;

namespace Telefonszamok_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Privát változó létrehzása az adatfottás számára
        private cnTelefonszamok cnTelefonszamok;

        public MainWindow()
        {
            InitializeComponent();
            
            //a telefonszámok adatbázis inicializálása
            cnTelefonszamok = new cnTelefonszamok();
        }

        private void miMentes_Click(object sender, RoutedEventArgs e)
        {
            //adatváltozások mentése 
            cnTelefonszamok.SaveChanges();
        }

        private void miKilepes_Click(object sender, RoutedEventArgs e)
        {
            //kilépés az aktuális aplikációból.
            //ui. ha ide is bekerül egy cnTelefonszamok.SaveChanges(); akkor kilépéskor van egy autómatikus mentés.
            Application.Current.Shutdown();
        }

        private void miHelysegek_Click(object sender, RoutedEventArgs e)
        {
            //a grHelyseg grid elrejtése a formon. Mivel alapból rejtett ezért ez akkor érdekes, ha előtte látható volt
            grHelyseg.Visibility = Visibility.Hidden;
            //a dgAdatracs láthatóvá tétele
            dgAdatracs.Visibility = Visibility.Visible;
            //LinQ lekérdezés amivel betöltjük az er változóba a enHelysegek tabla adatait. Értékadás 1. lehetősége
            var er = (from x in cnTelefonszamok.enHelysegek select new {  x.Irsz, x.Nev}).ToList();

            //értékadás a dgAdatracs esetében a Bindig property-n keresztül
            dgAdatracs.ItemsSource = er;
        }

        private void miMindenAdat_Click(object sender, RoutedEventArgs e)
        {

            //a grHelyseg grid elrejtése a formon. Mivel alapból rejtett ezért ez akkor érdekes, ha előtte látható volt
            grHelyseg.Visibility = Visibility.Hidden;
            //a dgAdatracs láthatóvá tétele
            dgAdatracs.Visibility = Visibility.Visible;
            //var tipusú változó létrehozása SzemélyesAdatok generikus tipussal
            var er = new List<SzemelyesAdatok>();
            //Az összes személy feldolgozása ciklusban
            foreach (var x in cnTelefonszamok.enSzemelyek)
            {
                //egy új SzemelyesAdatok változónak értékül adjuk az aktuális személy adatait és ezt az er listában letároljuk. Értékadás 2. lehetősége
                er.Add(new SzemelyesAdatok()
                {
                    Vezeteknev = x.Vezeteknev,
                    Utonev = x.Utonev,
                    Helysegnev = x.enHelyseg.Nev,
                    Irsz = x.enHelyseg.Irsz,
                    Lakcim = x.Lakcim,
                    //a Bovitő osztályban található metódust meghívva összefűzött telefonszám adatokat itt kapjuk meg. 
                    Telefonszamok = x.Telefonszamok()
                });
            }
            //a dgAdatracs forrásának beállítása a Binding property-n keresztül
            dgAdatracs.ItemsSource = er;
        }

        private void miHelysegAM_Click(object sender, RoutedEventArgs e)
        {
            //a dgAdatracs összecsukása
            dgAdatracs.Visibility = Visibility.Collapsed;
            //a grHelyseg grid megjelenítése a formon
            grHelyseg.Visibility = Visibility.Visible;
            //a grHelyseg grid értékadása a Binding property-n keresztül. Itt egy collectiont egyben adunk értékül. Értékadás 3. lehetősége
            grHelyseg.DataContext = cnTelefonszamok.enHelysegek.ToList();
            cbIrsz.SelectedItem = 0;
        }

        private void cbIrsz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //a cbIrsz combobox változásán kersztül megkapjuk azt az értéket ami ki lett választva. ezt töltjük be az enAktuális véltozóba cast-olás után
            var enAktualis = ((ComboBox)sender).SelectedItem as enHelyseg;
            //a cbHelysegnev combo box ertekenek beállítása, az IsSynchronizedWithCurrentItem beállítás miatt a két elem együtt változik 
            cbHelysegnev.SelectedItem = enAktualis;
            //a text boxok értékének bállítása
            tbIrsz.Text = enAktualis.Irsz.ToString();
            tbHelysegnev.Text = enAktualis.Nev;
        }

        private void btRogzit_Click(object sender, RoutedEventArgs e)
        {
            //var tipus létrehozása enHelység ként itt a textbox-ok értékei kerülnek beállításara.
            var teszt = new enHelyseg { Irsz = Int16.Parse(tbIrsz.Text), Nev = tbHelysegnev.Text.ToString() };

            //ha az  új helység nyomógomb aktív akkor hozzáadás a cnTelefonszámok.enHelysegek táblájához
            if (!btUjHelyseg.IsEnabled)
            {
                
                cnTelefonszamok.enHelysegek.Add(teszt);
            }
            //adatok mentése
            cnTelefonszamok.SaveChanges();
            //form bezárása
            grHelyseg.Visibility = Visibility.Hidden;
            //Gombok engedélyezése
            Beallit(true);
        }

        private void btVissza_Click(object sender, RoutedEventArgs e)
        {
            //aktuális ablak "bezárása"
            grHelyseg.Visibility = Visibility.Hidden;
        }

        private void btUjHelyseg_Click(object sender, RoutedEventArgs e)
        {
            //gombok letiltása
            Beallit(false);
            //textboxok értékének üresre állítása
            tbIrsz.Text = "";
            tbHelysegnev.Text = "";
        }

        private void Beallit(bool b)
        {
            btUjHelyseg.IsEnabled = b;
            cbIrsz.IsEnabled = b;
            cbHelysegnev.IsEnabled = b;
        }
    }
}
