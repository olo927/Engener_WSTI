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
    /// Logika interakcji dla klasy AddRule.xaml
    /// </summary>
    public partial class AddRule : Window
    {
        List<string> listOfChoosen;
        int curentNumber = 0;
        private string baseName;
        List<List<string>> ListOfIngredients;
        public AddRule(string baseName, List<string> listOfChoosen)
        {
            InitializeComponent();
            this.baseName = baseName;
            this.listOfChoosen = listOfChoosen;
            try
            {
                ListOfIngredients = FileAdapter.GetIngredients("data\\" + baseName + ".boi");
            }
            catch
            {
                return;
            }
            
            SetCategoryInWindow();
        }

        private void SetCategoryInWindow()
        {
            try
            {
                category.Content = ListOfIngredients[curentNumber][0];
                string[] options = new string[ListOfIngredients[curentNumber].Count];// = ListOfIngredients[curentNumber];
                ListOfIngredients[curentNumber].CopyTo(options);
                options[0] = "";
                option.ItemsSource = options;
            }
            catch
            {
                this.Close();
                return;
            }
            
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            SaveUserSet();
            curentNumber++;
            if (curentNumber >= ListOfIngredients.Count) // ListOfIngredients.Count - ilość kategorii
            {
                Summary sum = new Summary(listOfChoosen, ListOfIngredients, baseName);
                sum.Show();

                this.Close();
                return;
            }
            SetCategoryInWindow();
            
        }

        private void SaveUserSet()
        {
            try
            {
                listOfChoosen.Add(option.SelectedItem.ToString());
            }
            catch
            {
                listOfChoosen.Add("");
            }
            
        }
    }
}
