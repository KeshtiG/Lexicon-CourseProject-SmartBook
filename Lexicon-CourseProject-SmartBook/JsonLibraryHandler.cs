using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lexicon_CourseProject_SmartBook
{
    internal class JsonLibraryHandler
    {

        internal static void SaveLibraryToJson()
        {
            // Create a reference to the current library list by calling the method that returns it
            List<Book> library = Library.GetBookList();

            // Define the folder path within the current directory
            string folderPath = Path.Combine(Environment.CurrentDirectory, "Json");

            // Combine the folder path with the file name
            string filePath = Path.Combine(folderPath, "library.json");

            // Create the foler if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Convert the library to JSON format and save it to the specified file and path
            File.WriteAllText(filePath, JsonSerializer.Serialize(library));
        }

        internal static void LoadLibraryFromJson()
        {
            // Check if the JSON file exists before attempting to read it
            if (!File.Exists("Json/library.json"))
                return;

            // Read the JSON file and deserialize it into a list of books
            List<Book>? loadedLibrary = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText("Json/library.json"));

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
        }
    }
}
