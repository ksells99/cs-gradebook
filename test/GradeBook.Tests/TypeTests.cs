using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            // Arrange
            var x = GetInt();
            SetInt(ref x);

            // Assert - x is 42 as passing in "ref". If ref not passed in, would return 3
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New name");

            // Assert - check book1 has been renamed
            Assert.Equal("New name", book1.Name);
        
        }
        private void GetBookSetName(ref Book book, string name)
        {
            // Construct new book instance
            book = new Book(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New name");

            // Assert - check book1 has not been renamed
            Assert.Equal("Book 1", book1.Name);
        
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New name");

            // Assert - check book1 has been renamed
            Assert.Equal("New name", book1.Name);
        
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // Assert - check both books are different Book instances (not referencing the same object)
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // Assert - check both books point to same Book instance
            Assert.Same(book1, book2);
        }


        Book GetBook(string name)
        {
            return new Book(name);
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Kai";
            var upper = MakeUpperCase(name);

            Assert.Equal("KAI", upper);
        }

        private string MakeUpperCase(string param)
        {
            return param.ToUpper();
        }
    }
}
