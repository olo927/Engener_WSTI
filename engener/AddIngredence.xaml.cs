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
        public AddIngredence()
        {
            InitializeComponent();
        }



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string ingr = Ingedence.Text;
            string cat = Category.Text;
            //FileAdapter.SaveNewIngredient(cat, ingr);

        }
    }
}
