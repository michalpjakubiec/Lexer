using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _20181114
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "input.txt";

            IList<string> inputLines = ReadLinesToList(filePath);

            var regexPatterns = new List<Regex>
            {
                new Regex (@"(^\+|^-|^\*|^\/)(.*)"),         // operator
                new Regex (@"(^\(|^\))(.*)"),                // parentheses
                new Regex (@"(^\d+.\d+)(.*)"),               // float
                new Regex (@"(^\d+)(.*)"),                   // integer
                new Regex (@"(^[A-Za-z][A-Za-z0-9]*)(.*)"),  // integer
            };

            foreach (var line in inputLines)
            {
                GetTokens(line, regexPatterns);
            }
        }

        static void GetTokens(string line, IList<Regex> regexPatterns)
        {
            string remainingText = line;

            for (int i = 0; i < regexPatterns.Count; i++)
            {
                regexPatterns[i].Match(remainingText);
                regexPatterns[i].Split(remainingText).Select(x => x );
            } 
        }

        private static IList<string> ReadLinesToList(string fileName)
        {
            IList<string> input = new List<string>();

            if (File.Exists(fileName))
            {
                input = File.ReadLines(fileName).ToList();
            }
            else
            {
                Console.WriteLine("Input file not found. Quitting...");
                Environment.Exit(2);
            }

            return input;
        }
    }
}
