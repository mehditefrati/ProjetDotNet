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
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        public int employeeId;
        public UpdateEmployee()
        {
            InitializeComponent();
            employeeId = (int)AdminEmployes.updateEmp.EmployeeID;
            tbFName.Text = AdminEmployes.updateEmp.FirstName;
            tbLName.Text = AdminEmployes.updateEmp.LastName;
            tbEmail.Text = AdminEmployes.updateEmp.Email;
            tbTelephone.Text = AdminEmployes.updateEmp.Telephone;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbFName.Text != string.Empty && tbLName.Text != string.Empty && tbEmail.Text != string.Empty && tbTelephone.Text != string.Empty)
            {
                try
                {
                    using (var context = new LMSContext())
                    {
                        Employee employee = new Employee(employeeId, tbFName.Text, tbLName.Text, tbEmail.Text, tbTelephone.Text);

                        context.Update(employee);
                        int success = context.SaveChanges();

                        if (success > 0)
                        {
                            MessageBox.Show("Livre modifié");
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
