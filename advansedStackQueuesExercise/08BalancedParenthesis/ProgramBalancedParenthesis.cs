using System;
using System.Collections.Generic;

namespace _08BalancedParenthesis
{
    class ProgramBalancedParenthesis
    {
        static void Main(string[] args)
        {
            string parentheses = Console.ReadLine();
            Stack<char> parenthes = new Stack<char>();
            bool isMach = true;
            for (int i = 0; i < parentheses.Length; i++)
            {
                if (parentheses[i] == 40 || parentheses[i] == 91 || parentheses[i] == 123)
                {
                    parenthes.Push(parentheses[i]);
                }
                else
                {
                    if (parenthes.Count > 0)
                    {
                        if (parentheses[i] == 41)
                        {
                            if (parenthes.Pop() != 40)
                            {
                                isMach = false;
                                break;
                            }
                        }
                        else if (parentheses[i] == 93)
                        {
                            if (parenthes.Pop() != 91)
                            {
                                isMach = false;
                                break;
                            }
                        }
                        else if (parentheses[i] == 125)
                        {
                            if (parenthes.Pop() != 123)
                            {
                                isMach = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        isMach = false;
                        break;
                    }
                }
            }
            Console.WriteLine(isMach ? "YES" : "NO");
        }
    }
}
