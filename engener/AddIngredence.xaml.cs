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
    /// Logika interakcji dla klasy AddIngredence.xaml
    /// </summary>
    public partial class AddIngredence : Window
    {
        string baseName;
        List<string> ListOfCategory;
        public AddIngredence(string baseName)
        {
            InitializeComponent();
            this.baseName = baseName;
            ListOfCategory = FileAdapter.GetAllCategory(baseName);
            Category.ItemsSource = ListOfCategory;
        }



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            FileAdapter.SaveNewIngredient(baseName, Category.Text, Ingedence.Text, Description.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
