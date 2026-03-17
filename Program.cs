using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Requirements
{
    internal class Program
    {

        // ================== Abstraction ==================
        abstract class Person
        {
            public string Name { get; set; }
            public string StudentID { get; set; }

            public Person(string name, string id)
            {
                Name = name;
                StudentID = id;
            }
        }

        // ================== Inheritance ==================
        class Student : Person
        {
            private int score; // Encapsulation

            public int Score
            {
                get { return score; }
                set
                {
                    if (value >= 0 && value <= 100)
                        score = value;
                }
            }

            public Student(string name, string id, int score) : base(name, id)
            {
                Score = score;
            }

            // ================== Polymorphism ==================
            public virtual string GetGrade()
            {
                if (Score >= 80) return "A";
                else if (Score >= 75) return "B+";
                else if (Score >= 70) return "B";
                else if (Score >= 65) return "C+";
                else if (Score >= 60) return "C";
                else if (Score >= 55) return "D+";
                else if (Score >= 50) return "D";
                else return "F";
            }
        }

        // ================== Course ==================
        class Course
        {
            public string CourseName { get; set; }
            public string CourseID { get; set; }

            private List<Student> students = new List<Student>();

            public Course(string name, string id)
            {
                CourseName = name;
                CourseID = id;
            }

            public void AddStudent(Student s)
            {
                students.Add(s);
            }

            public void ShowAll()
            {
                Console.WriteLine("\n--- รายชื่อนักศึกษา ---");
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.Name} ({s.StudentID}) | {s.Score} | {s.GetGrade()}");
                }
            }

            public void ShowMaxMin()
            {
                if (students.Count == 0) return;

                var max = students.OrderByDescending(s => s.Score).First();
                var min = students.OrderBy(s => s.Score).First();

                Console.WriteLine($"\nสูงสุด: {max.Name} = {max.Score}");
                Console.WriteLine($"ต่ำสุด: {min.Name} = {min.Score}");
            }

            public void ShowFail()
            {
                Console.WriteLine("\n--- คนที่ไม่ผ่าน (F) ---");
                foreach (var s in students.Where(s => s.GetGrade() == "F"))
                {
                    Console.WriteLine($"{s.Name} ({s.Score})");
                }
            }

            public void ShowAverage()
            {
                if (students.Count == 0) return;

                double avg = students.Average(s => s.Score);
                Console.WriteLine($"\nค่าเฉลี่ย: {avg:F2}");
            }

            // ================== Main Program ==================
            static void Main()
            {
                Console.Write("ชื่อวิชา: ");
                string cname = Console.ReadLine();

                Console.Write("รหัสวิชา: ");
                string cid = Console.ReadLine();

                Course course = new Course(cname, cid);

                while (true)
                {
                    Console.WriteLine("\n===== MENU =====");
                    Console.WriteLine("1. เพิ่มนักศึกษา");
                    Console.WriteLine("2. แสดงทั้งหมด");
                    Console.WriteLine("3. คะแนนสูงสุด/ต่ำสุด");
                    Console.WriteLine("4. คนที่ไม่ผ่าน");
                    Console.WriteLine("5. ค่าเฉลี่ย");
                    Console.WriteLine("0. ออกจากโปรแกรม");

                    Console.Write("เลือก: ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 0) break;

                    switch (choice)
                    {
                        case 1:
                            Console.Write("ชื่อ: ");
                            string name = Console.ReadLine();

                            Console.Write("รหัส: ");
                            string id = Console.ReadLine();

                            Console.Write("คะแนน: ");
                            int score = int.Parse(Console.ReadLine());

                            course.AddStudent(new Student(name, id, score));
                            break;

                        case 2:
                            course.ShowAll();
                            break;

                        case 3:
                            course.ShowMaxMin();
                            break;

                        case 4:
                            course.ShowFail();
                            break;

                        case 5:
                            course.ShowAverage();
                            break;
                    }
                }
            }
        }
    }
}
 





