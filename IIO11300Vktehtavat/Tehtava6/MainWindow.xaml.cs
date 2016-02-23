using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
using System.Xml;
using System.Xml.Linq;

namespace Tehtava6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XElement xe;
        
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                cbCountry.SelectedIndex = 0;
                xe = XElement.Load(ConfigurationManager.AppSettings["file"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgdWines.Items.Clear();

                if (cbCountry.SelectedItem.ToString() == "All")
                {
                    foreach (XElement wine in xe.Elements("wine"))
                    {
                        dgdWines.Items.Add(wine);
                    }
                }
                else
                {
                    foreach (XElement wine in xe.Elements("wine"))
                    {
                        if (wine.Element("maa").Value == cbCountry.SelectedItem.ToString())
                        {
                            dgdWines.Items.Add(wine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbCountry_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(ConfigurationManager.AppSettings["file"]);
                XmlNodeList countryNodes = xd.SelectNodes("/viinikellari/wine/maa");
                cbCountry.Items.Add("All");

                foreach (XmlNode name in countryNodes)
                {
                    if (!cbCountry.Items.Contains(name.InnerText))
                    {
                        cbCountry.Items.Add(name.InnerText);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
