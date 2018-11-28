﻿using System;
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
                new Regex (@"(?<Identifier>^[A-Za-z][A-Za-z0-9]*)"),
                new Regex (@"(?<Operator>^\+|^-|^\*|^\/)"),
                new Regex (@"(?<Parenthese>^\(|^\))"),
                new Regex (@"(?<Float>^\d+\.\d+)"),
                new Regex (@"(?<Integer>^\d+)"),
            };

            foreach (var line in inputLines)
            {
                GetTokens(line, regexPatterns);
            }

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        static void GetTokens(string line, IList<Regex> regexPatterns)
        {
            string remainingText = line.TrimStart();

            var isEndOfLineOrUnexpectedToken = false;

            Console.WriteLine(remainingText);
            Console.WriteLine("==========================");

            do
            {
                foreach (var regex in regexPatterns)
                {
                    var match = regex.Match(remainingText);
                    var groupName = regex.GroupNameFromNumber(1);

                    if (match.Success)
                    {
                        Console.Write($"{groupName,-15} ");
                        Console.WriteLine($"{match.Value,-10}");

                        remainingText = regex.Replace(remainingText, string.Empty).TrimStart();

                        isEndOfLineOrUnexpectedToken = true;
                        break;
                    }

                    isEndOfLineOrUnexpectedToken = false;
                }

                if (isEndOfLineOrUnexpectedToken == false)
                {
                    if (!string.IsNullOrWhiteSpace(remainingText))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"[ ERROR ] Unexpected token: \"{remainingText}\".");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"[ OK ]");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
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