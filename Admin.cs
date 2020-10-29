using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace engener
{
    public class Admin
    {
        public string name { get; set; }
        public string pass { get; set; }
        public string baseName { get; set; }
        public string hint { get; set; }
        public string description { get; set; }

        public Admin(string name, string password, string baseName , string hint, string description)
        {
            this.name = name;
            this.pass = password;
            this.baseName = baseName;
            this.hint = hint;
            this.description = description;
        }

   

        public Admin(string all)
        {
            string[] vs = all.Split(";");
            this.name = vs[0];
            this.pass = vs[1];
            this.baseName = vs[2];
            this.hint = vs[4];
            this.description = vs[3];
        }

        public string ToCodedString()
        {
            string result = name + ";" + pass + ";" + baseName + ";" + description + ";" + hint + ";";
            return result;
        }

      

    }
}
