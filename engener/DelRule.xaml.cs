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
    /// Logika interakcji dla klasy DelRule.xaml
    /// </summary>
    public partial class DelRule : Window
    {
        private List<string> GoodRules;
        private string baseName;
        public DelRule(string baseName)
        {
            InitializeComponent();
            this.baseName = baseName;
            List<string[]> Rules = FileAdapter.GetAllRuleForDisplay(baseName);
            GoodRules = new List<string>();
            foreach(string[] rule in Rules)
            {
                GoodRules.Add(rule[0] + " = "+ rule[1]);
            }
            RuleComboBox.ItemsSource = GoodRules;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //new BaseEditor(baseName).Show();
            this.Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

            DeleteRule();
            BaseEditor baseEditor = new BaseEditor(baseName);
            baseEditor.Show();
            this.Close();

        }

        private void DeleteRule()
        {
            string choosenRule = RuleComboBox.Text;
            if(choosenRule == "")
            {
                return;
            }
            if(MessageBox.Show("Czy napewno chcesz usunąć tą regułę ?? \n" + RuleComboBox.Text, "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No, MessageBoxOptions.None) == MessageBoxResult.Yes)
            {
                int index = IndexOfRule(choosenRule);
                if (index != -1)
                {
                    FileAdapter.DeletingRule(baseName, index);

                }
                else
                {
                    MessageBox.Show("Błąd usuwania", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
        }


        private int IndexOfRule(string choosenRule)
        {
            for(int i = 0; i<GoodRules.Count; i++)
            {
                if(GoodRules[i] == choosenRule)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
