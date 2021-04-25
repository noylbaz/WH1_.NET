//Noy Elbaz 315073122
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH1_NoyElbaz
{
    public class Course
    {
        public string Name { get; set; }
        public String this[int index]
        {
            get
            {
                if (index < student.Grades.Count())
                    return student.Grades[index].ToString();
                else
                    return " ";
            } //no need set
        }
        public class Student
        {
            public string Name { get; set; }
            public List<int> Grades { get; set; }

            public override string ToString()
            {
                return String.Format("{0,-15} {1,-15}", Name, String.Join(" ", Grades));
            }
        }
        public Student student;

        public override string ToString()
        {
            return String.Format("{0,-15} {1,-15}", Name, student.ToString());
        }
    }
}

