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
    /// Interaction logic for AdminEmployes.xaml
    /// </summary>
    public partial class AdminEmployes : UserControl
    {
        public static Employee updateEmp = new Employee();
        public AdminEmployes()
        {
            InitializeComponent();
            initializeAdminEmployees();
        }

        public void initializeAdminEmployees()
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var employees = context.Employees.ToList();

                    dgBooks.ItemsSource = employees;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRefresh_Click_1(object sender, RoutedEventArgs e)
        {
            initializeAdminEmployees();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = dgBooks.SelectedItem as Employee;
            if (employee != null)
            {
                updateEmp = employee;
                UpdateEmployee updateEmployee = new UpdateEmployee();
                updateEmployee.Show();
            }
            else
            {
                MessageBox.Show("Select an employee to update...");
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    Employee employee = dgBooks.SelectedItem as Employee;
                    context.Remove(employee);
                    int success = context.SaveChanges();

                    if (success > 0)
                    {
                        MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        initializeAdminEmployees();
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
    }
}
