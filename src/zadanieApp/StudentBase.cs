using System;
using static zadanieApp.Student;

namespace zadanieApp
{
    public abstract class StudentBase : IStudent
    {
        public StudentBase(string Name)
        {
            this.Name = Name;
        }

        public string Name {get; set; }

        public abstract event GradeAddedDelegate GradeAdded;
        
        public abstract event GradeAddedDelegate GradeAdded1;

        public abstract void AddGrade(double grade);

        public abstract void AddGrade(string grade);
        
        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var stat = GetStatistics();
            if (stat.Count != 0)
            {
                Console.WriteLine($"Total grades: {stat.Count}");
                Console.WriteLine($"Highest grade: {stat.High:N2}");
                Console.WriteLine($"Lowest grade: {stat.Low:N2}");
                Console.WriteLine($"Average: {stat.Average:N2}");
                Console.WriteLine($"Letter: {stat.Letter}");
            }
            else
            {
                Console.WriteLine($"Couldn't get statistics for {this.Name}");
            }
        }
    }
}