using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from 1-5: ");
            
            string input = Console.ReadLine();
            if (int.TryParse(input, out choice))
            {
                if (choice == 1)
                {
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string entryText = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry();
                    newEntry._date = date;
                    newEntry._promptText = prompt;
                    newEntry._entryText = entryText;

                    theJournal.AddEntry(newEntry);
                }
                else if (choice == 2)
                {
                    theJournal.DisplayAll();
                }
                else if (choice == 3)
                {
                    Console.Write("Enter filename to load: ");
                    string filename = Console.ReadLine();
                    theJournal.LoadFromFile(filename);
                }
                else if (choice == 4)
                {
                    Console.Write("Enter filename to save: ");
                    string filename = Console.ReadLine();
                    theJournal.SaveToFile(filename);
                }
            }
        }
    }
}