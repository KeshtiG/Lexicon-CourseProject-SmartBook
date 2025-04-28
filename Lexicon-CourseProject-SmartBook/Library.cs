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
    private static List<Book> books = new List<Book>();

    public static List<Book> GetBookList()
    {
        return books;
    }

    public static void AddBook(Book book)
    {
        if (books.Any(b => b.ISBN == book.ISBN))
        {
            throw new ArgumentException("A book with this ISBN already exists in the library.");
        }

        books.Add(book);
    }

    internal static void ListAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("There are books in the library.");
            GeneralHelpers.ClearConsole("Press enter to continue...");
        }
        else
        {
            Console.WriteLine($"Books in the library:{Environment.NewLine}");
            string author = "Autor", title = "Title", year = "Year", genre = "Genre", isbn = "ISBN";
            Console.Write($"{author.PadRight(30)}{title.PadRight(45)}{year.PadRight(10)}{genre.PadRight(15)}{isbn}");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
            GeneralHelpers.ClearConsole("Press enter to continue...");
        }
    }
}
