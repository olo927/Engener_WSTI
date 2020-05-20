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
    /// Logika interakcji dla klasy Summary.xaml
    /// </summary>
    public partial class Summary : Window
    {
        public string rule, baseName;
        public Summary(List<string> listOfChoosen, List<List<string>> ListOfIngredients, string baseName)
        {
            rule = "";

            this.baseName = baseName;
            InitializeComponent();
            SetLabel(listOfChoosen, ListOfIngredients);
        }

        private void SetLabel(List<string> listOfChoosen, List<List<string>> ListOfIngredients)
        {
            string info = "Podsumowanie\n";
            for(int i = 0; i < listOfChoosen.Count; i++)
            {
                if(i== listOfChoosen.Count-1)
                    info += "Wynik reguły " + ListOfIngredients[i][0] + " : " + listOfChoosen[i] + '\n';
                else
                    info += "Kategoria " + ListOfIngredients[i][0] + " : " + listOfChoosen[i] + '\n';
                rule += ListOfIngredients[i][0] + "_" + listOfChoosen[i] + ";";
            }
            Info.Text = info;
            
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            FileAdapter.SaveNewRule(baseName,rule);
            BaseEditor baseEditor = new BaseEditor(baseName);
            baseEditor.Show();
            this.Close();
        }
    }
}
