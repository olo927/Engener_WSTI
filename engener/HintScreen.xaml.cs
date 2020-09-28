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
    /// Logika interakcji dla klasy HintScreen.xaml
    /// </summary>
    public partial class HintScreen : Window
    {
        public HintScreen()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GetHintButton_Click(object sender, RoutedEventArgs e)
        {
            List<Admin> admins = FileAdapter.GetAllAdmins();
            string loginStr = login.Text;
            bool isLoginCorrect = false;
            string hint = "";
            foreach (Admin admin in admins)
            {
                if (admin.name == loginStr)
                {
                    isLoginCorrect = true;
                    hint = admin.hint;
                    MessageBox.Show("Podpowiedź brzmi: " + hint, "Podpowiedź", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
            }
            if (!isLoginCorrect)
            {
                MessageBox.Show("Zły login", "Błąd Loginu", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
