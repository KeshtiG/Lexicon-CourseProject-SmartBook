using Lexicon_CourseProject_SmartBook;

namespace SmartBook_xUnitTest;

public class UnitTest
{
    [Fact]
    public void AddBook_ShouldAddBookToLibrary()
    {
        // Arrange
        // Create a new book object
        var book = new Book("Test Author", "Test Title", 2023, "Test Genre", "1234567890123");

        // Act
        // Add the book to the library
        Library.AddBookToLibrary(book);
        // Get the list of books in the library
        var books = Library.GetBookList();

        // Assert
        // Check if the test book is in the list of books
        Assert.Contains(book, books);
    }

    [Fact]
    public void SearchForBook_ShouldReturnCorrectBook()
    {
        // Arrange
        // Create a new book object
        var book = new Book("Test Author 2", "Test Title 2", 2024, "Test Genre 2", "1234567890125");
        Library.AddBookToLibrary(book);
        // Act
        // Search for the book by title
        var searchResult = SearchFunction.SearchForBookTitle("Test Title 2");
        // Assert
        // Check if the search result contains the test book
        Assert.Contains(book, searchResult);
    }
}
