using System;
using System.Collections.Generic;
using System.Linq;
namespace zadanieApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool closeApp = false;

            while (!closeApp)
            {
                Console.WriteLine(
                    "W - Add student's grades to the program memory and show statistics\n" +
                    "X - Add student's grades to the file and show statistics\n" +
                    "Y - Close app\n");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "w":
                        AddGradeToMemory();
                        break;

                    case "x":
                        AddGradeToFile();
                        break;

                    case "y":
                        closeApp = true;
                        break;
                }
            }
        }

        private static void EnterGrade(IStudent studenttext)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"Hello Enter grade for {studenttext.Name}");
                    var input = Console.ReadLine();

                    if (input == ("q"))
                    {
                        break;
                    }
                    else
                    {
                        var grade = double.Parse(input);
                        studenttext.AddGrade(grade);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ocena jest spoza zakresu");
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var stats = studenttext.GetStatistics();
                Console.WriteLine($"High: {stats.High}");
                Console.WriteLine($"Low: {stats.Low}");
                Console.WriteLine($"Average: {stats.Average}");
                Console.WriteLine($"Letter: {stats.Letter}");
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("Grade is seved in memory");
        }

        static void OnGradeAdded1(object sender, EventArgs args)
        {
            Console.WriteLine("Grade is seved in file");
        }

        private static void AddGradeToMemory()
        {
            var Memory = new Student("Sylwia");
            Memory.GradeAdded += OnGradeAdded;
            EnterGrade(Memory);
        }

        private static void AddGradeToFile()
        {
            var File = new StudentText("Sylwia");
            File.GradeAdded += OnGradeAdded1;
            EnterGrade(File);
            File.GetStatistics();
        }
    }
}