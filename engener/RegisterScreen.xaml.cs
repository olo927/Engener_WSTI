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
    /// Logika interakcji dla klasy RegisterScreen.xaml
    /// </summary>
    public partial class RegisterScreen : Window
    {
        private enum NamesOfTextBoxs
        {
            Login = 0,
            Password,
            ConfirmPassword,
            PasswordHint,
            NameOfBase,
            Description
        };
        private string[] names = new string[6];
        public RegisterScreen()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            FillArrayOfNames();
            int error = AllTextBoxIsNotEmpty();
            NamesOfTextBoxs namesOfTextBoxs = (NamesOfTextBoxs)error;
            if (error != -1)
            {
                MessageBox.Show("Błąd, nie podano wartości pola " + namesOfTextBoxs.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (!names[1].Equals(names[2]))
            {
                MessageBox.Show("Błąd, podane hasła muszą być jednakowe","Błąd",MessageBoxButton.OK,MessageBoxImage.Error);
            }
                       
        }
        private void FillArrayOfNames()
        {
            names[0] = LoginTextBox.Text;
            names[1] = PasswordBox.Password;
            names[2] = ConfirmPasswordBox.Password;
            names[3] = PasswordHintTextBox.Text;
            names[4] = BaseNameTextBox.Text;
            names[5] = BaseDescriptionTextBox.Text;
        }

        private int AllTextBoxIsNotEmpty()
        {
            for(int i = 0; i < names.Length; i++)
            {
                if(names[i] == "" || names[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Length < 5)
            {
                PasswordErrorLabel.Content = "Masz za krótkie hasło, min. 5 znaków";
            }
            else
            {
                PasswordErrorLabel.Content = "";
            }
        }
    }
}
