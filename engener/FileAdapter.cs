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

        internal static List<string> GetAllCategory(string baseName)
        {
            List<string> category = new List<string>();
            baseName = "data\\" + baseName + ".boi";
            string[] lines = File.ReadAllLines(baseName);

            foreach(string line in lines)
            {
                string[] splitedLine = line.Split(";");
                category.Add(splitedLine[0]);
            }

            return category;
        }

        internal static List<string[]> GetAllRule(string baseName)
        {
            List<string[]> rules = new List<string[]>();
            baseName = "data\\" + baseName + ".bok";
            string[] lines = File.ReadAllLines(baseName);
            foreach (string line in lines)
            {
                string[] splitedLine = line.Split(";");
                string[] oneRule = new string[2];
                for (int i = 0; i < splitedLine.Length; i++) 
                {
                    try
                    {
                        string[] splitedRule = splitedLine[i].Split("_");
                        if(i == splitedLine.Length - 2)
                        {
                            oneRule[1] += splitedRule[0] + " : " + splitedRule[1];
                        }
                        else if(i == 0)
                        {
                            oneRule[0] += splitedRule[0] + " : " + splitedRule[1];
                        }
                        else
                        {
                            oneRule[0] +=  " + "+splitedRule[0] + " : " + splitedRule[1];
                        }
                    }
                    catch
                    {
                        oneRule[0] += "";
                    }
                    
                    
                }
                
                rules.Add(oneRule);
            }

            return rules;
        }

        internal static void SaveNewIngredient(string baseName, string cat, string ingr)
        {
            baseName = "data\\" + baseName + ".boi";
            string[] lines = File.ReadAllLines(baseName);
            for(int i = 0; i<lines.Length;i++)
            {
                if (lines[i].Split(";")[0] == cat)
                {
                    lines[i] += ingr + ";";
                }
            }
            File.WriteAllLines(baseName,lines);
        }

        internal static void AddNewCategoryToFile(string baseName,string category)
        {
            baseName = "data\\" + baseName + ".boi";
            string[] lines = File.ReadAllLines(baseName);
            List<string> LinesList = lines.ToList();
            LinesList.Add(category + ";");
            File.WriteAllLines(baseName, LinesList);

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

        internal static void SaveNewRule(string baseName, string rule)
        {
            baseName = "data\\" + baseName + ".bok";
            List<string >lines = File.ReadAllLines(baseName).ToList();
            lines.Add(rule);
            File.WriteAllLines(baseName, lines);
        }
        //dla bazy wiedzy tutaj odczyty i zapisy
    }
}
