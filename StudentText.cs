using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static zadanieApp.Student;

namespace zadanieApp
{
    public class StudentText : StudentBase, IStudent
    {
        public const string FileName = "Sylwia";

        public const string audit = "audit.txt";

        public override event GradeAddedDelegate GradeAdded;

        public StudentText(string Name) : base(Name)
        {
        }
        // public List<double> grades = new List<double>();

        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 100)
            {
                using (var writer = File.AppendText($"{FileName}.txt"))
                {
                    writer.WriteLine(grade);
                }
                using (var writer2 = File.AppendText($"{audit}.txt"))
                {
                    writer2.WriteLine($"Ocena:{grade} - Date:{DateTime.UtcNow}");
                }
            }
            else
            {
                GradeAdded(this, new EventArgs());
            }
        }
            
        public override void AddGrade(string ocena)
        {
            var grade = ocena switch
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
           
            
            if (File.Exists($"{FileName}"))
            {
                using (var reader = File.OpenText($"{FileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = double.Parse(line);
                        result.Add(number);
                        line = reader.ReadLine();
                    }
                }
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
                this.Name = newname;
                Console.WriteLine($"No characters found in name {newname}");
            }
        }

        public string[] imie = new string[] { "Artur", "Kamil", "Julia", "Natalia", "Igor", "Marlena", "Wojtek", "Oskar", "Tymek", "Ignacy" };

        public int[] age = new int[] { 22, 16, 16, 19, 12, 30, 55, 12, 13, 11 };


        public void NameAge()
        {
            for (var index = 0; index < imie.Length; index++)
            {
                Console.WriteLine($" {imie[index]}-{age[index]}");
            }
        }
    }
}