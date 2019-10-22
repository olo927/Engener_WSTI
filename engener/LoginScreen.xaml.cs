using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace engener
{
    /// <summary>
    /// Logika interakcji dla klasy LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        private bool isUser;
        public LoginScreen(bool isUser)
        {
            InitializeComponent();
            this.isUser = isUser;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
