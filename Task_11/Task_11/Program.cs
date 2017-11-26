using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input format is");
            Console.WriteLine("fileName [name=someName] [lesson=someLesson] [startDate=someStartDate] " +
                "[endDate=someEndDate] [mark=someMark] [recordsNumber=someRecordsNumber]");

            string consoleString = Console.ReadLine();

            var studentFilter = new StudentFilter();

            var students = studentFilter.Filter(consoleString);

            foreach (var student in students)
                Console.WriteLine(student);
        }
    }
}