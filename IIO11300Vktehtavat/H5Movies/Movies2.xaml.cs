using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml;

namespace H5Movies
{
    /// <summary>
    /// Interaction logic for Movies2.xaml
    /// </summary>
    public partial class Movies2 : Window
    {
        public Movies2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Haetaan XmlDataProviderin XML-tiedoston nimi
            string file = xdpMovies.Source.LocalPath;
            // Tallennetaan XmlDocument olemassa olevan XML-tiedoston päälle
            xdpMovies.Document.Save(file);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Asetetaan textboxit viittaamaan pois datasta eli listasta ei ole valittuna mitään
            if (lbMovies.SelectedIndex >= 0)
            {
                lbMovies.SelectedIndex = -1;
                btnAdd.Content = "Save";
            }
            else
            {
                try
                {
                    // Lisätään uusi noodi XMLDocumenttiin
                    string file = xdpMovies.Source.LocalPath;
                    // Viittaus XmlDocumenttiin ja sen juurielementtiin
                    XmlDocument doc = xdpMovies.Document;
                    XmlNode root = doc.SelectSingleNode("/Movies");
                    // Luodaan uusi node
                    XmlNode newMovie = doc.CreateElement("Movie");
                    // Lisätään nodelle tarvittavat attribuutit
                    XmlAttribute nameAttr = doc.CreateAttribute("Name");
                    nameAttr.Value = txtName.Text;
                    newMovie.Attributes.Append(nameAttr);
                    XmlAttribute countryAttr = doc.CreateAttribute("Country");
                    countryAttr.Value = txtCountry.Text;
                    newMovie.Attributes.Append(countryAttr);
                    XmlAttribute directorAttr = doc.CreateAttribute("Director");
                    directorAttr.Value = txtDirector.Text;
                    newMovie.Attributes.Append(directorAttr);
                    XmlAttribute checkedAttr = doc.CreateAttribute("Checked");
                    checkedAttr.Value = chkWatched.IsChecked.Value.ToString();
                    newMovie.Attributes.Append(checkedAttr);
                    // Lisätään noodi juureen
                    root.AppendChild(newMovie);
                    // Tallennetaan XmlDocument uusine nodeineen olemassa olevan XML-tiedoston päälle
                    xdpMovies.Document.Save(file);
                    // Kaikki ok
                    MessageBox.Show("Uusi elokuva lisätty onnistuneesti");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    btnAdd.Content = "Add movie";
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Poistetaan käyttäjän valitsema elokuva -> poistettava node haetaan Name-attribuutin avulla
            try
            {
                string file = xdpMovies.Source.LocalPath;
                XmlDocument doc = xdpMovies.Document;
                XmlNode root = doc.SelectSingleNode("/Movies");
                XmlNode terminate = null;
                // Haetaan XPathilla poistettava node
                var item = doc.SelectSingleNode(string.Format("/Movies/Movie[@Name='{0}']", txtName.Text));
                if (item != null && MessageBox.Show("Poistetaanko elokuva " + txtName.Text, "Edit", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    terminate = item;
                    // Poistetaan noodi juuresta
                    root.RemoveChild(terminate);
                    xdpMovies.Document.Save(file);
                    // Listboxin osoitin
                    lbMovies.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
