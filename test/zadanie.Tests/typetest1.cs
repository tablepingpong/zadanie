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
            var player1 = GetStudent("Adam");
            var player2 = GetStudent("Tomek");
            var player3 = player1;

            Assert.NotSame(player1, player2);
            Assert.False(Object.ReferenceEquals(player1, player2));
            Assert.Equal(player3, player1);
            Assert.Same(player1, player3);
            Assert.True(Object.ReferenceEquals(player1, player3));
        }

        private Student GetStudent(string name)
        {
            return new Student(name);
        }
    }
}