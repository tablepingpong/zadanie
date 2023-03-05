using System;
using Xunit;
using zadanieApp;

namespace Zadanie.Tests
{
    public class Typetest
    {
       public delegate string WriteMessage(string Message);

       int counter = 0;
       
       [Fact]
       public void WriteMessageDelegateCanPointToMethode()
       {
        WriteMessage del = ReturnMessage;
        del += ReturnMessage;
        del += ReturnMessage2;
        var result = del ("Hello");
        Assert.Equal(3, counter);
       }

       string ReturnMessage(string message)
       {
        counter++;
        return message;
       }

       string ReturnMessage2(string message)
       {
        counter++;
        return message;
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
            var player1 = GetStudent("zawodnik 1");
            GetStudentSetName(out player1, "New zawodnik");
            Assert.Equal("New zawodnik", player1.name);

        }
        private void GetStudentSetName(out Student player1, string name)
        {
            player1 = new Student(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var player1 = GetStudent("Adam");
            this.SetName(player1, "NewName");
            Assert.Equal("NewName", player1.name);
        }
        private Student GetStudent(string name)
        {
            return new Student(name);
        }

        private void SetName(Student student, string name)
        {
            student.name = name;
        }
    }
}