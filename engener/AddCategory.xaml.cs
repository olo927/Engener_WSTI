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
using System.IO;
using Microsoft.Win32;

namespace engener
{
    /// <summary>
    /// Logika interakcji dla klasy AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        private string baseName;
        private string filePath;
        public AddCategory(string baseName)
        {
            InitializeComponent();
            this.baseName = baseName;
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if(isDiagnose.IsChecked == true)
            {
                AddDianoseCategory();
            }
            else
            {
                FileAdapter.AddNewCategoryToFile(baseName, CategoryTextBox.Text, Description.Text/*, CopyPhoto(filePath)*/);
                FileAdapter.UpdateRules(baseName, CategoryTextBox.Text);
            }
            BaseEditor baseEditor = new BaseEditor(baseName);
            baseEditor.Show();
            this.Close();
        }

        private void AddDianoseCategory()
        {
            
            if(!FileAdapter.isEmpty(baseName))
            {
                MessageBox.Show( "Diagnoza już istnieje", "Error");
            }
            else
            {
                FileAdapter.AddNewDiagnoseFile(baseName, CategoryTextBox.Text, Description.Text);
            }
        }

        //private string CopyPhoto(string filePath)
        //{
        //    Random rnd = new Random();
        //    string newName;
        //    do
        //    {
        //        newName = "";
        //        for (int i = 0; i < 10; i++)
        //        {
        //            newName += (char)('A' + rnd.Next(0, 26));
        //        }
        //        newName += ".jpeg";
        //    } while (File.Exists("\\data\\"+baseName+"\\"));
        //    string path = "data\\"+baseName+"\\"+newName;
        //    System.IO.File.Copy(filePath, path, true);
        //    return newName;
        //}

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void FindFileButton_Click(object sender, RoutedEventArgs e)
        //{

        //    OpenFileDialog openFileDialog = new OpenFileDialog();

        //    openFileDialog.InitialDirectory = "c:\\";
        //    openFileDialog.Filter = "Zdjęcia (*.jpeg)|*.jpeg";
        //    openFileDialog.FilterIndex = 2;
        //    openFileDialog.RestoreDirectory = true;

        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        filePath = openFileDialog.FileName;
        //    }

        //}
    }
}
