using System;
using System.Collections.Generic;

class BigIntCalculator
{
    // Method to add two large numbers
    public static List<int> Add(List<int> num1, List<int> num2)
    {
        List<int> result = new List<int>();
        int carry = 0, sum;

        int maxLength = Math.Max(num1.Count, num2.Count);
        for (int i = 0; i < maxLength; i++)
        {
            int digit1 = i < num1.Count ? num1[num1.Count - 1 - i] : 0;
            int digit2 = i < num2.Count ? num2[num2.Count - 1 - i] : 0;

            sum = digit1 + digit2 + carry;
            result.Insert(0, sum % 10);
            carry = sum / 10;
        }

        if (carry > 0)
            result.Insert(0, carry);

        return result;
    }

    // Method to parse a string number into a list of digits
    public static List<int> ParseNumber(string number)
    {
        List<int> digits = new List<int>();
        foreach (char ch in number)
        {
            if (char.IsDigit(ch))
            {
                digits.Add(ch - '0');
            }
            else
            {
                throw new ArgumentException("Invalid number format.");
            }
        }
        return digits;
    }

    // Method to display a list of digits as a number
    public static string DisplayNumber(List<int> digits)
    {
        return string.Join("", digits);
    }

    // REPL to handle user interaction
    public static void REPL()
    {
        Console.WriteLine("Welcome to the BigInt Calculator! Type 'exit' to quit.");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit") break;

            try
            {
                // Parse input like "123 + 456"
                string[] parts = input.Split(' ');
                if (parts.Length != 3)
                {
                    Console.WriteLine("Invalid input format. Use '<num1> <operator> <num2>'");
                    continue;
                }

                string left = parts[0];
                string op = parts[1];
                string right = parts[2];

                List<int> num1 = ParseNumber(left);
                List<int> num2 = ParseNumber(right);

                List<int> result = null;

                switch (op)
                {
                    case "+":
                        result = Add(num1, num2);
                        break;
                    // Implement additional operators (-, *, etc.) here
                    default:
                        Console.WriteLine($"Operator '{op}' is not supported.");
                        continue;
                }

                Console.WriteLine($"Result: {DisplayNumber(result)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        Console.WriteLine("Goodbye!");
    }

    // Main entry point
    static void Main()
    {
        REPL();
    }
}
