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

                string choice = Helpers.AskForString("Enter your choice", "number");

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Adding a new book...");
                        // Call method to add a new book
                        break;
                    case "2":
                        Console.WriteLine("Viewing all books...");
                        // Call method to view all books
                        break;
                    case "3":
                        Console.WriteLine("Searching for a book...");
                        // Call method to search for a book
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option (1-3).");
                        Helpers.ClearConsole("Press enter to continue...");
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
            Console.WriteLine("");
        }
    }
}
