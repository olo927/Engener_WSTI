using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace engener
{
    static class FileAdapter
    {
        public static List<Admin> GetAllAdmins()
        {
            string adminPath = "admin.ame";
            List<Admin> admins = new List<Admin>();
            if (!File.Exists(adminPath))
            {
                File.Create(adminPath);
            }
            string[] linesOfAdminFile = File.ReadAllLines(adminPath);
            foreach (string line in linesOfAdminFile)
            {
                admins.Add(new Admin(line));
            }
            return admins;
        }

        //dla bazy wiedzy tutaj odczyty i zapisy
    }
}
