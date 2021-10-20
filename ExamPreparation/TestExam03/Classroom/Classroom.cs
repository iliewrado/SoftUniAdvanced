using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public int Capacity { get; set; }
        public int Count => students.Count;
        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            if (students.Exists(x => x.FirstName == firstName 
            && x.LastName == lastName))
            {
                Student student = students.FirstOrDefault(x => x.LastName == lastName 
                && x.FirstName == firstName);
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }
            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            if (students.Count > 0 
                && students.Exists(x => x.Subject == subject))
            {
                StringBuilder studentsSub = new StringBuilder();
                studentsSub.AppendLine($"Subject: {subject}");
                studentsSub.AppendLine("Students:");
                foreach (var student in students.Where(x => x.Subject == subject))
                {
                    studentsSub.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return studentsSub.ToString().TrimEnd();
            }
            return "No students enrolled for the subject";
        }
        public int GetStudentsCount()
        {
            return students.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return student;
        }
    }
}
