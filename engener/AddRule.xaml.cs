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
        List<List<string>> ListOfIngredients, ListOfDiagnose;

        public AddRule(string baseName, List<string> listOfChoosen)
        {
            InitializeComponent();
            this.baseName = baseName;
            this.listOfChoosen = listOfChoosen;
            try
            {
                ListOfIngredients = FileAdapter.GetIngredients("data\\" + baseName + ".boi");
                ListOfDiagnose = FileAdapter.GetIngredients("data\\" + baseName + ".bod");
            }
            catch
            {
                return;
            }
            
            SetCategoryInWindow();
        }

        private void SetCategoryInWindow()
        {
            if (curentNumber < ListOfIngredients.Count)
            {
                category.Text = ListOfIngredients[curentNumber][0];
                string[] options = new string[ListOfIngredients[curentNumber].Count];// = ListOfIngredients[curentNumber];
                ListOfIngredients[curentNumber].CopyTo(options);
                options[0] = "";
                option.ItemsSource = options;
            }
            else
            {
                category.Text = ListOfDiagnose[0][0];
                string[] options = new string[ListOfDiagnose[0].Count];
                ListOfDiagnose[0].CopyTo(options);
                options[0] = "";
                option.ItemsSource = options;
            }
            
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            SaveUserSet();
            curentNumber++;
            if (curentNumber > ListOfIngredients.Count) 
            {
                ListOfIngredients.Add(ListOfDiagnose[0]);
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
