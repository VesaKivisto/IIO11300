using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; // for ObservableCollection
using System.ComponentModel;
using System.Data.Entity;
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

namespace H10BookshopEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookShopEntities ctx;
        ObservableCollection<Book> localBooks;
        ICollectionView view; // Filtteröintiä varten
        bool isBooks;
        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }

        private void InitMyStuff()
        {
            // Tänne kaikki tarvittavat alustukset
            ctx = new BookShopEntities();
            ctx.Books.Load();
            localBooks = ctx.Books.Local;
            // Comboboxin täyttäminen kirjojen eri mailla
            cbCountries.DataContext = localBooks.Select(n => n.country).Distinct();
            cbCountries.Visibility = Visibility.Visible;
            // View kirjojen filtteröintiä varten
            view = CollectionViewSource.GetDefaultView(localBooks);
        }

        private void btnGetCustomers_Click(object sender, RoutedEventArgs e)
        {
            var customers = ctx.Customers.ToList();
            dgBooks.DataContext = customers;
            isBooks = false;
        }

        private void btnGetBooks_Click(object sender, RoutedEventArgs e)
        {
            dgBooks.DataContext = localBooks;
            isBooks = true;
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isBooks)
            {
                spBook.DataContext = dgBooks.SelectedItem;
            }
            else
            {
                spCustomer.DataContext = dgBooks.SelectedItem;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Tallennetaan kirjaan tehdyt muutokset kantaan
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            // Luodaan uusi kirja-olio ensin kontekstiin ja sitten tietokantaan
            Book newBook;
            if (btnNew.Content.ToString() == "New")
            {
                // Luodaan uusi Book-olio
                newBook = new Book();
                newBook.name = "Anna kirjan nimi";
                spBook.DataContext = newBook;
                btnNew.Content = "Save to database";
            }
            else
            {
                // Lisätään uusi kirja ensin kontekstiin ja sieltä kantaan
                newBook = (Book)spBook.DataContext;
                ctx.Books.Add(newBook);
                ctx.SaveChanges();
                btnNew.Content = "New";
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Poistetaan valittu kirja-olio kontekstista ja sitten kannasta
            Book current = (Book)spBook.DataContext;
            var retval = MessageBox.Show("Are you sure you want to delete book " + current.DisplayName + "?", "Old books", MessageBoxButton.YesNo);
            if (retval == MessageBoxResult.Yes)
            {
                ctx.Books.Remove(current);
                ctx.SaveChanges();
            }
        }

        private void btnGetOrders_Click(object sender, RoutedEventArgs e)
        {
            string msg = "";
            Customer current = (Customer)spCustomer.DataContext;
            msg += string.Format("Customer {0} has {1} orders:\n", current.DisplayName, current.OrderCount);
            foreach (var item in current.Orders)
            {
                msg += string.Format("Order {0} contains {1} items:\n", item.odate, item.Orderitems.Count);
                // Kunkin tilauksen rivit ja sitä vastaava kirja
                Decimal summa = 0;
                foreach (var oitem in item.Orderitems)
                {
                    msg += string.Format("- {0}, {1} pieces\n", oitem.Book.name, oitem.count);
                    summa += oitem.count * oitem.Book.price.Value;
                }
                msg += string.Format("-- Order costs {0}\n", summa);
            }
            MessageBox.Show(msg);
        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Suodatetaan kirjat kyättäjän valinnan mukaan
            // Suodatus tehdään ns. predikaatti-funktiolla
            view.Filter = MyCountryFilter;
        }

        private bool MyCountryFilter(object item)
        {
            if (cbCountries.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return (item as Book).country.Contains(cbCountries.SelectedItem.ToString());
            }
        }
    }
}
