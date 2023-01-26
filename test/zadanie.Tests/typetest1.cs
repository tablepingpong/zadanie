using System;
using Xunit;
using zadanieApp;

namespace Zadanie.Tests
{
    public class Typetest1
    {
        [Fact]
        public void GetStudentReturnsDirrefentsObjects()
        {
            var zawodnik1 = GetStudent("Adam");
            var zawodnik2 = GetStudent("Tomek");
            var zawodnik3 = zawodnik1;

            Assert.NotSame(zawodnik1, zawodnik2);
            Assert.False(Object.ReferenceEquals(zawodnik1, zawodnik2));
            Assert.Equal(zawodnik3, zawodnik1);
            Assert.Same(zawodnik1, zawodnik3);
            Assert.True(Object.ReferenceEquals(zawodnik1, zawodnik3));
        }
        private Student GetStudent(string name)
        {
            return new Student(name);
        }
    }
}