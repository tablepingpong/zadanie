using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace zadanieApp
{
    public class Student : StudentBase
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public override event GradeAddedDelegate GradeAdded;

        public override event GradeAddedDelegate GradeAdded1;

        public Student(string name) : base(name)
        {
        }

        public List<double> grades = new List<double>();

        public override void AddGrade(double grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                GradeAdded1(this, new EventArgs());
            }
        }

        public override void AddGrade(string grade)
        {
            var score = grade switch
            {
                "1+" or "+1" => 1.5,
                "2+" or "+2" => 2.5,
                "3+" or "+3" => 3.5,
                "4+" or "+4" => 4.5,
                "5+" or "+5" => 5.5,
                "2-" or "-2" => 1.75,
                "3-" or "-3" => 2.75,
                "4-" or "-4" => 3.75,
                "5-" or "-5" => 4.75,
                "6-" or "-6" => 5.75,
                string => double.Parse(grade),
            };
            this.AddGrade(score);
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach (var grade in grades)
            {
                result.Add(grade);
            }
            return result;
        }
    }
}