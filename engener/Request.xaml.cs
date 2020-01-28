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
    /// Logika interakcji dla klasy Request.xaml
    /// </summary>
    public partial class Request : Window
    {
        bool isFirst;
        public Request()
        {
            InitializeComponent();
            List<string> bases = FileAdapter.GetAllBase();
            OptionsComboBox.ItemsSource = bases;
            isFirst = true;
        }
        List<string> choosen;
        string baseName;
        int index = 0;
        public Request(string baseName,List<string> choosen, int index = 0)
        {
            InitializeComponent();
            List<List<string>> indegrades = FileAdapter.GetIngredients("data\\" + baseName + ".boi");
            if(index == indegrades.Count - 3)
            {
                new Sumup(baseName, choosen).Show();
                this.Close();
            }
            Header.Content = indegrades[index][0];
            indegrades[index].RemoveAt(0);
            OptionsComboBox.ItemsSource = indegrades[index];
            isFirst = false;
            this.choosen = choosen;
            this.index = index;
            this.baseName = baseName;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if(OptionsComboBox.Text == ""&& isFirst)
            {
                MessageBox.Show("Nie wybrałeś bazy");
                return;
            }

            if (isFirst)
            {
                new Request(OptionsComboBox.Text, new List<string>()).Show();
                
            }
            else
            {
                new Request(baseName, choosen, index + 1).Show(); /// tu się pluje
            }
            
            this.Close();
        }
    }
}
