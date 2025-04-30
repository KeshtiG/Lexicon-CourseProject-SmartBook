using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lexicon_CourseProject_SmartBook;

public class Library
{
    // Create an empty list to store books
    //private static List<Book> books = new List<Book>();

    // Sample books
    private static List<Book> books = new List<Book>
    {
        new Book("J.K. Rowling", "Harry Potter and the Philosopher's Stone", 1997, "Fantasy", "9780747532699"),
        new Book("J.K. Rowling", "Harry Potter and the Chamber of Secrets", 1998, "Fantasy", "9780747538493"),
        new Book("J.R.R. Tolkien", "The Hobbit", 1937, "Fantasy", "9780261103344"),
        new Book("George Orwell", "1984", 1949, "Dystopian", "9780451524935"),
        new Book("Harper Lee", "To Kill a Mockingbird", 1960, "Fiction", "9780061120084"),
        new Book("F. Scott Fitzgerald", "The Great Gatsby", 1925, "Fiction", "9780743273565")
    };

    // Method to get the list of books
    public static List<Book> GetBookList()
    {
        return books;
    }

    public static void CreateBook()
    {
        // Prompt the user for book details
        string author = InputHelpers.AskForString("Enter the author", "author");
        string title = InputHelpers.AskForString("Enter the title", "title");
        uint year = InputHelpers.AskForUInt("Enter the publication year", "year");
        string genre = InputHelpers.AskForString("Enter the genre", "genre");
        // Prompt the user for the ISBN and check if it's valid
        string isbn = CheckValidISBN();

        try
        {
            // Try to create a new book object
            var book = new Book(author, title, year, genre, isbn);

            // Try to add the book to the library
            AddBookToLibrary(book);
            Console.WriteLine("Book added to the library.");

            // Wait for the user to press enter before clearing the console
            GeneralHelpers.ClearConsole("Press enter to continue...");
        }
        catch (Exception ex)
        {
            // Print error message if adding the book fails
            Console.WriteLine($"Error: {ex.Message}");

            // Wait for the user to press enter before clearing the console
            GeneralHelpers.ClearConsole("Press enter to continue...");

            // Return to the main menu if adding the book fails
            return;
        }
    }

    public static void AddBookToLibrary(Book book)
    {
        // Check if a book with the same ISBN already exists in the library
        if (books.Any(b => b.ISBN == book.ISBN))
        {
            throw new ArgumentException("A book with this ISBN already exists in the library.");
        }

        // Add the book to the library
        books.Add(book);
    }

    public static void RemoveBook()
    {
        string input = InputHelpers.AskForString("Enter the title or ISBN of the book to remove", "title or ISBN");

        // Find the book with the specified ISBN
        var bookToRemove = books.FirstOrDefault(b =>
            b.Title.Equals(input, StringComparison.OrdinalIgnoreCase) ||
            b.ISBN == input);

        // If the book is found, remove it from the library
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"The book '{bookToRemove.Title}' by {bookToRemove.Author} with ISBN {bookToRemove.ISBN} has been removed.");
            GeneralHelpers.ClearConsole("Press enter to continue...");
        }

        else
        {
            Console.WriteLine("No book with the entered title or ISBN was found.");
            GeneralHelpers.ClearConsole("Press enter to continue...");
        }
    }

    // Check if the ISBN is valid
    internal static string CheckValidISBN()
    {
        string isbn;

        while (true)
        {
            isbn = InputHelpers.AskForString("Enter the ISBN (without dashes)", "ISBN");

            // Check if the ISBN is valid based on the input and year
            if (Book.IsValidISBN(isbn))
                return isbn;
            else
                // Display error message that helps the user understand the format
                Console.WriteLine("Error: Invalid ISBN format. Please enter 10 or 13 characters (no dashes).");
        }
    }
}
