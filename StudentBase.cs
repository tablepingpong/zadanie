using static zadanieApp.Student;

namespace zadanieApp
{
    public abstract class StudentBase : IStudent
    {
        public StudentBase(string Name)
        {
        }

        public string Name {get; set; }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract void AddGrade(string grade);
        
        public abstract Statistics GetStatistics();
    }
}