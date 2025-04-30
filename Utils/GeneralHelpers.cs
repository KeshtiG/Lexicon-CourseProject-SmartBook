using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class GeneralHelpers
    {
        // Clear console and display message
        public static void ClearConsole(string message)
        {
            Console.WriteLine("");
            Console.WriteLine(message);
            Console.ReadLine();
            Console.Clear();
        }

        public static uint ValidatePositiveUintWithException(uint input, string type)
        {
            if (input > 0)
            {
                return input;
            }
            else
            {
                throw new ArgumentException($"Error: {type} must be a positive number.");
            }
        }

        // Validate if string is null or empty
        public static string CheckIfNullOrEmptyWithException(string value, string type)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{type} cannot be empty.");
            else
                return value.Trim();
        }
    }
}
