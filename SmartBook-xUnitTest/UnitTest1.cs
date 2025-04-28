using Lexicon_CourseProject_SmartBook;

namespace SmartBook_xUnitTest;

public class UnitTest1
{
    [Fact]
    public void AddBook_ShouldAddBookToLibrary()
    {
        // Arrange
        // Create a new book object
        var book = new Book("Test Author", "Test Title", 2023, "Test Genre", "1234567890123");

        // Act
        // Add the book to the library
        Library.AddBook(book);
        // Get the list of books in the library
        var books = Library.GetBookList();

        // Assert
        // Check if the test book is in the list of books
        Assert.Contains(book, books);
    }
}
