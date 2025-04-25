using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_CourseProject_SmartBook
{
    internal class Book
    {
        internal int ISBN { get; set; }
        internal string Title { get; set; }
        internal int Year { get; set; }
        internal string Author { get; set; }
        internal string Genre { get; set; }

        internal Book(int isbn, string title, int year, string author, string genre)
        {
            ISBN = isbn;
            Title = title;
            Year = year;
            Author = author;
            Genre = genre;
        }
    }
}
