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
    /// Logika interakcji dla klasy Sumup.xaml
    /// </summary>
    public partial class Sumup : Window
    {
        public Sumup(string baseName, List<string> choosen)
        {
            InitializeComponent();
            string sum = "";
            List<string> header = FileAdapter.GetHeders("data\\" + baseName + ".boi");
            for(int i = 0; i<choosen.Count;i++)
            {
                sum += header[i] +" : "+choosen[i] + "\n";
            }
            Choosen.Content = sum;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
