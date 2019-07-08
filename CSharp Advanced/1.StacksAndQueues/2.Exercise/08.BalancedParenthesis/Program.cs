using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();

            char[] openBrackets = { '(', '{', '[' };
            bool isValid = true;

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (openBrackets.Contains(ch))
                {
                    stack.Push(ch);
                    continue;
                }
                if (stack.Count == 0)
                {
                    isValid = false;
                    break;
                }
                if (stack.Peek() == '(' && ch == ')')
                {
                    stack.Pop();
                }
                else if (stack.Peek() == '{' && ch == '}')
                {
                    stack.Pop();
                }
                else if (stack.Peek() == '[' && ch == ']')
                {
                    stack.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}

