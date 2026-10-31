using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes" || playAgain.ToLower() == "y")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string answer = Console.ReadLine();
                guess = int.Parse(answer);
                
                guessCount++;

                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"It took you {guessCount} guesses.");
            Console.WriteLine();

            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine().Trim();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing!");
    }
}
