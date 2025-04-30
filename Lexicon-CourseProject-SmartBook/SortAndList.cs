using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Lexicon_CourseProject_SmartBook;

internal class SortAndList
{
    private static List<Book> books = Library.GetBookList();

    internal static void ShowBookList(string orderBy)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("There are no books in the library.");
            GeneralHelpers.ClearConsole("Press enter to continue...");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"Books sorted by {orderBy}:{Environment.NewLine}");
            DisplayBookListHeadings();

            // Determine the sorting order (query) based on user input
            var query = orderBy switch
            {
                "author" => books.OrderBy(b => b.Author),
                "title" => books.OrderBy(b => b.Title),
                "year" => books.OrderBy(b => b.Year),
                _ => books.AsEnumerable()
            };

            // Display the sorted books
            foreach (var book in query)
            {
                Console.WriteLine(book);
            }

            // Let the user return to the menu after displaying the books
            GeneralHelpers.ClearConsole("Press enter to continue...");
        }
    }

    internal static void HandleSortingMenu()
    {
        bool exit = false;

        do
        {
            DisplaySortingMenuOptions();

            string choice = InputHelpers.AskForString("Enter your choice", "choice").ToLower();

            // Call DisplayAllBooks with the chosen sorting
            switch (choice)
            {
                case "1":
                    ShowBookList("author");
                    break;
                case "2":
                    ShowBookList("title");
                    break;
                case "3":
                    ShowBookList("year");
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

    // Display the options for the sorting menu
    internal static void DisplaySortingMenuOptions()
    {
        Console.Clear();
        Console.WriteLine("View and sort books");
        Console.WriteLine($"==================={Environment.NewLine}");
        Console.WriteLine("Sort books by:");
        Console.WriteLine("1. Author");
        Console.WriteLine("2. Title");
        Console.WriteLine("3. Year");
        Console.WriteLine();
        Console.WriteLine("Q. Quit to main menu");
        Console.WriteLine();
    }

    // Display the headings for the book list
    internal static void DisplayBookListHeadings()
    {
        string author = "Autor", title = "Title", year = "Year", genre = "Genre", isbn = "ISBN";
        Console.Write($"{author,-25}{title,-50}{year,-10}{genre,-15}{isbn}");
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    }
}
