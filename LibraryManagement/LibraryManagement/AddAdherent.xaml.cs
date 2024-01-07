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
    /// Interaction logic for AddAdherent.xaml
    /// </summary>
    public partial class AddAdherent : Window
    {
        public AddAdherent()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbFName.Text != string.Empty && tbLName.Text != string.Empty && tbEmail.Text != string.Empty && tbTelephone.Text != string.Empty && tbPassword.Text != string.Empty)
            {
                try
                {
                    using (var context = new LMSContext())
                    {
                        Adherent adherent = new Adherent(tbFName.Text, tbLName.Text, tbEmail.Text, tbTelephone.Text, tbPassword.Text);

                        context.Add(adherent);
                        int success = context.SaveChanges();

                        if (success > 0)
                        {
                            MessageBox.Show("Adherent ajouté");
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("");
                }
                catch (Exception)
                {
                    MessageBox.Show("Some unknown exception is occured!!!, Try again..");
                }
            }
            else
            {
                MessageBox.Show("Veuillez saisir correctement les champs !!!, Chaque champ est requis.");
            }
        }
    }
}
