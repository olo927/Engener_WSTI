using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace engener
{
    class ListClassfy : Conclusion
    {
        protected List<string> SortedListOfRules;
        private string baseName;
        public ListClassfy(List<string> evidence, string baseName):
            base(evidence)
        {
            this.baseName = baseName;
            SortedListOfRules = SortingRule(this.baseName);
        }
        public string Classify()
        {
            foreach (string rule in SortedListOfRules)
            {
                if (CheckRule(rule))
                {
                    return GetRuleResult(rule);
                }
            }
            return "Żadna z reguł nie spełnia założonych przesłanek";
        }
        private List<string> SortingRule(string baseName)
        {
            List<string> NotSortedList = FileAdapter.GetAllNotEditedRule(baseName);
            NotSortedList.Sort(CompareByLength);
            return NotSortedList;
        }
        private static int CompareByLength(string x, string y)
        {
            if(x == null)
            {
                if (y == null)
                    return 0;
                else
                    return 1;
            }
            else
            {
                if (y == null)
                    return -1;
                else
                {
                    int retval = x.Length.CompareTo(y.Length);
                    if (retval != 0)
                        return -retval; //odwrocona wartosc przez compareto
                    else
                        return x.CompareTo(y);
                }
                
            }
        }
    }
}
