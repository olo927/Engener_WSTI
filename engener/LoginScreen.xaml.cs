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
        public LoginScreen()
        {
            InitializeComponent();
        }
        public List<Admin> admins;
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            this.admins = FileAdapter.GetAllAdmins();
            string loginStr = login.Text;
            string passStr = pass.Password;
            bool isLoginCorrect = false;
            string baseName = "";
            foreach(Admin admin in admins)
            {
                if(admin.name == loginStr && admin.pass == passStr)
                {
                    //otwórz baze z admin.base
                    isLoginCorrect = true;
                    baseName = admin.baseName;
                    break;
                }

            }
            if (isLoginCorrect)
            {
                BaseEditor baseEditor = new BaseEditor(baseName);
                baseEditor.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("wpisałeś błędne hasło lub login", "Błąd logowania");
            }
        }
    }
}
