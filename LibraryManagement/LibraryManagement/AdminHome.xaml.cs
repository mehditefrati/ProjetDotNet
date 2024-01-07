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
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : Window
    {
        public AdminHome()
        {
            InitializeComponent();
            AdminBooks adminBooks = new AdminBooks();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminBooks);
        }

        private void BtnBooks_Click(object sender, RoutedEventArgs e)
        {
            AdminBooks adminBooks = new AdminBooks();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminBooks);
        }

        private void BtnEmployees_Click(object sender, RoutedEventArgs e)
        {
            AdminEmployes adminEmployes = new AdminEmployes();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminEmployes);
        }

        private void BtnAdherents_Click(object sender, RoutedEventArgs e)
        {
            AdminAdherent adminAdherent = new AdminAdherent();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminAdherent);
        }

        private void BtnReservations_Click(object sender, RoutedEventArgs e)
        {
            AdminReservation adminReservation = new AdminReservation();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminReservation);
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new LMSContext())
            {
                var adherents = context.Adherents.ToList();

                AdherentImportExport importExport = new AdherentImportExport();

                // Export to Excel
                importExport.ExportToExcel(adherents, @"C:\Users\Mehdi\Desktop/exportedAdherents.xlsx");
            }
        }
    }
}
