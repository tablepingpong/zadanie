using zadanieApp;
using static zadanieApp.Student;

public interface IStudent
{
    void AddGrade(double grade);

    void AddGrade(string grade);

    Statistics GetStatistics();

    string Name { get; }

    event GradeAddedDelegate GradeAdded;
}