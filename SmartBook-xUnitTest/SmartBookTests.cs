using Lexicon_CourseProject_SmartBook;

namespace SmartBook_xUnitTest;

public class SmartBookTests : IDisposable
{
    // Test book object for testing purposes
    private readonly Book _testBook;

    // Constructor to initialize the test class
    public SmartBookTests()
    {
        // Reset the book list before each test
        var books = Library.GetBookList();
        books.Clear();

        // Create a test book object
        _testBook = new Book("Test Author", "Test Title", 2025, "Test Genre", "1234567890123");
    }

    [Fact]
    public void AddBook_ShouldAddBookToLibrary()
    {
        // Arrange
        // Get the test book object (for clarity in the test)
        var testBook = _testBook;

        // Act
        // Add the book to the library
        Library.AddBookToLibrary(testBook);
        // Get the list of books in the library
        var books = Library.GetBookList();

        // Assert
        // Check if the test book is in the list of books
        Assert.Contains(testBook, books);
    }

    [Fact]
    public void SearchForBook_ShouldReturnCorrectBook()
    {
        // Arrange
        // Get the test book object (for clarity in the test)
        var testBook = _testBook;
        // Add the test book to the library
        Library.AddBookToLibrary(testBook);

        // Act
        // Search for the book by title
        var searchResult = SearchFunction.SearchForBookTitle("Test Title");

        // Assert
        // Check if the search result contains the test book
        Assert.Contains(testBook, searchResult);
    }

    [Fact]
    public void RemoveBook_ShouldRemoveBookFromLibrary()
    {
        // Arrange
        // Get the test book object (for clarity in the test)
        var testBook = _testBook;
        // Add the test book to the library
        Library.AddBookToLibrary(testBook);

        // Act
        // Remove the book from the library
        Library.RemoveBook(testBook);

        // Get the list of books in the library
        var books = Library.GetBookList();

        // Assert
        // Check if the test book is not in the list of books
        Assert.DoesNotContain(testBook, books);
    }

    // Dispose method to clean up after tests
    public void Dispose()
    {
        // Get and clear the book list after each test
        var books = Library.GetBookList();
        books.Clear();
    }
}
