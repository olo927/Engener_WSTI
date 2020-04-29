using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Security.Cryptography;

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
        public static string ComputeSha256Hash(string pass)
        { 
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(pass));
  
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        internal static string GetDiagnoseName(string baseName)
        {
            try
            {
                baseName = "data\\" + baseName + ".bod";
                string[] lines = File.ReadAllLines(baseName);
                return lines[0].Split(":")[0];
            }
            catch {
                return null;

            }

            
            
        }

        internal static void UpdateRules(string baseName, string text)///Tu błąd
        {
            baseName = "data\\" + baseName + ".bok";
            List<string> lines = File.ReadAllLines(baseName).ToList();
            List<string> newLines = new List<string>();
            for(int i = 0; i < lines.Count; i++)
            {
                string[] splitedLine = lines[i].Split(";");
                string newLine = "";
                for(int j = 0; j<splitedLine.Length-1; j++)
                {
                    if (j == splitedLine.Length - 2)
                    {
                        newLine += text + "_;";
                    }
                    newLine += splitedLine[j]+";";
                }
                newLines.Add(newLine);

            }
            File.WriteAllLines(baseName, newLines);
        }

        internal static bool isEmpty(string baseName)
        {
            baseName = "data\\" + baseName + ".bod";
            string tekst = File.ReadAllText(baseName);
            if (tekst == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static string GetDescripionToResult(string searchingItem, string baseName)
        {
            string[] lines = File.ReadAllLines("data//" + baseName + ".bod");
            
            string[] currentLine = lines[0].Split(";");
            foreach (string item in currentLine)
            {
                if (searchingItem == item.Split(":")[0])
                {
                    try
                    {
                        return item.Split(":")[1];
                    }
                    catch
                    {
                        return currentLine[0].Split(":")[1];
                    }

                }
            }
            return currentLine[0].Split(":")[1];

        }

        internal static void SaveNewDiagnoseIngredient(string baseName, string cat, string ingr, string description)
        {
            baseName = "data\\" + baseName + ".bod";
            string[] lines = File.ReadAllLines(baseName);
            if (lines[0].Split(":")[0] == cat)
            {
                lines[0] += ingr + ":" + description + ";";
            }
            File.WriteAllLines(baseName, lines);
        }

        public static List<string> GetAllNamesOfBases()
        {
            List<Admin> Admins = GetAllAdmins();
            List<string> bases = new List<string>();
            foreach (Admin admin in Admins)
            {
                bases.Add(admin.baseName);
            }
            return bases;
        }

        internal static void AddNewDiagnoseFile(string baseName, string category, string description)
        {
            baseName = "data\\" + baseName + ".bod";
            string tekst = category + ":" + description /*+ ":" + PhotoName*/ + ";";
            File.WriteAllText(baseName, tekst);
        }

        //internal static string GetCategoryPhoto(string baseName, int index)
        //{
        //    string[] lines = File.ReadAllLines("data//" + baseName + ".boi");
        //    string[] currentLine = lines[index].Split(";");
        //    return baseName+"\\" + currentLine[0].Split(":")[2];
        //}

        internal static string GetDescripionToCategory(string baseName, int index)
        {
            string[] lines = File.ReadAllLines("data//" + baseName + ".boi");
            string[] currentLine = lines[index].Split(";");
            return currentLine[0].Split(":")[1];
        }

        internal static List<string> GetAllCategory(string baseName)
        {
            List<string> category = new List<string>();
            baseName = "data\\" + baseName + ".boi";
            string[] lines = File.ReadAllLines(baseName);

            foreach(string line in lines)
            {
                string[] splitedLine = line.Split(":");
                category.Add(splitedLine[0]);
            }

            return category;
        }

        internal static List<string[]> GetAllRuleForDisplay(string baseName)
        {
            List<string[]> rules = new List<string[]>();
            baseName = "data\\" + baseName + ".bok";
            string[] lines = new string[0];
            try
            {
                lines = File.ReadAllLines(baseName);
            }
            catch
            {
                Console.Error.WriteLine("Pusty plik");
            }
            
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
                            oneRule[0] +=  "\n"+splitedRule[0] + " : " + splitedRule[1];
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

        internal static string GetDescripionToItem(string searchingItem, string baseName, int iterator = -1)
        {
            string[] lines = File.ReadAllLines("data//" + baseName + ".boi");
            if(iterator == -1)
            {
                iterator = lines.Length - 1;
            }
            string[] currentLine = lines[iterator].Split(";");
            foreach (string item in currentLine)
            {
                if (searchingItem == item.Split(":")[0])
                {
                    try
                    {
                        return item.Split(":")[1];
                    }
                    catch
                    {
                        return currentLine[0].Split(":")[1];
                    }
                    
                }
            }
            return currentLine[0].Split(":")[1];

        }

        internal static string GetDescripionToBase(string category)
        {
            string[] lines = File.ReadAllLines("data//admin.ame");

            foreach (string line in lines)
            {
                string[] splitedLine = line.Split(";");
                if(splitedLine[2] == category)
                {
                    return splitedLine[3];
                }                
            }
            return "Brak Opisu";
        }

        internal static List<string> GetAllNotEditedRule(string baseName)
        {
            baseName = "data\\" + baseName + ".bok";
            string[] lines = File.ReadAllLines(baseName);
            return lines.ToList();
        }

        internal static void DeletingRule(string baseName, int index)
        {
            baseName = "data\\" + baseName + ".bok";
            List<string> lines = File.ReadAllLines(baseName).ToList();
            lines.RemoveAt(index);
            File.WriteAllLines(baseName, lines);
        }

        internal static void SaveNewIngredient(string baseName, string cat, string ingr, string description)
        {
            baseName = "data\\" + baseName + ".boi";
            string[] lines = File.ReadAllLines(baseName);
            for(int i = 0; i<lines.Length;i++)
            {
                if (lines[i].Split(":")[0] == cat)
                {
                    lines[i] += ingr + ":" + description + ";" ;
                    break;
                }
            }
            File.WriteAllLines(baseName,lines);
        }

        internal static bool DeletingBase(string baseName)
        {
            try
            {
                File.Delete("data\\" + baseName + ".boi");
                File.Delete("data\\" + baseName + ".bok");
                File.Delete("data\\" + baseName + ".bod");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
                return false;
            }
            List<string> lines = File.ReadAllLines("data\\admin.ame").ToList();
            int index = -1;
            for(int i = 0; i< lines.Count; i++)
            {
                if (lines[i].Split(';')[2] == baseName)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1) 
            {
                lines.RemoveAt(index);
                File.WriteAllLines("data\\admin.ame", lines);
                return true;
            }
            else
            {
                return false;
            }

        }

        internal static void AddNewCategoryToFile(string baseName,string category, string description/*, string PhotoName*/)
        {
            baseName = "data\\" + baseName + ".boi";
            string[] lines = File.ReadAllLines(baseName);
            List<string> LinesList = lines.ToList();
            LinesList.Add(category + ":" + description /*+ ":" + PhotoName*/ + ";");
            File.WriteAllLines(baseName, LinesList);
        }

        public static List<List<string>> GetIngredients(string fileName)
        {
            List<List<string>> result = new List<List<string>>();

            string[] lines;
           
            lines = File.ReadAllLines(fileName);

            foreach(string line in lines)
            {
                List<string> lineList = line.Split(";").ToList();
                List<string> ingredenceList = new List<string>();
                foreach(string pair in lineList)
                {
                    ingredenceList.Add(pair.Split(":")[0]);
                }
                result.Add(ingredenceList);
            }

            return result;
        }

        public static List<string> GetHeders(string fileName)
        {
            List<string> result = new List<string>();
            List<List<string>> every;
            try
            {
                every = GetIngredients(fileName);
            }
            catch
            {
                return null;
            }
            foreach(List<string> temp in every)
            {
                result.Add(temp[0]);
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
    }
}
