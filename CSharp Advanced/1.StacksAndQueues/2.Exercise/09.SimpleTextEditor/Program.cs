using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string text = string.Empty;
            Stack<string> operations = new Stack<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine()
                    .Split();
                int operation = int.Parse(command[0]);
                switch (operation)
                {
                    case 1:
                        operations.Push(text);
                        string addText = command[1];
                        text += addText;
                        break;
                    case 2:
                        operations.Push(text);
                        int count = int.Parse(command[1]);
                        text = text.Substring(0, text.Length - count);
                        break;
                    case 3:
                        int index = int.Parse(command[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        text = operations.Pop();
                        break;
                }
            }
        }
    }
}
