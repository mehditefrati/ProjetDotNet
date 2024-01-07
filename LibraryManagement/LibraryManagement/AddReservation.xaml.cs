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
    /// Interaction logic for AddReservation.xaml
    /// </summary>
    public partial class AddReservation : Window
    {
        public AddReservation()
        {
            InitializeComponent();
            using (var context = new LMSContext())
            {
                var a = context.Adherents.ToList();

                cmbAdherent.ItemsSource = a;
            }
            using (var context = new LMSContext())
            {
                var a = context.Books.ToList();

                cmbBook.ItemsSource = a;
            }
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAdherent.SelectedItem != null && cmbBook != null && dateRes.SelectedDate != null && dateRet != null && cmbIsReturned.SelectedItem != null)
            {
                try
                {
                    using (var context = new LMSContext())
                    {
                        Reservation reservation = new Reservation((int)cmbAdherent.SelectedValue, (int)cmbAdherent.SelectedValue, dateRes.SelectedDate.Value, dateRet.SelectedDate.Value, Convert.ToBoolean(cmbIsReturned.Text.ToString()));

                        context.Add(reservation);
                        int success = context.SaveChanges();

                        if (success > 0)
                        {
                            MessageBox.Show("Reservation ajouté");
                        }
                    }
                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.ToString());
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
            else
            {
                MessageBox.Show("Veuillez saisir correctement les champs !!!, Chaque champ est requis.");
            }
        }
    }
}
