using System;
using System.Windows;
using System.Windows.Controls;

namespace H9Bookshop
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

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Stackpaneliin datacontext
            spContent.DataContext = dgBooks.SelectedItem;
        }

        private void btnGetTestbooks_Click(object sender, RoutedEventArgs e)
        {
            dgBooks.DataContext = Bookshop.GetTestBooks();
        }

        private void btnGetSQLbooks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Haetaan kirjat BL-kerroksesta
                dgBooks.DataContext = Bookshop.GetBooks(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book current = (Book)spContent.DataContext;
                if (Bookshop.UpdateBook(current) > 0)
                {
                    MessageBox.Show(string.Format("Book {0} updated successfully", current.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            if (btnNew.Content.ToString() == "New")
            {
                // Luodaan uusi olio
                Book newBook = new Book(0);
                newBook.Name = "Anna kirjan nimi";
                spContent.DataContext = newBook;
                btnNew.Content = "Insert to database";
            }
            else
            {
                // Tallennetaan
                Book current = (Book)spContent.DataContext;
                Bookshop.InsertBook(current);
                dgBooks.DataContext = Bookshop.GetBooks(true);
                MessageBox.Show(string.Format("Book {0} inserted to database successfully", current.ToString()));
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Poistetaan valittu kirja
                Book current = (Book)spContent.DataContext;
                var retval = MessageBox.Show("Do you really want to delete book" + current.ToString(), "QUESTION", MessageBoxButton.YesNo);
                if (retval == MessageBoxResult.Yes)
                {
                    Bookshop.DeleteBook(current);
                    dgBooks.DataContext = Bookshop.GetBooks(true);
                    MessageBox.Show(string.Format("Book {0} deleted from the database successfully", current.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}