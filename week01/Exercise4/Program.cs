
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        if (numbers.Count > 0)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"The sum is: {sum}");

            double average = (double)sum / numbers.Count;

            Console.WriteLine($"The average is: {average}");

            int max = numbers[0];

            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine($"The largest number is: {max}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}
