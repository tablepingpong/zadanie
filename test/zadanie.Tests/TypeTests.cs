using System;
using Xunit;
using zadanieApp;

namespace Zadanie.Tests
{
    public class TypeTest
    {
        public delegate string WriteMessage(string Message);

        int counter = 0;

        [Fact]
        public void WriteMessageDelegateCanPointToMethode()
        {
            WriteMessage del = ReturnMessage;
            del += ReturnMessage;
            del += ReturnMessage2;
            var result = del("Hello");
            Assert.Equal(3, counter);
        }

        string ReturnMessage(string Message)
        {
            counter++;
            return Message;
        }

        string ReturnMessage2(string Message)
        {
            counter++;
            return Message;
        }

        [Fact]
        public void GetStudentReturnsDirrefentsObjects()
        {
            var player1 = GetStudent("Adam");
            var player2 = GetStudent("Tomek");

            Assert.NotSame(player2, player1);
            Assert.False(Object.ReferenceEquals(player1, player2));
        }

        [Fact]
        public void TwowarsCanReferenceSameObject()
        {
            var player1 = GetStudent("Adam");
            var player2 = player1;

            Assert.Same(player2, player1);
            Assert.True(Object.ReferenceEquals(player1, player2));
        }

        [Fact]
        public void CsharpCanPassByRef()
        {
            var player1 = GetStudent("Adam");
            GetStudentSetName(out player1, "NewName");
            Assert.Equal("NewName", player1.Name);
        }

        private void GetStudentSetName(out Student player1, string Name)
        {
            player1 = new Student(Name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var player1 = GetStudent("Adam");
            this.SetName(player1, "NewName");
            Assert.Equal("NewName", player1.Name);
        }

        private Student GetStudent(string Name)
        {
            return new Student(Name);
        }

        private void SetName(Student student, string Name)
        {
            student.Name = Name;
        }
    }
}