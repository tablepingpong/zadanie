using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static zadanieApp.Student;

namespace zadanieApp
{
    public class StudentText : StudentBase
    {
        public const string FileName = "Sylwia";

        public const string audit = "audit.txt";

        public override event GradeAddedDelegate GradeAdded;

        public override event GradeAddedDelegate GradeAdded1;

        public StudentText(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 6)
            {
                using (var writer = File.AppendText($"{FileName}.txt"))
                {
                    writer.WriteLine(grade);
                }
                using (var writer2 = File.AppendText($"{audit}.txt"))
                {
                    writer2.WriteLine($"Ocena:{grade} - Date:{DateTime.UtcNow}");
                }  
                GradeAdded(this, new EventArgs());  
            }
            else
            {
                GradeAdded1(this, new EventArgs());
            }
        }

         public override void AddGrade(string grade)
        {
            var score =  grade switch
            {
                "1+" or "+1" => 1.5,
                "2+" or "+2" => 2.5,
                "3+" or "+3"=> 3.5,
                "4+" or "+4"=> 4.5,
                "5+" or "+5"=> 5.5,
                "2-" or "-2"=> 1.75,
                "3-" or "-3"=> 2.75,
                "4-" or "-4"=> 3.75,
                "5-" or "-5"=> 4.75,
                "6-" or "-6"=> 5.75,
                string => double.Parse(grade),
            };
            this.AddGrade(score);
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            if (File.Exists($"{FileName}.txt"))
            {
                using (var reader = File.OpenText($"{FileName}.txt"))
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
    }
}