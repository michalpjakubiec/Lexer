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
                new Regex (@"(?<IDENTIFIER>^[A-Za-z][A-Za-z0-9]*\d*)"), // identifier
                new Regex (@"(?<OPERATOR>^\+|^-|^\*|^\/)"),             // operator
                new Regex (@"(?<PARENTHESE>^\(|^\))"),                  // parentheses
                new Regex (@"(?<FLOAT>^\d+\.\d+)"),                     // float
                new Regex (@"(?<INTEGER>^\d+)"),                        // integer
            };

            foreach (var line in inputLines)
            {
                GetTokens(line, regexPatterns);
            }
        }

        static void GetTokens(string line, IList<Regex> regexPatterns)
        {
            string remainingText = line;

            remainingText = Regex.Replace(remainingText, @"\s+", "");

            var isEndOfLineOrUnexpectedToken = false;

            do
            {
                foreach (var regex in regexPatterns)
                {
                    var match = regex.Match(remainingText);
                    var groupName = regex.GroupNameFromNumber(1);

                    if (match.Success)
                    {
                        remainingText = regex.Replace(remainingText, "");

                        Console.Write($"{groupName} ");
                        Console.Write($"{match.Value}, ");

                        isEndOfLineOrUnexpectedToken = true;
                        break;
                    }

                    isEndOfLineOrUnexpectedToken = false;
                }

                if (isEndOfLineOrUnexpectedToken == false)
                {
                    Console.WriteLine();
                    break;
                }
            } while (isEndOfLineOrUnexpectedToken);
        }

        private static IList<string> ReadLinesToList(string fileName)
        {
            IList<string> input = new List<string>();

            if (File.Exists(fileName))
            {
                input = File.ReadLines(fileName).Where(x => x != string.Empty).ToList();
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