﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new LMSContext())
            {
                var admin = context.Admins.SingleOrDefault(admin => admin.Email == txtEmail.Text);
                
                if (admin != null && admin.Password == txtPassword.Password)
                {
                    AdminHome adminHome = new AdminHome();
                    adminHome.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect email or password");
                }
            }
        }
    }
}
