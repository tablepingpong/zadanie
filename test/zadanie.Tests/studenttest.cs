using System;
using Xunit;
using zadanieApp;

namespace zadanie.Tests
{
    public class StudentTests
    {
        [Fact]
        public void Test1()
        {
            var emp = new Student("Sylwia");
            emp.AddGrade(5);
            emp.AddGrade(2);
            emp.AddGrade(1);
            emp.AddGrade(4);
            emp.AddGrade(5);
            emp.AddGrade(3);
            emp.AddGrade(4);
            emp.AddGrade(5);

            var result = emp.GetStatistics();

            Assert.Equal(4.8, result.Average, 1);
            Assert.Equal(6.0, result.High, 1);
            Assert.Equal(3.5, result.Low, 1);
        }
    }
}