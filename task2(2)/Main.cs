using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace task2_2_
{
    internal class Main
    {


        public static string[] readFile(string fileName)
        {
            string[] lines = null;
            try
            {
                lines = System.IO.File.ReadAllLines(fileName/*@"../../input.txt"*/);
                Console.WriteLine("Текст:");

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                return lines;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }


            return lines;
        }

        public static List<string> wordCheck(string[] text)
        {
            string pattern = @"(\b[С]\w+|\w+[С]\b)";
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            List<string> correctWords = new List<string>();

            Console.WriteLine("");
            Console.WriteLine("Найденные слова:");

            for (int i = 0; i < text.Length; i++)
            {
                MatchCollection matchedAuthors = rg.Matches(text[i]);
                for (int count = 0; count < matchedAuthors.Count; count++)
                {
                    Console.WriteLine(matchedAuthors[count].Value);
                    correctWords.Add(matchedAuthors[count].Value);
                }
            }

            return correctWords;
        }

        public static void writeInFile(List<string> correctWords)
        {
            try
            {
                using StreamWriter file = new(@"C:\Users\Ekaterina\RiderProjects\task2_3\task2_3\output.txt");

                //Writeout the numbers 1 to 10 on the same line.
                foreach (string word in correctWords)
                {
                    file.WriteLine(word);

                }
                //close the file
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }


        }



    }
}