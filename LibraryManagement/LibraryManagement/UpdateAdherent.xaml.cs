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
    /// Interaction logic for UpdateAdherent.xaml
    /// </summary>
    public partial class UpdateAdherent : Window
    {
        public int adherentId;
        public UpdateAdherent()
        {
            InitializeComponent();
            adherentId = (int)AdminAdherent.updateAdh.AdherentID;
            tbFName.Text = AdminAdherent.updateAdh.FirstName;
            tbLName.Text = AdminAdherent.updateAdh.LastName;
            tbEmail.Text = AdminAdherent.updateAdh.Email;
            tbTelephone.Text = AdminAdherent.updateAdh.Telephone;
            tbPassword.Text = AdminAdherent.updateAdh.Password;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbFName.Text != string.Empty && tbLName.Text != string.Empty && tbEmail.Text != string.Empty && tbTelephone.Text != string.Empty && tbPassword.Text != string.Empty)
            {
                try
                {
                    using (var context = new LMSContext())
                    {
                        Adherent adherent = new Adherent(adherentId, tbFName.Text, tbLName.Text, tbEmail.Text, tbTelephone.Text, tbPassword.Text);

                        context.Update(adherent);
                        int success = context.SaveChanges();

                        if (success > 0)
                        {
                            MessageBox.Show("Adherent modifié");
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
