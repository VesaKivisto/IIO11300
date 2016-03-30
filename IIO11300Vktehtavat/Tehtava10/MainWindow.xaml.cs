using System;
using System.Collections.Generic;
using System.Data;
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

namespace Tehtava10
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
            Init();
            HaePelaajat();
        }

        public void Init()
        {
            string[] seurat = new string[15] { "Blues", "HIFK", "HPK", "Ilves", "JYP", "KalPa", "KooKoo", "Kärpät", "Lukko", "Pelicans", "SaiPa", "Sport", "Tappara", "TPS", "Ässät" };
            foreach (string arvo in seurat)
            {
                cboSeura.Items.Add(arvo);
            } 
        }

        public void HaePelaajat()
        {
            try
            {
                pelaajaLista = Pelaaja.GetPlayers();
                lbPelaajat.Items.Clear();
                foreach (var arvo in pelaajaLista)
                {
                    lbPelaajat.Items.Add(arvo.EsitysNimi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                lblIlmoitus.Content = "Pelaaja " + pelaaja.KokoNimi + " valittu.";
            }
        }

        private void btnLopeta_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnTallennaKantaan_Click(object sender, RoutedEventArgs e)
        {
            if (lbPelaajat.SelectedIndex >= 0)
            {
                Pelaaja nykyinen = pelaajaLista[lbPelaajat.SelectedIndex];
                nykyinen.Etunimi = txtEtunimi.Text;
                nykyinen.Sukunimi = txtSukunimi.Text;
                nykyinen.Siirtohinta = txtSiirtohinta.Text;
                nykyinen.Seura = cboSeura.Text;
                lbPelaajat.SelectedIndex = -1;
                if (Pelaaja.UpdatePlayer(nykyinen) > 0)
                {
                    HaePelaajat();
                    MessageBox.Show(string.Format("Pelaajan {0} tiedot muutettu onnistuneesti", nykyinen.KokoNimi));
                }
            }
            else
            {
                Pelaaja uusi = new Pelaaja(txtEtunimi.Text, txtSukunimi.Text, txtSiirtohinta.Text, cboSeura.Text);
                Pelaaja.InsertPlayer(uusi);
                HaePelaajat();
                MessageBox.Show(string.Format("Pelaaja {0} lisätty onnistuneesti", uusi.KokoNimi));
            }
        }
    }
}
