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
                    case "w" or "W":
                        AddGradeToMemory();
                        break;

                    case "x" or "X":
                        AddGradeToFile();
                        break;

                    case "y" or "Y":
                        closeApp = true;
                        break;
                }
            }
        }

        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"Hello Enter grade for {student.name}");
                    var input = Console.ReadLine();

                    if (input == ("q"))
                    {
                        break;
                    }
                    else
                    {
                        student.AddGrade(input);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Grade is out of range");
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var stats = student.GetStatistics();
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
        static void OnGradeAdded3(object sender, EventArgs args)
        {
            Console.WriteLine("Grade is out of range ");
        }

        private static void AddGradeToMemory()
        {
            var memory = new Student("Sylwia");
            memory.GradeAdded += OnGradeAdded;
            memory.GradeAdded1 += OnGradeAdded3;
            EnterGrade(memory);
            memory.ShowStatistics();
        }

        private static void AddGradeToFile()
        {
            var file = new StudentText("Sylwia");
            file.GradeAdded += OnGradeAdded1;
            file.GradeAdded1 += OnGradeAdded3;
            EnterGrade(file);
            file.ShowStatistics();
        }
    }
}