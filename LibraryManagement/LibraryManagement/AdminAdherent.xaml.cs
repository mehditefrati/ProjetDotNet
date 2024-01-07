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
    /// Interaction logic for AdminAdherent.xaml
    /// </summary>
    public partial class AdminAdherent : UserControl
    {
        public static Adherent updateAdh = new Adherent();
        public AdminAdherent()
        {
            InitializeComponent();
            initializeAdminAdherents();
        }

        public void initializeAdminAdherents()
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var a = context.Adherents.ToList();

                    dgBooks.ItemsSource = a;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRefresh_Click_1(object sender, RoutedEventArgs e)
        {
            initializeAdminAdherents(); 
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddAdherent addAdherent = new AddAdherent();
            addAdherent.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Adherent adherent = dgBooks.SelectedItem as Adherent;
            if (adherent != null)
            {
                updateAdh = adherent;
                UpdateAdherent updateAdherent = new UpdateAdherent();
                updateAdherent.Show();
            }
            else
            {
                MessageBox.Show("Select an Adherent to update...");
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    Adherent adherent = dgBooks.SelectedItem as Adherent;
                    context.Remove(adherent);
                    int success = context.SaveChanges();

                    if (success > 0)
                    {
                        MessageBox.Show("Adherent supprimé", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        initializeAdminAdherents();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the Employee.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            AdherentImportExport importExport = new AdherentImportExport();
            List<Adherent> importedAdherents = importExport.ImportFromExcel();
            using (var context = new LMSContext())
            {
                context.AddRange(importedAdherents);
                int success = context.SaveChanges();

                if (success > 0)
                {
                    MessageBox.Show("Adherents ajouté");
                    initializeAdminAdherents();
                }
            }
        }
    }
}
