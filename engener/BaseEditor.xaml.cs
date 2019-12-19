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
        string baseName;
        public BaseEditor(string baseName)
        {
            InitializeComponent();
            this.baseName = baseName;
            Title = baseName;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void AddIngridence_Click(object sender, RoutedEventArgs e)
        {
            AddIngredence addIngridence = new AddIngredence(baseName);
            addIngridence.Show();
            
        }

        private void AddCat_Click(object sender, RoutedEventArgs e)
        {
            AddCategory addCategory = new AddCategory(baseName);
            addCategory.Show();
        }

        private void AddRule_Click(object sender, RoutedEventArgs e)
        {
            List<string> temp = new List<string>();
            AddRule addRule = new AddRule(baseName, temp);
            addRule.Show();
        }
    }
}
