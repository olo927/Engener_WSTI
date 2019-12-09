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
    /// Logika interakcji dla klasy AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        private string baseName;
        public AddCategory(string baseName)
        {
            InitializeComponent();
            this.baseName = baseName;
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            FileAdapter.AddNewCategoryToFile(baseName,CategoryTextBox.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
