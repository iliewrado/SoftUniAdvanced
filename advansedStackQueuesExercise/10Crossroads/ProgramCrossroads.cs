using System;
using System.Collections.Generic;
using System.Linq;

namespace _10Crossroads
{
    class ProgramCrossroads
    {
        static void Main(string[] args)
        {
            int trafickLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string command = Console.ReadLine();
            int count = 0;
            bool crash = false;
            while (command != "END" && crash == false)
            {
                if (command == "green")
                {
                    int greenLight = trafickLight;
                    int openWindow = freeWindow;

                    while (greenLight > 0 && cars.Count() != 0)
                    {
                        if (greenLight > cars.Peek().Count())
                        {
                            greenLight -= cars.Dequeue().Count();
                            count++;
                        }
                        else
                        {
                            if (openWindow + greenLight < cars.Peek().Count())
                            {
                                int index = greenLight + openWindow;
                                char characterHit = cars.Peek().ElementAt(index);
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{cars.Dequeue()} was hit at {characterHit}.");
                                crash = true;
                                return;
                            }
                            else
                            {
                                count++;
                                cars.Dequeue();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            if (crash == false)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{count} total cars passed the crossroads.");
            }
        }
    }
}
