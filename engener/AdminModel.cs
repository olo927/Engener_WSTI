using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace engener
{
    public class AdminModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Base { get; set; }
        public string Description { get; set; }
        public string Hint { get; set; }

        public string FullData
        {
            get
            {
                return $"{Login} {Password} {Base} {Description} {Hint}";
            }
        }


    }
}
