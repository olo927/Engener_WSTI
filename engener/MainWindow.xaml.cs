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
using System.IO;

namespace engener
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Admin> admins;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginAdminButton_Click(object sender, RoutedEventArgs e)
        {
            OpenLoginScreen();
        }

        private void NewUserButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterScreen registerScreen = new RegisterScreen();
            registerScreen.Show();
            this.Close();
        }

        private void OpenLoginScreen()
        {
            //logowanie z pliku sprawdzanie
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            this.Close();
        }

        private void UseSystemButton_Click(object sender, RoutedEventArgs e)
        {
            new Request().Show();
            this.Close();
        }
    }
}
