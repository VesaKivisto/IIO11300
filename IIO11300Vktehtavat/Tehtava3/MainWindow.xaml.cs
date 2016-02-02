using System;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace Tehtava3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHae_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string dirName = txtHakemisto.Text;
                string[] fileNames = Directory.GetFiles(dirName, "*.txt");
                lstTiedostot.Items.Clear();
                foreach (string file in fileNames)
                {
                    lstTiedostot.Items.Add(file);
                }
                txtTulos.Text = ConfigurationManager.AppSettings["tulos"];
            }
            catch (Exception ex)
            {
                lblError.Content = ex.Message;
            }
        }

        private void btnYhdista_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string dirName = txtHakemisto.Text;
                string tulos = txtTulos.Text;
                string[] fileNames = Directory.GetFiles(dirName);
                string text = "";

                foreach (string file in fileNames)
                {
                    text += File.ReadAllText(file) + "\r\n";
                }

                File.WriteAllText(tulos, text);
            }
            catch (Exception ex)
            {
                lblError.Content = ex.Message;
            }
        }
    }
}
