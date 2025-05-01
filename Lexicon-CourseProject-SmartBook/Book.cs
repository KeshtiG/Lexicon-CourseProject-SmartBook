using Utils;

namespace Lexicon_CourseProject_SmartBook
{
    public class Book
    {
        // Fields
        private string _author = string.Empty;
        private string _title = string.Empty;
        private uint _year;
        private string _genre = string.Empty;
        private string _isbn = string.Empty;
        private bool _isAvailable;

        // Properties
        public string Author
        {
            get => _author;
            set => _author = GeneralHelpers.CheckIfNullOrEmptyWithException(value, nameof(Author));
        }

        public string Title
        {
            get => _title;
            set => _title = GeneralHelpers.CheckIfNullOrEmptyWithException(value, nameof(Title));
        }

        public uint Year
        {
            get => _year;
            set => _year = GeneralHelpers.ValidatePositiveUintWithException(value, nameof(Year));
        }

        public string Genre
        {
            get => _genre;
            set => _genre = GeneralHelpers.CheckIfNullOrEmptyWithException(value, nameof(Genre));
        }

        public string ISBN
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

        public bool IsAvailable
        {
            get => _isAvailable;
            set => _isAvailable = value;
        }

        // Constructor
        public Book(string author, string title, uint year, string genre, string isbn)
        {
            Author = author;
            Title = title;
            Year = year;
            Genre = genre;
            ISBN = isbn;
            IsAvailable = true;
        }

        // Return avalability status in a readable format
        public static string GetAvailability(Book book)
        {
            if (book.IsAvailable)
            {
                return "✓ Available";
            }
            else
            {
                return "X Unavailable";
            }
        }

        // Override ToString method
        public override string ToString()
        {
            // Return a string with formatted book details and padding
            return $"{Author, -25}{Title, -50}{Year, -10}{Genre, -15}{ISBN, -20}{GetAvailability(this), -15}";
        }


        // Validate ISBN
        public static bool IsValidISBN(string isbn)
        {
            // For ISBN-13
            if (isbn.Length == 13)
            {
                // Check if all characters are digits
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
