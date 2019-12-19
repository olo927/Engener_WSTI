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
        public Summary(List<string> listOfChoosen, List<List<string>> ListOfIngredients)
        {
            InitializeComponent();
            SetLabel(listOfChoosen, ListOfIngredients);
        }

        private void SetLabel(List<string> listOfChoosen, List<List<string>> ListOfIngredients)
        {

            throw new NotImplementedException();
        }
    }
}
//dodawanie do bazy reguł
// wybór kategori wynikowej
//usuwanie