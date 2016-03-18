using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Tehtava9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionStr;
        string message;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                connectionStr = Properties.Settings.Default.Tietokanta;
            }
            catch (Exception ex)
            {
                lbMessages.Content = ex.Message;
            }
        }

        private void btnGetCustomers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgCustomers.ItemsSource = DBViini.GetAllCustomers(connectionStr, out message).DefaultView;
                lbMessages.Content = message;
            }
            catch (Exception ex)
            {
                lbMessages.Content = ex.Message;
            }
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tbFirstname.Text) && !string.IsNullOrWhiteSpace(tbLastname.Text) && !string.IsNullOrWhiteSpace(tbAddress.Text) && !string.IsNullOrWhiteSpace(tbZipcode.Text) && !string.IsNullOrWhiteSpace(tbCity.Text))
                {
                    string firstname = tbFirstname.Text;
                    string lastname = tbLastname.Text;
                    string address = tbAddress.Text;
                    string zipcode = tbZipcode.Text;
                    string city = tbCity.Text;

                    DBViini.AddNewCustomer(connectionStr, firstname, lastname, address, zipcode, city, out message);
                    lbMessages.Content = message;
                }
                else
                {
                    lbMessages.Content = "Please insert text into all fields above";
                }
            }
            catch (Exception ex)
            {
                lbMessages.Content = ex.Message;
            }
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedIndex > 0)
            {
                DataRowView drv = (DataRowView)dgCustomers.SelectedItem;
                string id = (drv["id"].ToString());
                MessageBoxResult mbr = MessageBox.Show("Do you really want to delete customer id " + id + "?", "Delete customer", MessageBoxButton.YesNo);
                if (mbr == MessageBoxResult.Yes)
                {
                    try
                    {
                        DBViini.DeleteCustomer(connectionStr, id, out message);
                        lbMessages.Content = message;
                    }
                    catch (Exception ex)
                    {
                        lbMessages.Content = ex.Message;
                    }
                }
            }
        }

        private void dgCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spLeft.DataContext = e.AddedItems[0];
        }
    }
}
