using System;
using System.Collections.Generic;
using System.Linq;

namespace _06SongsQueue
{
    class ProgramSongsQueue
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songs = new Queue<string>(input);

            while (songs.Count > 0)
            {
                string[] command = Console.ReadLine()
                    .Split();
                string song = string.Empty;
                if (command.Length > 2)
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        song += command[i]+" ";
                    }
                }
                else if(command.Length > 1)
                {
                    song = command[1];
                }
                switch (command[0])
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        if (songs.Contains(song.Trim()))
                        {
                            Console.WriteLine($"{song.Trim()} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(song.Trim());
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
