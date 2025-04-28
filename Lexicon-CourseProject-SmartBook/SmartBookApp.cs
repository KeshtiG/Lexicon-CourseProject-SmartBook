using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Lexicon_CourseProject_SmartBook
{
    internal static class SmartBookApp
    {
        internal static void HandleMainMenu()
        {
            bool exit = false;
            do
            {
                ShowMenuOptions();

                string choice = InputHelpers.AskForString("Enter your choice", "number").ToUpper();

                switch (choice)
                {
                    // Add a new book
                    case "1":
                        string author = InputHelpers.AskForString("Enter the author", "author");
                        string title = InputHelpers.AskForString("Enter the title", "title");
                        uint year = InputHelpers.AskForUInt("Enter the year", "year");
                        string genre = InputHelpers.AskForString("Enter the genre", "genre");

                        // Set default ISBN to "N/A"
                        string isbn = "N/A";
                        // Check if the year is 1970 (when ISBN was introduced) or later
                        if (year >= 1970)
                        {
                            isbn = CheckValidISBN(year);
                        }

                        try
                        {
                            // Try to create a new book object
                            var book = new Book(author, title, year, genre, isbn);

                            // Try adding the book to the library
                            Library.AddBook(book);
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
                            break;
                        }

                        break;

                    // View all books
                    case "2":
                        Library.ListAllBooks();
                        break;

                    // Search for a book
                    case "3":
                        Console.WriteLine("Searching for a book...");
                        break;

                    // Exit the application
                    case "Q":
                        exit = true;
                        break;

                    // Display error message for invalid input
                    default:
                        Console.WriteLine("Please enter a valid menu option (1-3).");
                        GeneralHelpers.ClearConsole("Press enter to continue...");
                        break;
                }
            }
            while (!exit);
        }

        internal static void ShowMenuOptions()
        {
            Console.WriteLine("Welcome to SmartBook!");
            Console.WriteLine($"Please choose an option:{Environment.NewLine}");
            Console.WriteLine("1. Add a new book");
            Console.WriteLine("2. View all books");
            Console.WriteLine("3. Search for a book");
            Console.WriteLine("Q. Exit the application");
            Console.WriteLine("");
        }

        internal static string CheckValidISBN(uint year)
        {
            string isbn;

            while (true)
            {
                isbn = InputHelpers.AskForString("Enter the ISBN (without dashes)", "ISBN");

                // Check if the ISBN is valid based on the input and year
                if (Book.IsValidISBN(isbn, year))
                {
                    return isbn;
                }
                else
                {
                    // Display error message that helps the user understand the format based on the year
                    if (year < 2007)
                        Console.WriteLine("Invalid ISBN format. Please enter 10 characters (no dashes).");
                    else
                        Console.WriteLine("Invalid ISBN format. Please enter 13 digits (no dashes).");
                }
            }
        }
    }
}
