using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tehtava11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SMLiigaEntities ctx;
        ObservableCollection<Pelaajat> localBooks;
        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }

        private void InitMyStuff()
        {
            ctx = new SMLiigaEntities();
            ctx.Pelaajat.Load();
            localBooks = ctx.Pelaajat.Local;

            string[] seurat = new string[17] { "Blues", "HIFK", "HPK", "Ilves", "JYP", "KalPa", "KooKoo", "Kärpät", "Lukko", "Pelicans", "SaiPa", "Sport", "Tappara", "TPS", "Ässät", "Jokerit", "Anaheim" };
            foreach (string arvo in seurat)
            {
                cboSeura.Items.Add(arvo);
            }
        }

        private void btnHae_Click(object sender, RoutedEventArgs e)
        {
            lbPelaajat.Items.Clear();
            var pelaajat = ctx.Pelaajat.ToList();
            foreach (var pelaaja in pelaajat)
            {
                lbPelaajat.Items.Add(pelaaja.Kokonimi);
            }
        }

        private void lbPelaajat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbPelaajat.SelectedIndex >= 0)
            {
                var pelaajat = ctx.Pelaajat.ToList();
                spPelaaja.DataContext = pelaajat[lbPelaajat.SelectedIndex];
            }
        }

        private void btnLuo_Click(object sender, RoutedEventArgs e)
        {
            Pelaajat uusiPelaaja;
            if (btnLuo.Content.ToString() == "Luo uusi pelaaja")
            {
                uusiPelaaja = new Pelaajat();
                uusiPelaaja.etunimi = "Anna pelaajan tiedot";
                spPelaaja.DataContext = uusiPelaaja;
                btnLuo.Content = "Tallenna kantaan";
            }
            else
            {
                uusiPelaaja = (Pelaajat)spPelaaja.DataContext;
                ctx.Pelaajat.Add(uusiPelaaja);
                ctx.SaveChanges();
                btnLuo.Content = "Luo uusi pelaaja";
            }
        }

        private void btnTallenna_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPoista_Click(object sender, RoutedEventArgs e)
        {
            Pelaajat valittu = (Pelaajat)spPelaaja.DataContext;
            var retval = MessageBox.Show("Haluatko varmasti poistaa pelaajan " + valittu.Kokonimi + "?", "SM Liiga", MessageBoxButton.YesNo);
            if (retval == MessageBoxResult.Yes)
            {
                ctx.Pelaajat.Remove(valittu);
                ctx.SaveChanges();
            }
        }

        private void btnTallennaKantaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLopeta_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
