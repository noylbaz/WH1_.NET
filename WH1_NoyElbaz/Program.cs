//Noy Elbaz 315073122
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH1_NoyElbaz
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch;
            List<Course> list = new List<Course>
            {
                new Course
                {
                    Name = "C#",
                    student=new Course.Student {Name = "Jojo", Grades = new List<int> { 10, 20, 100 } }
                },
                new Course
                {
                    Name = "C",
                    student=new Course.Student {Name = "Bambi", Grades = new List<int> { 99 } }
                },
                new Course
                {
                    Name = "Java",
                    student=new Course.Student {Name = "Bambi", Grades = new List<int> {} }
                },
                new Course
                {
                    Name = "C#",
                    student=new Course.Student {Name = "Jojo", Grades = new List<int> { 10, 20, 30,40 } }
                },
                new Course
                {
                    Name = "Java",
                    student=new Course.Student {Name = "Lady Gaga", Grades = new List<int> { 100,99,1,100,100 } }
                },
                new Course
                {
                    Name = "Java",
                    student=new Course.Student {Name = "Tami", Grades = new List<int> {60,70,80,1 } }
                },
                new Course
                {
                    Name = "SQL",
                    student=new Course.Student {Name = "Lady Gaga", Grades = new List<int> { 50 } }
                },
            };
      
            ShowCourses(list);
            Menu();
            ch = Console.ReadLine()[0];
            IEnumerable<Course> tempList = Q1(ch, list);
            Console.WriteLine("\n\n\nQ1 Results:\n");
            Console.WriteLine("false:");
            Console.WriteLine("===============\n");
            ShowCourses(list.Except(tempList));
            Console.WriteLine("true:");
            Console.WriteLine("===============\n");
            ShowCourses(tempList);
            Console.WriteLine("\nlist[1].ShowGrade(0):");
            Console.WriteLine(list[1].ShowGrade(0));
            Console.WriteLine("list[2].ShowGrade(3):");
            Console.WriteLine(list[2].ShowGrade(3));
            ShowStudent(Q2(list));
        }
        public static IEnumerable<T> Q1<T>(char ch, IEnumerable<T> list) where T : Course
        {
            IEnumerable<T> tempList;
            switch (ch)
            {
                case 'P':
                case 'p':
                    tempList = list.Where(course => (course.student.Grades.Count > 0 ? course.student.Grades.Average() : 0.0) >= 60.0);
                    break;
                case '#':
                    tempList = list.Where(course => course.Name == "C#");
                    break;
                default:
                    tempList = list.Where(course => course.student.Grades.Count(grade => grade == 100) >= 1);
                    break;
            }
            return tempList;
        }
        public static IEnumerable<Object> Q2<T>(IEnumerable<T> list) where T : Course
        {
            var tempList =
                from course in list
                where ((course.student.Grades.Where(grade => grade >= 60).Count() > 0 ?
                (course.student.Grades.Where(grade => grade >= 60).Average()) :
                (0.0)) > 90)
                select new { Name = course.student.Name, List = string.Join(" ", course.student.Grades) };
            return tempList;
        }
        public static void ShowStudent(IEnumerable<Object> list)
        {
            Console.WriteLine(String.Join("\n", list) + "\n");
        }
        public static void ShowCourses<T>(IEnumerable<T> list) where T : Course
        {
            Console.WriteLine(String.Join("\n", list) + "\n");
        }
        public static void Menu() 
        {
            Console.WriteLine("Press P / p : Those who passed in average and those who did not:");
            Console.WriteLine("Press # : C# courses, and other courses:");
            Console.WriteLine("Any other key: Courses with students who have at least one grade of 100, and all the other courses:");
        }
    }
}

