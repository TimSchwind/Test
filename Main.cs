using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Check if the correct number of arguments is provided
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: Program.exe <inputFilePath> <outputFilePath>");
            return;
        }

        string inputFilePath = args[0];
        string outputFilePath = args[1];

        try
        {
            // Read all lines from the input file
            string[] lines = File.ReadAllLines(inputFilePath);
            List<int> numbers = new List<int>();

            // Parse each line into an integer and add to the list
            foreach (string line in lines)
            {
                if (int.TryParse(line, out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine($"Warning: '{line}' is not a valid integer and will be skipped.");
                }
            }

            // Ensure there are numbers to process
            if (numbers.Count == 0)
            {
                Console.WriteLine("No valid integers found in the input file.");
                return;
            }

            // Calculate sum
            int sum = numbers.Sum();

            // Calculate average
            double average = numbers.Average();

            // Calculate median
            numbers.Sort();
            double median;
            int count = numbers.Count;
            if (count % 2 == 0)
            {
                // Even number of elements
                median = (numbers[count / 2 - 1] + numbers[count / 2]) / 2.0;
            }
            else
            {
                // Odd number of elements
                median = numbers[count / 2];
            }

            // Prepare the result string
            string result = $"Sum: {sum}{Environment.NewLine}" +
                            $"Average: {average:F2}{Environment.NewLine}" +
                            $"Median: {median:F2}{Environment.NewLine}";

            // Write the result to the output file
            File.WriteAllText(outputFilePath, result);

            Console.WriteLine("Processing complete. Results written to the output file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
