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
    /// Logika interakcji dla klasy BaseEditor.xaml
    /// </summary>
    public partial class BaseEditor : Window
    {
        public BaseEditor()
        {
            InitializeComponent();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void AddIngridence_Click(object sender, RoutedEventArgs e)
        {
            AddIngredence addIngridence = new AddIngredence();
            addIngridence.Show();
            
        }
    }
}
