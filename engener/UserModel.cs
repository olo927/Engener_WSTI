using System;
using System.Collections.Generic;
using System.Text;

namespace engener
{
    class UserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Hint { get; set; }

        public string FullData
        {
            get
            {
                return $"{Login} {Password} {Hint}";
            }
        }
    }
}
