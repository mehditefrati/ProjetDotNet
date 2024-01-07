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
using System.Windows.Shapes;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for AdminUpdateBook.xaml
    /// </summary>
    public partial class AdminUpdateBook : Window
    {
        public int bookId;
        public AdminUpdateBook()
        {
            InitializeComponent();
            bookId = (int)AdminBooks.updateBook.BookId;
            tbBName.Text = AdminBooks.updateBook.Title;
            tbBAuthor.Text = AdminBooks.updateBook.Author;
            tbBISBN.Text = AdminBooks.updateBook.ISBN;
            tbBPrice.Text = AdminBooks.updateBook.Price.ToString();
            tbBCopy.Text = AdminBooks.updateBook.Copies.ToString();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbBName.Text != string.Empty && tbBAuthor.Text != string.Empty && tbBISBN.Text != string.Empty && tbBPrice.Text != string.Empty &&
                tbBCopy.Text != string.Empty
                )
            {
                try
                {
                    using (var context = new LMSContext())
                    {
                        Book book = new Book(bookId, tbBName.Text, tbBAuthor.Text, tbBISBN.Text, double.Parse(tbBPrice.Text), int.Parse(tbBCopy.Text));

                        context.Update(book);
                        int success = context.SaveChanges();

                        if (success > 0)
                        {
                            MessageBox.Show("Book edited successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to edit the book.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Book price or Book copy!!!,\nThey should not be a string, Try again..");
                }
                catch (Exception)
                {
                    MessageBox.Show("Some unknown exception is occured!!!, Try again..");
                }
            }
            else
            {
                MessageBox.Show("Enter the fields properly!!!, Every field is required..");
            }
        }
    }
}
