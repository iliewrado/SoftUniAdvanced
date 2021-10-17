using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _02AverageStudentGrades
{
    class ProgramAverageStudentGrades
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentRecord = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < count; i++)
            {
                string[] stusentInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = stusentInfo[0];
                decimal grade = decimal.Parse(stusentInfo[1]);

                if (studentRecord.ContainsKey(name))
                {
                    studentRecord[name].Add(grade);
                }
                else
                {
                    studentRecord.Add(name, new List<decimal>()
                    { 
                        grade
                    });
                }
            }
            foreach (var student in studentRecord)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(' ', student.Value.Select(x => x.ToString("F2")))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
