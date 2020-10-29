using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logika interakcji dla klasy Sumup.xaml
    /// </summary>
    public partial class Sumup : Window
    {
        string baseName;
        string sum = "";
        public Sumup(string baseName, List<string> choosen)
        {
            InitializeComponent();
            this.baseName = baseName;
            List<string> header = FileAdapter.GetHeders("data\\" + baseName + ".boi");
            for (int i = 0; i < choosen.Count; i++)
            {
                sum += header[i] + " : " + choosen[i] + "\n";
            }
            Choosen.Text = sum;

            Stopwatch stopwatchVote = new Stopwatch();
            stopwatchVote.Start();
            SetVoteResult(baseName, choosen);
            stopwatchVote.Stop();
            Stopwatch stopwatchList = new Stopwatch();
            stopwatchList.Start();
            SetListResult(baseName, choosen);
            stopwatchList.Stop();
            long timeVote = stopwatchVote.ElapsedTicks;
            long timeList = stopwatchList.ElapsedTicks;
            string message = "Czas działania vote : " + timeVote + "\nCzas działania List: " + timeList + "\nCzas jest podany w taktach procesora";
            MessageBox.Show(message, "Czas Działania");
        }
        string listResult, listDescriptionResult, voteResult, voteDescriptionResult;
        private void SetListResult(string baseName, List<string> choosen)
        {
            ListClassfy list = new ListClassfy(choosen, baseName);
            listResult = list.Classify();
            listDescriptionResult = FileAdapter.GetDescripionToResult(listResult, baseName);
            string result = listResult + "\n" + listDescriptionResult;
            ListClassfyLabel.Text = result;

        }

        private void SetVoteResult(string baseName, List<string> choosen)
        {
            VoteClassfy vote = new VoteClassfy(choosen);
            voteResult = vote.Vote(baseName);
            string result = voteResult;
            try
            {
                voteDescriptionResult = FileAdapter.GetDescripionToResult(result.Split("\n")[1], baseName);
                result += voteDescriptionResult;
            }
            catch { }
           
            VoteClassfyLabel.Text = result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }



        private void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            string[] args =
            {
                baseName,
                sum,
                listResult,
                listDescriptionResult,
                voteResult,
                voteDescriptionResult
            };
            new PrintPreparationScreen(args).Show();
        }
    }
}
