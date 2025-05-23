﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utils;

namespace Lexicon_CourseProject_SmartBook
{
    internal class JsonLibraryHandler
    {

        internal static void SaveLibraryToJson()
        {
            // Create a reference to the current library list by calling the method that returns it
            List<Book> library = Library.GetBookList();

            // Convert the library to JSON format and save it to the specified file and path
            File.WriteAllText("library.json", JsonSerializer.Serialize(library));

            // Display a message indicating that the library has been saved
            Console.WriteLine("Library saved to JSON file.");
            GeneralHelpers.ClearConsole("Press enter to continue...");
        }

        internal static void LoadLibraryFromJson()
        {
            // Check if the JSON file exists before attempting to read it
            if (!File.Exists("library.json"))
            {
                Console.WriteLine("No library file found.");
                GeneralHelpers.ClearConsole("Press enter to continue...");
                return;
            }

            // Read the JSON file and deserialize it into a list of books
            List<Book>? loadedLibrary = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText("library.json"));

            // Check if the loaded library file contains something
            if (loadedLibrary != null)
            {
                // Create a reference to the current library list by calling the method that returns it
                List<Book> library = Library.GetBookList();

                // Clear the library list
                library.Clear();

                // Add the loaded list of books to the library list
                library.AddRange(loadedLibrary);
            }

            // Display a message indicating that the library has been loaded
            Console.WriteLine("Library loaded from JSON file.");

            GeneralHelpers.ClearConsole("Press enter to continue...");
        }
    }
}
