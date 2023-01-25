using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace zadanieApp
{
    public class Student : StudentBase, IStudent
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public override event GradeAddedDelegate GradeAdded;

        public Student(string Name) : base(Name)
        {
        }

        public List<double> grades = new List<double>();

        public override void AddGrade(double grade)
        {
             if (grade > 0 && grade < 100)
            {
                this.grades.Add(grade);
            }
            else
            {
                GradeAdded(this, new EventArgs());;
            }
        }

        public override void AddGrade(string ocena)
        {
            var grade =  ocena switch
            {
                "1+" => 1.5,
                "2+" => 2.5,
                "3+" => 3.5,
                "4+" => 4.5,
                "5+" => 5.5,
                "2-" => 1.75,
                "3-" => 2.75,
                "4-" => 3.75,
                "5-" => 4.75,
                "6-" => 5.75,
                string => double.Parse(ocena),
            };
            this.AddGrade(grade);
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for (var index = 0; index < grades.Count; index++)
            {
                
                result.Low = Math.Min( grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            };
            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 80:
                    result.Letter = 'A';
                    break;

                case var d when d >= 60:
                    result.Letter = 'B';
                    break;

                case var d when d >= 40:
                    result.Letter = 'C';
                    break;

                default:
                    result.Letter = 'Z';
                    break;
            }
            return result;
        }

        public void ChangeName(string newname)
        {
            var isDigit = false;

            foreach (var n in newname)
            {
                if (char.IsDigit(n))
                {
                    isDigit = true;
                }
            }

            if (isDigit)
            {
                Console.WriteLine($"Characters other than letters were found in the name, new name is {newname}");
            }
            else
            {
                this.name = newname;
                Console.WriteLine($"No characters found in name {newname}");
            }
        }

        public string[] imie = new string[] { "Artur", "Kamil", "Julia", "Natalia", "Igor", "Marlena", "Wojtek", "Oskar", "Tymek", "Ignacy" };

        public int[] age = new int[] { 22, 16, 16, 19, 12, 30, 55, 12, 13, 11 };
        private string name;

        public void NameAge()
        {
            for (var index = 0; index < imie.Length; index++)
            {
                Console.WriteLine($" {imie[index]}-{age[index]}");
            }
        }
    }
}