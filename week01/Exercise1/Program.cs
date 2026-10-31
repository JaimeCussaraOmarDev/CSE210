using System;

class Program
{ //ASk the user for their name.
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();
        Console.WriteLine(first);

        Console.Write("What is your last name? ");
        string last = Console.ReadLine();
        Console.WriteLine($"Your name is {last}, {first} {last}.");

    }
}