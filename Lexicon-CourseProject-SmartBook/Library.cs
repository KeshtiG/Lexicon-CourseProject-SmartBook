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
    // Make the 'books' field readonly
    private static readonly List<Book> books = new List<Book>();

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
            // If a book with the same ISBN exists, throw an exception
            throw new ArgumentException("A book with this ISBN already exists in the library.");
        }

        // Add the book to the library
        books.Add(book);
    }

    public static void GetBookToRemove()
    {
        bool exit = false;
        do
        {
            DisplayRemoveBookMenuOptions();
            string choice = InputHelpers.AskForString("Enter your choice", "choice from the list").ToLower();

            switch (choice)
            {
                // Remove a book by title
                case "1":
                    string inputTitle = InputHelpers.AskForString("Enter the title", "title");
                    var titleToRemove = SearchFunction.SearchForBookTitle(inputTitle);
                    if (titleToRemove.Count == 0)
                    {
                        Console.WriteLine("No book with the entered title was found.");
                        GeneralHelpers.ClearConsole("Press enter to continue...");
                    }
                    else if (titleToRemove.Count > 1)
                    {
                        Console.WriteLine("Multiple books found matching the title. Please use the ISBN.");
                        GeneralHelpers.ClearConsole("Press enter to continue...");
                    }
                    else
                    {
                        ConfirmRemoval(titleToRemove);
                    }

                    break;

                // Remove a book by ISBN
                case "2":
                    string inputISBN = InputHelpers.AskForString("Enter the ISBN", "ISBN");

                    // Call the method to search by ISBN and save the result
                    var isbnToRemove = SearchFunction.SearchForBookISBN(inputISBN);

                    // Check if the search result is empty
                    if (isbnToRemove.Count == 0)
                    {
                        Console.WriteLine("No book with the entered ISBN was found.");
                        GeneralHelpers.ClearConsole("Press enter to continue...");
                    }
                    else
                    {
                        // Call the method to confirm removal
                        ConfirmRemoval(isbnToRemove);
                    }

                    break;

                case "q":
                    exit = true;
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose an option from the list.");
                    GeneralHelpers.ClearConsole("Press enter to continue...");
                    break;
            }
        }
        while (!exit);
    }

    internal static void ConfirmRemoval(List<Book> books)
    {
        // Display the book details
        Console.WriteLine($"Are you sure you want to remove the book " +
                            $"{books[0].Title} by {books[0].Author} (Y/N)?");

        string confirm = InputHelpers.AskForString("Enter your choice", "choice").ToUpper();

        // Check if the user confirmed the removal
        if (confirm == "Y")
        {
            // Call the method to remove the book
            RemoveBook(books[0]);

            Console.WriteLine("Book removed from the library.");
            GeneralHelpers.ClearConsole("Press enter to continue...");
        }
        else
        {
            Console.WriteLine("Book not removed.");
            GeneralHelpers.ClearConsole("Press enter to continue...");
        }
    }

    public static void RemoveBook(Book book)
    {
        // Try to remove the book and display an error message if it fails
        if (!books.Remove(book))
        {
            Console.WriteLine("No book with the entered details was found.");
            GeneralHelpers.ClearConsole("Press enter to continue...");
        }
    }


    public static void GetBookForAvailability()
    {
        bool exit = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Change availability of a book");
            Console.WriteLine($"============================={Environment.NewLine}");
            Console.WriteLine($"Enter the ISBN or 'Q' to quit to main menu{Environment.NewLine}");

            string isbn = InputHelpers.AskForString("Enter the ISBN (or 'Q')", "ISBN or quit command").ToLower();

            // Check if the user wants to quit and exit the loop if so
            if (isbn == "q")
            {
                exit = true;
                Console.Clear();
                return;
            }

            // Get the matching book from the library with a Linq query
            var book = books.FirstOrDefault(b => b.ISBN == isbn);

            // Check if a book was found
            if (book != null)
            {
                // Display the current availability of the book
                string availability = book.IsAvailable ? "available" : "unavailable";
                Console.WriteLine($"The book '{book.Title}' is currently {availability}");

                // Ask the user if they want to change the availability
                Console.WriteLine($"Do you want to change it to " +
                    $"{(book.IsAvailable ? "'Unavailable'" : "'Available'")}? (Y/N){Environment.NewLine}");

                string confirm = InputHelpers.AskForString("Enter your choice", "choice").ToUpper();

                // Check if the user confirmed the change
                if (confirm == "Y")
                {
                    // Call the method to change the availability
                    SetAvailability(book);
                }
                else
                {
                    // If the user didn't confirm, display a message and return to the main menu
                    Console.WriteLine("Availability not changed.");
                    GeneralHelpers.ClearConsole("Press enter to continue...");
                    return;
                }

                Console.WriteLine($"{Environment.NewLine}The availability has been updated.");
                GeneralHelpers.ClearConsole("Press enter to continue...");
                return;
            }
            else
            {
                Console.WriteLine("No book with the entered ISBN was found.");
                GeneralHelpers.ClearConsole("Press enter to continue...");
            }
        }
        while (!exit);
    }

    // Change the availability of a book
    internal static void SetAvailability(Book book)
    {
        // Get the current availability of the book
        bool available = book.IsAvailable;

        // Toggle the availability based on the current state
        if (available)
        {
            book.IsAvailable = false;
        }
        else
        {
            book.IsAvailable = true;
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

    // Display the menu options for removing a book
    internal static void DisplayRemoveBookMenuOptions()
    {
        Console.Clear();
        Console.WriteLine("Remove a book");
        Console.WriteLine($"=============={Environment.NewLine}");
        Console.WriteLine("Find by:");
        Console.WriteLine("1. Title");
        Console.WriteLine("2. ISBN");
        Console.WriteLine();
        Console.WriteLine("Q. Quit to main menu");
        Console.WriteLine();
    }
}
