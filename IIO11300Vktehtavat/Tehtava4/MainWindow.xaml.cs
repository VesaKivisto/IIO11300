using System;
using System.Collections.Generic;
using System.IO;
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

namespace Tehtava4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pelaaja> pelaajaLista;
        public MainWindow()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            pelaajaLista = new List<Pelaaja>();
            string[] seurat = new string[15] { "Blues", "HIFK", "HPK", "Ilves", "JYP", "KalPa", "KooKoo", "Kärpät", "Lukko", "Pelicans", "SaiPa", "Sport", "Tappara", "TPS", "Ässät" };
            foreach (string arvo in seurat)
            {
                cboSeura.Items.Add(arvo);
            }
        }

        private void btnLuo_Click(object sender, RoutedEventArgs e)
        {
            int listaKoko = pelaajaLista.Count;
            Pelaaja pelaaja;
            try
            {
                if (txtEtunimi.Text != "" && txtSukunimi.Text != "" && txtSiirtohinta.Text != "" && cboSeura.Text != "")
                {
                    if (listaKoko > 0)
                    {                      
                        if (!pelaajaLista.Exists(item => item.KokoNimi == (txtEtunimi.Text + " " + txtSukunimi.Text)))
                        {
                            pelaaja = new Pelaaja(txtEtunimi.Text, txtSukunimi.Text, int.Parse(txtSiirtohinta.Text), cboSeura.Text);
                            pelaajaLista.Add(pelaaja);
                            ApplyChanges();
                            lblIlmoitus.Content = "Pelaaja lisätty.";
                        }
                        else
                        {
                            lblIlmoitus.Content = "Pelaaja on jo luotu.";
                        }  
                    }
                    else
                    {
                        pelaaja = new Pelaaja(txtEtunimi.Text, txtSukunimi.Text, int.Parse(txtSiirtohinta.Text), cboSeura.Text);
                        pelaajaLista.Add(pelaaja);
                        ApplyChanges();
                        lblIlmoitus.Content = "Pelaaja lisätty.";
                    }
                }
                else
                {
                    lblIlmoitus.Content = "Täytäthän jokaisen kentän.";
                }
            }
            catch (Exception ex) 
            {
                lblIlmoitus.Content = ex.Message;
            }
        }
        private void ApplyChanges()
        {
            lbPelaajat.Items.Clear();
            foreach(var arvo in pelaajaLista)
            {
                lbPelaajat.Items.Add(arvo.EsitysNimi);
            }
        }
        private void lbPelaajat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbPelaajat.SelectedIndex >= 0)
            {
                Pelaaja pelaaja = pelaajaLista[lbPelaajat.SelectedIndex];
                txtEtunimi.Text = pelaaja.Etunimi;
                txtSukunimi.Text = pelaaja.Sukunimi;
                txtSiirtohinta.Text = pelaaja.Siirtohinta.ToString();
                cboSeura.Text = pelaaja.Seura;
                imgPelaaja.Source = getImageSource(pelaaja.Kuva);

                lblIlmoitus.Content = "Pelaaja " + pelaaja.KokoNimi + " valittu.";
            }
        }
        private void btnTallenna_Click(object sender, RoutedEventArgs e)
        {
            if (lbPelaajat.SelectedIndex >= 0)
            {
                Pelaaja pelaaja = pelaajaLista[lbPelaajat.SelectedIndex];
                pelaaja.Etunimi = txtEtunimi.Text;
                pelaaja.Sukunimi = txtSukunimi.Text;
                pelaaja.Siirtohinta = int.Parse(txtSiirtohinta.Text);
                pelaaja.Seura = cboSeura.Text;
                lbPelaajat.SelectedIndex = -1;
                ApplyChanges();
                lblIlmoitus.Content = "Pelaajan tiedot tallennettu.";
            }
            else
            {
                lblIlmoitus.Content = "Ei pelaajaa valittuna.";
            }
        }
        private void btnPoista_Click(object sender, RoutedEventArgs e)
        {
            if (lbPelaajat.SelectedIndex >= 0)
            {
                pelaajaLista.RemoveAt(lbPelaajat.SelectedIndex);
                lbPelaajat.SelectedIndex = -1;
                ApplyChanges();
                lblIlmoitus.Content = "Pelaaja poistettu.";
            }
            else
            {
                lblIlmoitus.Content = "Ei pelaajaa valittuna.";
            }
        }
        private void btnKirjoita_Click(object sender, RoutedEventArgs e)
        {
            Save dialog = new Save();
            dialog.ShowDialog();
            string tiedosto = dialog.txtTiedosto.Text;

            foreach (var arvo in pelaajaLista)
            {
                string kirjoita = "Pelaaja: " + arvo.EsitysNimi + "\r\n" + "Siirtohinta: " + arvo.Siirtohinta + "\r\n" + "Kuva: " + arvo.Kuva + "\r\n\r\n";
                File.AppendAllText(tiedosto, kirjoita);
            }

            lblIlmoitus.Content = "Tiedot kirjoitettu tiedostoon " + tiedosto + ".";
        }
        private void btnLopeta_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private BitmapImage getImageSource(string source)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = new Uri(source, UriKind.Relative);
            bmp.EndInit();
            return bmp;
        }
    }
}
