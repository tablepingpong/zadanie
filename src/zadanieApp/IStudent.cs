using zadanieApp;
using static zadanieApp.Student;

public interface IStudent
{
    void AddGrade(double grade);

    void AddGrade(string grade);

    Statistics GetStatistics();

    string name { get; set;}

    event GradeAddedDelegate GradeAdded;

    event GradeAddedDelegate GradeAdded1;

    void ShowStatistics();
}