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
            emp.AddGrade(59.5);
            emp.AddGrade(45.4);
            emp.AddGrade(60.7);
            emp.AddGrade(62.6);
            emp.AddGrade(78.5);
            emp.AddGrade(50.7);
            emp.AddGrade(63.7);
            emp.AddGrade(64.8);
        }
    }
}