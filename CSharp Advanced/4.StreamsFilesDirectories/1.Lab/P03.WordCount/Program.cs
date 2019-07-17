using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            string words = @"words.txt";
            string textToProcess = @"text.txt";

            string[] wordsInFile = File.ReadAllText(words)
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] linesInText = File.ReadAllLines(textToProcess);

            foreach (var item in wordsInFile)
            {
                if (!list.ContainsKey(item))
                {
                    list[item] = 0;
                }
            }

            foreach (var line in linesInText)
            {
                string[] wordsInLine = line
                    .ToLower()
                    .Split(new char[] { '-', ' ', ',', '?', '!', '.' });
                foreach (var word in wordsInLine)
                {
                    if (list.ContainsKey(word))
                    {
                        list[word]++;
                    }
                }
            }
            foreach (var kvp in list.OrderByDescending(x => x.Value))
            {
                File.AppendAllText("output.txt", $"{kvp.Key} - {kvp.Value} {Environment.NewLine}");
            }
        }
    }
}
