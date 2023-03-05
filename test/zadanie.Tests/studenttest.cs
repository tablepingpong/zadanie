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

            Assert.Equal(3.6, result.Average, 1);
            Assert.Equal(5.0, result.High, 1);
            Assert.Equal(1.0, result.Low, 1);
        }
    }
}