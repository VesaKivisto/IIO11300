//Koodannut ja testannut toimivaksi 6.3.2014 EsaSalmik
using System;
using System.Linq;
using System.Data;
using System.Windows;
using JAMK.ICT.Data;

namespace JAMK.ICT.ADOBlanco
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connStr;
        private string tableName;
        private DataTable dtCustomerData; // UI:n kaikki metodit käyttävät tätä samaa DataTablea
        private DataView view;
        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }

        private void InitMyStuff()
        {
            try
            {
                string message = "";

                //esimerkki kuinka App.Configissa oleva connectionstring luetaan
                connStr = Properties.Settings.Default.Tietokanta;
                lbMessages.Content = connStr;
                tableName = Properties.Settings.Default.Taulu;
                dtCustomerData = DBPlacebo.GetAllCustomersFromSQLServer(connStr, tableName, "", out message);
                // Luodaan DataTablen oletusnäkymästä DataView
                view = dtCustomerData.DefaultView;
                FillMyCombo();
                lbMessages.Content = message;
            }
            catch (Exception ex)
            {
                lbMessages.Content = ex.Message;
            }
        }

        private void FillMyCombo()
        {
            // Täytetään cbCities kaupunkien nimillä
            // V1 Haetaan palvelimelta
            //cbCities.ItemsSource = DBPlacebo.GetCitiesFromSQLServer(connStr, tableName).DefaultView;
            //cbCities.DisplayMemberPath = "city";
            //cbCities.SelectedValuePath = "city";
            
            // V2 Haetaan dtCustomerData-muuttujasta
            var result = (from c in dtCustomerData.AsEnumerable() select c.Field<string>("City")).Distinct().ToList();
            cbCities.ItemsSource = result;
        }

        private void btnGet3_Click(object sender, RoutedEventArgs e)
        {
            dgCustomers.ItemsSource = DBPlacebo.GetTestCustomers().DefaultView;
        }

        private void btnGetAll_Click(object sender, RoutedEventArgs e)
        {
            // Haetaan asiakastiedot palvelimelta
            string message = "";
            try
            {
                // Kaikki asiakkaat DataGridiin
                // dgCustomers.ItemsSource = DBPlacebo.GetAllCustomersFromSQLServer(connStr, tableName, "", out message).DefaultView;
                dgCustomers.ItemsSource = view;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                lbMessages.Content = message;
            }
        }

        private void btnGetFrom_Click(object sender, RoutedEventArgs e)
        {
            // V1 haetaan asiakastiedot palvelimelta joka kerta uudestaan
            string message = "";
            string cityName = "";
            try
            {
                // Asiakkaat valitusta kaupungista DataGridiin
                if (cbCities.SelectedIndex >= 0)
                {
                    cityName = cbCities.SelectedValue.ToString();
                    view.RowFilter = string.Format("city = '{0}'", cityName);
                    dgCustomers.ItemsSource = view;
                    // dgCustomers.ItemsSource = DBPlacebo.GetAllCustomersFromSQLServer(connStr, tableName, cityName, out message).DefaultView;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                lbMessages.Content = message;
            }
        }

        private void btnYield_Click(object sender, RoutedEventArgs e)
        {
            JAMK.ICT.JSON.JSONPlacebo2015 roskaa = new JAMK.ICT.JSON.JSONPlacebo2015();
            MessageBox.Show(roskaa.Yield());
        }
    }
}
