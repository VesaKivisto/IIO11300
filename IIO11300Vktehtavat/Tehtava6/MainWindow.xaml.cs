using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        XmlDocument xd;
        XElement xe;
        XmlNodeList countryNodes;
        public MainWindow()
        {
            InitializeComponent();
            CountrySelectorData();
        }

        public void CountrySelectorData()
        {
            string file = "..\\..\\Resources\\Viinit1.xml";
            xd = new XmlDocument();
            xd.Load(file);
            countryNodes = xd.SelectNodes("/viinikellari/wine/maa");
            List<string> countries = new List<string>();
            foreach (XmlElement item in countryNodes)
            {
                countries.Add(item.InnerText);
            }
            cbCountry.ItemsSource = countries.Distinct();
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
