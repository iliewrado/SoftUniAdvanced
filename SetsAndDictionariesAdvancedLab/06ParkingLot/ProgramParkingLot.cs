using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ParkingLot
{
    class ProgramParkingLot
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> carPlates = new HashSet<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] temp = input
                    .Split(new char[] { ',', ' ', }, StringSplitOptions.RemoveEmptyEntries);
                string direction = temp[0];
                string plateNumber = temp[1];

                if (direction == "IN")
                {
                    carPlates.Add(plateNumber);
                }
                else
                {
                    carPlates.Remove(plateNumber);
                }
            }
            if (carPlates.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, carPlates));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
