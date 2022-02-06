using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(13.5);
            book.AddGrade(74.3);

            // Actual
            var result = book.GetStatistics();

            // Assert - check against result (to 1dp only)
            Assert.Equal(59.0, result.Average, 1);
            Assert.Equal(89.1, result.High, 1);
            Assert.Equal(13.5, result.Low, 1);
        }
    }
}
