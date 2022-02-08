using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void CalculateGradeBookStats()
        {
            // Arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(13.5);
            book.AddGrade(74.3);

            // Actual
            var result = book.GetStatistics();

            // Assert - check against result (to 1dp only)
            Assert.Equal(59.0, result.Average, 1);
            Assert.Equal(89.1, result.High, 1);
            Assert.Equal(13.5, result.Low, 1);
            Assert.Equal('F', result.Letter);
        }

        [Fact]
        public void CheckMaxGradeValues()
        {
            
            var book = new InMemoryBook("Test");
            book.AddGrade(103.5);

            var grades = book.grades;
            var result = book.GetStatistics();

            // Check that 103.5 didn't get added as >100
            Assert.Equal(0, result.Total);

            // This would fail as 103.5 >100 so not added
            // Assert.Contains(103.5, grades);
        }
    }
}
