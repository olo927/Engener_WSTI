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

        public void Vote(string baseName)
        {
            List<List<string>> ind = FileAdapter.GetIngredients(baseName);
            List<string> results = ind[ind.Count - 1];
            int[] score = new int[results.Count-1];

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
                        score[results.IndexOf(res)-1]++;
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            string message;

            if (goodRule == 0)
            {
                message = "nie znana reguła odpowadająca podanym przesłanką";
            }

            //for(int i = 0; i<score.Length; i++)
            //{

            //}

        }

    }
}
