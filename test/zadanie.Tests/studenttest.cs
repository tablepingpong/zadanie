using System;
using Xunit;
using zadanieApp;

namespace zadanie.Tests
{
    public class studenttest
    {
        [Fact]
        public void Test1()
        {
            var emp = new Student("Sylwia");
            emp.AddGrade(5);
            emp.AddGrade(4);
            emp.AddGrade(3);


            var result = emp.GetStatistics();

            Assert.Equal(4, result.Average);
            Assert.Equal(5, result.High, 1);
            Assert.Equal(3, result.Low, 1);
        }

    }
}