﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
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
        public List<Admin> admins;
        public RegisterScreen()
        {
            InitializeComponent();
            this.admins = FileAdapter.GetAllAdmins();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string hashPassword = FileAdapter.ComputeSha256Hash(PasswordBox.Password);
            Admin newAdmin = new Admin(LoginTextBox.Text, hashPassword,  BaseNameTextBox.Text,PasswordHintTextBox.Text, BaseDescriptionTextBox.Text);

            if (!File.Exists("data\\" + newAdmin.baseName + ".bok"))
            {
                bool isUniqLogin = true;
                foreach(Admin adm in admins)
                {
                    if(adm.name == newAdmin.name)
                    {
                        MessageBox.Show("Taki login jest już zajęty");
                        isUniqLogin = false;
                        break;
                    }
                }
                if (isUniqLogin && PassCheck())
                {
                    admins.Add(newAdmin);
                    List<string> ListOfAdminsString = new List<string>();
                    foreach(Admin admin in admins)
                    {
                        ListOfAdminsString.Add(admin.ToCodedString());
                    }
                    File.WriteAllLines("data\\admin.ame", ListOfAdminsString);
                    CreateFiles(newAdmin);
                    BaseEditor baseEditor = new BaseEditor(newAdmin.baseName);
                    baseEditor.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Hasła nie są poprawne");
                }
            }
            else
            {
                MessageBox.Show("Baza już istnieje!");
            }
            
            
                       
        }

        private bool PassCheck()
        {
            if ((PasswordBox.Password.Length < 5) && (ConfirmPasswordBox.Password == PasswordBox.Password))
                return true;
            else
                return false;
        }

        private void CreateFiles(Admin admin)
        {
            File.Create("data\\" + admin.baseName + ".bok");
            File.Create("data\\" + admin.baseName + ".boi");
            File.Create("data\\" + admin.baseName + ".bod");
            //System.IO.Directory.CreateDirectory("data\\" + admin.baseName);
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

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(ConfirmPasswordBox.Password != PasswordBox.Password)
            {
                PasswordErrorLabel.Content = "Hasła nie są zgodne";
            }
            else
            {
                PasswordErrorLabel.Content = "";
            }
        }
    }
}
