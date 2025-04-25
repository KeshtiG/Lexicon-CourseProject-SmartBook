namespace Utils
{
    public static class Helpers
    {
        // Verify STRING input
        public static string AskForString(string prompt, string type)
        {
            bool success = false;
            string answer;

            do
            {
                Console.Write($"{prompt}: ");
                answer = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine($"Error: You must enter a {type}");
                }
                else
                {
                    success = true;
                }
            } while (!success);

            return answer;
        }

        // Verify UINT input
        public static uint AskForUInt(string prompt, string type)
        {

            do
            {
                string input = AskForString(prompt, type);

                if (uint.TryParse(input, out uint result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Error: Please enter a {type}");
                }

            } while (true);
        }

        // Verify INT input
        public static int AskForInt(string prompt, string type)
        {

            do
            {
                string input = AskForString(prompt, type);

                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Error: Please enter a {type}");
                }

            } while (true);
        }

        // Verify DOUBLE input
        public static double AskForDouble(string prompt, string type)
        {

            do
            {
                string input = AskForString(prompt, type);

                if (double.TryParse(input, out double result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Error: Please enter a {type}");
                }

            } while (true);
        }

        // Verify BOOL input
        public static bool AskForBool(string prompt, string type)
        {
            do
            {
                string input = AskForString(prompt, type).ToLower();

                // Check for "yes" or "no" input
                if (input == "yes" || input == "y")
                    return true;
                else if (input == "no" || input == "n")
                    return false;
                else
                    Console.WriteLine($"Error: Please enter a valid {type} (yes/no)");
            } while (true);
        }

        // Validate string length
        public static string ValidateStringLength(string value, string name, int minVal, int maxVal)
        {
            if (value.Length < minVal || value.Length > maxVal)
                throw new ArgumentException($"Error: {name} must be between {minVal} and {maxVal} characters long.");
            return value;
        }

        // Validate year span
        public static int ValidateYearSpan(int year, int minYear, int maxYear)
        {
            if (year < minYear || year > maxYear)
                throw new ArgumentException($"Error: Year must be between {minYear} and {maxYear}.");
            return year;
        }

        // Validate positive double
        public static double ValidatePositiveDouble(double value, string name)
        {
            if (value <= 0)
                throw new ArgumentException($"Error: {name} must be a positive number.");
            return value;
        }

        // Clear console and display message
        public static void ClearConsole(string message)
        {
            Console.WriteLine("");
            Console.WriteLine(message);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
