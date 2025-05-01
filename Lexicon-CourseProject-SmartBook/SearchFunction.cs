using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using Utils;
using System.Collections;

namespace Lexicon_CourseProject_SmartBook;

public class SearchFunction
{
    private static List<Book> books = Library.GetBookList();

    public static void HandleSearchMenu()
    {
        bool exit = false;

        do
        {
            DisplaySearchMenuOptions();
            string choice = InputHelpers.AskForString("Enter your choice", "choice").ToLower();

            switch (choice)
            {
                // Search by title
                case "1":
                    string inputTitle = InputHelpers.AskForString("Enter the title", "title");

                    // Get the search results by calling the SearchForBookTitle method
                    var titleResult = SearchForBookTitle(inputTitle);

                    // Display the search results
                    DisplaySearchResults(titleResult);

                    GeneralHelpers.ClearConsole("Press enter to continue...");
                    break;

                // Search by author
                case "2":
                    string inputAuthor = InputHelpers.AskForString("Enter the author", "author");

                    // Get the search results by calling the SearchForBookAuthor method
                    var authorResult = SearchForBookAuthor(inputAuthor);

                    // Display the search results
                    DisplaySearchResults(authorResult);

                    GeneralHelpers.ClearConsole("Press enter to continue...");
                    break;

                // Search by ISBN
                case "3":
                    string inputISBN = InputHelpers.AskForString("Enter the ISBN", "ISBN");

                    // Get the search results by calling the SearchForBookISBN method
                    var isbnResult = SearchForBookISBN(inputISBN);

                    // Display the search results
                    DisplaySearchResults(isbnResult);

                    GeneralHelpers.ClearConsole("Press enter to continue...");
                    break;

                case "q":
                    exit = true;
                    Console.Clear();
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please choose an option from the list.");
                    GeneralHelpers.ClearConsole("Press enter to continue...");
                    break;
            }
        }
        while (!exit);
    }

    // Search for a book by title
    public static List<Book> SearchForBookTitle(string title)
    {
        // Get the requested books with a Linq query and convert the result to a list
        var q1 = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();

        return q1;
    }

    // Search for a book by author
    public static List<Book> SearchForBookAuthor(string author)
    {
        // Get the requested books with a Linq query and convert the result to a list
        var q1 = books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();

        return q1;
    }

    // Search for a book by ISBN
    public static List<Book> SearchForBookISBN(string isbn)
    {
        // Get the requested books with a Linq query and convert the result to a list
        var q1 = books.Where(b => b.ISBN.Contains(isbn, StringComparison.OrdinalIgnoreCase)).ToList();

        return q1;
    }

    // Display the search results
    internal static void DisplaySearchResults(List<Book> searchResult)
    {
        Console.WriteLine();

        // Check if the search result is empty
        if (searchResult.Count == 0)
        {
            Console.WriteLine("No books found.");
            return;
        }

        Console.WriteLine($"Search results:{Environment.NewLine}");

        // Display the headings for the book list
        SortAndList.DisplayBookListHeadings();

        // Iterate through the search results and display each book
        foreach (var book in searchResult)
        {
            Console.WriteLine(book);
        }
    }

    // Display the options for the search menu
    internal static void DisplaySearchMenuOptions()
    {
        Console.Clear();
        Console.WriteLine("Search for a book");
        Console.WriteLine($"================={Environment.NewLine}");
        Console.WriteLine("Search by:");
        Console.WriteLine("1. Title");
        Console.WriteLine("2. Author");
        Console.WriteLine("3. ISBN");
        Console.WriteLine();
        Console.WriteLine("Q. Quit to main menu");
        Console.WriteLine();
    }
}
