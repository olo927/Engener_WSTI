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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace engener
{
    /// <summary>
    /// Interaction logic for PrintPreparationScreen.xaml
    /// </summary>
    public partial class PrintPreparationScreen : Window
    {
        string[] args;
        public PrintPreparationScreen(string[] args)
        {
            InitializeComponent();
            this.args = args;

        }
        private string textToPrint = "";
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            GetTextToPrint();
            Printing(textToPrint);
        }

        private void GetTextToPrint()
        {
            if ((bool)Title.IsChecked)
            {
                textToPrint += "Wnioskowanie z użyciem bazy \" " + args[0] + "\"\n";
            }
            if ((bool)User_facts.IsChecked)
            {
                textToPrint += "fakty poodane przez użytkownika: \n" + args[1] + "\n";
            }
            if ((bool)Result_list_classfy.IsChecked)
            {
                textToPrint += "Wynik klasyfikacji listowej: \n" + args[2] + "\n";
            }
            if ((bool)Result_list_classfy_description.IsChecked)
            {
                textToPrint += "Opis wyniku klasyfikacji listowej: \n" + args[3] + "\n";
            }
            if ((bool)Result_vote_classfy.IsChecked)
            {
                textToPrint += "Wynik klasyfikacji głosującej: \n" + args[4] + "\n";
            }
            if ((bool)Result_vote_classfy_description.IsChecked)
            {
                textToPrint += "Opis wyniku klasyfikacji głosującej: \n" + args[5] + "\n";
            }
        }

        private void Printing(string text)
        {
            PrintDialog printDialog = new PrintDialog
            {
                PageRangeSelection = PageRangeSelection.AllPages,
                UserPageRangeEnabled = true
            };
            FlowDocument doc = new FlowDocument(new Paragraph(new Run(text)))
            {
                Name = "PrintEncrypt"
            };
            Nullable<Boolean> print = printDialog.ShowDialog();
            if (print == true)
            {
                IDocumentPaginatorSource idps = doc;
                printDialog.PrintDocument(idps.DocumentPaginator, "PrintEncrypt");
            }
        }

        private void Choose_every_Click(object sender, RoutedEventArgs e)
        {
            Title.IsChecked = true;
            User_facts.IsChecked = true;
            Result_list_classfy.IsChecked = true;
            Result_list_classfy_description.IsChecked = true;
            Result_vote_classfy.IsChecked = true;
            Result_vote_classfy_description.IsChecked = true;
        }
    }
}
