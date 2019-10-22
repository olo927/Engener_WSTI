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

namespace engener
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
        private void LoginUserButton_Clicked(object sender, RoutedEventArgs e)
        {
            OpenLoginScreen(true);
        }

        private void LoginAdminButton_Click(object sender, RoutedEventArgs e)
        {
            OpenLoginScreen(false);
        }

        private void NewUserButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterScreen registerScreen = new RegisterScreen();
            registerScreen.Show();
            this.Close();
        }

        private void OpenLoginScreen(bool isUser)
        {
            LoginScreen loginScreen = new LoginScreen(isUser);
            loginScreen.Show();
            this.Close();
        }
    }
}
