using System;
using Xunit;

namespace GradeBook.Test
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new InMemoryBook("");
            book.AddGrade(88.1);
            book.AddGrade(77.3);
            book.AddGrade(90.1);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(85.2, result.Average,1);
            Assert.Equal(90.1, result.High,1);
            Assert.Equal(77.3, result.Low,1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void GradeTest()
        {
            var book = new InMemoryBook("marko");
            book.AddGrade(100);


        }
    }
}
