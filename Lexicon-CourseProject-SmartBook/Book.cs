using Utils;

namespace Lexicon_CourseProject_SmartBook
{
    public class Book
    {
        private string _author = string.Empty;
        private string _title = string.Empty;
        private uint _year;
        private string _genre = string.Empty;
        private string _isbn = string.Empty;


        internal string Author
        {
            get => _author;
            set => _author = GeneralHelpers.CheckIfNullOrEmptyWithException(value, nameof(Author));
        }

        internal string Title
        {
            get => _title;
            set => _title = GeneralHelpers.CheckIfNullOrEmptyWithException(value, nameof(Title));
        }

        internal uint Year
        {
            get => _year;
            set => _year = GeneralHelpers.ValidatePositiveUintWithException(value, nameof(Year));
        }

        internal string Genre
        {
            get => _genre;
            set => _genre = GeneralHelpers.CheckIfNullOrEmptyWithException(value, nameof(Genre));
        }

        internal string ISBN
        {
            get => _isbn;
            set
            {
                if (IsValidISBN(value))
                {
                    _isbn = value;
                }
                else
                {
                    throw new ArgumentException("Invalid ISBN format.");
                }
            }
        }


        // Constructor
        public Book(string author, string title, uint year, string genre, string isbn)
        {
            Author = author;
            Title = title;
            Year = year;
            Genre = genre;
            ISBN = isbn;
        }

        // Override ToString method
        public override string ToString()
        {
            return $"{Author,-25}{Title,-50}{Year,-10}{Genre,-15}{ISBN}";
        }


        // Validate ISBN
        public static bool IsValidISBN(string isbn)
        {
            // For ISBN-13
            if (isbn.Length == 13)
            {
                if (isbn.All(char.IsDigit))
                {
                    return true;
                }
            }

            // For ISBN-10
            if (isbn.Length == 10)
            {
                // Check if the first 9 characters are digits and the last character is either 'X' or a digit
                if (isbn.Substring(0, 9).All(char.IsDigit) &&
                    (char.ToUpper(isbn[9]) == 'X' || char.IsDigit(isbn[9])))
                {
                    return true;
                }
            }

            // If neither condition is met, return false
            return false;
        }
    }
}
