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
            var zawodnik1 = GetStudent("Adam");
            var zawodnik2 = GetStudent("Tomek");

            Assert.NotSame(zawodnik2, zawodnik1);
            Assert.False(Object.ReferenceEquals(zawodnik1, zawodnik2));
        }
        [Fact]
        public void TwowarsCanReferenceSameObject()
        {
            var zawodnik1 = GetStudent("Adam");
            var zawodnik2 = zawodnik1;

            Assert.Same(zawodnik2, zawodnik1);
            Assert.True(Object.ReferenceEquals(zawodnik1, zawodnik2));
        }

        [Fact]
        public void CsharpCanPassByRef()
        {
            var zawodnik1 = GetStudent("zawodnik 1");
            GetStudentSetName(out zawodnik1, "New zawodnik");
            Assert.Equal("New zawodnik", zawodnik1.name);

        }
        private void GetStudentSetName(out Student zawodnik1, string name)
        {
            zawodnik1 = new Student(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var zawodnik1 = GetStudent("Adam");
            this.SetName(zawodnik1, "NewName");
            Assert.Equal("NewName", zawodnik1.name);
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