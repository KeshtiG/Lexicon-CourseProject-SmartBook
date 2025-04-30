using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Lexicon_CourseProject_SmartBook;

internal static class SmartBookApp
{
    internal static void HandleMainMenu()
    {
        bool exit = false;
        do
        {
            DisplayMenuOptions();

            string choice = InputHelpers.AskForString("Enter your choice", "number").ToUpper();

            switch (choice)
            {
                // Add a new book
                case "1":
                    Library.CreateBook();
                    break;
                
                // Remove a book
                case "2":
                    Library.RemoveBook();
                    break;

                // View all books
                case "3":
                    SortAndList.HandleSortingMenu();
                    break;

                // Search for a book
                case "4":
                    SearchFunction.HandleSearchMenu();
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


    // Display the menu options
    internal static void DisplayMenuOptions()
    {
        Console.WriteLine("Welcome to SmartBook!");
        Console.WriteLine($"====================={Environment.NewLine}");
        Console.WriteLine($"Please choose an option:{Environment.NewLine}");
        Console.WriteLine("1. Add a new book");
        Console.WriteLine("2. Remove a book");
        Console.WriteLine("3. View and sort books");
        Console.WriteLine("4. Search for a book");
        Console.WriteLine();
        Console.WriteLine("Q. Exit the application");
        Console.WriteLine("");
    }
}
