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
using System.Windows.Navigation;
using System.Windows.Shapes;
using JAMK.IT.IIO11300;

namespace H3MittausData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Luodaan lista mittausolioita varten
        List<MittausData> mittaukset;
        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }
        private void InitMyStuff()
        {
            //omat ikkunaan liittyvät alustukset
            txtToday.Text = DateTime.Today.ToShortDateString();
            mittaukset = new List<MittausData>();
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            //luodaan uusi mittausdata olio ja näytetään se käyttäjälle
            MittausData md = new MittausData(txtClock.Text, txtData.Text);
            //lbData.Items.Add(md); //testausta varten
            mittaukset.Add(md);
            ApplyChanges();
        }
        private void ApplyChanges()
        {
            lbData.ItemsSource = null;
            lbData.ItemsSource = mittaukset;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Kirjoitetaan mitatut tiedostoon
            try
            {
                MittausData.SaveToFileV2(txtFileName.Text, mittaukset);
                MessageBox.Show("Tiedot tallennettu onnistuneesti tiedostoon " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            // Haetaan käyttäjän antamasta tiedostosta mitatut arvot
            try
            {
                mittaukset = MittausData.ReadFromFile(txtFileName.Text);
                ApplyChanges();
                MessageBox.Show("Tiedot haettu onnistuneesti tiedostosta " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSerialize_Click(object sender, RoutedEventArgs e)
        {
            // Kutsutaan serialisointia
            try
            {
                Serialisointi.SerialisoiXml(txtFileName.Text, mittaukset);
                MessageBox.Show("Serialisoitu onnistuneesti tiedostoon " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            // Kutsutaan deserialisointia
            try
            {
                mittaukset = Serialisointi.DeSerialisoiXml(txtFileName.Text);
                ApplyChanges();
                MessageBox.Show("Deserialisoitu onnistuneesti tiedostosta " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSerializeBin_Click(object sender, RoutedEventArgs e)
        {
            // Kutsutaan serialisointia binäärimuotoon
            try
            {
                Serialisointi.Serialisoi(txtFileName.Text, mittaukset);
                MessageBox.Show("Binäärimuotoinen serialisointi onnistui tiedostoon " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDeserializeBin_Click(object sender, RoutedEventArgs e)
        {
            // Kutsutaan deserialisointia
            object obj = new object();
            try
            {
                Serialisointi.DeSerialisoi(txtFileName.Text, ref obj);
                // Ja nyt koetaan astata object-tyyppinen olio listaksi mittausdataan
                mittaukset = (List<MittausData>)obj;
                ApplyChanges();
                MessageBox.Show("Binäärimuotoinen deserialisointi onnistui tiedostosta " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
