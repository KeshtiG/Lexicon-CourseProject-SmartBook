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
            ShowSearchMenuOptions();
            string choice = InputHelpers.AskForString("Enter your choice", "choice").ToLower();

            switch (choice)
            {
                case "1":
                    string title = InputHelpers.AskForString("Enter the title", "title");
                    SearchForBookTitle(title);
                    break;

                case "2":
                    string isbn = InputHelpers.AskForString("Enter the author", "author");
                    SearchForBookISBN(isbn);
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

    public static List<Book> SearchForBookTitle(string title)
    {
        var q1 = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        DisplaySearchResults(q1);

        return q1;
    }

    public static List<Book> SearchForBookAuthor(string author)
    {
        var q1 = books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
        DisplaySearchResults(q1);

        return q1;
    }

    public static List<Book> SearchForBookISBN(string isbn)
    {
        var q1 = books.Where(b => b.ISBN.Contains(isbn, StringComparison.OrdinalIgnoreCase)).ToList();
        DisplaySearchResults(q1);

        return q1;
    }


    internal static void DisplaySearchResults(List<Book> searchResult)
    {
        Console.WriteLine();
        Console.WriteLine($"Search results:{Environment.NewLine}");
        SortAndList.DisplayBookListHeadings();

        // Check if the search result is empty
        if (searchResult.Count == 0)
        {
            Console.WriteLine("No books found.");
            GeneralHelpers.ClearConsole("Press enter to continue...");
            return;
        }

        // Display the search results
        foreach (var book in searchResult)
        {
            Console.WriteLine(book);
        }
    }

    // Display the options for the search menu
    internal static void ShowSearchMenuOptions()
    {
        Console.Clear();
        Console.WriteLine("Search for a book");
        Console.WriteLine($"================={Environment.NewLine}");
        Console.WriteLine("Search by:");
        Console.WriteLine("1. Title");
        Console.WriteLine("2. Author");
        Console.WriteLine();
        Console.WriteLine("Q. Quit to main menu");
        Console.WriteLine();
    }
}
