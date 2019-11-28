using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace engener
{
    static class FileAdapter
    {
        public static List<Admin> GetAllAdmins()
        {
            string adminPath = "data\\admin.ame";
            List<Admin> admins = new List<Admin>();
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }
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

        public static List<List<string>> GetIngredients(string fileName)
        {
            List<List<string>> result = new List<List<string>>();
            string[] lines = File.ReadAllLines(fileName);

            foreach(string line in lines)
            {
                List<string> lineList = line.Split(";").ToList();
                result.Add(lineList);
            }

            return result;
        }
        //dla bazy wiedzy tutaj odczyty i zapisy
    }
}
