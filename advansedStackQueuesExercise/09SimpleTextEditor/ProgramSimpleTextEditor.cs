using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09SimpleTextEditor
{
    class ProgramSimpleTextEditor
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            Stack<string> backup = new Stack<string>();

            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (int.Parse(input[0]))
                {
                    case 1:
                        text.Append(input[1]);
                        backup.Push(text.ToString());
                        break;
                    case 2:
                        int count = int.Parse(input[1]);
                        text.Remove(text.Length - count, count);
                        backup.Push(text.ToString());
                        break;
                    case 3:
                        int index = int.Parse(input[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case 4:
                        if (backup.Count > 1)
                        {
                            backup.Pop();
                            text = new StringBuilder(backup.Peek());
                        }
                        else
                        {
                            backup.Pop();
                            text.Clear();
                        }
                        break;
                }
            }
        }
    }
}
