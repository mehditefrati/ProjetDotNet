using LibraryManagement.Models;
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

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for AdminBooks.xaml
    /// </summary>
    public partial class AdminBooks : UserControl
    {
        public static Book updateBook = new Book();
        public AdminBooks()
        {
            InitializeComponent();
            initializeAdminBooks();
        }

        public void initializeAdminBooks()
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var books = context.Books.ToList();

                    dgBooks.ItemsSource = books;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AdminAddBook addBook = new AdminAddBook();
            addBook.Show();
        }

        private void BtnRefresh_Click_1(object sender, RoutedEventArgs e)
        {
            initializeAdminBooks();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Book book = dgBooks.SelectedItem as Book;
            if (book != null)
            {
                updateBook = book;
                AdminUpdateBook adminUpdateBook = new AdminUpdateBook();
                adminUpdateBook.Show();
            }
            else
            {
                MessageBox.Show("Select a book to update...");
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    Book book = dgBooks.SelectedItem as Book;
                    context.Remove(book);
                    int success = context.SaveChanges();

                    if (success > 0)
                    {
                        MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        initializeAdminBooks();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the book.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }
        }
    }
}
