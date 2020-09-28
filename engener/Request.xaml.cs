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
        private bool isFirst;
        public Request()
        {
            InitializeComponent();
            List<string> bases = FileAdapter.GetAllNamesOfBases();
            OptionsComboBox.ItemsSource = bases;
            Descriptions.Text = "Proszę o wybranie bazy z której chcesz skorzystać";
            isFirst = true;
        }
        List<string> choosen;
        List<List<string>> indegrades;
        string baseName;
        int index = 0;
        public Request(string baseName, List<string> choosen)
        {
            InitializeComponent();
            this.indegrades = FileAdapter.GetIngredients("data\\" + baseName + ".boi");
            Header.Content = indegrades[index][0];
            indegrades[index].RemoveAt(0);
            OptionsComboBox.ItemsSource = indegrades[index];
            Descriptions.Text = FileAdapter.GetDescripionToCategory(baseName, index);

            isFirst = false;
            this.choosen = choosen;
            this.baseName = baseName;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (OptionsComboBox.Text == "" && isFirst)
            {
                MessageBox.Show("Nie wybrałeś bazy");
                return;
            }

            if (isFirst)
            {
                new Request(OptionsComboBox.Text, new List<string>()).Show();
                this.Close();
            }
            else
            {
                choosen.Add(OptionsComboBox.Text);
                this.Visibility = Visibility.Hidden;
                index++;
                try
                {
                    Header.Content = indegrades[index][0];
                    indegrades[index].RemoveAt(0);
                    OptionsComboBox.ItemsSource = indegrades[index];
                    OptionsComboBox.SelectedIndex = indegrades.Count - 1;
                    Descriptions.Text = FileAdapter.GetDescripionToCategory(baseName, index);
                }
                catch { }
                this.Visibility = Visibility.Visible;
                ////
                if (index == indegrades.Count)
                {
                    this.Hide();
                    new Sumup(baseName, choosen).Show();
                    this.Close();
                }
            }
        }

        private void OptionsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (isFirst)
                    Descriptions.Text = FileAdapter.GetDescripionToBase(OptionsComboBox.SelectedItem.ToString());
                else

                    Descriptions.Text = FileAdapter.GetDescripionToItem(OptionsComboBox.SelectedItem.ToString(), baseName, index);
            }
            catch
            {
                Descriptions.Text = "";
            }

        }
    }
}
