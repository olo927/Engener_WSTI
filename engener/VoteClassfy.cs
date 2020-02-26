using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace engener
{
    class VoteClassfy : Conclusion
    {
        public VoteClassfy(List<string> evidence) :
            base(evidence)
        { }

        public string Vote(string baseName)
        {
            List<List<string>> ind = FileAdapter.GetIngredients("data\\" + baseName + ".boi");
            List<string> diagnose = ind[ind.Count - 1];
            int[] score = new int[diagnose.Count-1];

            int goodRule = 0;
            List<string> ListOfRules = FileAdapter.GetAllNotEditedRule(baseName);
            foreach(string rule in ListOfRules)
            {
                if (CheckRule(rule))
                {
                    goodRule++;
                    string res = GetRuleResult(rule);
                    try
                    {
                        score[diagnose.IndexOf(res)]++;
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            string message = "Błąd klasyfikacji";

            if (goodRule == 0)
            {
                message = "nie znana reguła odpowadająca podanym przesłanką";
            }
            else
            {
                message = "Największą ilość głosów otrzymały diagnozy:\n";
                string[] maxVoted = GetMaxVotedItems(score,diagnose);
                foreach(string item in maxVoted)
                {
                    message += item + '\n';
                }
            }
            return message;
        }

        private string[] GetMaxVotedItems(int[] score, List<string> diagnose)
        {
            List<string> result = new List<string>();
            int maxVotes = 0;
            for(int i = 0; i < score.Length; i++)
            {
                if(maxVotes == score[i])
                {
                    result.Add(diagnose[i]);
                }
                if (maxVotes < score[i])
                {
                    maxVotes = score[i];
                    result.Clear();
                    result.Add(diagnose[i]);
                }
            }
            return result.ToArray();
        }
    }
}
