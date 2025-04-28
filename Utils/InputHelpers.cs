namespace Utils
{
    public static class InputHelpers
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
                    Console.WriteLine($"Error: You must enter a/an {type}");
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
            while (true)
            {
                string input = AskForString(prompt, type);

                if (uint.TryParse(input, out uint result))
                {
                    return result;
                }
                
                Console.WriteLine($"Error: Please enter a/an {type}");
            }
        }

        // Verify INT input
        public static int AskForInt(string prompt, string type)
        {
            while (true)
            {
                string input = AskForString(prompt, type);

                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                
                Console.WriteLine($"Error: Please enter a/an {type}");
            }
        }

        // Verify DOUBLE input
        public static double AskForDouble(string prompt, string type)
        {
            while (true)
            {
                string input = AskForString(prompt, type);

                if (double.TryParse(input, out double result))
                {
                    return result;
                }

                Console.WriteLine($"Error: Please enter a/an {type}");
            }
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
                    Console.WriteLine($"Error: Please enter a/an {type} (yes/no)");
            } while (true);
        }

        // Validate string length between min and max values
        public static string AskForStringLengthBetween(string prompt, string type, int minVal, int maxVal)
        {
            while (true)
            {
                string input = AskForString(prompt, type);

                if (input.Length >= minVal && input.Length <= maxVal)
                {
                    return input;
                }

                Console.WriteLine($"Error: {type} must be between {minVal} and {maxVal} characters long.");
            }
        }

        // Validate string length
        public static string AskForStringLength(string prompt, string type, int length)
        {
            while (true)
            {
                string input = AskForString(prompt, type);

                if (input.Length == length)
                {
                    return input;
                }

                Console.WriteLine($"Error: {type} must be exactly {length} characters.");
            }
        }

        // Validate year span
        public static uint AskForNumberSpan(string prompt, string type, int maxNum, int minNum)
        {
            while (true)
            {
                // Prompt for input
                string input = AskForString(prompt, type);

                // If input is not a valid uint, prompt again
                if (!uint.TryParse(input, out uint number))
                {
                    Console.WriteLine($"Error: Please enter a/an {type}.");
                    continue;
                }

                // Check if the year is within the specified range
                if (number < minNum || number > maxNum)
                {
                    Console.WriteLine($"Error: Year must be between {minNum} and {maxNum}.");
                    continue;
                }

                // If valid, return the year
                return number;
            }
        }
    }
}
