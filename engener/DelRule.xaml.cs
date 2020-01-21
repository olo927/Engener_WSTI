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
        public DelRule(string baseName)
        {
            InitializeComponent();
            List<string[]> Rules = FileAdapter.GetAllRule(baseName);
            GoodRules = new List<string>();
            foreach(string[] rule in Rules)
            {
                GoodRules.Add(rule[0] + " = "+ rule[1]);
            }
            RuleComboBox.ItemsSource = GoodRules;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            DeleteRule();
            this.Close();
        }

        private void DeleteRule()
        {
            string choosenRule = RuleComboBox.Text;
            if(choosenRule == "")
            {
                return;
            }

            int index = IndexOfRule(choosenRule);
            //użyć fileadapter do znalezienia linijki do usunięcia z pliku reload programu.
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
