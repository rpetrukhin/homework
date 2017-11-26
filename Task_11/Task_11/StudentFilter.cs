using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Task_11
{
    public class Student
    {
        public readonly string Name;
        public readonly string Lesson;
        public readonly DateTime Date;
        public readonly int Mark;

        public Student(string name, string lesson, DateTime date, int mark)
        {
            Name = name;
            Lesson = lesson;
            Date = date;
            Mark = mark;
        }

        public override string ToString()
        {
            return String.Format("Name:{0}, Lesson:{1}, Date:{2}.{3}.{4}, Mark:{5}", Name, Lesson, Date.Day, Date.Month, Date.Year, Mark);
        }
    }

    public class StudentFilter
    {
        public List<Student> Filter(string consoleString)
        {
            if (consoleString == null || consoleString == "")
                return new List<Student>();

            string fileName = consoleString.Split()[0];

            string stringOfFilters = null;
            if (fileName.Length != consoleString.Length)
                stringOfFilters = consoleString.Substring(fileName.Length + 1);
                
            var filters = ParseFilters(stringOfFilters);

            var students = ReadFile(fileName);

            return ApplyFilters(students, filters);
        }

        private Dictionary<string, string> ParseFilters(string stringOfFilters)
        {
            if (stringOfFilters == null || stringOfFilters == "")
                return null;

            var dict = new Dictionary<string, string>();

            string[] filters = stringOfFilters.Split();

            foreach (string filter in filters)
            {
                string[] s = filter.Split('=');
                dict.Add(s[0], s[1]);
            }

            return dict;
        }

        private List<Student> ReadFile(string fileName)
        {
            if (fileName == null || fileName == "")
                return null;

            var students = new List<Student>();

            using (var sr = new StreamReader(fileName))
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(',');
                    students.Add(new Student(values[0], values[1], Convert.ToDateTime(values[2]), Convert.ToInt32(values[3])));
                }

            return students;
        }

        private List<Student> ApplyFilters(List<Student> students, Dictionary<string, string> filters)
        {
            if (students == null || filters == null)
                return students;

            var filteredStudents = new List<Student>(students);

            foreach (var filter in filters)
            {
                switch (filter.Key.ToLower())
                {
                    case "name":
                        filteredStudents = filteredStudents.Where(stud => stud.Name == filter.Value).ToList();
                        break;
                    case "lesson":
                        filteredStudents = filteredStudents.Where(stud => stud.Lesson == filter.Value).ToList();
                        break;
                    case "startdate":
                        filteredStudents = filteredStudents.Where(stud => stud.Date >= Convert.ToDateTime(filter.Value)).ToList();
                        break;
                    case "enddate":
                        filteredStudents = filteredStudents.Where(stud => stud.Date <= Convert.ToDateTime(filter.Value)).ToList();
                        break;
                    case "mark":
                        filteredStudents = filteredStudents.Where(stud => stud.Mark == Convert.ToInt32(filter.Value)).ToList();
                        break;
                    case "recordsnumber":
                        filteredStudents = filteredStudents.Take(Convert.ToInt32(filter.Value)).ToList();
                        break;
                }
            }

            return filteredStudents;
        }
    }
}