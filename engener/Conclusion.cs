using System;
using System.Collections.Generic;
using System.Text;

namespace engener
{
    abstract class Conclusion
    {
        protected List<string> evidence;
        public Conclusion(List<string> evidence)
        {
            this.evidence = evidence;
        }


        protected string GetRuleResult(string rule)
        {
            string[] splitedRule = rule.Split(";");
            return splitedRule[splitedRule.Length - 2].Split("_")[1];
        }


        protected bool CheckRule(string rule)
        {
            string[] tabOfRule = rule.Split(";");
            for(int i =0; i<evidence.Count; i++)
            {
                if (evidence[i] == "")
                    continue;
                if (evidence[i] != tabOfRule[i].Split("_")[1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
