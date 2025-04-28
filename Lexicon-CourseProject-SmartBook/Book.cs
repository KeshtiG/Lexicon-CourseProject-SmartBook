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
            set => _author = CheckIfNullOrEmpty(value, nameof(Author));
        }

        internal string Title
        {
            get => _title;
            set => _title = CheckIfNullOrEmpty(value, nameof(Title));
        }

        internal uint Year
        {
            get => _year;
            set => _year = GeneralHelpers.ValidatePositiveUint(value, nameof(Year));
        }

        internal string Genre
        {
            get => _genre;
            set => _genre = CheckIfNullOrEmpty(value, nameof(Genre));
        }

        internal string ISBN
        {
            get => _isbn;
            set
            {
                if (Year >= 1970)
                {
                    if (IsValidISBN(value, Year))
                        _isbn = value;
                    else
                        throw new ArgumentException("Invalid ISBN format.");
                }
                else
                {
                    _isbn = "N/A";
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
            return $"{Author.PadRight(30)}{Title.PadRight(45)}{Year.ToString().PadRight(10)}{Genre.PadRight(15)}{ISBN}";
        }

        // Validate if string is null or empty
        internal static string CheckIfNullOrEmpty(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{fieldName} cannot be empty.");
            else
                return value.Trim();
        }

        // Validate ISBN
        public static bool IsValidISBN(string isbn, uint year)
        {
            // For ISBN-13
            // Check if the year is 2007 or later, and if the ISBN is 13 characters long
            if (isbn.Length == 13 && year >= 2007)
            {
                if (isbn.All(char.IsDigit))
                {
                    return true;
                }
            }

            // For ISBN-10
            // Check if the year is before 2007, if the ISBN is 10 characters long
            if (isbn.Length == 10 && year < 2007)
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
