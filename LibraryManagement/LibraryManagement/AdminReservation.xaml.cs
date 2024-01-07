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
    /// Interaction logic for AdminReservation.xaml
    /// </summary>
    public partial class AdminReservation : UserControl
    {
        public static Reservation updateRes = new Reservation();
        public AdminReservation()
        {
            InitializeComponent();
            initializeAdminReservation();
        }

        public void initializeAdminReservation()
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var a = context.Reservations.ToList();

                    dgBooks.ItemsSource = a;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddReservation addReservation = new AddReservation();
            addReservation.Show();
        }

        private void BtnRefresh_Click_1(object sender, RoutedEventArgs e)
        {
            initializeAdminReservation();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Reservation reservation = dgBooks.SelectedItem as Reservation;
            if (reservation != null)
            {
                updateRes = reservation;
                UpdateReservation updateReservation = new UpdateReservation();
                updateReservation.Show();
            }
            else
            {
                MessageBox.Show("Select a Reservation to update...");
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    Reservation reservation = dgBooks.SelectedItem as Reservation;
                    context.Remove(reservation);
                    int success = context.SaveChanges();

                    if (success > 0)
                    {
                        MessageBox.Show("Reservation supprimé", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        initializeAdminReservation();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the Reservation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
