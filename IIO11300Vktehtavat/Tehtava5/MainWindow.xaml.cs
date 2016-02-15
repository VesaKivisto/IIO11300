using Microsoft.Win32;
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
using System.Xml;
using System.Xml.Serialization;
using System.IO;

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
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "pelaajat";
                sfd.InitialDirectory = "d:\\";
                sfd.Filter = "Tekstitiedostot|*.txt|Xml-tiedostot|*.xml";
                Nullable<bool> result = sfd.ShowDialog();

                if (result == true)
                {
                    string tiedostonimi = sfd.FileName;
                    string tyyppi = System.IO.Path.GetExtension(tiedostonimi);
                    if (tyyppi == ".txt")
                    {
                        try
                        {
                            StreamWriter sw = new StreamWriter(tiedostonimi);
                            string rivi = "";
                            foreach (var arvo in pelaajaLista)
                            {
                                rivi = arvo.GetEverything();
                                sw.WriteLine(rivi);
                            }
                            sw.Close();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    if (tyyppi == ".xml")
                    {
                        try
                        {
                            Pelaaja.SerialisoiXml(tiedostonimi, pelaajaLista);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnLue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = "d:\\";
                ofd.Filter = "Tekstitiedostot .txt|*.txt|Xml-tiedostot .xml|*.xml";
                Nullable<bool> result = ofd.ShowDialog();

                if (result == true)
                {
                    string tiedostonimi = ofd.FileName;
                    string tyyppi = System.IO.Path.GetExtension(tiedostonimi);

                    if (tyyppi == ".txt")
                    {
                        if (File.Exists(tiedostonimi))
                        {
                            pelaajaLista = new List<Pelaaja>();
                            StreamReader sr;
                            string line;
                            try
                            {
                                sr = new StreamReader(File.OpenRead(tiedostonimi));
                                while (!sr.EndOfStream)
                                {
                                    line = sr.ReadLine();
                                    string[] tiedot = line.Split(' ');
                                    pelaajaLista.Add(new Pelaaja(tiedot[0], tiedot[1], int.Parse(tiedot[2]), tiedot[3]));
                                }
                                ApplyChanges();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    if (tyyppi == ".xml")
                    {
                        if (File.Exists(tiedostonimi))
                        {
                            try
                            {
                                pelaajaLista = Pelaaja.DeSerialisoiXml(tiedostonimi);
                                ApplyChanges();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnLopeta_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
